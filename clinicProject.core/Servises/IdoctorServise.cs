using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.core.Servises
{
    public interface IdoctorServise
    {
        public Task<List<ClassDoctor>> GetClassDoctorsAsync();
        public Task<ClassDoctor> AddDoctorAsync(ClassDoctor doctor);
        public Task<ClassDoctor> GetAsync(int id);
        public Task SaveChangesAsync();
       

        public Task PutAsync(int id, ClassDoctor value);
        public  Task<bool> DeleteIdAsync(int id);
    }
}
