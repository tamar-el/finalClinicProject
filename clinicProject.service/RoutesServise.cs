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
    public class RoutesServise: IroutesSrevise
    {
        private Iroutes _routesRepository;
        public RoutesServise(Iroutes routesRepository)
        {
            _routesRepository = routesRepository;
        }
        public async Task<List<ClassRoute>> GetClassRoutesAsync()
        {
            return await _routesRepository.GetAsync();

        }
        public async Task<ClassRoute> GetAsync(int id)
        {
            var route = await _routesRepository.GetAsync();
            var index = route.FindIndex(x => x.id == id);
            return route[index];

        }

        public async Task<ClassRoute> AddRoutesAsync(ClassRoute route)
        {
            var IsDoctor = _routesRepository.ReturnIDoctorByDname(route.Dname);

            if (IsDoctor.Result == -1)
            {
                Console.WriteLine("Dname Isnot exist!");
                return null;
            }
            route.doctorId = IsDoctor.Result;
            return await _routesRepository.AddAsync(route);
        }

        public async Task SaveChangesAsync()
        {
            await _routesRepository.SaveChangesAsync();
        }
        public async Task PutAsync(int id, ClassRoute value)
        {
            if (id <= 0)
            {

            }
        
            var routes = await _routesRepository.GetAsync();
            var index = routes.FindIndex(x => x.id == id);
            //if (index == -1)
            //{
            //    return NotFound($"Doctor with ID {id} not found.");
            //}
         
            routes[index].Date = value.Date;
            routes[index].startTime = value.startTime;
            routes[index].endTime = value.endTime;
            //routes[index].id = routes[index].id;
            routes[index].Dname = value.Dname;
            await _routesRepository.SaveChangesAsync();

        }
        public async Task<bool> DeleteIdAsync(int id)
        {
            var routes = await _routesRepository.GetAsync();
            var findR = routes.FirstOrDefault(x => x.id == id);
            if (findR == null)
            {
                return false;
            }
            else
            {

                //  _doctorRepository.DeleteByClass(findD);
                await _routesRepository.DeleteIdAsync(id);
                return true;
            }

        }
    }
}
