using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class EmployeeAndDepartementVM
    {
        public string DepartementName { get; set; }
        public int TotalEmployee { get; set; }
        public double? MinSalary { get; set; }
        public double? MaxSalary { get; set; }
        public dynamic? AvgSalary { get; set; }

        public override string ToString()
        {
            return $"{DepartementName} - {TotalEmployee} - {MinSalary} - {MaxSalary} - {AvgSalary} ";
        }
    }
}
