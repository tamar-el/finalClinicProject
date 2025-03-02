using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Servises
{
    public interface IroutesSrevise
    {
        public Task<List<ClassRoute>> GetClassRoutesAsync();
        public Task<ClassRoute> GetAsync(int id);
        public Task<ClassRoute> AddRoutesAsync(ClassRoute route);
       public Task SaveChangesAsync();
        public Task PutAsync(int id, ClassRoute value);
        public  Task<bool> DeleteIdAsync(int id);
    }
}
