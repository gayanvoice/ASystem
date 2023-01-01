select c.PilotId,
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
left join Employee em on em.EmployeeId = cr.EmployeeId