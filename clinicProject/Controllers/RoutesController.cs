using clinicProject.core.Servises;
using clinicProject.core.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using clinicProject.core.DBOs;
using clinicProject.service;
using clinicProject.core.DTOs;
using clinicProject.Models;
using clinicProject.data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
       private readonly IroutesSrevise _RoutesServise;
        private readonly IMapper _Mapper;
        public RoutesController(IroutesSrevise routesServise,IMapper mapper)
        {
            _RoutesServise = routesServise;
            _Mapper = mapper;
        }
        // GET: api/<RoutesController>
        [HttpGet]
       
        public async Task<ActionResult> Get()
        {
            var list =await  _RoutesServise.GetClassRoutesAsync();
            var Rtolist = new List<RouteDto>();
            Rtolist = _Mapper.Map<List<RouteDto>>(list);

            return Ok(Rtolist);
        }

        // GET api/<RoutesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var list = await _RoutesServise.GetAsync(id);
            var Dtolist = new RouteDto();
            Dtolist = _Mapper.Map<RouteDto>(list);
            return Ok(Dtolist);
        }

        // POST api/<RoutesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RouteModel value)
        {
            return Ok(await _RoutesServise.AddRoutesAsync(_Mapper.Map<ClassRoute>(value)));
        }



        // PUT api/<RoutesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] RouteModel value)
        {
           
            await _RoutesServise.PutAsync(id, _Mapper.Map<ClassRoute>(value));

        }


        // DELETE api/<RoutesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
             
            bool isDeleted = await _RoutesServise.DeleteIdAsync(id);
            if (isDeleted)
            {
                return Ok($"Route with ID {id} deleted successfully.");
            }
            else
            {
                return NotFound($"Route with ID {id} does not exist.");
            }
        }
    }
}
