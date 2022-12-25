using ASystem.Enum;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Singleton;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SASystem.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class UserViewModel
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
            public IEnumerable<SelectListItem> StatusOption { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "User Id")]
                public int UserId { get; set; }
                public string Username { get; set; }
                public string Password { get; set; }
                public string Status { get; set; }
                public static FormViewModel FromUserContextModel(UserContextModel userContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.UserId = userContextModel.UserId;
                    formViewModel.Username = userContextModel.Username;
                    formViewModel.Password = userContextModel.Password;
                    formViewModel.Status = userContextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<UserContextModel> UserContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public string Title { get; set; }
            public UserContextModel UserContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> StatusOption { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "UserId")]
                public int UserId { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Username { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Password { get; set; }
                [Required]
                [DataType(DataType.Text)]
                public UserEnum Status { get; set; }
                public static FormViewModel FromUserContextModel(UserContextModel userContextModel)
                {
                    CipherSingleton cipherSingleton = CipherSingleton.Instance;
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.UserId = userContextModel.UserId;
                    formViewModel.Username = userContextModel.Username;
                    formViewModel.Password = cipherSingleton.Decrypt(userContextModel.Password);
                    formViewModel.Status = (UserEnum) System.Enum.Parse(typeof(UserEnum), userContextModel.Status);
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> StatusOption { get; set; }
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {
                [Required]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Username { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Password { get; set; }
                [Required]
                [DataType(DataType.Text)]
                public UserEnum Status { get; set; }
            }
        
        }

    }
}