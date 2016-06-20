using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranta.QuartzDemo
{
    class SayHiJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string content = dataMap.GetString("jobSays");

            Console.WriteLine("作业执行, jobSays:{0}", content);
        }
    }
}
