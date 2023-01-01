using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class ScheduleCrewViewModel
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
                [Display(Name = "Schedule Crew Id")]
                public int ScheduleCrewId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Crew Id")]
                public int CrewId { get; set; }

                [Display(Name = "Time In")]
                public DateTime TimeIn { get; set; }

                [Display(Name = "Time Out")]
                public DateTime TimeOut { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(ScheduleCrewContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ScheduleCrewId = contextModel.ScheduleCrewId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.CrewId = contextModel.CrewId;
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
            public IEnumerable<ScheduleCrewContextModel> ScheduleCrewContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public ScheduleCrewContextModel ScheduleCrewContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> CrewEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Schedule Crew Id")]
                public int ScheduleCrewId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Crew Id")]
                public int CrewId { get; set; }

                [Display(Name = "Time In")]
                public DateTime TimeIn { get; set; }

                [Display(Name = "Time Out")]
                public DateTime TimeOut { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(ScheduleCrewContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ScheduleCrewId = contextModel.ScheduleCrewId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.CrewId = contextModel.CrewId;
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
            public IEnumerable<SelectListItem> CrewEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Crew Id")]
                public int CrewId { get; set; }

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