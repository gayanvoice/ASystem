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
    public class PassportController : Controller
    {
        private readonly IPassportContext _passportContext;
        public PassportController(IPassportContext passportContext)
        {
            _passportContext = passportContext;
        }
        public IActionResult Index()
        {
            PassportViewModel.IndexViewModel viewModel = new PassportViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            PassportViewModel.ListViewModel list = new PassportViewModel.ListViewModel();
            list.PassportContextModelEnumerable = _passportContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PassportContextModel contextModel = _passportContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }

            PassportViewModel.ShowViewModel showViewModel = new PassportViewModel.ShowViewModel();
            showViewModel.Form = PassportViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            PassportContextModel contextModel = _passportContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                PassportViewModel.EditViewModel editViewModel = new PassportViewModel.EditViewModel();
                editViewModel.Form = PassportViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(PassportViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            PassportBuilder builder = new PassportBuilder();
            PassportContextModel contextModel = builder
                .SetPassportId(editViewModel.Form.PassportId)
                .SetPassportNo(editViewModel.Form.PassportNo)
                .SetType(editViewModel.Form.Type)
                .SetCountryCode(editViewModel.Form.CountryCode)
                .SetSurname(editViewModel.Form.Surname)
                .SetOtherName(editViewModel.Form.OtherName)
                .SetNationalStatus(editViewModel.Form.NationalStatus)
                .SetDateOfBirth(editViewModel.Form.DateOfBirth)
                .SetIdNo(editViewModel.Form.IdNo)
                .SetProfession(editViewModel.Form.Profession)
                .SetSex(editViewModel.Form.Sex)
                .SetPlaceOfBirth(editViewModel.Form.PlaceOfBirth)
                .SetDateOfIssue(editViewModel.Form.DateOfIssue)
                .SetDateOfExpiry(editViewModel.Form.DateOfExpiry)
                .SetAuthority(editViewModel.Form.Authority)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _passportContext.Update(contextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Insert()
        {
            PassportViewModel.InsertViewModel insertViewModel = new PassportViewModel.InsertViewModel();
            insertViewModel.Form = new PassportViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(PassportViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            PassportBuilder builder = new PassportBuilder();
            PassportContextModel contextModel = builder
                .SetPassportNo(insertViewModel.Form.PassportNo)
                .SetType(insertViewModel.Form.Type)
                .SetCountryCode(insertViewModel.Form.CountryCode)
                .SetSurname(insertViewModel.Form.Surname)
                .SetOtherName(insertViewModel.Form.OtherName)
                .SetNationalStatus(insertViewModel.Form.NationalStatus)
                .SetDateOfBirth(insertViewModel.Form.DateOfBirth)
                .SetIdNo(insertViewModel.Form.IdNo)
                .SetProfession(insertViewModel.Form.Profession)
                .SetSex(insertViewModel.Form.Sex)
                .SetPlaceOfBirth(insertViewModel.Form.PlaceOfBirth)
                .SetDateOfIssue(insertViewModel.Form.DateOfIssue)
                .SetDateOfExpiry(insertViewModel.Form.DateOfExpiry)
                .SetAuthority(insertViewModel.Form.Authority)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _passportContext.Insert(contextModel);
            return RedirectToAction(nameof(List));
        }

        //public IActionResult Delete(int id)
        //{
        //    JobContextModel contextModel = _jobContext.Select(id);
        //    if (contextModel is null)
        //    {
        //        return RedirectToAction(nameof(List));
        //    }
        //    JobViewModel.DeleteViewModel viewModel = new JobViewModel.DeleteViewModel();
        //    viewModel.JobContextModel = contextModel;
        //    return View(viewModel);
        //}
        //[HttpPost]
        //public IActionResult Delete(JobViewModel.DeleteViewModel deleteViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(deleteViewModel);
        //    }
        //    try
        //    {
        //        _jobContext.Delete(deleteViewModel.JobContextModel.JobId);
        //        return RedirectToAction(nameof(List));
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Show", "Error", new { Code = 100, Controller = "Job", Action = "List" });
        //    }
        //}
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passport", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passport", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}