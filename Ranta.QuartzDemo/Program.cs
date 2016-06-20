using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranta.QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            var scheduler = schedulerFactory.GetScheduler();

            //Demo 1 简单使用
            IJobDetail helloJob = JobBuilder.Create<HelloJob>().WithIdentity("HelloJob_1", "Demo").Build();

            ITrigger helloTrigger = TriggerBuilder.Create()
                .WithIdentity("Trigger_1", "Demo")
                .StartNow()//现在开始
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever())//每3秒触发一次，永远执行下去
                .Build();

            scheduler.ScheduleJob(helloJob, helloTrigger);

            //Demo 2 执行时，作业数据传递，时间表达式使用
            IJobDetail sayHiJob = JobBuilder.Create<SayHiJob>()
                .WithIdentity("SaiHiJob_1", "Demo")
                .UsingJobData("jobSays", "Hi. Nice to seeo you")
                .Build();


            ITrigger sayHiTrigger = TriggerBuilder.Create()
                .WithIdentity("Trigger_2", "Demo")
                .StartNow()
                .WithCronSchedule("/5 * * ? * *")//时间表达式 5秒一次
                .Build();

            scheduler.ScheduleJob(sayHiJob, sayHiTrigger);

            scheduler.Start();

            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }
    }
}
