using System;

namespace ASystem.Models.Context
{
    public class EmployeeContextModel
    {
        public int EmployeeId { get; set; } //11
        public int JobId { get; set; } //11
        public string Surname { get; set; } //45
        public string OtherName { get; set; } //45
        public DateTime DateOfBirth{ get; set; }
        public string Address { get; set; } //200
        public int Phone { get; set; } //20
        public string Status { get; set; } //20
    }
}