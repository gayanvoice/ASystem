using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class SchedulePriceHelper
    {
        public static IEnumerable<SelectListItem> FromFlightScheduleEnumerable(IEnumerable<FlightScheduleContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (FlightScheduleContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = contextModel.FlightScheduleId.ToString()
                    + " -AirplaneId " + contextModel.AirplaneId
                    + " -AirportOrigin " + contextModel.AirportIdOrigin
                    + " -AirportDestination " + contextModel.AirportIdDestination
                    + " -DepartureTime " + contextModel.DepartureTime.ToString()
                    + " -ArriveTime " + contextModel.ArriveTime.ToString(),
                    Value = contextModel.FlightScheduleId.ToString()
                });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromClassEnumerable(IEnumerable<ClassContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (ClassContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.ClassId + " -ClassName " + contextModel.Name + " " + contextModel.SubClass + " -AirplaneId " + contextModel.AirplaneId, Value = contextModel.ClassId.ToString() });
            }
            return selectListItemList;
        }
    }
}