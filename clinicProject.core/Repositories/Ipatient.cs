using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Repositories
{
    public interface Ipatient
    {
        public Task<List<ClassPatient>> GetAsync();
        public Task<ClassPatient> AddAsync(ClassPatient patient);
        public void Delete(ClassPatient patient);
        public Task<bool> DeleteIdAsync(int id);
        public Task SaveChangesAsync();
    }
}
