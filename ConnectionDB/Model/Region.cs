

using System.Xml.Linq;

namespace ConnectionDB.Model
{
    internal class Region
    {

        private QueryModel query;

        private readonly string tabelName = "tbl_regions";
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }

        public List<Region> GetAll()
        {
            query = new QueryModel();
            List<dynamic> regions = query.getAll(tabelName);

            List<Region> getAll = regions.Select(item => new Region
            {
                Id = item.Id,
                Name = item.Name,

            }).ToList();

            return getAll;
        }

        public List<Region> GetById(int id)
        {
            query = new QueryModel();
            List<dynamic> region = query.getById(tabelName, id);

            List<Region> getById = region.Select(item => new Region
            {
                Id = item.Id,
                Name = item.Name,

            }).ToList();

            return getById;

        }


        public string Insert(string name)
        {

            Region region = new Region();
            region.Name = name;
            query = new QueryModel();
            string result = query.Insert(tabelName, region);
            return result;
        }

        public string Delete(int id)
        {


            Region region = new Region();
            region.Id = id;
            query = new QueryModel();
            string result = query.Delete(tabelName, region);

            return result;
        }

        public string Update(Region data)
        {
            query = new QueryModel();
            string result = query.Update(tabelName, data);
            return result;
        }
    }
}
