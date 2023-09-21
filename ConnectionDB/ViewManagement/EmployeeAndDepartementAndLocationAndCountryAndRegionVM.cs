using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class EmployeeAndDepartementAndLocationAndCountryAndRegionVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  Phone { set; get; } 
        public double Salary { get; set; }
        public string DepartementName { get; set; }
        public string StreetAddress { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }


         //
        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} - {Email} - {Phone} - {Salary} - {DepartementName}" +
                $" - {StreetAddress} - {CountryName} - {RegionName}\n";
        }
    }
}
