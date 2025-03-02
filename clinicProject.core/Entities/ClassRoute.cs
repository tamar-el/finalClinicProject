using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Entities
{
    public class ClassRoute
    {
        public DateTime Date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int id { get; set; }
        public string Dname { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public ClassDoctor doctor { get; set; }
        public ClassPatient patient { get; set; }
    }
}
