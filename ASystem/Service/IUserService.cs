using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASystem.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }

}
