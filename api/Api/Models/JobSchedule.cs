using System;

namespace Api.Models
{
    public class JobSchedule
    {
        public JobSchedule(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }
        public Type JobType { get; }
        public string CronExpression { get; }
    }
}