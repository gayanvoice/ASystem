using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ICrewContext
    {
        int Delete(int crewId);
        int Insert(CrewContextModel crewContextModel);
        CrewContextModel Select(int crewId);
        IEnumerable<CrewContextModel> SelectAll();
        int Update(CrewContextModel crewContextModel);
    }
}