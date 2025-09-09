namespace ASMOrganization.NonForms
{
    public class House
    {
        public string Name { get; set; } = "";
        public int Id { get; set; } = 0;
        public int[] Coordinates { get; set; } = [0, 0];
        public List<string> Missionaries { get; set; } = [];
        public string TeachingArea { get; set; } = "";

        public override bool Equals(object? obj)
        {
            if (obj is not House house) return false;
            return Id == house.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Id, Coordinates, Missionaries, TeachingArea);
    }
}
