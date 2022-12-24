using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class UserContext : IUserContext
    {
        public int Delete(int userId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM User WHERE UserId IN (@UserId)";
            object param = new { UserId = userId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO User (Username, Password, Status) values (@Username, @Password, @Status)";
            return mySqlSingleton.Insert(query, userContextModel);
        }
        public UserContextModel Select(int userId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM User WHERE UserId IN (@UserId)";
            object param = new { UserId = userId};
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }
        public UserContextModel Select(string username)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM User WHERE Username IN (@Username)";
            object param = new { Username = username };
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }
        public IEnumerable<UserContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM User";
            return mySqlSingleton.SelectAll<UserContextModel>(query);
        }
        public int Update(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE User SET Username = @Username, Password = @Password, Status = @Status WHERE UserId IN (@UserId)";
            return mySqlSingleton.Update(query, userContextModel);
        }
    }
}