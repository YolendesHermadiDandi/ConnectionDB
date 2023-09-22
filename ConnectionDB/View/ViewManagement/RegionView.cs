using ConnectionDB.Controller;
using ConnectionDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.View.ViewManagement
{
    internal class RegionView : GeneralView
    {
        private static string input = "";
        public static void RegionMenu()
        {
            var isLoop = true;
            while (isLoop)
            {

                Console.WriteLine("1. List all region");
                Console.WriteLine("2. Insert region");
                Console.WriteLine("3. Get region by id");
                Console.WriteLine("4. Update region");
                Console.WriteLine("5. Delete region");
                Console.WriteLine("6. Back");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
                isLoop = Menu(input);
            }
        }

        private static bool Menu(string input)
        {
            var region = new Region();
            var regionView = new RegionView();

            var regionController = new RegionController(region, regionView);
            switch (input)
            {
                case "1":
                    regionController.GetAll();
                    break;
                case "2":
                    regionController.Insert();
                    break;
                case "3":
                    Console.Write("Masukan Id : ");
                    input = Console.ReadLine();
                    regionController.GetById(input);
                    break;
                case "4":
                    break;
                case "5":
                    regionController.Delete();
                    break;
                case "6":
                    return false;

                default:
                    Console.WriteLine("inputan tidak valid");
                    break;
            }
            return true;
        }

        public string InsertInput()
        {
            Console.Write("Masukan nama region : ");
            var name = Console.ReadLine();

            return name;
        }

        public string InsertDelete()
        {
            Console.Write("Masukan id region : ");
            var name = Console.ReadLine();

            return name;
        }

    }
}
