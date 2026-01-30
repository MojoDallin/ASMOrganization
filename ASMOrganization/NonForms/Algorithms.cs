using System.Diagnostics;
using System.Text.Json; // save/load housing data
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts; // write to excel

namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";
        private static XLWorkbook Workbook = new();
        private static int NextAvailableSlot = 0;
        private static int MiniIndex = 0;
        private static readonly List<Missionary> CurrentMissionaries = [.. TransportNumbers.allMissionaries];
        private static List<Missionary> NewMissionaries = [];
        //current transfer missionaries, next transfer missionaries, closing/staying/opening
        private static Dictionary<string, List<string>> CurrentAreaMissionaries = [];
        private static Dictionary<string, List<string>> NewAreaMissionaries = [];
        private static string[] TransportMethod(string missionary, List<House>? housingData, string[] endArea)
        {
            // endArea[0] == zone, endArea[1] == area; [0] is area if staying in zone

            // TRANSPORT RULES
            //Any distance less than 30km will use public transport
            //If using a car AND the distance with office is less than the direct distance + half, go to office
            //Otherwise, no office

            // TIME SLOT RULES
            //Each person getting a new companion should go to their office with their current companion.
            //This new companion (and their current one) should arrive ASAP to the office.
            //Whitewashing missionaries need to arrive after the current ones to hand off sim/keys/car.


            if (housingData is null)
                return ["", ""]; // if in the same area or released, doesnt need any data
            string[] transportData = ["", ""];
            House? missionaryHouse = null;
            House? endHouse = null;
            House office = null!;
            missionary = $"{missionary[(missionary.IndexOf(',') + 2) ..]} {missionary[0 .. missionary.IndexOf(',')]}"; // format missionary so they can be found
            missionary = missionary.Replace("  ", " "); // some have double spaces, so fix
            StringComparison compare = StringComparison.CurrentCultureIgnoreCase; // non case sensitive
            foreach (House house in housingData)
            {
               if (TransportNumbers.allMissionaries.Any(miss => miss.FlatID.Equals(house.Id))) // find missionary house
                    missionaryHouse = house;
                if (house.TeachingAreas.Any(area => area.Contains(endArea[2], compare))) // find new home
                    endHouse = house;
                else if (house.Id == 0) // never null
                    office = house;
                if (missionaryHouse is not null && endHouse is not null && office is not null) // end early once all are found
                    break;
            }
            if (office is null)
                return ["Office Not Found", "Office Not Found"];
            else if (missionaryHouse is null)
                return ["Current House Not Found", "Current House Not Found"];
            else if (endHouse is null)
                return ["New House Not Found", "New House Not Found"];

            double directDistance = CalcHaversineDistance(missionaryHouse.Coordinates, endHouse.Coordinates);
            double distanceWithOffice = CalcHaversineDistance(missionaryHouse.Coordinates, office.Coordinates) + CalcHaversineDistance(office.Coordinates, endHouse.Coordinates);
            string[] carZones = TransportNumbers.GetOverriddenZones().Split(',');
            for(int i = 0; i < carZones.Length; i++)
                carZones[i] = carZones[i].Replace(" ", ""); // remove spaces

            if (carZones.Contains(missionaryHouse.Zone) || carZones.Contains(endHouse.Zone))
                transportData[0] = "Car";
            else if (directDistance < TransportNumbers.GetMaxDistance() * 1000) // only moving small areas, not zones
                transportData[0] = "Public Transport";
            else
                transportData[0] = "Car";
            if (transportData[0].Contains("Car") && distanceWithOffice < directDistance * TransportNumbers.GetMaxDistance()) // go to office if going to the office adds less than 50% distance
                transportData[1] = "Yes";
            else
                transportData[1] = "No";

            return transportData;
        }
        private static void WriteToFile(string header, List<string> data, List<bool> arrIsGolden, List<List<string>>? optionalData = null)
        {
            List<House>? housingData = null;
            if(optionalData is not null)
            {
                // put this here so it only reads once when needed
                string json = File.ReadAllText("HousingData.json");
                housingData = JsonSerializer.Deserialize<List<House>>(json, new JsonSerializerOptions { WriteIndented = true })!;
            }
            optionalData ??= [];
            var sheet = Workbook.Worksheets.Add(header);
            sheet.Cell(1, 1).Value = "Missionaries";
            sheet.Cell(1, 2).Value = "Zone";
            sheet.Cell(1, 3).Value = "District";
            sheet.Cell(1, 4).Value = "Area";
            sheet.Cell(1, 5).Value = "Transport Method";
            sheet.Cell(1, 6).Value = "Office";
            sheet.Cell(1, 7).Value = "Time Slot";
            var headerRange = sheet.Range(1, 1, 1, 7);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            for (int index = 0; index < data.Count; index++)
            {
                string[] toWrite = [data[index], "", "", "", "", ""];
                if (optionalData.Count > 0)
                {
                    for (int optIndex = 0; optIndex < optionalData[index].Count; optIndex++)
                        toWrite[optIndex + 1] = optionalData[index][optIndex];
                    string[] method = TransportMethod(data[index], housingData, [.. optionalData[index]]);
                    toWrite[4] = method[0];
                    toWrite[5] = method[1];
                    if (arrIsGolden[index])
                        sheet.Cell(index + 2, 1).Style.Fill.BackgroundColor = XLColor.Yellow; // golden bg for goldens
                    for(int col = 0; col < toWrite.Length; col++)
                        sheet.Cell(index + 2, col + 1).Value = toWrite[col];
                }
            }

            sheet.Columns().AdjustToContents();
        }
        public static string FigureOutLogistics(List<List<string>> transferData, string filePath)
        {
            NewMissionaries = CalculateMissionariesStayingLeaving(transferData);
            if (filePath == "none")
                return "No file path has currently been set!";
            DateTime now = DateTime.Now;
            path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.xlsx";
            var sheet = Workbook.Worksheets.Add("Transfer Logistics");
            int rowIndex = 2;
            List<string> newAreaOrder = CalculateAreaTransferOrder();

            foreach (string area in newAreaOrder)
            {
                //area, current missionaries, new missionaries, staying/office/area/whatever, time slot
                string[] toWrite = [area, "N/A", "", "", "staying/office/area/whatever"];
                //find current missionaries
                foreach (Missionary missionary in CurrentMissionaries)
                    if (missionary.Area.Equals(area))
                        toWrite[2] += missionary.Name + ", ";
                foreach (Missionary missionary in NewMissionaries)
                    if (missionary.Area.Equals(area))
                        toWrite[3] += missionary.Name + ", ";
                if (toWrite[2].Length > 2)
                    toWrite[2] = toWrite[2][..^2]; // formatting
                if (toWrite[3].Length > 2)
                    toWrite[3] = toWrite[3][..^2]; // formatting (again)
                // 0: amount staying, 1: total in area
                if (toWrite[2].Equals(toWrite[3]))
                    toWrite[4] = "Stay in your area and work, and offer your car as needed. God loves yous!";
                else
                {
                    toWrite[4] = "Either use your area's car or borrow one to come to the office at the time slot provided. Do not be late nor early!";
                    toWrite[1] = GetTimeSlot();
                }

                for (int colIndex = 0; colIndex < toWrite.Length; colIndex++)
                {
                    sheet.Cell(rowIndex, colIndex + 1).Value = toWrite[colIndex];
                }
                rowIndex++;
            }
            sheet.Cell(1, 1).Value = "Area";
            sheet.Cell(1, 2).Value = "Time Slot";
            sheet.Cell(1, 3).Value = "Current Missionaries";
            sheet.Cell(1, 4).Value = "New Missionaries";
            sheet.Cell(1, 5).Value = "Assignment";
            sheet.Columns().AdjustToContents();

            if (File.Exists(path))
                File.Delete(path); // delete file if already exists to avoid double data
            Workbook.SaveAs(path);
            Workbook = new(); // prevents errors

            return $"Successfully generated logistics at: {path}";
        }
        private static double DegreeToRadians(double deg) => deg * Math.PI / 180.0;
        private static double CalcHaversineDistance(double[] curCoords, double[] newCoords)
        {
            // i did NOT sign up for this crazy ahh formula
            // thanks chatgpt
            double la1 = DegreeToRadians(curCoords[0]); // first, we convert degrees to radians
            double la2 = DegreeToRadians(newCoords[0]);
            double lo1 = DegreeToRadians(curCoords[1]);
            double lo2 = DegreeToRadians(newCoords[1]);
            const int radius = 6_371_000; // meters for science standard
            double latDiff = la2 - la1; // second, difference of each point
            double lonDiff = lo2 - lo1;
            double sin1 = Math.Pow(Math.Sin(latDiff/2), 2); // then this
            double sin2 = Math.Cos(la1) * Math.Cos(la2); // and this
            sin2 *= Math.Pow(Math.Sin(lonDiff/2), 2); // plus this
            return 2 * radius * Math.Asin(Math.Sqrt(sin1 + sin2)); // finally
        }
        private static string GetTimeSlot()
        {
            int companionshipsPerSlot = 3;
            string[] label = ["AM", "AM", "PM", "PM", "PM", "PM", "PM"];
            string[] hours = ["10", "11", "12", "1", "2", "3", "4"];
            string[] minutes = ["00", "10", "20", "30", "40", "50"];
            decimal floor = NextAvailableSlot / 6; // needed! for some reason
            string hourSlot = hours[(int)Math.Floor(floor)];
            string minuteSlot = minutes[NextAvailableSlot % 6];
            string labelSlot = label[(int)Math.Floor(floor)];

            MiniIndex++;
            if (MiniIndex >= companionshipsPerSlot)
            {
                NextAvailableSlot++;
                MiniIndex = 0;
            }
            if (NextAvailableSlot >= 42 * companionshipsPerSlot) //ran out of slots, oops!
                return "99:99AM";
            return hourSlot + ":" + minuteSlot + labelSlot;
        }
        private static string FormatName(string name)
        {
            string[] seperate = name.Split(',');
            seperate[1] = seperate[1].Trim();
            return seperate[1] + " " + seperate[0];
        }

        private static List<Missionary> CreateDeepCopy()
        {
            List<Missionary> allMissionariesNew = [];
            foreach (Missionary missionary in TransportNumbers.allMissionaries) // create a deep copy
            {
                Missionary newMiss = new()
                {
                    Name = missionary.Name,
                    ID = missionary.ID,
                    Area = missionary.Area,
                    FlatID = missionary.FlatID,
                };
                allMissionariesNew.Add(newMiss);
            }
            return allMissionariesNew;
        }
        private static List<Missionary> NewTransferData(List<List<string>> transferData)
        {
            List<Missionary> allMissionariesNew = CreateDeepCopy();   
            for(int index = 0; index < transferData[0].Count; index++)
            {
                Missionary? mis = null;
                foreach (Missionary missionary in allMissionariesNew)
                    if (missionary.Name == FormatName(transferData[5][index]))
                        mis = missionary;
                if(mis is not null)
                    mis.Area = transferData[2][index];
            }
            return allMissionariesNew;
        }
        private static void RemoveSome(ref Dictionary<string, List<string>> miss)
        {
            foreach (KeyValuePair<string, List<string>> pair in miss)
            {
                StringComparison comparison = StringComparison.CurrentCultureIgnoreCase;
                if (pair.Key.Contains("Sr", comparison) || // remove sr angels/office/service (sorry :( )
                    pair.Key.Contains("Service", comparison) ||
                    pair.Key.Contains("Office", comparison) ||
                    pair.Key.Contains("Finance", comparison) ||
                    pair.Key.Contains("Administrative", comparison) ||
                    pair.Key.Contains("Education") ||
                    pair.Key.Contains("Transportation") ||
                    pair.Key.Contains("Legal"))
                    miss.Remove(pair.Key);
            }
        }

        private static List<Missionary> CalculateMissionariesStayingLeaving(List<List<string>> transferData)
        {
            List<Missionary> allMissionariesNew = NewTransferData(transferData);
            foreach(Missionary missionary in CurrentMissionaries)
            {
                if (!CurrentAreaMissionaries.ContainsKey(missionary.Area))
                    CurrentAreaMissionaries[missionary.Area] = [];
                CurrentAreaMissionaries[missionary.Area].Add(missionary.Name);
            }
            foreach (Missionary missionary in allMissionariesNew)
            {
                if (!NewAreaMissionaries.ContainsKey(missionary.Area))
                    NewAreaMissionaries[missionary.Area] = [];
                NewAreaMissionaries[missionary.Area].Add(missionary.Name);
            }
            RemoveSome(ref CurrentAreaMissionaries);
            RemoveSome(ref NewAreaMissionaries);
            return allMissionariesNew;
        }
        //hELP ME
        private static List<string> CalculateAreaTransferOrder()
        {
            Equalizer();
            bool sorted = false;
            List<string> areas = [];
            List<string> newAreaOrder = [];
            foreach(KeyValuePair<string, List<string>> pair in CurrentAreaMissionaries)
                areas.Add(pair.Key);
            while (true)
            {
                int startIndex = 1;
                string area = areas[startIndex];
                while (CurrentAreaMissionaries[area].Count > 0 &&
                    (CurrentAreaMissionaries[area].Intersect(NewAreaMissionaries[area]).Any()) || NewAreaMissionaries[area].Count < 1)
                { // begin with whitewash (or new area) to transfer sim/keys
                    startIndex++;
                    if (areas.Count > startIndex)
                        area = areas[startIndex];
                    else // rest are staying as is
                    {
                        foreach(string stayingArea in areas)
                            newAreaOrder.Add(stayingArea);
                        sorted = true;
                        break;
                    }
                }
                if (sorted)
                    break;
                areas.RemoveAt(startIndex);
                newAreaOrder.Add(area);
                bool compsFound = false;
                while(!compsFound)
                {
                    List<string> leavingMissionaries = CurrentAreaMissionaries[area];
                    bool changeAreas = false;
                    foreach(KeyValuePair<string, List<string>> newPair in NewAreaMissionaries)
                    {
                        if (newPair.Value.Intersect(leavingMissionaries).Any())
                        {
                            foreach (KeyValuePair<string, List<string>> curPair in CurrentAreaMissionaries)
                                if (curPair.Value.Intersect(newPair.Value).Any() && !newAreaOrder.Contains(curPair.Key))
                                {
                                    newAreaOrder.Add(curPair.Key);
                                    areas.Remove(curPair.Key);
                                    changeAreas = true;
                                }
                        }
                    }
                    area = newAreaOrder.Last();
                    if (!changeAreas)
                        compsFound = true;
                }
            }
            return newAreaOrder;
        }
        // im losing touch, get me
        //can you heal me, have i gained too much?
        //it hurts me just to think and I Dont Do Pain
        private static void Equalizer() // make the 2 dictionaries equal
        {
            foreach (KeyValuePair<string, List<string>> pair in CurrentAreaMissionaries)
                if (!NewAreaMissionaries.ContainsKey(pair.Key))
                    NewAreaMissionaries[pair.Key] = [];
            foreach (KeyValuePair<string, List<string>> pair in NewAreaMissionaries)
                if (!CurrentAreaMissionaries.ContainsKey(pair.Key))
                    CurrentAreaMissionaries[pair.Key] = [];
        }
    }
}
