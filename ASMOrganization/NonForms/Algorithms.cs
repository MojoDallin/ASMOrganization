using System.Text.Json;

namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";

        private static string TransportMethod(string missionary, List<House>? housingData, string endArea)
        {
            // TRANSPORT RULES
            // Any transport involving Teancum, Nephi, Enos, and Jacob zones always use cars
            // Going to/from Teancum/Nephi does not attend office; anyone else in the above zones does
            // Staying in the same zone (except for those above) will always be PT
            // If office between transfer locations, come to office; otherwise, go directly to area
            if (housingData is null)
                return "";
            return "Abc";
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
                    for (int optIndex = 0; optIndex < optionalData.Count; optIndex++)
                    {
                        toWrite += $" -> {optionalData[optIndex][index]}";
                    }
                    if (optionalData.Count > 0)
                    {
                        toWrite += $"\n{TransportMethod(data[index], housingData, optionalData[optionalData.Count - 1][index])}";
                    }
                    writer.WriteLine(toWrite + "\n"); // add a blank line for readability
                }
            }
            writer.WriteLine("\n\n"); // three extra blank lines
        }
        public static string FigureOutLogistics(List<List<string>> curTransfer, List<List<string>> newTransfer, string filePath)
        {
            if (filePath == "none")
                return "No file path has currently been set!";
            DateTime now = DateTime.Now;
            path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.txt";
            if(File.Exists(path))
                File.Delete(path); // delete file if already exists to avoid double data
            // curTransfer[missionaryNames, missionaryZones, missionaryAreas]
            List<string> newMissionaries = [];
            List<List<string>> newMissionaryAreas = [[], []];
            List<string> releasedMissionaries = [];
            foreach(string missionary in newTransfer[0].ToList()) // create copy of list so it can execute
            {
                if (!curTransfer[0].Contains(missionary)) // check for new missionaries
                {
                    int index = newTransfer[0].IndexOf(missionary);
                    newMissionaries.Add(missionary);
                    newMissionaryAreas[0].Add(newTransfer[1][index]);
                    newMissionaryAreas[1].Add(newTransfer[2][index]);
                    newTransfer[0].Remove(missionary); // remove missionary
                    newTransfer[1].RemoveAt(index); // remove zone
                    newTransfer[2].RemoveAt(index); // remove area
                }
            }
            foreach(string missionary in curTransfer[0].ToList()) // check for released missionaries
            {
                if (!newTransfer[0].Contains(missionary))
                {
                    int index = curTransfer[0].IndexOf(missionary);
                    releasedMissionaries.Add(missionary);
                    curTransfer[0].Remove(missionary);
                    curTransfer[1].RemoveAt(index);
                    curTransfer[2].RemoveAt(index);
                }
            }
            WriteToFile("--RELEASED MISSIONARIES--", releasedMissionaries);
            WriteToFile("--NEW MISSIONARIES--", newMissionaries, newMissionaryAreas);

            List<string> sameZoneMissionaries = [];
            List<List<string>> newAreaSameZoneMissionaries = [[]];
            List<string> sameAreaMissionaries = [];
            for(int index = 0; index < newTransfer[0].Count; index++)
            {
                if (curTransfer[2][index] == newTransfer[2][index])
                {
                    sameAreaMissionaries.Add(curTransfer[0][index]);
                    // using Remove instead of setting it to "" breaks the program
                    // this is because it shifts the index up by one and offsets it
                    newTransfer[0][index] = "";
                    newTransfer[1][index] = "";
                    newTransfer[2][index] = "";
                }
                else if (curTransfer[1][index] == newTransfer[1][index])
                {
                    sameZoneMissionaries.Add(curTransfer[0][index]);
                    newAreaSameZoneMissionaries[0].Add(newTransfer[2][index]);
                    newTransfer[0][index] = "";
                    newTransfer[1][index] = "";
                    newTransfer[2][index] = "";
                }
            }
            WriteToFile("--MISSIONARIES IN THE SAME AREA--", sameAreaMissionaries);
            WriteToFile("--MISSIONARIES IN THE SAME ZONE--", sameZoneMissionaries, newAreaSameZoneMissionaries);
            WriteToFile("--MISSIONARIES MOVING ZONES--", newTransfer[0], [newTransfer[1], newTransfer[2]]);

            return $"Successfully generated logistics at: {path}";
        }
        static double DegreeToRadians(double deg) => deg * Math.PI / 180.0;
        public static double CalcHaversineDistance(double la1 , double lo1, double la2, double lo2)
        {
            // i did NOT sign up for this crazy ahh formula
            // thanks chatgpt
            la1 = DegreeToRadians(la1); // first, we convert degrees to radians
            la2 = DegreeToRadians(la2);
            lo1 = DegreeToRadians(lo1);
            lo2 = DegreeToRadians(lo2);
            const int radius = 6371000; // meters for science standard
            double latDiff = la2 - la1; // second, difference of each point
            double lonDiff = lo2 - lo1;
            double sin1 = Math.Pow(Math.Sin(latDiff/2), 2); // then this
            double sin2 = Math.Cos(la1) * Math.Cos(la2); // and this
            sin2 *= Math.Pow(Math.Sin(lonDiff/2), 2); // plus this
            return 2 * radius * Math.Asin(Math.Sqrt(sin1 + sin2)); // finally
        }
    }
}
