using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASystem.Helper
{
    public class CrewHelper
    {
        public static IEnumerable<SelectListItem> FromEmployeeEnumerable(IEnumerable<EmployeeContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (EmployeeContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.OtherName + " " + contextModel.Surname + " -JobId " + contextModel.JobId, Value = contextModel.EmployeeId.ToString() });
            }
            return selectListItemList;
        }
       
    }
}