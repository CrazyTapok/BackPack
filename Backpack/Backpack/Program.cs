using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack
{
    class Program
    {
        static void Main(string[] args)
        {
            Backpack backpack = new Backpack("Test1.txt");
            Console.WriteLine(">>> Начальный набор предметов\n" + backpack);

            GreedyAlgoritm greedyAlgoritm = new GreedyAlgoritm("Test1.txt");
            Console.WriteLine(">>> Жадный алгоритм\n" + greedyAlgoritm);

            DynamicAlgoritm dynamicAlgoritm = new DynamicAlgoritm("Test1.txt");
            Console.WriteLine(">>> Метод динамического программирования\n" + dynamicAlgoritm);
        }
    }
}
