using ConnectionDB.Model;
using ConnectionDB.View.ViewManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.Controller
{
    internal class RegionController
    {
        private Region _region;
        private RegionView _regionView;

        public RegionController(Region region, RegionView regionView)
        {
            _region = region;
            _regionView = regionView;
        }

        public void GetAll()
        {
            var results = _region.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _regionView.List("regions", results);
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
                var result = _region.GetById(getId);

                if (!result.Any())
                {
                    Console.WriteLine("Region tidak ditemukan");
                }
                else
                {
                    _regionView.List("regions", result);
                }

            }
        }

        public void Insert()
        {
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _regionView.InsertInput();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Region name cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var result = _region.Insert(input);

            _regionView.Transaction(result);
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
                    input = _regionView.InsertDelete();

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
                result = _region.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            _regionView.Transaction(result);
        }

        public void Update()
        {
            string id = _regionView.InsertUpdate();


            if (!int.TryParse(id, out int getId))
            {
                Console.WriteLine("invalid input");
            }
            else
            {
                var result = _region.GetById(getId);

                if (!result.Any())
                {
                    Console.WriteLine("Region tidak ditemukan");
                }
                else
                {
                    string name = _regionView.InsertInput();

                    Region data = new Region();
                    foreach (var item in result)
                    {
                        data.Id = item.Id;
                        data.Name = name;
                    }
                    _region.Update(data);
                    Console.WriteLine("Data berhasil diupdate");
                }

            }


        }
    }
}
