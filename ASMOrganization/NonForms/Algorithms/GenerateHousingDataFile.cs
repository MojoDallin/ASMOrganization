using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASMOrganization.NonForms.Algorithms
{
    public static class GenerateHousingDataFile
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true }; // i hate warnings bro
        //IN ORDER: 0Zone 1District 2Area 3AreaPhone 4AreaAddress 5MissionaryName 6Position 7AreaPriorToChange 8PositionPriorToChange 9Type 10Language 11DrivingStatus 12Companion(s)
        public static string GenerateHousingData(string filePath)
        {
            List<List<string>> allRowData = [];
            // read data from transfer file
            using (XLWorkbook transferFile = new(filePath))
            {
                var wks = transferFile.Worksheet(1);
                var range = wks.RangeUsed();
                if (range is not null)
                    foreach (var row in range.Rows())
                    {
                        List<string> rowData = [];
                        foreach (var cell in row.Cells())
                            rowData.Add(cell.Value.ToString());
                        allRowData.Add(rowData);
                    }
                allRowData = allRowData[1..]; // get rid of first row because its junk
            }
            // now we actually gotta parse the data
            List<House> newHousingData = []; // what will be saved as a .json
            // gotta add these manually because they wont ever be in the transfer data
            House officeHouse = new()
            {
                Coordinates = [-33.77560, 151.05063],
                TeachingAreas = [],
                Zone = "Moroni"
            };
            House bhChapelHouse = new()
            {
                Coordinates = [-33.76753, 150.98392],
                TeachingAreas = [],
                Zone = "Moroni"
            };
            Dictionary<string, House> addressDataPair = [];
            addressDataPair.Add("77 Watkins Road (Baulkham Hills Chapel)", bhChapelHouse);
            addressDataPair.Add("756 Pennant Hills Road (Office)", officeHouse);
            newHousingData.Add(officeHouse);
            foreach (List<string> rowInfo in allRowData)
            {
                rowInfo[4] = rowInfo[4][0..Math.Max(Math.Max(rowInfo[4].IndexOf("NSW"), rowInfo[4].IndexOf("ACT")), 0)]; // remove NSW/ACT from address, also has rowInfo[4].Length as a failsafe
                bool duplicate = false;
                foreach (KeyValuePair<string, House> pair in addressDataPair) // check for already existing houses
                    if (pair.Key == rowInfo[4]) // duplicate was found
                    {
                        pair.Value.Missionaries.Add(rowInfo[5]); // add missionary
                        if(!pair.Value.TeachingAreas.Contains(rowInfo[2]))
                            pair.Value.TeachingAreas.Add(rowInfo[2]); // add teaching area if not already added
                        duplicate = true;
                    }
                if (!duplicate)
                { // duplicate was not found
                    House newhouse = new()
                    {
                        Coordinates = [0, 0], // needs to be manually filled in!
                        TeachingAreas = [rowInfo[2]],
                        Zone = rowInfo[0],
                        Missionaries = [rowInfo[5]],
                    };
                    addressDataPair.Add(rowInfo[4], newhouse);
                }
            }
            // because houses are missing sometimes
            addressDataPair.Add("No House Assigned!", addressDataPair[""]);
            addressDataPair.Remove("");
            // move over coordinates to new file (because NOBODY should reenter them manually)
            BindingList<House> housingData = JsonSerializer.Deserialize<BindingList<House>>(File.ReadAllText("HousingData.json"), options)!; // this aint NEVER be null
            foreach (House house in housingData)
            {
                if (addressDataPair.TryGetValue(house.Address, out House? value)) // if a house isnt in here then it means it was sold or something (i think), also it will never not be a house but whatever i hate warnings
                    value.Coordinates = house.Coordinates; // update coords
            }

            // convert dictionary to list
            foreach (KeyValuePair<string, House> pair in addressDataPair)
            {
                House house = new()
                {
                    Address = pair.Key,
                    Coordinates = pair.Value.Coordinates,
                    TeachingAreas = pair.Value.TeachingAreas,
                    Zone = pair.Value.Zone,
                    Missionaries = pair.Value.Missionaries,
                };
                newHousingData.Add(house);
            }

            //finally, convert file over to new one
            string path = "HousingData_GenTest.json";
            string json = JsonSerializer.Serialize(newHousingData, options);
            File.WriteAllText(path, json);

            // convenience
            string returnString = $"Successfully generated file!\nFind it at: {new FileInfo(path).FullName}";
            returnString += $"\nMissionaries Without Assigned Houses: {addressDataPair["No House Assigned!"].Missionaries.Count}"; // just cause yknow
            returnString += $"\n--Houses Without Proper Coordinates--";
            foreach (KeyValuePair<string, House> pair in addressDataPair)
                if (pair.Value.Coordinates[0] == 0 || pair.Value.Coordinates[1] == 0)
                    returnString += $"\n{pair.Key}"; // may as well

            return returnString;
        }
    }
}
