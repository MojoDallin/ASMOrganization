using System.Text.Json; // save/load housing data
using ClosedXML.Excel; // write to excel

namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";
        private static XLWorkbook Workbook = new();

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
            missionary = $"{missionary[(missionary.IndexOf(',') + 2) ..]} {missionary[0 .. missionary.IndexOf(',')]}"; // format missionary so they can be found
            missionary = missionary.Replace("  ", " "); // some have double spaces, so fix
            StringComparison compare = StringComparison.CurrentCultureIgnoreCase; // non case sensitive
            foreach (House house in housingData)
            {
                if (house.Missionaries.Any(miss => miss.Contains(missionary, compare))) // find missionary house
                    missionaryHouse = house;
                if (house.TeachingAreas.Any(area => area.Contains(endArea[2], compare))) // find new home
                    endHouse = house;
                else if ((house.Id == 0 && TransportNumbers.GoToOffice()) || (house.Id == 1 && !TransportNumbers.GoToOffice())) // never null
                    office = house;
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
            var headerRange = sheet.Range(1, 1, 1, 6);
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
            if (filePath == "none")
                return "No file path has currently been set!";
            DateTime now = DateTime.Now;
            path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.xlsx";

            bool isGolden(int index) // convenience
            {
                if (transferData[12][index].Contains("(TR)") || transferData[12][index].Contains("(DT)"))
                    return true;
                return false;
            }

            List<bool> missionariesMovingAreGolden = [];
            List<string> missionariesMoving = [];
            List<List<string>> missionariesMovingAreas = [];
            List<bool> missionariesNotMovingAreGolden = [];
            List<string> missionariesNotMoving = [];
            List<List<string>> missionariesNotMovingAreas = [];

            //0: zone, 1: district, 2: area, 3: phone, 4: address, 5: name, 6: position, 7: previous area
            //8: previous position, 9: elder/sister, 10: language, 11: driving status, 12: next companion

            // new missionaries
            StringComparison compare = StringComparison.CurrentCultureIgnoreCase;
            for (int index = 0; index < transferData[0].Count; index++)
            {
                List<string> areas = [transferData[0][index], transferData[1][index], transferData[2][index]];
                if (!transferData[2][index].Contains("Sr", compare) &&
                    !transferData[2][index].Contains("Service", compare) &&
                    !transferData[1][index].Contains("Office", compare)) // exclude senior angels, service missionaries, office (sorry)
                {
                    if (!string.IsNullOrEmpty(transferData[7][index])) // moving areas
                    {
                        missionariesMoving.Add(transferData[5][index]);
                        missionariesMovingAreas.Add(areas);
                        missionariesMovingAreGolden.Add(isGolden(index));
                    }
                    else // not moving areas
                    {
                        missionariesNotMoving.Add(transferData[5][index]);
                        missionariesNotMovingAreas.Add(areas);
                        missionariesNotMovingAreGolden.Add(isGolden(index));
                    }
                }
            }

            WriteToFile("Moving Areas", missionariesMoving, missionariesMovingAreGolden, missionariesMovingAreas);
            WriteToFile("Staying in Area", missionariesNotMoving, missionariesNotMovingAreGolden, missionariesNotMovingAreas);
            if (File.Exists(path))
                File.Delete(path); // delete file if already exists to avoid double data
            Workbook.SaveAs(path);
            Workbook = new(); // prevents errors

            return $"Successfully generated logistics at: {path}";
        }
        static double DegreeToRadians(double deg) => deg * Math.PI / 180.0;
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
    }
}
