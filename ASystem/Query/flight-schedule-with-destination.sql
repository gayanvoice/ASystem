CREATE VIEW v_FlightScheduleWithDestination AS
select b.*
from (select a.FlightScheduleId,
             a.FlightName,
             a.FlightNumber,
             DATE_FORMAT(a.DepartureTime, '%Y/%m/%d %H:%i') as DepartureTime,
             DATE_FORMAT(a.ArriveTime, '%Y/%m/%d %H:%i') as ArriveTime,
             TIMESTAMPDIFF(hour, DepartureTime, ArriveTime) as DurationHours,
             (TIMESTAMPDIFF(minute, DepartureTime, ArriveTime)%60) as DurationInMinutes,
             (TIMESTAMPDIFF(second, DepartureTime, ArriveTime)%60) as DurationInSeconds,
             CONCAT(apo.Name, ' ', apo.Code) as Origin,
             CONCAT(apd.Name, ' ', apd.code) as Destination,
             a.type
      from (select concat(ma.Name, ' ', am.Name) as FlightName,
                   ap.FlightNumber,
                   fs.FlightScheduleId,
                   fs.AirportIdOrigin,
                   fs.AirportIdDestination,
                   fs.DepartureTime,
                   fs.ArriveTime,
                   fs.Type
            from FlightSchedule fs
                     left join Airplane ap on ap.AirplaneId = fs.AirplaneId
                     left join AirplaneModel am on am.AirplaneModelId = ap.AirplaneModelId
                     left join AirplaneManufacturer ma on ma.AirplaneManufacturerId = am.AirplaneManufacturerId) a
               left join Airport apo on apo.AirportId = a.AirportIdOrigin
               left join Airport apd on apd.AirportId = a.AirportIdDestination) b
order by b.FlightScheduleId