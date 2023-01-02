CREATE VIEW v_NumberOfPassengersByFlight AS
select fs.FlightScheduleId, a.Count, concat(man.Name, ' ', am.SubModel) Airplane, ap.FlightNumber
from (select FlightScheduleId, count(*) as Count from SchedulePassenger group by FlightScheduleId) a
left join FlightSchedule fs on fs.FlightScheduleId = a.FlightScheduleId
left join Airplane ap on ap.AirplaneId = fs.AirplaneId
left join AirplaneModel am on am.AirplaneModelId = ap.AirplaneModelId
left join AirplaneManufacturer man on man.AirplaneManufacturerId = am.AirplaneManufacturerId