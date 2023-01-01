select c.CrewId,
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
                       -- where TimeIn between '2022-10-01' and '2022-10-15'
                  order by CrewId) a
            group by CrewId) b) c
left join Crew cr on cr.CrewId = c.CrewId
left join Employee em on em.EmployeeId = cr.EmployeeId