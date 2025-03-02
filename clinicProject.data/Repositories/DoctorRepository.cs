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
    public class DoctorRepository : Idoctor
    {
        private DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ClassDoctor>> GetAsync()
        {
            return await _context.doctors.Include(o=>o.Routes).ToListAsync();
        }
        public async Task<ClassDoctor> AddAsync(ClassDoctor doctor)
        {
            _context.doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async  Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async void DeleteByClass(ClassDoctor doctor)
        {
            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();

        }
       
        public async Task<bool> DeleteIdAsync(int id)
        {
           // var index= _context.doctors.FirstAsync(x => x.id == id);
            var doctors =await _context.doctors.FirstOrDefaultAsync(x => x.id == id);
            if (doctors != null)
            {
                _context.doctors.Remove(doctors);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        

    }
}
