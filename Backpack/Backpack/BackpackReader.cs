using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Backpack
{
    class BackpackReader
    {
        public BackpackReader() { }

        public List<Item> Read(String fileName)
        {
            StreamReader fin = new StreamReader(fileName);
            List<Item> items = new List<Item>();
            String[] list = fin.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            items.Add(new Item("", int.Parse(list[0]),0));
            for (int i = 1; i < list.Length; i++)
            {
                String[] s = list[i].Split(' ');
                items.Add(new Item(s[0], int.Parse(s[1]),int.Parse(s[2])));
            }
            return items;
        }
    }
}
