using CalendarApp.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Delete
{
    public class ScheduleDeleteOutputData
    {
        public ScheduleEntity Schedule { get; set; }

        public ScheduleDeleteOutputData(ScheduleEntity schedule)
        {
            Schedule = schedule;
        }
    }
}