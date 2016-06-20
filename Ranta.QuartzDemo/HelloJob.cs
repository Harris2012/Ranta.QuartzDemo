using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranta.QuartzDemo
{
    class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Word");
        }
    }
}
