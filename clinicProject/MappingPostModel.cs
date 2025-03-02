using AutoMapper;
using clinicProject.core.Entities;
using clinicProject.Models;

namespace clinicProject
{
    public class MappingPostModel:Profile
    {
        public MappingPostModel()
        {
            CreateMap<DoctorModel, ClassDoctor>().ReverseMap();
            CreateMap<PatientModel, ClassPatient>().ReverseMap();
            CreateMap<RouteModel, ClassRoute>().ReverseMap();
        }
    }
}
