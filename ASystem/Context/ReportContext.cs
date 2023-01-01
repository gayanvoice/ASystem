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
    public class ReportContext : IReportContext
    {     
        public IEnumerable<CrewScheduleReportModel> GetCrewScheduleReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "select sc.CrewId, sc.FlightScheduleId, TimeIn, TimeOut from ScheduleCrew sc where sc.TimeIn between @From and @To";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<CrewScheduleReportModel>(query, param);
        }

        public IEnumerable<FlightScheduleWithDestinationReportModel> GetFlightScheduleWithDestinationReport()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "select * from v_FlightScheduleWithDestination";
            return mySqlSingleton.SelectAll<FlightScheduleWithDestinationReportModel>(query);
        }
    }
}