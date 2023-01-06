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
    public class AirportController : Controller
    {
        private readonly IAirportContext _airportContext;
        public AirportController(IAirportContext airportContext)
        {
            _airportContext = airportContext;
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
                    AirportViewModel.IndexViewModel indexViewModel = new AirportViewModel.IndexViewModel();
                    indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
                    return View(indexViewModel);
                }

                else
                {
                    return RedirectToAction("LogIn", "Home", new { area = "" });
                }
            }
        }
        public IActionResult List(string param)
        {
            AirportViewModel.ListViewModel list = new AirportViewModel.ListViewModel();
            list.Status = param;
            list.AirportContextModelEnumerable = _airportContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            AirportContextModel airportContextModel = _airportContext.Select(id);
            if (airportContextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            AirportViewModel.ShowViewModel showViewModel = new AirportViewModel.ShowViewModel();
            showViewModel.Form = AirportViewModel.ShowViewModel.FormViewModel.FromAirportContextModel(airportContextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            AirportContextModel airportContextModel = _airportContext.Select(id);
            if (airportContextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                AirportViewModel.EditViewModel editViewModel = new AirportViewModel.EditViewModel();
                editViewModel.Form = AirportViewModel.EditViewModel.FormViewModel.FromAirportContextModel(airportContextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(AirportViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            AirportBuilder airportBuilder = new AirportBuilder();
            AirportContextModel airportContextModel = airportBuilder
                .SetAirportId(editViewModel.Form.AirportId)
                .SetCode(editViewModel.Form.Code)
                .SetName(editViewModel.Form.Name)
                .SetCity(editViewModel.Form.City)
                .SetCountry(editViewModel.Form.Country)
                .Build();
            _airportContext.Update(airportContextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            AirportViewModel.InsertViewModel insertViewModel = new AirportViewModel.InsertViewModel();
            insertViewModel.Form = new AirportViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(AirportViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            AirportBuilder airportBuilder = new AirportBuilder();
            AirportContextModel airportContextModel = airportBuilder
                .SetCode(insertViewModel.Form.Code)
                .SetName(insertViewModel.Form.Name)
                .SetCity(insertViewModel.Form.City)
                .SetCountry(insertViewModel.Form.Country)
                .Build();
            _airportContext.Insert(airportContextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            AirportContextModel airportContextModel = _airportContext.Select(id);
            if (airportContextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            AirportViewModel.DeleteViewModel deleteViewModel = new AirportViewModel.DeleteViewModel();
            deleteViewModel.AirportContextModel = airportContextModel;
            return View(deleteViewModel);
        }
        [HttpPost]
        public IActionResult Delete(AirportViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _airportContext.Delete(deleteViewModel.AirportContextModel.AirportId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Airport", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airport", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}