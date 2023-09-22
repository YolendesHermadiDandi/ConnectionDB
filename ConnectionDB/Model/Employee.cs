using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConnectionDB.Controller;

namespace ConnectionDB.Model
{
    internal class Employee
    {

        private const string tabelName = "tbl_employees";
        public int Id { get; set; }
        public int JobId { get; set; }
        public int ManagerId { get; set; }
        public int DepartementId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public double Comissionpct { get; set; }

        public override string ToString()
        {
            return $"{Id} - {JobId} - {ManagerId} - {DepartementId} - {FirstName} - {LastName}" +
                $"- {Email} - {PhoneNumber} - {HireDate} - {Salary} - {Comissionpct}";
        }

        //public List<Employee> GetAll()
        //{

        //    if (ErrorHandler.EHandlerGetAll(tabelName) == true)
        //    {
        //        var employee = new TabelQuery();

        //        List<dynamic> getAllEmployee = employee.getAll(tabelName);
        //        List<Employee> employees = getAllEmployee.Select(item => new Employee
        //        {
        //            Id = item.Id,
        //            JobId = item.JobId,
        //            ManagerId = item.ManagerId,
        //            DepartementId = item.DepartementId,
        //            FirstName = item.FirstName,
        //            LastName = item.LastName,
        //            PhoneNumber = item.PhoneNumber,
        //            HireDate = item.HireDate,
        //            Salary = item.Salary,
        //            Comissionpct = item.Comissionpct,
        //            Email = item.Email,

        //        }).ToList();
        //        return employees;

        //    };

        //    return new List<Employee>();
        //}

        //public Employee GetById(string id)
        //{
            

        //    int getid = ErrorHandler.EHandlerGetRegionById(id);
        //    if (getid > 0)
        //    {
        //        var employee = new TabelQuery();
        //        Employee getEmployeeById = (Employee) employee.getById(tabelName, getid);
        //        Employee emp = new Employee
        //        {
        //            Id = getEmployeeById.Id,
        //            JobId = getEmployeeById.JobId,
        //            ManagerId = getEmployeeById.ManagerId,
        //            DepartementId = getEmployeeById.DepartementId,
        //            FirstName = getEmployeeById.FirstName,
        //            LastName = getEmployeeById.LastName,
        //            PhoneNumber = getEmployeeById.PhoneNumber,
        //            HireDate = getEmployeeById.HireDate,
        //            Salary = getEmployeeById.Salary,
        //            Comissionpct = getEmployeeById.Comissionpct,
        //            Email = getEmployeeById.Email,
        //        };
        //        return emp;
        //    }
        //    return new Employee();
                       

        //}



        public static void Insert(int jobId, int managerId, int departementId, string firstName, string email,
            string lastName, string phoneNumber, DateTime hireDate, float salary, float commissionPct)
        {
            Employee employee = new Employee();
            employee.JobId = jobId;
            employee.ManagerId = managerId;
            employee.DepartementId = departementId;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.PhoneNumber = phoneNumber;
            employee.HireDate = hireDate;
            employee.Salary = salary;
            employee.Comissionpct = commissionPct;
            employee.Email = email;
            var query = new TabelQuery();
            //query.Insert("tbl_employees", employee);


        }


    }
}
