using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class EmployeeViewModel
    {
        public IndexViewModel Index { get; set; }
        public ListViewModel List { get; set; }
        public InsertViewModel Insert { get; set; }
        public DeleteViewModel Delete { get; set; }
        public EditViewModel Edit { get; set; }
        public ShowViewModel Show { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
        public class ShowViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Display(Name = "Job Id")]
                public int JobId { get; set; }

                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Display(Name = "Other Name")]
                public string OtherName { get; set; }

                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }

                [Display(Name = "Address")]
                public string Address { get; set; }

                [Display(Name = "Phone")]
                public int Phone { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(EmployeeContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.JobId = contextModel.JobId;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.OtherName = contextModel.OtherName;
                    formViewModel.DateOfBirth = contextModel.DateOfBirth;
                    formViewModel.Address = contextModel.Address;
                    formViewModel.Phone = contextModel.Phone;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<EmployeeContextModel> EmployeeContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public EmployeeContextModel EmployeeContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> JobEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Display(Name = "Job Id")]
                public int JobId { get; set; }

                [Display(Name = "Surname")]
                [StringLength(45)]
                public string Surname { get; set; }

                [Display(Name = "Other Name")]
                [StringLength(45)]
                public string OtherName { get; set; }

                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }

                [Display(Name = "Address")]
                [StringLength(200)]
                public string Address { get; set; }

                [Display(Name = "Phone")]
                public int Phone { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(EmployeeContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.JobId = contextModel.JobId;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.OtherName = contextModel.OtherName;
                    formViewModel.DateOfBirth = contextModel.DateOfBirth;
                    formViewModel.Address = contextModel.Address;
                    formViewModel.Phone = contextModel.Phone;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> JobEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {

                [Display(Name = "Job Id")]
                public int JobId { get; set; }

                [Display(Name = "Surname")]
                [StringLength(45)]
                public string Surname { get; set; }

                [Display(Name = "Other Name")]
                [StringLength(45)]
                public string OtherName { get; set; }

                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }

                [Display(Name = "Address")]
                [StringLength(200)]
                public string Address { get; set; }

                [Display(Name = "Phone")]
                public int Phone { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}