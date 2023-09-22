using ConnectionDB.Controller.Linq;
using ConnectionDB.Model;
using ConnectionDB.View;
using ConnectionDB.View.ViewManagement;

namespace ConnectionDB
{
    public class Program
    {

        private static void Main()
        {

            var choice = true;
            while (choice)
            {
                Console.WriteLine("1. regions");
                Console.WriteLine("2. countries");
                Console.WriteLine("3. List all locations");
                Console.WriteLine("4. List all departements");
                Console.WriteLine("5. List all employees");
                Console.WriteLine("6. List all job history");
                Console.WriteLine("7. List all Job");
                Console.WriteLine("8. Join Employee And Departement");
                Console.WriteLine("9. Detail Departements");
                Console.WriteLine("10. Get employee by id");
                Console.WriteLine("21. Exit");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                choice = Menu(input);
            }
        }
        public static bool Menu(string input)
        {
            switch (input)
            {
                case "1":
                    RegionView.RegionMenu();
                    break;
                case "2":
                    CountriesView.CountryMenu();
                    //var country = new Country();
                    //var countries = country.GetAll();
                    //GeneralMenu.List("countries", countries);
                    break;
                case "3":
                    //var location = new Location();
                    //var locations = location.GetAll();
                    //GeneralMenu.List("locations", locations);
                    break;
                case "4":
                    //var departement = new Departement();
                    //var departements = departement.GetAll();
                    //GeneralMenu.List("departements", departements);
                    break;
                case "5":
                    //var employee = new Employee();
                    //var employees = employee.GetAll();
                    //GeneralMenu.List("employees", employees);
                    break;
                case "6":
                    //var jobHistory = new JobHistory();
                    //var alljobhistory = jobHistory.GetAll();
                    //GeneralMenu.List("Job History", alljobhistory);
                    break;
                case "7":
                    //var job = new Job();
                    //var allJob = job.GetAll();
                    //GeneralMenu.List("Job", allJob);
                    break;
                case "8":
                    //Linq.GetDetailEmployee();
                    break;
                case "9":
                    //Linq.GetDetailDepartement();
                    break;
                case "10":
                    var employee1 = new Employee();

                    //var getById = employee1.GetById(Console.ReadLine());
                    break;
                case "21":
                    return false;
                default:

                    Console.WriteLine("Invalid choice");
                    break;
            }
            return true;
        }



    }
}
