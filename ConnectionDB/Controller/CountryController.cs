using ConnectionDB.Model;
using ConnectionDB.View.ViewManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.Controller
{
    internal class CountryController
    {
        private Country _country;
        private CountriesView _countryView;

        public CountryController(Country country, CountriesView countryView)
        {
            _country = country;
            _countryView = countryView;
        }

        public void GetAll()
        {
            var results = _country.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _countryView.List("regions", results);
            }
        }

        public void GetById(string id)
        {
            if (!int.TryParse(id, out int getId))
            {
                Console.WriteLine("invalid input");
            }
            else
            {
                var result = _country.GetById(getId);

                if (!result.Any())
                {
                    Console.WriteLine("Region tidak ditemukan");
                }
                else
                {
                    _countryView.List("regions", result);
                }

            }
        }


        public void Insert()
        {
            var isTrue = true;
            Country input = new Country();
            while (isTrue)
            {
                try
                {
                    dynamic country = _countryView.InsertInput();
                    input = new Country
                    {
                        RegionId = country.RegionId,
                        Name = country.Name,
                    };

                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var result = _country.Insert(input);

            _countryView.Transaction(result);

        }

        public void Update()
        {
            string id = _countryView.InsertUpdate();


            if (!int.TryParse(id, out int getId))
            {
                Console.WriteLine("invalid input");
            }
            else
            {
                var result = _country.GetById(getId);

                if (!result.Any())
                {
                    Console.WriteLine("Country tidak ditemukan");
                }
                else
                {
                    Country input = new Country();
                    dynamic country = _countryView.InsertInput();

                    input = new Country
                    {
                        RegionId = country.RegionId,
                        Name = country.Name,
                    };


                    Country data = new Country();
                    foreach (var item in result)
                    {
                        data.Id = item.Id;
                        data.RegionId = input.RegionId;
                        data.Name = input.Name;

                    }

                    _country.Update(data);
                    Console.WriteLine("Data berhasil diupdate");
                }

            }


        }

        public void Delete()
        {
            string result = "";
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _countryView.InsertDelete();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Region id cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                int id = Convert.ToInt32(input);
                result = _country.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            _countryView.Transaction(result);
        }
    }
}

