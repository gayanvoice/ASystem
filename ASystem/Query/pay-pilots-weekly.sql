select a.PilotId,
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
where sp.TimeIn between '2022-10-01' and '2022-10-07'
order by sp.PilotId) a