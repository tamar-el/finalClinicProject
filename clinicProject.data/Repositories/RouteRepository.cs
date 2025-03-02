

using clinicProject.core.Entities;
using clinicProject.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.data.Repositories
{
   
    public class RouteRepository:Iroutes
    {
        private DataContext _context;
        public RouteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ClassRoute>> GetAsync()
        {
            return await _context.routes.ToListAsync();
        }
        public async Task<ClassRoute> AddAsync(ClassRoute routes)
        {
            _context.routes.Add(routes);
            await _context.SaveChangesAsync();
            return routes;
        }
        public async Task<int> ReturnIDoctorByDname(string Dname)
        {
            List<ClassDoctor> doctor =await _context.doctors.ToListAsync();
           var find=  doctor.FirstOrDefault(x => x.name.Equals(Dname));
            if (find != null)
            {
                return find.id;
            }
            else return -1;

        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteIdAsync(int id)
        {
           
            var route = await _context.routes.FirstOrDefaultAsync(x => x.id == id);
            if (route != null)
            {
                _context.routes.Remove(route);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
