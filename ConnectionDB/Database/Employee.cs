﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConnectionDB.Database
{
    internal class Employee
    {
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

        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_employees";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var employee = new TabelQuery();

                List<dynamic> getAllEmployee = employee.getAll(tabelName);
                return getAllEmployee;
            };

            return new List<dynamic>();
        }



        public static void Insert(int jobId, int managerId, int departementId, string firstName,
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

            var query = new TabelQuery();
            query.Insert("tbl_employees", employee);


        }








        //untuk Linq
        public List<Employee> GetAllEmployee()
        {
            var countries = new List<Employee>();

            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_employees";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(new Employee()
                        {
                            Id = reader.GetInt32(0),
                            JobId = reader.GetInt32(1),
                            //ManagerId = reader.GetInt32(reader.GetOrdinal("id")),
                            ManagerId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            DepartementId = reader.GetInt32(3),
                            FirstName = reader.GetString(4),
                            LastName = reader.GetString(5),
                            Email = reader.GetString(6),
                            PhoneNumber = reader.GetString(7),
                            HireDate = reader.GetDateTime(8),
                            Salary = reader.GetDouble(9),
                            Comissionpct = reader.GetDouble(10),
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return countries;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Employee>();
        }
    }
}
