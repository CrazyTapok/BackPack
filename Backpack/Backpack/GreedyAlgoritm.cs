using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Backpack
{
    class GreedyAlgoritm : Backpack
    {
        List<Item> BestSet = new List<Item>();
        Stopwatch Watch = new Stopwatch();

        public GreedyAlgoritm(String fileName) : base(fileName) {
            PutInBackpack(items);
        }

        public void Sort(List<Item> items)
        {
            items.Sort((a, b) => b.Value.CompareTo(a.Value));
        }
        
        public void PutInBackpack(List<Item> items)
        {
            Sort(items);
            Watch.Start();
            for (int i = 0; i < items.Count - 1; i++)
            {
                if (CalcWeight(BestSet) + items[i].Weight <= WeightBag)
                    BestSet.Add(items[i]);
            }
            Watch.Stop();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < BestSet.Count; i++)
                str.Append("- " + BestSet[i] + "\n");
            str.Append(">>> Стоимость данного набора: " + CalcCost(BestSet) + "\n");
            str.Append(">>> Вес данного набора: " + CalcWeight(BestSet) + "\n");
            str.Append(">>> Время работы алгоритма :" + Watch.Elapsed + "\n");
            return str.ToString();
        }
    }
}
