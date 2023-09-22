using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionDB.Controller;

namespace ConnectionDB.Model
{
    internal class Country
    {
        private QueryModel query;
        private readonly string tabelName = "tbl_countries";

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {RegionId} - {Name}";
        }

        public List<Country> GetAll()
        {
            query = new QueryModel();
            List<dynamic> country = query.getAll(tabelName);

            List<Country> getAll = country.Select(item => new Country
            {
                Id = item.Id,
                RegionId = item.RegionId,
                Name = item.Name,

            }).ToList();

            return getAll;
        }

        public List<Country> GetById(int id)
        {
            query = new QueryModel();
            List<dynamic> country = query.getById(tabelName, id);

            List<Country> getById = country.Select(item => new Country
            {

                Id = item.Id,
                RegionId = item.RegionId,
                Name = item.Name,

            }).ToList();

            return getById;

        }
        public string Insert(Country data)
        {

            Country country = new Country();
            country.Name = data.Name;
            country.RegionId = data.RegionId;

            query = new QueryModel();
            string result = query.Insert(tabelName, country);
            return result;
        }





        //public void Insert(int regionId, string name)
        //{

        //    var country = new Country();
        //    country.RegionId = regionId;
        //    country.Name = name;

        //    var query = new TabelQuery();
        //    Console.WriteLine(query.Insert("tbl_countries", country));
        //}

    }
}
