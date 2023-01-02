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
    public class SchedulePilotContext : ISchedulePilotContext
    {
        private const string table_name = "SchedulePilot";
        public int Delete(int schedulePilotId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM SchedulePilot WHERE SchedulePilotId IN (@SchedulePilotId)";
            object param = new { SchedulePilotId = schedulePilotId };
            return mySqlSingleton.Delete(query, param);
        }

        public IEnumerable<SchedulePilotProcedureModel> GetAllSchedulePilot()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "CALL p_GetAllSchedulePilot";
            return mySqlSingleton.SelectAll<SchedulePilotProcedureModel>(query);
        }

        public int Insert(SchedulePilotContextModel schedulePilotContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(schedulePilotContextModel);
            return mySqlSingleton.Insert(query, schedulePilotContextModel);
        }
        public SchedulePilotContextModel Select(int schedulePilotId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM SchedulePilot WHERE SchedulePilotId IN (@SchedulePilotId)";
            object param = new { SchedulePilotId = schedulePilotId };
            return mySqlSingleton.Select<SchedulePilotContextModel>(query, param);
        }
        public IEnumerable<SchedulePilotContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<SchedulePilotContextModel>(query);
        }
        public int Update(SchedulePilotContextModel schedulePilotContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(schedulePilotContextModel);
            return mySqlSingleton.Update(query, schedulePilotContextModel);
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