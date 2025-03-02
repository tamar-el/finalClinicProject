using AutoMapper;
using clinicProject.core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using clinicProject.core.DBOs;
using clinicProject.core.Entities;


namespace clinicProject.core
{
    public class MappingProfile :Profile
    {
        public MappingProfile() { 
           CreateMap<ClassDoctor,DoctorDto>().ReverseMap();
           CreateMap<ClassPatient,PatientDto>().ReverseMap();
           CreateMap<ClassRoute,RouteDto>().ReverseMap();
        }
    }
}
