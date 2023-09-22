using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConnectionDB.Controller;

namespace ConnectionDB.Model
{
    internal class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }


        public override string ToString()
        {
            return $"{Id} - {Title} - {MinSalary} - {MaxSalary}";
        }

        //public List<dynamic> GetAll()
        //{
        //    string tabelName = "tbl_jobs";
        //    if (ErrorHandler.EHandlerGetAll(tabelName) == true)
        //    {
        //        var job = new TabelQuery();

        //        List<dynamic> getAllJob = job.getAll(tabelName);
        //        return getAllJob;
        //    };

        //    return new List<dynamic>();
        //}

    }
}
