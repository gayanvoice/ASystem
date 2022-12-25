using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IJobContext
    {
        int Delete(int jobId);
        int Insert(JobContextModel jobContextModel);
        JobContextModel Select(int jobId);
        IEnumerable<JobContextModel> SelectAll();
        int Update(JobContextModel jobContextModel);
    }
}