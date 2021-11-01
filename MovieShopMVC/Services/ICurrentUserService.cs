using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Services
{
    public interface ICurrentUserService
    {
        public int UserId { get; }
        public bool IsAuthenticated { get; }
        public string FullName { get; }
        public string Email { get; }
        public IEnumerable<string> Roles { get; }
        public bool IsAdmin { get; }

        public DateTime DateOfBirth { get; }
    }
}
