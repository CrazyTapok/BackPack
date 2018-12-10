using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Backpack
{
    class DynamicAlgoritm : Backpack
    {
        List<Item> BestSet = new List<Item>();
        public int[,] table;
        Stopwatch Watch = new Stopwatch();

        public DynamicAlgoritm(String fileName) : base(fileName)
        {
            FillingTable(items);
        }

        public int Max(int a, int b)
        {
            return a > b ? a: b;
        }

        public void PutInBackpack(int k, int n)
        {
            if (table[k, n] != 0)
            {
                if (table[k - 1, n] == table[k, n])
                    PutInBackpack(k - 1, n);
                else
                {
                    PutInBackpack(k - 1, n - items[k - 1].Weight);
                    BestSet.Add(items[k - 1]);
                }
            }
        }

        public void FillingTable(List<Item> items)
        {
            table = new int[items.Count + 1, WeightBag + 1];
            Watch.Start();
            /* for (int i = 0; i <= WeightBag; i++)
                 table[0, i] = 0;
             for (int i = 0; i <= items.Count; i++)
                 table[i, 0] = 0;*/
            for (int i = 1; i <= items.Count; i++)
            {
                for (int j = 0; j <= WeightBag; j++)
                {
                    if (j >= items[i - 1].Weight)
                        table[i, j] = Max(table[i - 1, j], table[i - 1, j - items[i - 1].Weight] + items[i - 1].Cost);
                    else
                        table[i, j] = table[i - 1, j];
                }
            }
            PutInBackpack(items.Count, WeightBag);
            Watch.Stop();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < BestSet.Count; i++)
                str.Append("- "+BestSet[i] + "\n");
            str.Append(">>> Стоимость данного набора: " + CalcCost(BestSet) + "\n");
            str.Append(">>> Вес данного набора: " + CalcWeight(BestSet) + "\n");
            str.Append(">>> Время работы алгоритма :" + Watch.Elapsed + "\n");
            return str.ToString();
        }
    }
}
