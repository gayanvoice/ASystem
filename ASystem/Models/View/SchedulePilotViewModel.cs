using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.Procedure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class SchedulePilotViewModel
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
                [Display(Name = "Schedule Pilot Id")]
                public int SchedulePilotId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Pilot Id")]
                public int PilotId { get; set; }

                [Display(Name = "Time In")]
                public DateTime TimeIn { get; set; }

                [Display(Name = "Time Out")]
                public DateTime TimeOut { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(SchedulePilotContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePilotId = contextModel.SchedulePilotId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.PilotId = contextModel.PilotId;
                    formViewModel.TimeIn = contextModel.TimeIn;
                    formViewModel.TimeOut = contextModel.TimeOut;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<SchedulePilotProcedureModel> SchedulePilotProcedureModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public SchedulePilotContextModel SchedulePilotContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> PilotEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Schedule Pilot Id")]
                public int SchedulePilotId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Pilot Id")]
                public int PilotId { get; set; }

                [Display(Name = "Time In")]
                public DateTime TimeIn { get; set; }

                [Display(Name = "Time Out")]
                public DateTime TimeOut { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(SchedulePilotContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePilotId = contextModel.SchedulePilotId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.PilotId = contextModel.PilotId;
                    formViewModel.TimeIn = contextModel.TimeIn;
                    formViewModel.TimeOut = contextModel.TimeOut;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> PilotEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Pilot Id")]
                public int PilotId { get; set; }

                [Required]
                [Display(Name = "Time In")]
                public DateTime TimeIn { get; set; }

                [Required]
                [Display(Name = "Time Out")]
                public DateTime TimeOut { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}