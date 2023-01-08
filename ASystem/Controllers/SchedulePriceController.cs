using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Controllers
{
    public class SchedulePriceController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly IClassContext _classContext;
        private readonly ISchedulePriceContext _schedulePriceContext;
        public SchedulePriceController(
            IFlightScheduleContext flightScheduleContext,
            IClassContext classContext,
            ISchedulePriceContext schedulePriceContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _classContext = classContext;
            _schedulePriceContext = schedulePriceContext;
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
                    SchedulePriceViewModel.IndexViewModel viewModel = new SchedulePriceViewModel.IndexViewModel();
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
            SchedulePriceViewModel.ListViewModel list = new SchedulePriceViewModel.ListViewModel();
            list.Status = param;
            list.SchedulePriceProcedureModelEnumerable = _schedulePriceContext.GetAllSchedulePrice().OrderBy(schedulePrice => int.Parse(schedulePrice.FlightScheduleId));
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            SchedulePriceViewModel.ShowViewModel showViewModel = new SchedulePriceViewModel.ShowViewModel();
            showViewModel.Form = SchedulePriceViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                       .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                SchedulePriceViewModel.EditViewModel editViewModel = new SchedulePriceViewModel.EditViewModel();
                editViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                editViewModel.Form = SchedulePriceViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SchedulePriceViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                        .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(editViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(editViewModel.Form.FlightScheduleId);
            ClassContextModel classContextModel = _classContext.Select(editViewModel.Form.ClassId);
            if (!(classContextModel.AirplaneId.Equals(flightScheduleContextModel.AirplaneId)))
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                          .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                ModelState.AddModelError("Form.ClassId", "Airplane is dfferent from the flight schedule");
                return View(editViewModel);
            }
            SchedulePriceBuilder builder = new SchedulePriceBuilder();
            SchedulePriceContextModel contextModel = builder
                .SetSchedulePriceId(editViewModel.Form.SchedulePriceId)
                .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                .SetClassId(editViewModel.Form.ClassId)
                .SetPrice(editViewModel.Form.Price)
                .Build();
            _schedulePriceContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()) 
                && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
            IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
            SchedulePriceViewModel.InsertViewModel insertViewModel = new SchedulePriceViewModel.InsertViewModel();
            insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
            insertViewModel.Form = new SchedulePriceViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SchedulePriceViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                        .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(insertViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(insertViewModel.Form.FlightScheduleId);
            ClassContextModel classContextModel = _classContext.Select(insertViewModel.Form.ClassId);
            if (!(classContextModel.AirplaneId.Equals(flightScheduleContextModel.AirplaneId)))
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                        .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                         && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                ModelState.AddModelError("Form.ClassId", "Airplane is dfferent from the flight schedule");
                return View(insertViewModel);
            }
            IEnumerable<SchedulePriceContextModel> schedulePriceContextModelEnumerable = _schedulePriceContext.SelectAll();
            bool exist = schedulePriceContextModelEnumerable.Any(schedulePrice => schedulePrice.FlightScheduleId.Equals(insertViewModel.Form.FlightScheduleId) &&
                                schedulePrice.ClassId.Equals(insertViewModel.Form.ClassId));
            if (exist)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                       .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString())
                        && flightSchedule.Type.Equals(Enum.FlightSchedule.TypeEnum.PASSENGER.ToString()));
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                ModelState.AddModelError("Form.ClassId", "Already class is added to schedule price");
                return View(insertViewModel);
            }
            SchedulePriceBuilder builder = new SchedulePriceBuilder();
            SchedulePriceContextModel contextModel = builder
                .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                .SetClassId(insertViewModel.Form.ClassId)
                .SetPrice(insertViewModel.Form.Price)
                .Build();
            _schedulePriceContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SchedulePriceViewModel.DeleteViewModel viewModel = new SchedulePriceViewModel.DeleteViewModel();
            viewModel.SchedulePriceContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SchedulePriceViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _schedulePriceContext.Delete(deleteViewModel.SchedulePriceContextModel.SchedulePriceId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}