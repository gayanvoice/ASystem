using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class AirplaneModelController : Controller
    {
        private readonly IAirplaneModelContext _airplaneModelContext;
        private readonly IAirplaneManufacturerContext _airplaneManufacturerContext;
        public AirplaneModelController(IAirplaneModelContext airplaneModelContext,
            IAirplaneManufacturerContext airplaneManufacturerContext)
        {
            _airplaneModelContext = airplaneModelContext;
            _airplaneManufacturerContext = airplaneManufacturerContext;
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
                    AirplaneModelViewModel.IndexViewModel viewModel = new AirplaneModelViewModel.IndexViewModel();
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
            AirplaneModelViewModel.ListViewModel list = new AirplaneModelViewModel.ListViewModel();
            list.Status = param;
            list.AirplaneModelContextModelEnumerable = _airplaneModelContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            AirplaneModelContextModel contextModel = _airplaneModelContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            AirplaneModelViewModel.ShowViewModel showViewModel = new AirplaneModelViewModel.ShowViewModel();
            showViewModel.Form = AirplaneModelViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            AirplaneModelContextModel contextModel = _airplaneModelContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<AirplaneManufacturerContextModel> airplaneManufacturerContextModelEnumerable = _airplaneManufacturerContext.SelectAll();
                AirplaneModelViewModel.EditViewModel editViewModel = new AirplaneModelViewModel.EditViewModel();
                editViewModel.AirplaneManufacturerIdEnumerable = AirplaneModelHelper.FromAirplaneManufacturerEnumerable(airplaneManufacturerContextModelEnumerable);
                editViewModel.Form = AirplaneModelViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult edit(AirplaneModelViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneManufacturerContextModel> airplaneManufacturerContextModelEnumerable = _airplaneManufacturerContext.SelectAll();
                editViewModel.AirplaneManufacturerIdEnumerable = AirplaneModelHelper.FromAirplaneManufacturerEnumerable(airplaneManufacturerContextModelEnumerable); ;
                return View(editViewModel);
            }
            AirplaneModelBuilder builder = new AirplaneModelBuilder();
            AirplaneModelContextModel contextmodel = builder
                .SetAirplaneModelId(editViewModel.Form.AirplaneModelId)
                .SetAirplaneManufacturerId(editViewModel.Form.AirplaneManufacturerId)
                .SetName(editViewModel.Form.Name)
                .SetSubModel(editViewModel.Form.SubModel)
                .Build();
            _airplaneModelContext.Update(contextmodel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<AirplaneManufacturerContextModel> airplaneManufacturerContextModelEnumerable = _airplaneManufacturerContext.SelectAll();
            AirplaneModelViewModel.InsertViewModel insertViewModel = new AirplaneModelViewModel.InsertViewModel();
            insertViewModel.AirplaneManufacturerIdEnumerable = AirplaneModelHelper.FromAirplaneManufacturerEnumerable(airplaneManufacturerContextModelEnumerable); ;
            insertViewModel.Form = new AirplaneModelViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(AirplaneModelViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneManufacturerContextModel> airplaneManufacturerContextModelEnumerable = _airplaneManufacturerContext.SelectAll();
                insertViewModel.AirplaneManufacturerIdEnumerable = AirplaneModelHelper.FromAirplaneManufacturerEnumerable(airplaneManufacturerContextModelEnumerable); ;
                return View(insertViewModel);
            }
            AirplaneModelBuilder builder = new AirplaneModelBuilder();
            AirplaneModelContextModel contextmodel = builder
                .SetAirplaneManufacturerId(insertViewModel.Form.AirplaneManufacturerId)
                .SetName(insertViewModel.Form.Name)
                .SetSubModel(insertViewModel.Form.SubModel)
                .Build();
            _airplaneModelContext.Insert(contextmodel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            AirplaneModelContextModel contextModel = _airplaneModelContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            AirplaneModelViewModel.DeleteViewModel viewModel = new AirplaneModelViewModel.DeleteViewModel();
            viewModel.AirplaneContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(AirplaneModelViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _airplaneModelContext.Delete(deleteViewModel.AirplaneContextModel.AirplaneModelId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneModel", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneModel", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}