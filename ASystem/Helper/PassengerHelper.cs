using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASystem.Helper
{
    public class PassengerHelper
    {
        public static IEnumerable<SelectListItem> FromPassportEnumerable(IEnumerable<PassportContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (PassportContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.PassportNo.ToString() + " -Name " + contextModel.OtherName + " " + contextModel.Surname, Value = contextModel.PassportId.ToString() });
            }
            return selectListItemList;
        }
       
    }
}