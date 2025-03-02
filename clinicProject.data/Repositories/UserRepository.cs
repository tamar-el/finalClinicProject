using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinicProject.core.Entities;
using clinicProject.core.Repositories;
using Microsoft.EntityFrameworkCore;
namespace clinicProject.data.Repositories
{
    public class UserRepository:IUser

    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetByUserNameAsync(string userName, string Password)
        {
            return await _dataContext.User.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == Password);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dataContext.User.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

    }
}
