using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class AirplaneManufacturerController : Controller
    {
        private readonly IAirplaneManufacturerContext _airplaneManufacturerContext;
        public AirplaneManufacturerController(IAirplaneManufacturerContext airplaneManufacturerContext)
        {
            _airplaneManufacturerContext = airplaneManufacturerContext;
        }
        public IActionResult Index()
        {
            AirplaneManufacturerViewModel.IndexViewModel indexViewModel = new AirplaneManufacturerViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult List()
        {
            AirplaneManufacturerViewModel.ListViewModel list = new AirplaneManufacturerViewModel.ListViewModel();
            list.AirplaneManufacturerContextModelEnumerable = _airplaneManufacturerContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            AirplaneManufacturerContextModel airplaneManufacturerContextModel = _airplaneManufacturerContext.Select(id);
            if (airplaneManufacturerContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }

            AirplaneManufacturerViewModel.ShowViewModel showViewModel = new AirplaneManufacturerViewModel.ShowViewModel();
            showViewModel.Form = AirplaneManufacturerViewModel.ShowViewModel.FormViewModel.FromUserContextModel(airplaneManufacturerContextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            AirplaneManufacturerContextModel airplaneManufacturerContextModel = _airplaneManufacturerContext.Select(id);
            if (airplaneManufacturerContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                AirplaneManufacturerViewModel.EditViewModel editViewModel = new AirplaneManufacturerViewModel.EditViewModel();
                editViewModel.Form = AirplaneManufacturerViewModel.EditViewModel.FormViewModel.FromUserContextModel(airplaneManufacturerContextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(AirplaneManufacturerViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            AirplaneManufacturerBuilder airplaneManufacturerBuilder = new AirplaneManufacturerBuilder();
            AirplaneManufacturerContextModel airplaneManufacturerContextModel = airplaneManufacturerBuilder
                .SetAirplaneManufacturerId(editViewModel.Form.AirplaneManufacturerId)
                .SetName(editViewModel.Form.Name)
                .SetCountry(editViewModel.Form.Country)
                .Build();
            _airplaneManufacturerContext.Update(airplaneManufacturerContextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Insert()
        {
            AirplaneManufacturerViewModel.InsertViewModel insertViewModel = new AirplaneManufacturerViewModel.InsertViewModel();
            insertViewModel.Form = new AirplaneManufacturerViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(AirplaneManufacturerViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            AirplaneManufacturerBuilder airplaneManufacturerBuilder = new AirplaneManufacturerBuilder();
            AirplaneManufacturerContextModel airplaneManufacturerContextModel = airplaneManufacturerBuilder
                .SetName(insertViewModel.Form.Name)
                .SetCountry(insertViewModel.Form.Country)
                .Build();
            _airplaneManufacturerContext.Insert(airplaneManufacturerContextModel);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            AirplaneManufacturerContextModel airplaneManufacturerContextModel = _airplaneManufacturerContext.Select(id);
            if (airplaneManufacturerContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            AirplaneManufacturerViewModel.DeleteViewModel deleteViewModel = new AirplaneManufacturerViewModel.DeleteViewModel();
            deleteViewModel.AirplaneManufacturerContextModel = airplaneManufacturerContextModel;
            return View(deleteViewModel);
        }
        [HttpPost]
        public IActionResult Delete(AirplaneManufacturerViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _airplaneManufacturerContext.Delete(deleteViewModel.AirplaneManufacturerContextModel.AirplaneManufacturerId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Error", "Show", new { Code = 100, Controller = "AirplaneManufacturer", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneManufacturer", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneManufacturer", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}