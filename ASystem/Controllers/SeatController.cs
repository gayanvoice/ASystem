using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Class;
using ASystem.Enum.FlightSchedule;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class SeatController : Controller
    {
        private readonly IClassContext _classContext;
        private readonly ISeatContext _seatContext;
        public SeatController(IClassContext classContext,
            ISeatContext seatContext)
        {
            _classContext = classContext;
            _seatContext = seatContext;
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
                    SeatViewModel.IndexViewModel viewModel = new SeatViewModel.IndexViewModel();
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
            SeatViewModel.ListViewModel list = new SeatViewModel.ListViewModel();
            list.Status = param;
            list.SeatContextModelEnumerable = _seatContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SeatContextModel contextModel = _seatContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SeatViewModel.ShowViewModel showViewModel = new SeatViewModel.ShowViewModel();
            showViewModel.Form = SeatViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SeatContextModel contextModel = _seatContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                SeatViewModel.EditViewModel editViewModel = new SeatViewModel.EditViewModel();
                editViewModel.ClassEnumerable = SeatHelper.FromClassEnumerable(classContextModelEnumerable);
                editViewModel.Form = SeatViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SeatViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                editViewModel.ClassEnumerable = SeatHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(editViewModel);
            }
            SeatBuilder builder = new SeatBuilder();
            SeatContextModel contextModel = builder
                .SetSeatId(editViewModel.Form.SeatId)
                .SetClassId(editViewModel.Form.ClassId)
                .SetSeatNo(editViewModel.Form.SeatNo)
                .Build();
            _seatContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
            SeatViewModel.InsertViewModel insertViewModel = new SeatViewModel.InsertViewModel();
            insertViewModel.ClassEnumerable = SeatHelper.FromClassEnumerable(classContextModelEnumerable);
            insertViewModel.Form = new SeatViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SeatViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                insertViewModel.ClassEnumerable = SeatHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(insertViewModel);
            }
            SeatBuilder builder = new SeatBuilder();
            SeatContextModel contextModel = builder
                .SetClassId(insertViewModel.Form.ClassId)
                .SetSeatNo(insertViewModel.Form.SeatNo)
                .Build();
            _seatContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SeatContextModel contextModel = _seatContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SeatViewModel.DeleteViewModel viewModel = new SeatViewModel.DeleteViewModel();
            viewModel.SeatContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SeatViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _seatContext.Delete(deleteViewModel.SeatContextModel.SeatId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Seat", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Seat", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}