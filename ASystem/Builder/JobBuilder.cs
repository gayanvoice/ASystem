using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class JobBuilder
    {
        private JobContextModel _jobContextModel = new JobContextModel();
        public JobBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _jobContextModel = new JobContextModel();
        }
        public void Set(JobContextModel jobContextModel)
        {
            _jobContextModel = jobContextModel;
        }
        public JobBuilder SetJobId (int jobId)
        {
            _jobContextModel.JobId = jobId;
            return this;
        }
        public JobBuilder SetName(string name)
        {
            _jobContextModel.Name = name;
            return this;
        }
        public JobBuilder SetPayPerHour(double payPerHour)
        {
            _jobContextModel.PayPerHour = payPerHour;
            return this;
        }
        public JobBuilder SetPayOverTime(double payOverTime)
        {
            _jobContextModel.PayOverTime = payOverTime;
            return this;
        }
        public JobBuilder SetHoursWeekly(double hoursWeekly)
        {
            _jobContextModel.HoursWeekly = hoursWeekly;
            return this;
        }
        public JobContextModel Build()
        {
            JobContextModel model = _jobContextModel;
            Reset();
            return model;
        }
    }
}