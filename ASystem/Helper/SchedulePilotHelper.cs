using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class SchedulePilotHelper
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
        public static IEnumerable<SelectListItem> FromPilotEnumerable(IEnumerable<PilotContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (PilotContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.PilotId.ToString(), Value = contextModel.PilotId.ToString() });
            }
            return selectListItemList;
        }
    }
}