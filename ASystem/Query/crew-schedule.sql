select sc.CrewId, sc.FlightScheduleId, TimeIn, TimeOut
from ScheduleCrew sc
where sc.TimeIn between '2022-10-01' and '2022-10-31'