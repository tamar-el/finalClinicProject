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
    public class PatientServise: IpatientSrevise
    {
        private Ipatient _patientRepository;
        public PatientServise(Ipatient patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<ClassPatient>> GetClassdPatientAsync()
        {
            return await _patientRepository.GetAsync();

        }
        public async Task<ClassPatient> GetAsync(int id)
        {
            var patient = await _patientRepository.GetAsync();
            var index = patient.FindIndex(x => x.id == id);
            return patient[index];

        }
        public async Task<ClassPatient> AddPatientAsync(ClassPatient patient)
        {
            return await _patientRepository.AddAsync(patient);
        }
        public async Task SaveChangesAsync()
        {
            await _patientRepository.SaveChangesAsync();
        }
        public async Task PutAsync(int id, ClassPatient value)
        {
           
            // חיפוש הלקוח במערכת
            var patients = await _patientRepository.GetAsync();
            var index = patients.FindIndex(x => x.id == id);
            //if (index == -1)
            //{
            //    return NotFound($"Doctor with ID {id} not found.");
            //}
            // עדכון  במערך
            patients[index].name = value.name;
            patients[index].phone = value.phone;
            patients[index].email = value.email;
            patients[index].id = patients[index].id;
            patients[index].age = value.age;
            patients[index].address = value.address;
            await _patientRepository.SaveChangesAsync();

        }
        public async Task<bool> DeleteIdAsync(int id)
        {
            var patients = await _patientRepository.GetAsync();
            var findP = patients.FirstOrDefault(x => x.id == id);
            if (findP == null)
            {
                return false;
            }
            else
            {

                //  _doctorRepository.DeleteByClass(findD);
                await _patientRepository.DeleteIdAsync(id);
                return true;
            }

        }

    }
}
