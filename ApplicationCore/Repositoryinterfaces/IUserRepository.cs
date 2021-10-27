using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositoryinterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string Email);
        Task<User> AddUser(User user);

    }
}
