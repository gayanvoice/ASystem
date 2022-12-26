using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class ClassContext
    {
        public int Delete(int classId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Class WHERE ClassId IN (@ClassId)";
            object param = new { ClassId = classId };
            return mySqlSingleton.Delete(query, param);
        }
        //public int Insert(ClassContextModel classContextModel)
        //{
        //    MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
        //    string query = "INSERT INTO Class (AirplaneModelId, Name, SubClass) values (@AirplaneModelId, @FlightNumber, @Status)";
        //    return mySqlSingleton.Insert(query, classContextModel);
        //}
        //public AirplaneContextModel Select(int airplaneId)
        //{
        //    MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
        //    string query = "SELECT * FROM Airplane WHERE AirplaneId IN (@AirplaneId)";
        //    object param = new { AirplaneId = airplaneId };
        //    return mySqlSingleton.Select<AirplaneContextModel>(query, param);
        //}
        //public IEnumerable<AirplaneContextModel> SelectAll()
        //{
        //    MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
        //    string query = "SELECT * FROM Airplane";
        //    return mySqlSingleton.SelectAll<AirplaneContextModel>(query);
        //}
        //public int Update(AirplaneContextModel airplaneContextModel)
        //{
        //    MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
        //    string query = "UPDATE Airplane SET AirplaneId = @AirplaneId, AirplaneModelId = @AirplaneModelId, FlightNumber =  @FlightNumber, Status = @Status WHERE AirplaneId IN (@AirplaneId)";
        //    return mySqlSingleton.Update(query, airplaneContextModel);
        //}
    }
}