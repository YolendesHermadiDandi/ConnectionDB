


using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace ConnectionDB.Model
{
    internal class QueryModel
    {
        const string tblEmployees = "tbl_employees";
        const string tblRegions = "tbl_regions";
        const string tblLocations = "tbl_locations";
        const string tblCountries = "tbl_countries";
        const string tblLocatons = "tbl_locations";
        const string tblDepartements = "tbl_departements";
        const string tblJob = "tbl_jobs";
        const string tblJobHistory = "tbl_job_history";

        public List<object> getAll(string tableName)
        {

            var listData = new List<object>();

            //ambil koneksi dan createcommand
            using var connection = Connection.Connect();
            using var command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = $"SELECT * FROM {tableName}";

            try
            {
                connection.Open();
                using var reader = command.ExecuteReader();

                //cek data
                if (!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return listData;
                }
                while (reader.Read())
                {

                    TableSelector(reader, tableName, listData);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    rowData.Add(reader[i]);

                    //}
                    //listData.Add(rowData);
                }

                reader.Close();
                connection.Close();
                return listData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new List<object>();
        }

        public List<object> getById(string tableName, int id)
        {

            var listData = new List<object>();

            //ambil koneksi dan createcommand
            using var connection = Connection.Connect();
            using var command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = $"SELECT * FROM {tableName} WHERE id = {id}";

            try
            {
                connection.Open();
                using var reader = command.ExecuteReader();

                //cek data
                if (!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return listData;
                }
                while (reader.Read())
                {

                    TableSelector(reader, tableName, listData);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    rowData.Add(reader[i]);

                    //}
                    //listData.Add(rowData);
                }

                reader.Close();
                connection.Close();
                return listData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new List<object>();
        }

        public String Insert(string tabelName, dynamic Data)
        {

            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();


            command.Connection = connection;

            if (InsertQuerySelector(tabelName).Equals("TABEL TIDAK ADA"))
            {
                return "TABEL TIDAK DITEMUKAN";
            }

            command.CommandText = InsertQuerySelector(tabelName);




            try
            {

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
                }
                else if (tabelName.Equals(tblRegions))
                {
                    command.Parameters.Add(new SqlParameter("@name", Data.Name));
                }
                else if (tabelName.Equals(tblLocations))
                {
                    command.Parameters.Add(new SqlParameter("@countryId", Data.CountryId));
                    command.Parameters.Add(new SqlParameter("@streetAddress", Data.StreetAddress));
                    command.Parameters.Add(new SqlParameter("@streetAddress", Data.StreetAddress));


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

        public String Delete(string tableName, dynamic Data)
        {
            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();

            command.Connection = connection;



            command.CommandText = $"DELETE FROM {tableName} WHERE id = @id"; ;




            try
            {

                command.Parameters.Add(new SqlParameter("@id", Data.Id));

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

        public string Update(string tabelName, dynamic Data)
        {


            using var connection = Connection.Connect();
            using var command = Connection.SqlCommand();


            command.Connection = connection;

            if (InsertQuerySelector(tabelName).Equals("TABEL TIDAK ADA"))
            {
                return "TABEL TIDAK DITEMUKAN";
            }

            command.CommandText = UpdateQuerySelector(tabelName, Data.Id);




            try
            {

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
                }
                else if (tabelName.Equals(tblRegions))
                {
                    command.Parameters.Add(new SqlParameter("@name", Data.Name));
                }
                else if (tabelName.Equals(tblLocations))
                {
                    command.Parameters.Add(new SqlParameter("@countryId", Data.CountryId));
                    command.Parameters.Add(new SqlParameter("@streetAddress", Data.StreetAddress));
                    command.Parameters.Add(new SqlParameter("@streetAddress", Data.StreetAddress));


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

        private object TableSelector(dynamic reader, String tabelName, dynamic listData)
        {


            switch (tabelName)
            {

                case tblRegions:

                    listData.Add(new Region
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                    break;
                case tblCountries:
                    listData.Add(new Country
                    {
                        Id = reader.GetInt32(0),
                        RegionId = reader.GetInt32(1),
                        Name = reader.GetString(2)
                    });
                    break;
                case tblLocations:
                    listData.Add(new Location
                    {
                        Id = reader.GetInt32(0),
                        CountryId = reader.GetInt32(1),
                        StreetAddress = reader.GetString(2),
                        PostCode = reader.GetString(3),
                        City = reader.GetString(4),
                        StateProvince = reader.GetString(5),

                    });
                    break;
                case tblDepartements:
                    listData.Add(new Departement
                    {
                        Id = reader.GetInt32(0),
                        ManagerId = reader.GetInt32(1),
                        LocationId = reader.GetInt32(2),
                        Name = reader.GetString(3)
                    });
                    break;
                case tblEmployees:

                    listData.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        JobId = reader.GetInt32(1),
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
                    break;
                case tblJobHistory:
                    listData.Add(new JobHistory
                    {
                        EmployeeId = reader.GetInt32(0),
                        StartDate = reader.GetDateTime(1),
                        JobId = reader.GetInt32(2),
                        DepartementId = reader.GetInt32(3),
                        EndDate = reader.GetDateTime(4)

                    });
                    break;
                case tblJob:
                    listData.Add(new Job
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        MinSalary = reader.GetDouble(2),
                        MaxSalary = reader.GetDouble(3),

                    });

                    break;

                default:
                    break;
            }
            return listData;

        }


        private string InsertQuerySelector(string tabelName)
        {


            if (tabelName.Equals(tblEmployees))
            {
                return "INSERT INTO "+tblEmployees+" VALUES (@jobId, @managerId," +
                     " @departementId, @firstName, @lastName, @email, @phoneNumber, @hireDate, @salary," +
                     " @commisionPct);";
            }
            else if (tabelName.Equals(tblRegions))
            {
                return "INSERT INTO " + tblRegions + " VALUES (@name)";
            }
            else if (tabelName.Equals(tblCountries))
            {
                return "INSERT INTO "+tblCountries+" VALUES (@regionId, @name)";
            }
            else if (tabelName.Equals(tblLocatons))
            {
                return "INSERT INTO tbl_locations VALUES (@countryId, @streetAddress," +
                    " @postCode, @city, @state_province)";
            }
            else if (tabelName.Equals(tblDepartements))
            {
                return "INSERT INTO tbl_locations VALUES (@departementName, @managerID," +
                    " @locationID)";
            }
            else if (tabelName.Equals(tblJobHistory))
            {
                return "INSERT INTO " + tblJobHistory + " VALUES (@emoloyeeId, " +
                    "@startDate, @jobId, @departementId, @endDate)";
            }
            else if (tabelName.Equals(tblJob))
            {
                return "INSERT INTO " + tblJob + " VALUES (@id, @title, " +
                    "@minSalary, @maxSalary)";
            }

            return "TABEL TIDAK ADA";


        }

        private string UpdateQuerySelector(string tabelName, int id)
        {


            if (tabelName.Equals(tblEmployees))
            {


                return "INSERT INTO tbl_employees VALUES (@jobId, @managerId," +
                     " @departementId, @firstName, @lastName, @email, @phoneNumber, @hireDate, @salary," +
                     " @commisionPct);";
            }
            else if (tabelName.Equals(tblRegions))
            {

                return $"UPDATE tbl_regions SET name = @name where id={id}";
            }
            else if (tabelName.Equals(tblCountries))
            {
                return "INSERT INTO tbl_countries VALUES (@regionId, @name)";
            }
            else if (tabelName.Equals(tblLocatons))
            {
                return "INSERT INTO tbl_locations VALUES (@countryId, @streetAddress," +
                    " @postCode, @city, @state_province)";
            }
            else if (tabelName.Equals(tblDepartements))
            {
                return "INSERT INTO tbl_locations VALUES (@departementName, @managerID," +
                    " @locationID)";
            }
            else if (tabelName.Equals(tblJobHistory))
            {
                return "INSERT INTO " + tblJobHistory + " VALUES (@emoloyeeId, " +
                    "@startDate, @jobId, @departementId, @endDate)";
            }
            else if (tabelName.Equals(tblJob))
            {
                return "INSERT INTO " + tblJob + " VALUES (@id, @title, " +
                    "@minSalary, @maxSalary)";
            }

            return "TABEL TIDAK ADA";

        }
    }
}

/*
 
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
            }
            else if (tabelName.Equals(tblJob))
            {
                command.CommandText = "INSERT INTO " + tblJob + " VALUES (@id, @title, " +
                    "@minSalary, @maxSalary)";
            }
            else
            {
                return "TABEL TIDAK ADA";
            }

*/

