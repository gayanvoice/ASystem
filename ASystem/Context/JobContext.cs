using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class JobContext : IJobContext
    {
        public int Delete(int jobId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Job WHERE JobId IN (@JobId)";
            object param = new { JobId = jobId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(JobContextModel jobContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO Job (JobId, Name, PayPerHour, PayOverTime, HoursWeekly) values (@JobId, @Name, @PayPerHour, @PayOverTime, @HoursWeekly)";
            return mySqlSingleton.Insert(query, jobContextModel);
        }
        public JobContextModel Select(int jobId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Job WHERE JobId IN (@JobId)";
            object param = new { JobId = jobId };
            return mySqlSingleton.Select<JobContextModel>(query, param);
        }
        public IEnumerable<JobContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Job";
            return mySqlSingleton.SelectAll<JobContextModel>(query);
        }
        public int Update(JobContextModel jobContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE Job SET JobId = @JobId, Name = @Name, PayPerHour = @PayPerHour, PayOverTime = @PayOverTime, HoursWeekly = @HoursWeekly WHERE JobId IN (@JobId)";
            return mySqlSingleton.Update(query, jobContextModel);
        }
    }
}