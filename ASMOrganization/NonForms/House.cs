namespace ASMOrganization.NonForms
{
    public class House
    {
        public string Name { get; set; } = "";
        public int Id { get; set; } = 0;
        public double[] Coordinates { get; set; } = [0, 0];
        public List<string> Missionaries { get; set; } = [];
        public string Zone { get; set; } = "";
        public List<string> TeachingAreas { get; set; } = [];

        public override bool Equals(object? obj)
        {
            if (obj is not House house) return false;
            return Id == house.Id;
        }

        public static List<string> ParseTeachingAreas(string areas) // put this here because its used in multiple places
        {
            List<string> separatedAreas = [.. areas.Split(',')];
            for (int index = 0; index < separatedAreas.Count; index++)
                if (separatedAreas[index].StartsWith(' '))
                    separatedAreas[index] = separatedAreas[index][1..];
            return separatedAreas;
        }
        public string ReverseParseTeachingAreas()
        {
            string total = "";
            foreach (string area in TeachingAreas)
                total += area + ", ";
            total = total[0..(total.Length - 2)];
            return total;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Id, Coordinates, Missionaries, Zone, TeachingAreas);
    }
}
