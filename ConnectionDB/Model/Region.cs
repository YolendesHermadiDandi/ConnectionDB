

namespace ConnectionDB.Model
{
    internal class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }

        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_regions";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var region = new TabelQuery();

                List<dynamic> getAllRegion = region.getAll(tabelName);
                return getAllRegion;
            };

            return new List<dynamic>();
        }




        //public static string GetById(string id)
        //{

        //    return ErrorHandler.EHandlerGetRegionById(id);
        //}

        //public static string Insert(String name) { }
    }
}
