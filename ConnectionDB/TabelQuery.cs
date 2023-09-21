using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConnectionDB.Database;

namespace ConnectionDB
{
    internal class TabelQuery
    {
        List<dynamic> listData = new List<dynamic>();
        const string tblEmployees = "tbl_employees";
        const string tblRegions = "tbl_regions";
        const string tblLocations = "tbl_locations";
        const string tblCountries = "tbl_countries";
        const string tblLocatons = "tbl_locations";
        const string tblDepartements = "tbl_departements";
        const string tblJob = "tbl_jobs";
        const string tblJobHistory = "tbl_job_history";


        public List<dynamic> getAll(string tabelName)
        {
            //var listData = new List<dynamic>();


            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM " + tabelName;

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      TableSelector(reader, tabelName);
                    }
                    reader.Close();
                    connection.Close();

                    return listData;
                }
                reader.Close();
                connection.Close();

                return new List<dynamic>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<dynamic>();
        }

        public dynamic getById(string tabelName, int id)
        {
            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM " + tabelName + " WHERE id =" + id;

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tabelName.Equals(tblRegions))
                        {
                            var region = new Region
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            return region;
                        }
                        else if (tabelName.Equals(tblLocations))
                        {
                            var location = new Location
                            {
                                Id = reader.GetInt32(0),
                                CountryId = reader.GetInt32(1),
                                StreetAddress = reader.GetString(2),
                                PostCode = reader.GetString(3),
                                City = reader.GetString(4),
                                StateProvince = reader.GetString(5),

                            };
                            return location;
                        }
                        else if (tabelName.Equals(tblCountries))
                        {
                            var country = new Country
                            {
                                Id = reader.GetInt32(0),
                                RegionId = reader.GetInt32(1),
                                Name = reader.GetString(2)
                            };
                            return country;

                        }
                        else if (tabelName.Equals(tblDepartements))
                        {

                            var departement = new Departement
                            {
                                Id = reader.GetInt32(0),
                                ManagerId = reader.GetInt32(1),
                                LocationId = reader.GetInt32(2),
                                Name = reader.GetString(3)
                            };
                            return departement;

                        }
                        else if (tabelName.Equals(tblEmployees))
                        {
                            var employee = new Employee
                            {
                                Id = reader.GetInt32(0),
                                JobId = reader.GetInt32(1),
                                DepartementId = reader.GetInt32(2),
                                FirstName = reader.GetString(3),
                                LastName = reader.GetString(4),
                                Email = reader.GetString(5),
                                PhoneNumber = reader.GetString(6),
                                HireDate = reader.GetDateTime(7),
                                Salary = reader.GetDouble(8),
                                Comissionpct = reader.GetDouble(9),

                            };
                            return employee;
                        }
                        else if (tabelName.Equals(tblJobHistory))
                        {
                            var jobHistory = new JobHistory
                            {
                                EmployeeId = reader.GetInt32(0),
                                StartDate = reader.GetDateTime(1),
                                JobId = reader.GetInt32(2),
                                DepartementId = reader.GetInt32(3),
                                EndDate = reader.GetDateTime(4)

                            };
                            return jobHistory;

                        }
                        else if (tabelName.Equals(tblJob))
                        {
                            var job = new Job
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                MinSalary = reader.GetDouble(2),
                                MaxSalary = reader.GetDouble(3),

                            };
                            return job;
                        }
                    }
                    reader.Close();
                    connection.Close();

                    return null;
                }
                reader.Close();
                connection.Close();

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public String Insert(string tabelName, dynamic Data)
        {

            using var connection = Connection.Connect();

            using var command = Connection.SqlCommand();



            command.Connection = connection;

            if (tabelName.Equals(tblEmployees))
            {
                command.CommandText = "INSERT INTO tbl_employees VALUES (@jobId, @managerId," +
                    " @departementId, @firstName, @lastName, @email, @phoneNumber, @hireDate, @salary," +
                    " @commisionPct);";
            }
            else if (tabelName.Equals(tblRegions))
            {
                command.CommandText = "INESRT INTO tbl_regions VALUES (@name)";
            }
            else if (tabelName.Equals(tblCountries))
            {
                command.CommandText = "INSERT INTO tbl_countries VALUES (@regionId, @name)";
            }
            else if (tabelName.Equals(tblLocatons))
            {
                command.CommandText = "INSERT INTO tbl_locations VALUES (@countryId, @streetAddress," +
                    " @postCode, @city, @state_province)";
            }
            else if (tabelName.Equals(tblDepartements))
            {
                command.CommandText = "INSERT INTO tbl_locations VALUES (@departementName, @managerID," +
                    " @locationID)";
            }
            else if (tabelName.Equals(tblJobHistory))
            {
                command.CommandText = "INSERT INTO " + tblJobHistory + " VALUES (@emoloyeeId, " +
                    "@startDate, @jobId, @departementId, @endDate)";
            }else if (tabelName.Equals(tblJob))
            {
                command.CommandText = "INSERT INTO " + tblJob + " VALUES (@id, @title, " +
                    "@minSalary, @maxSalary)";
            }
            else
            {
                return "TABEL TIDAK ADA";
            }



            try
            {
                ;
                if (tabelName.Equals(tblEmployees))
                {
                    command.Parameters.Add(new SqlParameter("@name", Data.Name));
                    command.Parameters.Add(new SqlParameter("@jobId", Data.JobId));
                    command.Parameters.Add(new SqlParameter("@managerId", Data.ManagerId));
                    command.Parameters.Add(new SqlParameter("@departementId", Data.DepartementId));
                    command.Parameters.Add(new SqlParameter("@firstName", Data.FirstName));
                    command.Parameters.Add(new SqlParameter("@lastName", Data.LastName));
                    command.Parameters.Add(new SqlParameter("@email", Data.Email));
                    command.Parameters.Add(new SqlParameter("@phoneNumber", Data.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@hireDate", Data.HireDate));
                    command.Parameters.Add(new SqlParameter("@salary", Data.Salary));
                    command.Parameters.Add(new SqlParameter("@commisionPct", Data.CommisionPct));

                }
                else if (tabelName.Equals(tblCountries))
                {
                    command.Parameters.Add(new SqlParameter("@name", Data.Name));
                    command.Parameters.Add(new SqlParameter("@regionId", Data.RegionId));
                }else if (tabelName.Equals(tblRegions))
                {
                    command.Parameters.Add(new SqlParameter("@name", Data.Name));
                }else if (tabelName.Equals(tblLocations))
                {
                    command.Parameters.Add(new SqlParameter("@countryId", Data.CountryId));
                    //sisanya belom ya kk
                }






                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        public List<dynamic> TableSelector(dynamic reader, String tabelName)
        {
            if (tabelName.Equals(tblRegions))
            {
                listData.Add(new Region
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
                return listData;
            }
            else if (tabelName.Equals(tblLocations))
            {
                listData.Add(new Location
                {
                    Id = reader.GetInt32(0),
                    CountryId = reader.GetInt32(1),
                    StreetAddress = reader.GetString(2),
                    PostCode = reader.GetString(3),
                    City = reader.GetString(4),
                    StateProvince = reader.GetString(5),

                });
                return listData;
            }
            else if (tabelName.Equals(tblCountries))
            {
                listData.Add(new Country
                {
                    Id = reader.GetInt32(0),
                    RegionId = reader.GetInt32(1),
                    Name = reader.GetString(2)
                });
                return listData;
            }
            else if (tabelName.Equals(tblDepartements))
            {
                listData.Add(new Departement
                {
                    Id = reader.GetInt32(0),
                    ManagerId = reader.GetInt32(1),
                    LocationId = reader.GetInt32(2),
                    Name = reader.GetString(3)
                });
                return listData;

            }
            else if (tabelName.Equals(tblEmployees))
            {

                listData.Add(new Employee
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
                return listData;
            }
            else if (tabelName.Equals(tblJobHistory))
            {
                listData.Add(new JobHistory
                {
                    EmployeeId = reader.GetInt32(0),
                    StartDate = reader.GetDateTime(1),
                    JobId = reader.GetInt32(2),
                    DepartementId = reader.GetInt32(3),
                    EndDate = reader.GetDateTime(4)

                });
                return listData;

            }
            else if (tabelName.Equals(tblJob))
            {
                listData.Add(new Job
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    MinSalary = reader.GetDouble(2),
                    MaxSalary = reader.GetDouble(3),

                });
                return listData;
            }
            return listData;
        }
    }
}
