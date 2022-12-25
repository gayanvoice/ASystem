using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class AirportContext : IAirportContext
    {
        public int Delete(int airportId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Airport WHERE AirportId IN (@AirportId)";
            object param = new { AirportId = airportId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(AirportContextModel airportContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO Airport (AirportId, Code, Name, City, Country) values (@AirportId, @Code, @Name, @City, @Country)";
            return mySqlSingleton.Insert(query, airportContextModel);
        }
        public AirportContextModel Select(int airportId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Airport WHERE AirportId IN (@AirportId)";
            object param = new { AirportId = airportId };
            return mySqlSingleton.Select<AirportContextModel>(query, param);
        }
        public IEnumerable<AirportContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Airport";
            return mySqlSingleton.SelectAll<AirportContextModel>(query);
        }
        public int Update(AirportContextModel airportContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE Airport SET AirportId = @AirportId, Code = @Code, Name = @Name, City = @City, Country = @Country WHERE AirportId IN (@AirportId)";
            return mySqlSingleton.Update(query, airportContextModel);
        }
    }
}