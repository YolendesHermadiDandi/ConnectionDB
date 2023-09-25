using ConnectionDB.Controller;

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

        


    }
}
