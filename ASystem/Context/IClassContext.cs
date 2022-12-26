using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IClassContext
    {
        int Delete(int classId);
        int Insert(ClassContextModel classContextModel);
        ClassContextModel Select(int classId);
        IEnumerable<ClassContextModel> SelectAll();
        int Update(ClassContextModel classContextModel);
    }
}