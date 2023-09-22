using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class GeneralView
    {
        public void List<T>(string title, List<T> data)
        {
            Console.WriteLine("List data " + title);
            Console.WriteLine("-----------------------------");
            foreach (T item in data)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Single<T>(string title, T item)
        {
            Console.WriteLine($"List of {title}");
            Console.WriteLine("---------------");
            Console.WriteLine(item.ToString());
        }

        public void Transaction(string result)
        {
            int.TryParse(result, out int res);
            if (res > 0)
            {
                Console.WriteLine("Transaction completed successfully");
            }
            else
            {
                Console.WriteLine("Transaction failed");
                Console.WriteLine(result);
            }
        }
    }
}
