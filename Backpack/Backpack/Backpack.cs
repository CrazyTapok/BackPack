using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack
{
    class Backpack
    {
        public List<Item> items = new List<Item>();
        public int WeightBag { get; set; }

        public Backpack(String fileName)
        {
            BackpackReader backpackReader = new BackpackReader();
            items = backpackReader.Read(fileName);
            WeightBag = items[0].Weight;
            items.Remove(items[0]);
        }

        public double CalcWeight(List<Item> items)
        {
            double SumWeight = 0;
            foreach (Item k in items) SumWeight += k.Weight;
            return SumWeight;
        }

        public double CalcCost(List<Item> items)
        {
            double SumCost = 0;
            foreach (Item k in items) SumCost += k.Cost;
            return SumCost;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < items.Count; i++)
                str.Append("- " + items[i]+"\n");
            str.Append(">>> Допустимый вес рюкзака: "+ WeightBag+"\n");
            return str.ToString();
        }
    }
}
