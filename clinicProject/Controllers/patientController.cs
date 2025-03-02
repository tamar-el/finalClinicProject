using clinicProject.core.Servises;
using clinicProject.core.Entities;
using Microsoft.AspNetCore.Mvc;
using clinicProject.service;
using AutoMapper;
using clinicProject.core.DTOs;
using clinicProject.core.DBOs;
using clinicProject.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="customer")]
    public class patientController : ControllerBase
    {
       private readonly IpatientSrevise _PatientServise;
        private readonly IMapper _Mapper;
        private readonly IUserService _UserService;
        public patientController(IpatientSrevise PatientServise,IMapper mapper, IUserService userService)
        {
            _PatientServise = PatientServise;
            _Mapper = mapper;
            _UserService = userService;
        }

        // GET: api/<patientController>
        [HttpGet]
       
        public async Task<ActionResult> Get()
        {
            var list =await  _PatientServise.GetClassdPatientAsync();
            var Ptolist = new List<PatientDto>();
            Ptolist = _Mapper.Map<List<PatientDto>>(list);

            return Ok(Ptolist);
        }

        // GET api/<patientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var list = await _PatientServise.GetAsync(id);
            var Dtolist = new PatientDto();
            Dtolist = _Mapper.Map<PatientDto>(list);
            return Ok(Dtolist);
        }
        // POST api/<patientController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PatientModel value)
        {


            var user = new User { UserName = value.UserName, Password = value.Password, Role = eRole.customer };
            var user2 = await _UserService.AddUserAsync(user);
            var newPatient = _Mapper.Map<ClassPatient>(value);
            newPatient.User = user2;
            newPatient.UserId = user2.Id;
            var patient = await _PatientServise.GetAsync(newPatient.id);
            if (patient != null)
            {
                return Conflict();
            }
            await _PatientServise.AddPatientAsync(newPatient);
            return Ok();
        }

        // PUT api/<patientController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PatientModel value)
        {
           
            await _PatientServise.PutAsync(id, _Mapper.Map<ClassPatient>(value));

        }
        // DELETE api/<patientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
             
            bool isDeleted = await _PatientServise.DeleteIdAsync(id);
            if (isDeleted)
            {
                return Ok($"Patient with ID {id} deleted successfully.");
            }
            else
            {
                return NotFound($"Patient with ID {id} does not exist.");
            }
        }
    }
}
