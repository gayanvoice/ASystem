using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IFlightScheduleContext
    {
        int Delete(int flightScheduleId);
        int Insert(FlightScheduleContextModel flightScheduleContextModel);
        FlightScheduleContextModel Select(int flightScheduleId);
        IEnumerable<FlightScheduleContextModel> SelectAll();
        int Update(FlightScheduleContextModel flightScheduleContextModel);
    }
}