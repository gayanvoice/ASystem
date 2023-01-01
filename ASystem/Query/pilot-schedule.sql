select sc.PilotId, sc.FlightScheduleId, TimeIn, TimeOut
from SchedulePilot sc
where sc.TimeIn between '2022-10-01' and '2022-10-31'