using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SASystem.Context
{
    public class AirplaneContext : IAirplaneContext
    {
        private const string table_name = "Airplane";
        public int Delete(int airplaneId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Airplane WHERE AirplaneId IN (@AirplaneId)";
            object param = new { AirplaneId = airplaneId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(AirplaneContextModel airplaneContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(airplaneContextModel);
            return mySqlSingleton.Insert(query, airplaneContextModel);
        }
        public AirplaneContextModel Select(int airplaneId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Airplane WHERE AirplaneId IN (@AirplaneId)";
            object param = new { AirplaneId = airplaneId };
            return mySqlSingleton.Select<AirplaneContextModel>(query, param);
        }
        public IEnumerable<AirplaneContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<AirplaneContextModel>(query);
        }
        public int Update(AirplaneContextModel airplaneContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(airplaneContextModel);
            string queryx = "UPDATE Airplane SET AirplaneId = @AirplaneId, AirplaneModelId = @AirplaneModelId, FlightNumber =  @FlightNumber, Status = @Status WHERE AirplaneId IN (@AirplaneId)";
            return mySqlSingleton.Update(query, airplaneContextModel);
        }
        private string GetInsertQuery<Type>(Type type)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO ").Append(table_name).Append(" VALUES ").Append("(");
            PropertyInfo lastPropertyInfo = type.GetType().GetProperties().Last();
            foreach (PropertyInfo propertyInfo in type.GetType().GetProperties())
            {
                stringBuilder.Append(string.Concat("@", propertyInfo.Name));
                if (propertyInfo.Equals(lastPropertyInfo))    stringBuilder.Append(" ");
                else stringBuilder.Append(", ");
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }
        private string GetUpdateQuery<Type>(Type type)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Concat("UPDATE ", table_name, " SET "));
            PropertyInfo firstPropertyInfo = type.GetType().GetProperties().First();
            PropertyInfo lastPropertyInfo = type.GetType().GetProperties().Last();
            foreach (PropertyInfo propertyInfo in type.GetType().GetProperties())
            {
                stringBuilder.Append(string.Concat(propertyInfo.Name, " = ", "@", propertyInfo.Name));
                if (propertyInfo.Equals(lastPropertyInfo)) stringBuilder.Append(" ");
                else stringBuilder.Append(", ");
            }
            stringBuilder.Append(string.Concat("WHERE ", firstPropertyInfo.Name,"  IN (@", firstPropertyInfo.Name,")"));
            return stringBuilder.ToString();
        }
    }
}