namespace ConnectionDB.Model
{
    internal class Location
    {

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StreetAddress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }

        public override string ToString()
        {
            return $"{Id} - {CountryId} - {StreetAddress} - {PostCode} - {City} - {StateProvince}";
        }

        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_locations";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var location = new TabelQuery();

                List<dynamic> getAllLocation = location.getAll(tabelName);
                return getAllLocation;
            };

            return new List<dynamic>();
        }


    }
}
