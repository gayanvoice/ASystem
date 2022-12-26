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
    public class FlightScheduleContext : IFlightScheduleContext
    {
        private const string table_name = "FlightSchedule";
        public int Delete(int flightScheduleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM FlightSchedule WHERE FlightScheduleId IN (@FlightScheduleId)";
            object param = new { FlightScheduleId = flightScheduleId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(FlightScheduleContextModel flightScheduleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(flightScheduleContextModel);
            return mySqlSingleton.Insert(query, flightScheduleContextModel);
        }
        public FlightScheduleContextModel Select(int flightScheduleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM FlightSchedule WHERE FlightScheduleId IN (@FlightScheduleId)";
            object param = new { FlightScheduleId = flightScheduleId };
            return mySqlSingleton.Select<FlightScheduleContextModel>(query, param);
        }
        public IEnumerable<FlightScheduleContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<FlightScheduleContextModel>(query);
        }
        public int Update(FlightScheduleContextModel flightScheduleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(flightScheduleContextModel);
            return mySqlSingleton.Update(query, flightScheduleContextModel);
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