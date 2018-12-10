using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack
{
    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        public double Value { get; set; }

        public Item(string Name, int Weight, int Cost)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.Cost = Cost;
            this.Value = Cost / Weight;
        }

        public override string ToString()
        {
            return Name + " " + Weight + " " + Cost + " " + Value;
        }
    }
}
