using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Entities
{
    public class ClassPatient
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ClassRoute> Routes { get; set; }
        public List<ClassDoctor> doctors { get; set; }
    }
}
