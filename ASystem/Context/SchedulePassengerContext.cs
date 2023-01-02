using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Models.Procedure;
using ASystem.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SASystem.Context
{
    public class SchedulePassengerContext : ISchedulePassengerContext
    {
        private const string table_name = "SchedulePassenger";
        public int Delete(int schedulePassengerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM SchedulePassenger WHERE SchedulePassengerId IN (@SchedulePassengerId)";
            object param = new { SchedulePassengerId = schedulePassengerId };
            return mySqlSingleton.Delete(query, param);
        }

        public IEnumerable<SchedulePassengerProcedureModel> GetAllSchedulePassenger()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "CALL p_GetAllSchedulePassenger";
            return mySqlSingleton.SelectAll<SchedulePassengerProcedureModel>(query);
        }

        public int Insert(SchedulePassengerContextModel schedulePassengerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(schedulePassengerContextModel);
            return mySqlSingleton.Insert(query, schedulePassengerContextModel);
        }
        public SchedulePassengerContextModel Select(int schedulePassengerId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM SchedulePassenger WHERE SchedulePassengerId IN (@SchedulePassengerId)";
            object param = new { SchedulePassengerId = schedulePassengerId };
            return mySqlSingleton.Select<SchedulePassengerContextModel>(query, param);
        }
        public IEnumerable<SchedulePassengerContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<SchedulePassengerContextModel>(query);
        }
        public int Update(SchedulePassengerContextModel schedulePassengerContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(schedulePassengerContextModel);
            return mySqlSingleton.Update(query, schedulePassengerContextModel);
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