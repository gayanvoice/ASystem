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
    public class PassengerContext : IPassengerContext
    {
        private const string table_name = "Passenger";
        public int Delete(int passengerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Passenger WHERE PassengerId IN (@PassengerId)";
            object param = new { PassengerId = passengerId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(PassengerContextModel passengerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(passengerContextModel);
            return mySqlSingleton.Insert(query, passengerContextModel);
        }
        public PassengerContextModel Select(int passengerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Passenger WHERE PassengerId IN (@PassengerId)";
            object param = new { PassengerId = passengerId };
            return mySqlSingleton.Select<PassengerContextModel>(query, param);
        }
        public IEnumerable<PassengerContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<PassengerContextModel>(query);
        }
        public int Update(PassengerContextModel passengerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(passengerContextModel);
            return mySqlSingleton.Update(query, passengerContextModel);
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