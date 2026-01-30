using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOrganization.NonForms
{
    public class Missionary
    {
        public required string Name { get; set; }
        public required int ID { get; set; }
        public required int FlatID { get; set; }
        public required string Area { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Missionary mis)
                return false;
            return mis.ID == ID;
        }

        public override string ToString() => Name;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
