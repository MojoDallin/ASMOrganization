using System.Diagnostics;
using System.Text.Json; // save/load housing data
using ClosedXML.Excel; // write to excel

namespace ASMOrganization.NonForms.Algorithms
{
    public static class Algorithms
    {
        private static string path = "";
        private static XLWorkbook Workbook = new();
        private static PriorityQueue<List<string>, int> pQueue = new();
        private static List<House> housingData = JsonSerializer.Deserialize<List<House>>(File.ReadAllText("HousingData.json"), new JsonSerializerOptions { WriteIndented = true })!;

        private static string[] TransportMethod(string missionary, List<House>? housingData, string[] endArea)
        {
            // endArea[0] == zone, endArea[1] == area; [0] is area if staying in zone
            // TRANSPORT RULES
            //Any distance less than 30km will use public transport
            //If using a car AND the distance with office is less than the direct distance + half, go to meeting location
            //Otherwise, no ML

            if (housingData is null)
                return ["", ""]; // if in the same area or released, doesnt need any data
            string[] transportData = ["", ""];
            House? missionaryHouse = null;
            House? endHouse = null;
            House office = null!;
            missionary = $"{missionary[(missionary.IndexOf(',') + 2)..]} {missionary[0..missionary.IndexOf(',')]}"; // format missionary so they can be found
            missionary = missionary.Replace("  ", " "); // some have double spaces, so fix
            StringComparison compare = StringComparison.CurrentCultureIgnoreCase; // non case sensitive
            foreach (House house in housingData)
            {
                if (house.Missionaries.Any(miss => miss.Contains(missionary, compare))) // find missionary house
                    missionaryHouse = house;
                if (house.TeachingAreas.Any(area => area.Contains(endArea[2], compare))) // find new home
                    endHouse = house;
                /*else if (house.Id == 0 && TransportNumbers.GoToOffice() || house.Id == 1 && !TransportNumbers.GoToOffice()) // never null
                    office = house;*/
                if (missionaryHouse is not null && endHouse is not null && office is not null) // end early once all are found
                    break;
            }
            if (office is null)
                return ["Meeting Location Not Found", "Meeting Location Not Found"];
            else if (missionaryHouse is null)
                return ["Current House Not Found", "Current House Not Found"];
            else if (endHouse is null)
                return ["New House Not Found", "New House Not Found"];

            double directDistance = CalcHaversineDistance(missionaryHouse.Coordinates, endHouse.Coordinates);
            double distanceWithOffice = CalcHaversineDistance(missionaryHouse.Coordinates, office.Coordinates) + CalcHaversineDistance(office.Coordinates, endHouse.Coordinates);
            string[] carZones = TransportNumbers.GetOverriddenZones().Split(',');
            for (int i = 0; i < carZones.Length; i++)
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
        /// THIS CODE IS STILL IN USE I THINK, DO NOT DELETE UNTIL REUSEN OR REWRITTEN
        //private static void WriteToFile(string header, List<string> data, List<bool> arrIsGolden, List<List<string>>? optionalData = null)
        //{
        //    List<House>? housingData = null;
        //    if(optionalData is not null)
        //    {
        //        // put this here so it only reads once when needed
        //        string json = File.ReadAllText("HousingData.json");
        //        housingData = JsonSerializer.Deserialize<List<House>>(json, new JsonSerializerOptions { WriteIndented = true })!;
        //    }
        //    optionalData ??= [];
        //    var sheet = Workbook.Worksheets.Add(header);
        //    sheet.Cell(1, 1).Value = "Missionaries";
        //    sheet.Cell(1, 2).Value = "Zone";
        //    sheet.Cell(1, 3).Value = "District";
        //    sheet.Cell(1, 4).Value = "Area";
        //    sheet.Cell(1, 5).Value = "Transport Method";
        //    sheet.Cell(1, 6).Value = "Office";
        //    var headerRange = sheet.Range(1, 1, 1, 6);
        //    headerRange.Style.Font.Bold = true;
        //    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
        //    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        //    for (int index = 0; index < data.Count; index++)
        //    {
        //        string[] toWrite = [data[index], "", "", "", "", ""];
        //        if (optionalData.Count > 0)
        //        {
        //            for (int optIndex = 0; optIndex < optionalData[index].Count; optIndex++)
        //                toWrite[optIndex + 1] = optionalData[index][optIndex];
        //            string[] method = TransportMethod(data[index], housingData, [.. optionalData[index]]);
        //            toWrite[4] = method[0];
        //            toWrite[5] = method[1];
        //            if (arrIsGolden[index])
        //                sheet.Cell(index + 2, 1).Style.Fill.BackgroundColor = XLColor.Yellow; // golden bg for goldens
        //            for(int col = 0; col < toWrite.Length; col++)
        //                sheet.Cell(index + 2, col + 1).Value = toWrite[col];
        //        }
        //    }

        //    sheet.Columns().AdjustToContents();
        //}
        public static string FigureOutLogistics(List<List<string>> transferData, string filePath)
        {
            // hoo boy, here we go! the 'meat and potatoes' of this program, if you will :p
            // very first of all, we get the *NEW* flat/missionary information and store it
            Dictionary<string, List<string>> newFlatAndMissionaryData = []; // dictionary where ADDRESS ARE KEYS, VALUES ARE MISSIONARY NAMES
            for (int index = 0; index < transferData[4].Count; index++)
            {
                // parse address
                string address = transferData[4][index];
                if (address.Length >= 1) // if the field is blank then skip because that means the data isnt necessary
                {
                    int startIndex = Math.Max(address.IndexOf("NSW"), address.IndexOf("ACT")) - 1;
                    address = address[..startIndex];
                    // parse missionary so its correct format
                    string name = transferData[5][index];
                    string[] split = name.Split(",");
                    name = split[1][1..] + " " + split[0];
                    if (!newFlatAndMissionaryData.TryGetValue(address, out List<string>? value))
                        newFlatAndMissionaryData.Add(address, [name]); // create entry if address doesnt exist
                    else
                        value.Add(name); // otherwise, add to the entry itself
                }
            }
            // now that we have all the *new* flat data, we calculate FLAT (NOT area) whitewashes; we do this to get a "starting point" for each different "transfer path"
            // (whitewash missionaries' old comps find their new comps, and said new comps' old comps find their new comps, etc etc until everyone in that set has comps; then we move on and repeat this process)
            bool[] flatWhitewashes = new bool[newFlatAndMissionaryData.Count]; // keeps in order, and all values default to False
            int wwIndex = 0;
            foreach (House house in housingData) // House house is old (prev/current transfer) house
            {
                List<string> missionaries = house.Missionaries;  // old missionaries
                List<string> newFlatMissionaries = newFlatAndMissionaryData.FirstOrDefault(pair => pair.Key.Contains(house.Address)).Value; // grabs the missionaries for the house it's currently checking
                if (newFlatMissionaries is not null && newFlatMissionaries.Count > 0) // if it is null, then the flat has no teaching areas (for whatever reason (is that even correct that makes no sense)); also only check for flats that WILL have missionaries
                {
                    int stayingMissionaryCount = missionaries.Intersect(newFlatMissionaries).Count(); // check how many missionaries are staying in the flat
                    if (stayingMissionaryCount == 0 || missionaries.Count == 0) // if none are staying OR an empty flat is getting new missionaries (maybe unneeded? check when i actually can)...
                        flatWhitewashes[wwIndex] = true; // ...then its a FLAT whitewash, but DOES NOT MEAN ITS AN AREA WHITEWASH
                    wwIndex++;
                }
            }
            bool logisticsSorted = false;
            int start = 0;
            int priority = 0;
            while (!logisticsSorted)
            {
                while (!flatWhitewashes[start]) // find next-in-queue (pun intended) whitewash
                    start++; // increment until first whitewash is located
                KeyValuePair<string, List<string>> pair = newFlatAndMissionaryData.ElementAt(start);
                pQueue.Enqueue(pair.Value, priority); // set the whitewash to the highest priority at the moment to kick it off
                foreach (string missionary in pair.Value)
                {
                    bool hasGolden = true;
                    foreach (House house in housingData)
                        if (house.Missionaries.Contains(missionary))
                        {
                            hasGolden = false;
                            pQueue.Enqueue(house.Missionaries, priority); // TODO: change this so only comps arrive, not entire flat (use transferData[7] and parse it or something? and then get their comp and etc etc)
                            priority++;
                            break;
                        }
                    if (hasGolden) // prob change this
                    {
                        pQueue.Enqueue(pair.Value, priority);
                        priority++;
                    }
                }
                logisticsSorted = true;
            }
            /// OLD CODE BELOW THATS OUTDATED AND DOESNT DO WHAT IT NEEDS TO. ONLY USE AS REFERENCE DO NOT ACTUALLY USE LOL
            //if (filePath == "none")
            //    return "No file path has currently been set!";
            //DateTime now = DateTime.Now;
            //path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.xlsx";

            //bool isGolden(int index) // convenience
            //{
            //    if (transferData[12][index].Contains("(TR)") || transferData[12][index].Contains("(DT)"))
            //        return true;
            //    return false;
            //}

            //List<bool> missionariesMovingAreGolden = [];
            //List<string> missionariesMoving = [];
            //List<List<string>> missionariesMovingAreas = [];
            //List<bool> missionariesNotMovingAreGolden = [];
            //List<string> missionariesNotMoving = [];
            //List<List<string>> missionariesNotMovingAreas = [];

            ////0: zone, 1: district, 2: area, 3: phone, 4: address, 5: name, 6: position, 7: previous area
            ////8: previous position, 9: elder/sister, 10: language, 11: driving status, 12: next companion

            //// new missionaries
            //StringComparison compare = StringComparison.CurrentCultureIgnoreCase;
            //for (int index = 0; index < transferData[0].Count; index++)
            //{
            //    List<string> areas = [transferData[0][index], transferData[1][index], transferData[2][index]];
            //    if (!transferData[2][index].Contains("Sr", compare) &&
            //        !transferData[2][index].Contains("Service", compare) &&
            //        !transferData[1][index].Contains("Office", compare)) // exclude senior angels, service missionaries, office (sorry)
            //    {
            //        if (!string.IsNullOrEmpty(transferData[7][index])) // moving areas
            //        {
            //            missionariesMoving.Add(transferData[5][index]);
            //            missionariesMovingAreas.Add(areas);
            //            missionariesMovingAreGolden.Add(isGolden(index));
            //        }
            //        else // not moving areas
            //        {
            //            missionariesNotMoving.Add(transferData[5][index]);
            //            missionariesNotMovingAreas.Add(areas);
            //            missionariesNotMovingAreGolden.Add(isGolden(index));
            //        }
            //    }
            //}

            ////WriteToFile("Moving Areas", missionariesMoving, missionariesMovingAreGolden, missionariesMovingAreas);
            ////WriteToFile("Staying in Area", missionariesNotMoving, missionariesNotMovingAreGolden, missionariesNotMovingAreas);
            //if (File.Exists(path))
            //    File.Delete(path); // delete file if already exists to avoid double data
            //Workbook.SaveAs(path);
            //Workbook = new(); // prevents errors

            return $"Successfully generated logistics at: {path}";
        }
        static double DegreeToRadians(double deg) => deg * Math.PI / 180.0;
        private static double CalcHaversineDistance(double[] curCoords, double[] newCoords) // calculates the distance between flats on a globe (because we live on a globe and not a flat earth. nerds)
        {
            // i did NOT sign up for this crazy ahh formula
            // thanks chatgpt
            double la1 = DegreeToRadians(curCoords[0]); // first, we convert degrees to radians for scientific standard
            double la2 = DegreeToRadians(newCoords[0]);
            double lo1 = DegreeToRadians(curCoords[1]);
            double lo2 = DegreeToRadians(newCoords[1]);
            const int radius = 6_371_000; // meters for scientific standard
            double latDiff = la2 - la1; // second, difference of each point
            double lonDiff = lo2 - lo1;
            double sin1 = Math.Pow(Math.Sin(latDiff / 2), 2); // then this
            double sin2 = Math.Cos(la1) * Math.Cos(la2); // and this
            sin2 *= Math.Pow(Math.Sin(lonDiff / 2), 2); // plus this
            return 2 * radius * Math.Asin(Math.Sqrt(sin1 + sin2)); // finally
        }
    }
}
