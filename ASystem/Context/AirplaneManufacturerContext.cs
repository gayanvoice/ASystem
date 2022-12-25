using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class AirplaneManufacturerContext : IAirplaneManufacturerContext
    {
        public int Delete(int airplaneManufacturerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM AirplaneManufacturer WHERE AirplaneManufacturerId IN (@AirplaneManufacturerId)";
            object param = new { AirplaneManufacturerId = airplaneManufacturerId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(AirplaneManufacturerContextModel airplaneManufacturerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO AirplaneManufacturer (AirplaneManufacturerId, Name, Country) values (@AirplaneManufacturerId, @Name, @Country)";
            return mySqlSingleton.Insert(query, airplaneManufacturerContextModel);
        }
        public AirplaneManufacturerContextModel Select(int airplaneManufacturerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM AirplaneManufacturer WHERE AirplaneManufacturerId IN (@AirplaneManufacturerId)";
            object param = new { AirplaneManufacturerId = airplaneManufacturerId };
            return mySqlSingleton.Select<AirplaneManufacturerContextModel>(query, param);
        }
        public IEnumerable<AirplaneManufacturerContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM AirplaneManufacturer";
            return mySqlSingleton.SelectAll<AirplaneManufacturerContextModel>(query);
        }
        public int Update(AirplaneManufacturerContextModel airplaneManufacturerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE AirplaneManufacturer SET AirplaneManufacturerId = @AirplaneManufacturerId, Name = @Name, Country = @Country WHERE AirplaneManufacturerId IN (@AirplaneManufacturerId)";
            return mySqlSingleton.Update(query, airplaneManufacturerContextModel);
        }
    }
}