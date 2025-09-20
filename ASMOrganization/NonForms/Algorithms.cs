using System.Text.Json; // save/load housing data
using ClosedXML.Excel; // write to excel

namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";

        private static string TransportMethod(string missionary, List<House>? housingData, string[] endArea)
        {
            // endArea[0] == zone, endArea[1] == area; [0] is area if staying in zone
            // TRANSPORT RULES
            //Any distance less than 30km will use public transport
            //If using a car AND the distance with office is less than the direct distance + half, go to office
            //Otherwise, no office

            if (housingData is null)
                return ""; // if in the same area or released, doesnt need any data
            string[] transportData = ["", ""];
            House? missionaryHouse = null;
            House? endHouse = null;
            House office = null!;
            missionary = $"{missionary[(missionary.IndexOf(',') + 2) ..]} {missionary[0 .. missionary.IndexOf(',')]}"; // format missionary so they can be found
            missionary = missionary.Replace("  ", " "); // some have double spaces, so fix
            foreach (House house in housingData)
            {
                if (house.Missionaries.Contains(missionary)) // find missionary house
                    missionaryHouse = house;
                else if (house.TeachingAreas.Contains(endArea[^1])) // find new home
                    endHouse = house;
                else if (house.Id == 0) // never null
                    office = house;
                if (missionaryHouse is not null && endHouse is not null && office is not null) // end early once all are found
                    break;
            }
            if (office is null)
                return "Could not find office! Is it in the housing data with the ID of 0?";
            else if (missionaryHouse is null)
                return "Could not find house missionary is in!";
            else if (endHouse is null)
                return "Could not find house missionary is going to!";

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
                transportData[1] = "Office";
            else
                transportData[1] = "No Office";

            return $"Using {transportData[0]} ({transportData[1]})";
        }
        private static void WriteToFile(string header, List<string> data, List<List<string>>? optionalData = null)
        {
            List<House>? housingData = null;
            if(optionalData is not null)
            {
                // put this here so it only reads once when needed
                string json = File.ReadAllText("HousingData.json");
                housingData = JsonSerializer.Deserialize<List<House>>(json, new JsonSerializerOptions { WriteIndented = true })!;
            }
            optionalData ??= [];
            using StreamWriter writer = new(path, true);
            writer.WriteLine(header + "\n"); // extra blank line
            for (int index = 0; index < data.Count; index++)
            {
                if (data[index] != "") // do not write whitespace
                {
                    string toWrite = data[index];
                    if (optionalData.Count > 0)
                    {
                        for (int optIndex = 0; optIndex < optionalData[index].Count; optIndex++)
                            toWrite += $" -> {optionalData[index][optIndex]}";
                        if (!header.Contains("GOLDEN")) // no transport method for new missionaries (always car)
                            toWrite += $"\n{TransportMethod(data[index], housingData, [.. optionalData[index]])}";
                    }
                    writer.WriteLine(toWrite + "\n"); // add a blank line for readability
                }
            }
            writer.WriteLine("\n\n"); // three extra blank lines
        }
        public static string FigureOutLogistics(List<List<string>> transferData, string filePath)
        {
            if (filePath == "none")
                return "No file path has currently been set!";
            DateTime now = DateTime.Now;
            path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.txt";
            if(File.Exists(path))
                File.Delete(path); // delete file if already exists to avoid double data

            List<string> newMissionaries = [];
            List<List<string>> newMissionaryAreas = [];
            List<string> missionariesMoving = [];
            List<List<string>> missionariesMovingAreas = [];
            List<string> missionariesNotMoving = [];

            //0: zone, 1: district, 2: area, 3: phone, 4: address, 5: name, 6: position, 7: previous area
            //8: previous position, 9: elder/sister, 10: language, 11: driving status, 12: next companion

            // new missionaries
            for (int index = 0; index < transferData[0].Count; index++)
            {
                if (transferData[6][index].Contains("TR") || transferData[6][index].Contains("DT")) // trainer? 
                {
                    newMissionaries.Add(transferData[12][index]);
                    newMissionaryAreas.Add([transferData[0][index], transferData[1][index], transferData[2][index]]);
                }
                if (!string.IsNullOrEmpty(transferData[7][index])) // moving areas
                {
                    missionariesMoving.Add(transferData[5][index]);
                    missionariesMovingAreas.Add([transferData[0][index], transferData[1][index], transferData[2][index]]);
                }
                else
                    missionariesNotMoving.Add(transferData[5][index]);
            }
            // TODO: get rid of office senior couples, write to excel spreadsheet instead of .txt

            WriteToFile("--GOLDENS--", newMissionaries, newMissionaryAreas);
            WriteToFile("--MOVING AREAS--", missionariesMoving, missionariesMovingAreas);
            WriteToFile("--STAYING IN AREA--", missionariesNotMoving);


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
