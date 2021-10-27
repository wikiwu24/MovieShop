using ApplicationCore.Entities;
using ApplicationCore.Repositoryinterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public MovieShopDbContext _dbContext;

        public UserRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            // we need to commit the changes to the database
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
