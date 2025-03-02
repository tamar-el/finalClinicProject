using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.DTOs
{
    public class DoctorDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public int businesshours { get; set; }
        public List<ClassRoute> Routes { get; set; }
    }
}
