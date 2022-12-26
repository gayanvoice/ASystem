using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IEmployeeContext
    {
        int Delete(int employeeId);
        int Insert(EmployeeContextModel employeeContextModel);
        CrewContextModel Select(int employeeId);
        IEnumerable<EmployeeContextModel> SelectAll();
        int Update(EmployeeContextModel employeeContextModel);
    }
}