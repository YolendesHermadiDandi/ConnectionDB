using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    internal class ErrorHandler
    {

        public static Boolean EHandlerGetAll(string tabelName)
        {
            var tabelQuery = new TabelQuery();
            var getAllData = tabelQuery.getAll(tabelName);

            if (getAllData.Count > 0)
            {
                return true;

            }
            return false;


        }



        //public static String EHandlerGetRegionById(string id)
        //{


        //    if (int.TryParse(id, out int getId) == true)
        //    {
        //        var region = new TabelQuery();
        //        var getRegionbyId = region.getById("tbl_regions", getId);
        //        if (getRegionbyId != null)
        //        {
        //            return $"Id: {getRegionbyId.Id}, Name: {getRegionbyId.Name}";
        //        }
        //        return "DATA DENGAN ID :" + id + " TIDAK DITEMUKAN";


        //    }
        //    return "INPUTAN TIDAK VALID";
        //}


    }
}
