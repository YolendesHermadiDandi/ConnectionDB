
using ConnectionDB.Controller;

namespace ConnectionDB.Model
{
    internal class JobHistory
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public int JobId { get; set; }
        public int DepartementId { get; set; }
        public DateTime EndDate { get; set; }


        public override string ToString()
        {
            return $"{EmployeeId} - {StartDate} - {JobId} - {DepartementId} - {EndDate}";
        }

        public List<dynamic> GetAll()
        {
            string tabelName = "tbl_job_history";
            if (ErrorHandler.EHandlerGetAll(tabelName) == true)
            {
                var history = new TabelQuery();

                List<dynamic> getAllHistory = history.getAll(tabelName);
                return getAllHistory;
            };

            return new List<dynamic>();
        }

    }
}
