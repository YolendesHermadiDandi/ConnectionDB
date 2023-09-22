using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.Model
{
    internal class Country
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {RegionId} - {Name}";
        }


        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_countries";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var country = new TabelQuery();

                List<dynamic> getAllCountries = country.getAll(tabelName);
                return getAllCountries;
            };

            return new List<dynamic>();
        }



        public void Insert(int regionId, string name)
        {

            var country = new Country();
            country.RegionId = regionId;
            country.Name = name;

            var query = new TabelQuery();
            Console.WriteLine(query.Insert("tbl_countries", country));
        }

    }
}
