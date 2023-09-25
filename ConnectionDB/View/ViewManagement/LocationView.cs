using ConnectionDB.Controller;
using ConnectionDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.View.ViewManagement
{
    internal class LocationView
    {
        private static string input = "";
        public static void RegionMenu()
        {
            var isLoop = true;
            while (isLoop)
            {

                Console.WriteLine("1. List all location");
                Console.WriteLine("2. Insert location");
                Console.WriteLine("3. Get location by id");
                Console.WriteLine("4. Update location");
                Console.WriteLine("5. Delete location");
                Console.WriteLine("6. Back");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
                isLoop = Menu(input);
            }
        }

        private static bool Menu(string input)
        {
            var location = new Location();
            var locationView = new LocationView();

            var regionController = new RegionController(location, LocationView);
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
                    regionController.Update();
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

        public string InsertUpdate()
        {
            Console.Write("Masukan id region: ");
            var name = Console.ReadLine();
            return name;
        }
    }
}
