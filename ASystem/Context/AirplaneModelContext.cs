using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class AirplaneModelContext : IAirplaneModelContext
    {
        public int Delete(int airplaneModelId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM AirplaneModel WHERE AirplaneModelId IN (@AirplaneModelId)";
            object param = new { AirplaneModelId = airplaneModelId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(AirplaneModelContextModel airplaneModelContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO AirplaneModel (AirplaneManufacturerId, Name, SubModel) values (@AirplaneManufacturerId, @Name, @SubModel)";
            return mySqlSingleton.Insert(query, airplaneModelContextModel);
        }

        public AirplaneModelContextModel Select(int airplaneModelId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM AirplaneModel WHERE AirplaneModelId IN (@AirplaneModelId)";
            object param = new { AirplaneModelId = airplaneModelId };
            return mySqlSingleton.Select<AirplaneModelContextModel>(query, param);
        }
        public IEnumerable<AirplaneModelContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM AirplaneModel";
            return mySqlSingleton.SelectAll<AirplaneModelContextModel>(query);
        }
        public int Update(AirplaneModelContextModel airplaneModelContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE AirplaneModel SET AirplaneManufacturerId = @AirplaneManufacturerId, Name = @Name, SubModel =  @SubModel WHERE AirplaneModelId IN (@AirplaneModelId)";
            return mySqlSingleton.Update(query, airplaneModelContextModel);
        }
    }
}