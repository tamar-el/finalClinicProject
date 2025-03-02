using clinicProject.core.Entities;

namespace clinicProject.Models
{
    public class RouteModel
    {
        public DateTime Date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int id { get; set; }
        public string Dname { get; set; }
        public int patientId { get; set; }

    }
}
