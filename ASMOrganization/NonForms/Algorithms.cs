namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";
        private static void WriteToFile(string header, List<string> data, List<List<string>>? optionalData = null)
        {
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
                    writer.WriteLine(toWrite);
                }
            }
            writer.WriteLine("\n"); // two extra blank lines
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
    }
}
