using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASystem.Helper
{
    public class PilotHelper
    {
        public static IEnumerable<SelectListItem> FromEmployeeEnumerable(IEnumerable<EmployeeContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (EmployeeContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.OtherName + " " + contextModel.Surname, Value = contextModel.EmployeeId.ToString() });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromAirplaneModelEnumerable(IEnumerable<AirplaneModelContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (AirplaneModelContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.Name + " " + contextModel.SubModel, Value = contextModel.AirplaneModelId.ToString() });
            }
            return selectListItemList;
        }
    }
}