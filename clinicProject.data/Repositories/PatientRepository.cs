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
    public class PatientRepository:Ipatient
    {
        private DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ClassPatient>> GetAsync()
        {
            return await _context.patients.Include(o=>o.doctors).ToListAsync();
        }
        public async Task<ClassPatient> AddAsync(ClassPatient patient)
        {
            _context.patients.Add(patient);
           await _context.SaveChangesAsync();
            return patient;
        }
        public void Delete(ClassPatient patient)
        {
            _context.patients.Remove(patient);

        }
        public async Task<bool> DeleteIdAsync(int id)
        {
            // var index= _context.doctors.FirstAsync(x => x.id == id);
            var patient = await _context.patients.FirstOrDefaultAsync(x => x.id == id);
            if (patient != null)
            {
                _context.patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
