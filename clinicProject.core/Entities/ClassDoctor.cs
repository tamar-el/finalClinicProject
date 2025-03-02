using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Entities
{
    public class ClassDoctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public int businesshours { get; set; }
        public int UserId { get; set; } // הוסף
        public User User { get; set; } // הוסף
        public List<ClassPatient> patients { get; set; }
        public List <ClassRoute> Routes { get; set; }

    }
}
