using System.Text.Json;
using ASMOrganization.NonForms;
using System.IO;
using System.ComponentModel;
namespace ASMOrganization.Forms
{
    public partial class NewHouse : Form
    {
        private readonly BindingList<House> houses = [];
        public NewHouse(BindingList<House> h)
        {
            InitializeComponent();
            missionaryHolder.RowStyles.Clear();
            houses = h;
        }

        private void AddMissionary(object sender, EventArgs e)
        {
            TextBox newMissionary = new()
            {
                Size = houseNameBox.Size,
                Font = houseNameBox.Font,
                PlaceholderText = "Enter Missionary...",
                TextAlign = HorizontalAlignment.Center,
                Anchor = houseNameBox.Anchor,
            };
            missionaryHolder.Controls.Add(newMissionary);
        }
        private static int ParseID(string id)
        {
            id = id.Replace("M", "");
            id = id.Replace("S", "");
            id = id.Replace("H", "");
            id = id.Replace("-", "");
            return Int32.Parse(id);
        }


        private bool CheckDuplicateHouseID(House newHouse)
        {
            foreach (House house in houses)
                if (house.Equals(newHouse))
                    return true;
            return false;
        }

        private void CreateHouse(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(houseNameBox.Text))
                resultCreateHouseLabel.Text = "No name has been entered!";
            else if (string.IsNullOrEmpty(houseIDBox.Text))
                resultCreateHouseLabel.Text = "No ID has been entered!";
            else if (string.IsNullOrEmpty(houseAddressBox.Text))
                resultCreateHouseLabel.Text = "No address has been entered!";
            else if (string.IsNullOrEmpty(houseXCoordinateBox.Text))
                resultCreateHouseLabel.Text = "No X coordinate has been entered!";
            else if (string.IsNullOrEmpty(houseYCoordinateBox.Text))
                resultCreateHouseLabel.Text = "No Y coordinate has been entered!";
            else if (string.IsNullOrEmpty(houseZoneBox.Text))
                resultCreateHouseLabel.Text = "No zone has been entered!";
            else if (string.IsNullOrEmpty(houseTeachingAreaBox.Text))
                resultCreateHouseLabel.Text = "No teaching area has been entered!";
            else
            {
                try
                {
                    House house = new()
                    {
                        Name = houseNameBox.Text,
                        Id = ParseID(houseIDBox.Text),
                        Address = houseAddressBox.Text,
                        Coordinates = [Double.Parse(houseXCoordinateBox.Text), Double.Parse(houseYCoordinateBox.Text)],
                        Zone = houseZoneBox.Text,
                        TeachingAreas = House.ParseTeachingAreas(houseTeachingAreaBox.Text)
                    };
                    if (!CheckDuplicateHouseID(house))
                    {
                        foreach (TextBox box in missionaryHolder.Controls)
                            house.Missionaries.Add(box.Text);
                        houses.Add(house);
                        resultCreateHouseLabel.Text = "Successfully created house!";
                    }
                    else
                        resultCreateHouseLabel.Text = "House ID already exists!";
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                        resultCreateHouseLabel.Text = "House ID, X coordinate, or Y coordinate is in the wrong format!";
                    else
                        resultCreateHouseLabel.Text = "Something went wrong, is everything in the correct format?";
                }
            }
        }
    }
}
