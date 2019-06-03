using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Create
{
    public class ScheduleCreateInputData
    {
        public DateTime DataTimeFrom { get; set; }
        public DateTime DataTimeTo { get; set; }
        public string Name { get; set; }

        public ScheduleCreateInputData(DateTime from, DateTime to, string name)
        {
            DataTimeFrom = from;
            DataTimeTo = to;
            Name = name;
        }
    }
}