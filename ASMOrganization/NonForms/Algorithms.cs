using System.Diagnostics;
using System.IO;

namespace ASMOrganization.NonForms
{
    public static class Algorithms
    {
        private static string path = "";
        private static void WriteToFile(string header, List<string> data)
        {
            using (StreamWriter writer = new(path, true))
            {
                writer.WriteLine(header + "\n"); // extra blank line
                foreach(string item in data)
                    writer.WriteLine(item);
                writer.WriteLine("\n"); // two extra blank lines
            }

        }
        public static string FigureOutLogistics(List<List<string>> curTransfer, List<List<string>> newTransfer)
        {
            // curTransfer[missionaryNames, missionaryZones, missionaryAreas]
            List<string> newMissionaries = [];
            foreach(string missionary in newTransfer[0])
            {
                if (!curTransfer[0].Contains(missionary)) // check for new missionaries
                {
                    int index = newTransfer[0].IndexOf(missionary);
                    newMissionaries.Add(missionary);
                    newTransfer[1].RemoveAt(index); // remove zone
                    newTransfer[2].RemoveAt(index); // remove area
                    newTransfer[0].Remove(missionary); // remove missionary
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
                    newTransfer[0].RemoveAt(index);
                    newTransfer[1].RemoveAt(index);
                    newTransfer[2].RemoveAt(index);
                }
                else if (curTransfer[1][index] == newTransfer[1][index])
                {
                    sameZoneMissionaries.Add(curTransfer[0][index]);
                    newTransfer[0].RemoveAt(index);
                    newTransfer[1].RemoveAt(index);
                    newTransfer[2].RemoveAt(index);
                }
            }
            WriteToFile("--MISSIONARIES IN THE SAME AREA--", sameAreaMissionaries);
            WriteToFile("--MISSIONARIES IN THE SAME ZONE--", sameZoneMissionaries);
            WriteToFile("--MISSIONARIES MOVING ZONES--", newTransfer[0]);

            return $"Successfully generated logistics at: {path}";
        }
    }
}
