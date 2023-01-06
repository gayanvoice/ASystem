using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Class;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassContext _classContext;
        private readonly IAirplaneContext _airplaneContext;
        public ClassController(IClassContext classContext,
            IAirplaneContext airplaneContext)
        {
            _classContext = classContext;
            _airplaneContext = airplaneContext;
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
                    ClassViewModel.IndexViewModel viewModel = new ClassViewModel.IndexViewModel();
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
            ClassViewModel.ListViewModel list = new ClassViewModel.ListViewModel();
            list.Status = param;
            list.ClassContextModelEnumerable = _classContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            ClassContextModel contextModel = _classContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            ClassViewModel.ShowViewModel showViewModel = new ClassViewModel.ShowViewModel();
            showViewModel.Form = ClassViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            ClassContextModel contextModel = _classContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<AirplaneContextModel> airplaneEnumerable = _airplaneContext.SelectAll();
                ClassViewModel.EditViewModel editViewModel = new ClassViewModel.EditViewModel();
                editViewModel.AirplaneIdEnumerable = ClassHelper.FromAirplaneEnumerable(airplaneEnumerable);
                editViewModel.ChangeFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<ChangeFeeEnum>();
                editViewModel.RefundFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<RefundFeeEnum>();
                editViewModel.SeatSelectionEnumerable = ClassHelper.GetIEnumerableSelectListItem<SeatSelectionEnum>();
                editViewModel.SkywardMilesEnumerable = ClassHelper.GetIEnumerableSelectListItem<SkywardsMilesEnum>();
                editViewModel.UpgradeEnumerable = ClassHelper.GetIEnumerableSelectListItem<UpgradeEnum>();
                editViewModel.Form = ClassViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(ClassViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneContextModel> airplaneEnumerable = _airplaneContext.SelectAll();
                editViewModel.AirplaneIdEnumerable = ClassHelper.FromAirplaneEnumerable(airplaneEnumerable);
                editViewModel.ChangeFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<ChangeFeeEnum>();
                editViewModel.RefundFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<RefundFeeEnum>();
                editViewModel.SeatSelectionEnumerable = ClassHelper.GetIEnumerableSelectListItem<SeatSelectionEnum>();
                editViewModel.SkywardMilesEnumerable = ClassHelper.GetIEnumerableSelectListItem<SkywardsMilesEnum>();
                editViewModel.UpgradeEnumerable = ClassHelper.GetIEnumerableSelectListItem<UpgradeEnum>();
                return View(editViewModel);
            }
            ClassBuilder builder = new ClassBuilder();
            ClassContextModel contextModel = builder
                .SetClassId(editViewModel.Form.ClassId)
                .SetAirplaneId(editViewModel.Form.AirplaneId)
                .SetName(editViewModel.Form.Name)
                .SetSubClass(editViewModel.Form.SubClass)
                .SetNoOfSeats(editViewModel.Form.NoOfSeats)
                .SetBaggageSize(editViewModel.Form.BaggageSize)
                .SetCabinBaggageSize(editViewModel.Form.CabinBaggageSize)
                .SetIsSeatSelection(editViewModel.Form.IsSeatSelection)
                .SetIsSkywardsMiles(editViewModel.Form.IsSkywardsMiles)
                .SetIsUpgrade(editViewModel.Form.IsUpgrade)
                .SetIsChangeFee(editViewModel.Form.IsChangeFee)
                .SetIsRefundFee(editViewModel.Form.IsRefundFee)
                .Build();
            _classContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<AirplaneContextModel> airplaneEnumerable = _airplaneContext.SelectAll();
            ClassViewModel.InsertViewModel insertViewModel = new ClassViewModel.InsertViewModel();
            insertViewModel.AirplaneIdEnumerable = ClassHelper.FromAirplaneEnumerable(airplaneEnumerable);
            insertViewModel.ChangeFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<ChangeFeeEnum>();
            insertViewModel.RefundFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<RefundFeeEnum>();
            insertViewModel.SeatSelectionEnumerable = ClassHelper.GetIEnumerableSelectListItem<SeatSelectionEnum>();
            insertViewModel.SkywardMilesEnumerable = ClassHelper.GetIEnumerableSelectListItem<SkywardsMilesEnum>();
            insertViewModel.UpgradeEnumerable = ClassHelper.GetIEnumerableSelectListItem<UpgradeEnum>();
            insertViewModel.Form = new ClassViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(ClassViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneContextModel> airplaneEnumerable = _airplaneContext.SelectAll();
                insertViewModel.AirplaneIdEnumerable = ClassHelper.FromAirplaneEnumerable(airplaneEnumerable);
                insertViewModel.ChangeFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<ChangeFeeEnum>();
                insertViewModel.RefundFeeEnumerable = ClassHelper.GetIEnumerableSelectListItem<RefundFeeEnum>();
                insertViewModel.SeatSelectionEnumerable = ClassHelper.GetIEnumerableSelectListItem<SeatSelectionEnum>();
                insertViewModel.SkywardMilesEnumerable = ClassHelper.GetIEnumerableSelectListItem<SkywardsMilesEnum>();
                insertViewModel.UpgradeEnumerable = ClassHelper.GetIEnumerableSelectListItem<UpgradeEnum>();
                return View(insertViewModel);
            }
            ClassBuilder builder = new ClassBuilder();
            ClassContextModel contextModel = builder
                .SetAirplaneId(insertViewModel.Form.AirplaneId)
                .SetName(insertViewModel.Form.Name)
                .SetSubClass(insertViewModel.Form.SubClass)
                .SetNoOfSeats(insertViewModel.Form.NoOfSeats)
                .SetBaggageSize(insertViewModel.Form.BaggageSize)
                .SetCabinBaggageSize(insertViewModel.Form.CabinBaggageSize)
                .SetIsSeatSelection(insertViewModel.Form.IsSeatSelection)
                .SetIsSkywardsMiles(insertViewModel.Form.IsSkywardsMiles)
                .SetIsUpgrade(insertViewModel.Form.IsUpgrade)
                .SetIsChangeFee(insertViewModel.Form.IsChangeFee)
                .SetIsRefundFee(insertViewModel.Form.IsRefundFee)
                .Build();
            _classContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ClassContextModel contextModel = _classContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            ClassViewModel.DeleteViewModel viewModel = new ClassViewModel.DeleteViewModel();
            viewModel.ClassContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ClassViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _classContext.Delete(deleteViewModel.ClassContextModel.ClassId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Class", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Class", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}