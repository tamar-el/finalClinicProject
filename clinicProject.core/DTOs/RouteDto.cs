using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.DTOs
{
    public class RouteDto
    {
        public DateTime Date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int id { get; set; }
        public string Dname { get; set; }
      
    }
}
