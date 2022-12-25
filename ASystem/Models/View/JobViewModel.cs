using ASystem.Models.Component;
using ASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class JobViewModel
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
                [Display(Name = "Job Id")]
                public int JobId { get; set; }
                public string Name { get; set; }
                [Display(Name = "Pay Per Hour")]
                public double PayPerHour { get; set; }
                [Display(Name = "Pay Over Time")]
                public double PayOverTime { get; set; }
                [Display(Name = "Hours Weekly")]
                public double HoursWeekly { get; set; }
                public static FormViewModel FromJobContextModel(JobContextModel jobContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.JobId = jobContextModel.JobId;
                    formViewModel.Name = jobContextModel.Name;
                    formViewModel.PayPerHour = jobContextModel.PayPerHour;
                    formViewModel.PayOverTime = jobContextModel.PayOverTime;
                    formViewModel.HoursWeekly = jobContextModel.HoursWeekly;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<JobContextModel> JobContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public JobContextModel JobContextModel { get; set; }
        }
        public class EditViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Job Id")]
                public int JobId { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [Display(Name = "Pay Per Hour")]
                [DataType(DataType.Currency)]
                public double PayPerHour { get; set; }
                [Required]
                [Display(Name = "Pay Over Time")]
                [DataType(DataType.Currency)]
                public double PayOverTime { get; set; }
                [Required]
                [Display(Name = "Hours Weekly")]
                public double HoursWeekly { get; set; }
                public static FormViewModel FromJobContextModel(JobContextModel jobContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.JobId = jobContextModel.JobId;
                    formViewModel.Name = jobContextModel.Name;
                    formViewModel.PayPerHour = jobContextModel.PayPerHour;
                    formViewModel.PayOverTime = jobContextModel.PayOverTime;
                    formViewModel.HoursWeekly = jobContextModel.HoursWeekly;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [Display(Name = "Pay Per Hour")]
                [DataType(DataType.Currency)]
                public double PayPerHour { get; set; }
                [Required]
                [Display(Name = "Pay Over Time")]
                [DataType(DataType.Currency)]
                public double PayOverTime { get; set; }
                [Required]
                [Display(Name = "Hours Weekly")]
                public double HoursWeekly { get; set; }
            }
        }
    }
}