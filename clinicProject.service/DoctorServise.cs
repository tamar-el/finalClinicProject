using clinicProject.core.Servises;
using clinicProject.core.Repositories;
using clinicProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicProject.service
{
    public class DoctorServise : IdoctorServise
    {
        private Idoctor _doctorRepository;
        public DoctorServise(Idoctor doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<List<ClassDoctor>> GetClassDoctorsAsync()
        {
            return await _doctorRepository.GetAsync();

        }
        public async Task<ClassDoctor> AddDoctorAsync(ClassDoctor doctor)
        {
            return await _doctorRepository.AddAsync(doctor);
        }
        public async Task SaveChangesAsync()
        {
            await _doctorRepository.SaveChangesAsync();
        }

        public async Task<ClassDoctor> GetAsync(int id)
        {
           var doctor= await _doctorRepository.GetAsync();
            var index = doctor.FindIndex(x => x.id == id);
            return doctor[index];

        }
       
        public async Task<bool> DeleteIdAsync(int id)
        {
            var doctors = await _doctorRepository.GetAsync();
            var findD= doctors.FirstOrDefault(x => x.id == id);
            if (findD == null)
            {
                return false;
            }
            else
            {

                //  _doctorRepository.DeleteByClass(findD);
                await _doctorRepository.DeleteIdAsync(id);
                return true;
            }
            
        }
        public async Task PutAsync(int id, ClassDoctor value)
        {
           
            // חיפוש הרופא במערכת
            var doctors = await _doctorRepository.GetAsync();
            var index = doctors.FindIndex(x => x.id == id);
            //if (index == -1)
            //{
            //    return NotFound($"Doctor with ID {id} not found.");
            //}
            // עדכון הרופא במערך
            doctors[index].name = value.name;
            doctors[index].phone = value.phone;
            doctors[index].email = value.email;
            await _doctorRepository.SaveChangesAsync();
            
        }
    }
}
