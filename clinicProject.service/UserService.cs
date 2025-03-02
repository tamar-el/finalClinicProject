using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinicProject.core.Entities;
using clinicProject.core.Servises;
using clinicProject.core.Repositories;

namespace clinicProject.service
{
    public class UserService: IUserService
    {
        private readonly IUser _userRepository;
        public UserService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByUserNameAsync(string userName, string Password)
        {
            return await _userRepository.GetByUserNameAsync(userName, Password);
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }
    }
}
