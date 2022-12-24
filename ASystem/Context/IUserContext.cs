using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IUserContext
    {
        int Delete(int userId);
        int Insert(UserContextModel userContextModel);
        UserContextModel Select(int userId);
        UserContextModel Select(string username);
        IEnumerable<UserContextModel> SelectAll();
        int Update(UserContextModel userContextModel);

    }
}