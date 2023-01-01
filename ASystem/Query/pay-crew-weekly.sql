select a.CrewId,
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
where sc.TimeIn between '2022-10-01' and '2022-10-07'
order by sc.CrewId) a