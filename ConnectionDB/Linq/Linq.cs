using ConnectionDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class Linq
    {
        public static void GetDetailEmployee()
        {
            var employee = new Employee();
            var departement = new Departement();
            var location = new Location();
            var country = new Country();
            var region = new Region();

            var getEmployee = employee.GetAll();
            var getDepartement = departement.GetAll();
            var getLocation = location.GetAll();
            var getCountry = country.GetAll();
            var getRegion = region.GetAll();

            var resultJoin = getEmployee.Join(getDepartement,
                                                e => e.DepartementId,
                                                d => d.Id,
                                                (e, d) => new { e, d }).
                                                Join(getLocation,
                                                ed => ed.d.LocationId,
                                                l => l.Id,
                                                (ed, l) => new { ed, l }).
                                                Join(getCountry,
                                                edl => edl.l.CountryId,
                                                c => c.Id,
                                                (edl, c) => new { edl, c }).
                                                Join(getRegion,
                                                edlc => edlc.c.RegionId,
                                                r => r.Id,
                                                (edlc, r) => new EmployeeAndDepartementAndLocationAndCountryAndRegionVM
                                                {
                                                    Id = edlc.edl.ed.e.Id,
                                                    FirstName = edlc.edl.ed.e.FirstName,
                                                    LastName = edlc.edl.ed.e.LastName,
                                                    Email = edlc.edl.ed.e.Email,
                                                    Phone = edlc.edl.ed.e.PhoneNumber,
                                                    Salary = edlc.edl.ed.e.Salary,
                                                    DepartementName = edlc.edl.ed.d.Name,
                                                    StreetAddress = edlc.edl.l.StreetAddress,
                                                    CountryName = edlc.c.Name,
                                                    RegionName = r.Name
                                                }).ToList();


            GeneralMenu.List("Join", resultJoin);
        }

        public static void GetDetailDepartement()
        {
            var employee = new Employee();
            var departement = new Departement();

            var getEmployee = employee.GetAll();
            var getDepartement = departement.GetAll();

            try
            {


                var result = (from d in getDepartement
                              join e in getEmployee on d.Id equals e.DepartementId
                              group e by d.Name into g
                              where g.Count() > 3
                              select new EmployeeAndDepartementVM
                              {
                                  DepartementName = g.Key,
                                  TotalEmployee = g.Count(),
                                  MinSalary = g.Min(e => e.Salary),
                                  MaxSalary = g.Max(e => e.Salary),
                                  AvgSalary = g.Average(e => e.Salary),
                              }).ToList();
                GeneralMenu.List("Detail Departement", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }
    }
}
