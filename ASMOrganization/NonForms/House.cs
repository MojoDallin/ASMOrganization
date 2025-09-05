namespace ASMOrganization.NonForms
{
    public class House
    {
        public string Name { get; set; } = "";
        public int Id { get; set; } = 0;
        public int[] Coordinates { get; set; } = [0, 0];
        public List<string> Missionaries { get; set; } = [];
    }
}
