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

        public IEnumerable<PassengersByFlightScheduleReportModel> GetPassengersByFlightScheduleReport()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "select * from v_NumberOfPassengersByFlight";
            return mySqlSingleton.SelectAll<PassengersByFlightScheduleReportModel>(query);
        }

        public IEnumerable<PayCrewWeeklyReportModel> GetPayCrewWeeklyReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = @"select a.CrewId,
                               a.EmployeeId,
                               a.EmployeeName,
                               case
                                  when a.Duration<=a.HoursWeekly then a.Duration * a.PayPerHour
                                  when a.Duration>a.HoursWeekly then (a.HoursWeekly * a.PayPerHour) + ((a.Duration - a.HoursWeekly) * a.PayOvertime)
                                  else 0
                                end as Pay,
                               a.Duration,
                               a.HoursWeekly,
                               a.PayPerHour,
                               a.PayOvertime
                        from
                            (select sc.CrewId,
                                    em.EmployeeId,
                                    concat(em.OtherName, ' ', em.Surname) EmployeeName,
                               TIMESTAMPDIFF(hour, sc.TimeIn, sc.TimeOut) as Duration,
                               jb.HoursWeekly,
                               jb.PayPerHour,
                               jb.PayOvertime
                        from ScheduleCrew sc
                        left join Crew cr on cr.CrewId = sc.CrewId
                        left join Employee em on em.EmployeeId = cr.EmployeeId
                        left join Job jb on jb.JobId = em.JobId
                        where sc.TimeIn between @From and @To
                        order by sc.CrewId) a";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<PayCrewWeeklyReportModel>(query, param);
        }

        public IEnumerable<PilotScheduleReportModel> GetPilotScheduleReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = @"select sc.PilotId, sc.FlightScheduleId, TimeIn, TimeOut
                                from SchedulePilot sc
                                where sc.TimeIn between @From and @To";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<PilotScheduleReportModel>(query, param);
        }

        public IEnumerable<PayPilotWeeklyReportModel> GetPayPilotWeeklyReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = @"select a.PilotId,
                           a.EmployeeId,
                           a.EmployeeName,
                           case
                              when a.Duration<=a.HoursWeekly then a.Duration * a.PayPerHour
                              when a.Duration>a.HoursWeekly then (a.HoursWeekly * a.PayPerHour) + ((a.Duration - a.HoursWeekly) * a.PayOvertime)
                              else 0
                            end as Pay,
                           a.Duration,
                           a.HoursWeekly,
                           a.PayPerHour,
                           a.PayOvertime
                    from
                        (select sp.PilotId,
                                em.EmployeeId,
                                concat(em.OtherName, ' ', em.Surname) EmployeeName,
                           TIMESTAMPDIFF(hour, sp.TimeIn, sp.TimeOut) as Duration,
                           jb.HoursWeekly,
                           jb.PayPerHour,
                           jb.PayOvertime
                    from SchedulePilot sp
                    left join Pilot pt on pt.PilotId = sp.PilotId
                    left join Employee em on em.EmployeeId = pt.EmployeeId
                    left join Job jb on jb.JobId = em.JobId
                    where sp.TimeIn between @From and @To
                    order by sp.PilotId) a";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<PayPilotWeeklyReportModel>(query, param);
        }

        public IEnumerable<RemainingSeatsOfFlightScheduleByClassReportModel> GetRemainingSeatsOfFlightScheduleByClassReport()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "select * from v_NumberOfRemainingSeatsOfFlightScheduleByClass";
            return mySqlSingleton.SelectAll<RemainingSeatsOfFlightScheduleByClassReportModel>(query);
        }

        public IEnumerable<WorkingHoursOfCrewReportModel> GetWorkingHoursOfCrewReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = @"select c.CrewId,
                               em.EmployeeId,
                               concat(em.OtherName, ' ', em.Surname) Name,
                               c.Hour, c.Minute, c.Second
                        from (select b.CrewId,
                                     hour(sec_to_time(b.Sum))   Hour,
                                     minute(sec_to_time(b.Sum)) Minute,
                                     second(sec_to_time(b.Sum)) Second
                              from (select a.CrewId,
                                           sum(Duration) Sum
                                    from (select sp.CrewId,
                                                 TIMESTAMPDIFF(second, TimeIn, TimeOut) as Duration
                                          from ScheduleCrew sp
                                               -- where TimeIn between @From and @To
                                          order by CrewId) a
                                    group by CrewId) b) c
                        left join Crew cr on cr.CrewId = c.CrewId
                        left join Employee em on em.EmployeeId = cr.EmployeeId";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<WorkingHoursOfCrewReportModel>(query, param);
        }

        public IEnumerable<WorkingHoursOfPilotReportModel> GetWorkingHoursOfPilotReport(DateTime From, DateTime To)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = @"select c.PilotId,
                           em.EmployeeId,
                           concat(em.OtherName, ' ', em.Surname) Name,
                           c.Hour, c.Minute, c.Second
                    from (select b.PilotId,
                           hour(sec_to_time(b.Sum)) Hour,
                           minute(sec_to_time(b.Sum)) Minute,
                           second( sec_to_time(b.Sum)) Second
                        from
                        (select a.PilotId,
                                sum(Duration) Sum from
                                (select sp.PilotId, TIMESTAMPDIFF(second, TimeIn, TimeOut) as Duration
                                from SchedulePilot sp
                                -- where TimeIn between '2022-10-01' and '2022-10-15'
                                order by PilotId) a
                            group by PilotId) b) c
                    left join Crew cr on cr.CrewId = c.PilotId
                    left join Employee em on em.EmployeeId = cr.EmployeeId";
            object param = new { From = From, To = To };
            return mySqlSingleton.SelectAll<WorkingHoursOfPilotReportModel>(query, param);
        }
    }
}