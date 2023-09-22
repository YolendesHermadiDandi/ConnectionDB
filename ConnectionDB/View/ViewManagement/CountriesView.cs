using ConnectionDB.Controller;
using ConnectionDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.View.ViewManagement
{
    internal class CountriesView : GeneralView
    {
        private static string input = "";
        public static void CountryMenu()
        {
            var isLoop = true;
            while (isLoop)
            {

                Console.WriteLine("1. List all country");
                Console.WriteLine("2. Insert country");
                Console.WriteLine("3. Get country by id");
                Console.WriteLine("4. Update country");
                Console.WriteLine("5. Delete country");
                Console.WriteLine("6. Back");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
                isLoop = Menu(input);
            }
        }

        private static bool Menu(string input)
        {
            var country = new Country();
            var countriesView = new CountriesView();

            var countryController = new CountryController(country, countriesView);
            switch (input)
            {
                case "1":
                    countryController.GetAll();
                    break;
                case "2":
                    //regionController.Insert();
                    countryController.Insert();
                    break;
                case "3":
                    Console.Write("Masukan Id : ");
                    input = Console.ReadLine();
                    countryController.GetById(input);
                    break;
                case "4":
                    //regionController.Update();
                    break;
                case "5":
                    //regionController.Delete();
                    break;
                case "6":
                    return false;

                default:
                    //Console.WriteLine("inputan tidak valid");
                    break;
            }
            return true;
        }

        public object InsertInput()
        {

            var country = new Country();
            var countriesView = new CountriesView();

            var countryController = new CountryController(country, countriesView);

            Console.Write("Masukan region id : ");
            var regionId = Console.ReadLine();
            Console.Write("masukan country name: ");
            var name = Console.ReadLine();

            if(int.TryParse(regionId, out int id) == true)
            {
                country.Name = name;
                country.RegionId = id;
            }

            

            return country;
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
