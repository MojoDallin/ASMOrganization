namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";
        private static void WriteToFile(string header, List<string> data)
        {
            using StreamWriter writer = new(path, true);
            writer.WriteLine(header + "\n"); // extra blank line
            foreach (string item in data)
                if(item != "") // do not write whitespace
                    writer.WriteLine(item);
            writer.WriteLine("\n"); // two extra blank lines
        }
        public static string FigureOutLogistics(List<List<string>> curTransfer, List<List<string>> newTransfer, string filePath)
        {
            if (filePath == "none")
                return "No file path has currently been set!";
            else if (curTransfer.Count == 0)
                return "No data for the current transfer!";
            else if (newTransfer.Count == 0)
                return "No data for the new transfer!";
            DateTime now = DateTime.Now;
            path = filePath + $"\\Logistics_{now.Day}-{now.Month}-{now.Year}.txt";
            if(File.Exists(path))
                File.Delete(path); // delete file if already exists to avoid double data
            // curTransfer[missionaryNames, missionaryZones, missionaryAreas]
            List<string> newMissionaries = [];
            foreach(string missionary in newTransfer[0])
            {
                if (!curTransfer[0].Contains(missionary)) // check for new missionaries
                {
                    int index = newTransfer[0].IndexOf(missionary);
                    newMissionaries.Add(missionary);
                    newTransfer[0].Remove(missionary);
                    newTransfer[1].RemoveAt(index); // remove zone
                    newTransfer[2].RemoveAt(index); // remove area
                }
            }
            WriteToFile("--NEW MISSIONARIES--", newMissionaries);

            List<string> sameZoneMissionaries = [];
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
                    newTransfer[0][index] = "";
                    newTransfer[1][index] = "";
                    newTransfer[2][index] = "";
                }
            }
            WriteToFile("--MISSIONARIES IN THE SAME AREA--", sameAreaMissionaries);
            WriteToFile("--MISSIONARIES IN THE SAME ZONE--", sameZoneMissionaries);
            WriteToFile("--MISSIONARIES MOVING ZONES--", newTransfer[0]);

            return $"Successfully generated logistics at: {path}";
        }
    }
}
