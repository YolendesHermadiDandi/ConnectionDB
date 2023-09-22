using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class GeneralMenu
    {
        public static void List<T>(string title, List<T> data)
        {
            Console.WriteLine("List data " + title);
            Console.WriteLine("-----------------------------");
            foreach (T item in data) 
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
