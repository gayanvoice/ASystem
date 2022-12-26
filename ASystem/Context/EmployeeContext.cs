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
    public class EmployeeContext : IEmployeeContext
    {
        private const string table_name = "Employee";
        public int Delete(int employeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Employee WHERE EmployeeId IN (@EmployeeId)";
            object param = new { EmployeeId = employeeId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetInsertQuery(employeeContextModel);
            return mySqlSingleton.Insert(query, employeeContextModel);
        }
        public EmployeeContextModel Select(int employeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Employee WHERE EmployeeId IN (@EmployeeId)";
            object param = new { EmployeeId = employeeId };
            return mySqlSingleton.Select<EmployeeContextModel>(query, param);
        }
        public IEnumerable<EmployeeContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = string.Concat("SELECT * FROM ", table_name);
            return mySqlSingleton.SelectAll<EmployeeContextModel>(query);
        }
        public int Update(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = GetUpdateQuery(employeeContextModel);
            return mySqlSingleton.Update(query, employeeContextModel);
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