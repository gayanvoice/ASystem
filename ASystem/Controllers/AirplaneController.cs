using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.Airplane;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class AirplaneController : Controller
    {
        private readonly IAirplaneContext _airplaneContext;
        private readonly IAirplaneModelContext _airplaneModelContext;
        public AirplaneController(IAirplaneContext airplaneContext,
            IAirplaneModelContext airplaneModelContext)
        {
            _airplaneContext = airplaneContext;
            _airplaneModelContext = airplaneModelContext;
        }
        public IActionResult Index()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null)
            {
                return RedirectToAction("LogIn", "Home", new { area = "" });
            }
            else
            {
                if (role.Equals(UserRoleEnum.STAFF.ToString()))
                {
                    AirplaneViewModel.IndexViewModel viewModel = new AirplaneViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
                    return View(viewModel);
                }
                else
                {
                    return RedirectToAction("LogIn", "Home", new { area = "" });
                }
            }
        }
        public IActionResult List(string param)
        {
            AirplaneViewModel.ListViewModel list = new AirplaneViewModel.ListViewModel();
            list.Status = param;
            list.AirplaneContextModelEnumerable = _airplaneContext.SelectAll();            
            return View(list);
        }
        public IActionResult Show(int id)
        {
            AirplaneContextModel contextModel = _airplaneContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            AirplaneViewModel.ShowViewModel showViewModel = new AirplaneViewModel.ShowViewModel();
            showViewModel.Form = AirplaneViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            AirplaneContextModel contextModel = _airplaneContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<AirplaneModelContextModel> airplaneModelIdEnumerable =  _airplaneModelContext.SelectAll();
                AirplaneViewModel.EditViewModel editViewModel = new AirplaneViewModel.EditViewModel();
                editViewModel.AirplaneModelIdEnumerable =  AirplaneHelper.FromAirplaneModelEnumerable(airplaneModelIdEnumerable);
                editViewModel.StatusEnumerable = AirplaneHelper.GetIEnumerableSelectListItem<AirplaneStatusEnum>();
                editViewModel.Form = AirplaneViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(AirplaneViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneModelContextModel> airplaneModelIdEnumerable = _airplaneModelContext.SelectAll();
                editViewModel.StatusEnumerable = AirplaneHelper.GetIEnumerableSelectListItem<AirplaneStatusEnum>();
                editViewModel.AirplaneModelIdEnumerable = AirplaneHelper.FromAirplaneModelEnumerable(airplaneModelIdEnumerable);
                return View(editViewModel);
            }
            AirplaneBuilder builder = new AirplaneBuilder();
            AirplaneContextModel contextModel = builder
                .SetAirplaneId(editViewModel.Form.AirplaneId)
                .SetAirplaneModelId(editViewModel.Form.AirplaneModelId)
                .SetFlightNumber(editViewModel.Form.FlightNumber)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _airplaneContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<AirplaneModelContextModel> airplaneModelIdEnumerable = _airplaneModelContext.SelectAll();
            AirplaneViewModel.InsertViewModel insertViewModel = new AirplaneViewModel.InsertViewModel();
            insertViewModel.StatusEnumerable = AirplaneHelper.GetIEnumerableSelectListItem<AirplaneStatusEnum>();
            insertViewModel.AirplaneModelIdEnumerable = AirplaneHelper.FromAirplaneModelEnumerable(airplaneModelIdEnumerable);
            insertViewModel.Form = new AirplaneViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(AirplaneViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneModelContextModel> airplaneModelIdEnumerable = _airplaneModelContext.SelectAll();
                insertViewModel.StatusEnumerable = AirplaneHelper.GetIEnumerableSelectListItem<AirplaneStatusEnum>();
                insertViewModel.AirplaneModelIdEnumerable = AirplaneHelper.FromAirplaneModelEnumerable(airplaneModelIdEnumerable);
                return View(insertViewModel);
            }
            AirplaneBuilder builder = new AirplaneBuilder();
            AirplaneContextModel contextModel = builder
                .SetAirplaneModelId(insertViewModel.Form.AirplaneModelId)
                .SetFlightNumber(insertViewModel.Form.FlightNumber)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _airplaneContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            AirplaneContextModel contextModel = _airplaneContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            AirplaneViewModel.DeleteViewModel viewModel = new AirplaneViewModel.DeleteViewModel();
            viewModel.AirplaneContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(AirplaneViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _airplaneContext.Delete(deleteViewModel.AirplaneContextModel.AirplaneId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airplane", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airplane", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}