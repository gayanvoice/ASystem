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
    public class ScheduleCrewContext : IScheduleCrewContext
    {
        private const string table_name = "ScheduleCrew";
        public int Delete(int scheduleCrewId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM ScheduleCrew WHERE ScheduleCrewId IN (@ScheduleCrewId)";
            object param = new { ScheduleCrewId = scheduleCrewId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(ScheduleCrewContextModel scheduleCrewContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(scheduleCrewContextModel);
            return mySqlSingleton.Insert(query, scheduleCrewContextModel);
        }
        public ScheduleCrewContextModel Select(int scheduleCrewId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM ScheduleCrew WHERE ScheduleCrewId IN (@ScheduleCrewId)";
            object param = new { ScheduleCrewId = scheduleCrewId };
            return mySqlSingleton.Select<ScheduleCrewContextModel>(query, param);
        }
        public IEnumerable<ScheduleCrewContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<ScheduleCrewContextModel>(query);
        }
        public int Update(ScheduleCrewContextModel scheduleCrewContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(scheduleCrewContextModel);
            return mySqlSingleton.Update(query, scheduleCrewContextModel);
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