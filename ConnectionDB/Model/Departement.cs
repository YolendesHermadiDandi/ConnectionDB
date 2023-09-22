using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionDB.Controller;

namespace ConnectionDB.Model
{
    internal class Departement
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {ManagerId} - {LocationId} - {Name}";
        }

        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_departements";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var departement = new TabelQuery();

                List<dynamic> getAllDepartement = departement.getAll(tabelName);
                return getAllDepartement;
            };

            return new List<dynamic>();
        }
    }
}
