using CalendarApp.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Update
{
    public class ScheduleUpdateOutputData
    {
        public ScheduleEntity Schedule { get; set; }

        public ScheduleUpdateOutputData(ScheduleEntity schedule)
        {
            Schedule = schedule;
        }
    }
}