CREATE VIEW v_NumberOfRemainingSeatsOfFlightScheduleByClass AS
select cl.ClassId,
       cl.Name,
       (cl.NoOfSeats-b.Reserve) as Remaining,
       b.Reserve,
       cl.NoOfSeats as total
from (select a.ClassId, count(a.ClassId) as Reserve
      from (select se.ClassId,
                   sp.SchedulePassengerId
            from Seat se
            left join SchedulePassenger sp on sp.SeatId = se.SeatId) a
      where a.SchedulePassengerId is not null
      group by a.ClassId) b
right join Class cl on cl.ClassId = b.ClassId;