using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class SchedulePassengerHelper
    {
        public static IEnumerable<SelectListItem> GetIEnumerableSelectListItem<TEnum>()
       where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (TEnum tEnum in System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                string value = tEnum.ToString();
                selectListItemList.Add(new SelectListItem() { Text = value, Value = value });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromFlightScheduleEnumerable(IEnumerable<FlightScheduleContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (FlightScheduleContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.FlightScheduleId.ToString(), Value = contextModel.FlightScheduleId.ToString() });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromPassengerEnumerable(IEnumerable<PassengerContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (PassengerContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.PassengerId.ToString(), Value = contextModel.PassengerId.ToString() });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromSeatEnumerable(IEnumerable<SeatContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (SeatContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.SeatId + " " + contextModel.SeatNo, Value = contextModel.SeatId.ToString() });
            }
            return selectListItemList;
        }
    }
}