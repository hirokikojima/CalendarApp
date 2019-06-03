using CalendarApp.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Create
{
    public class ScheduleCreateOutputData
    {
        public ScheduleEntity Schedule { get; set; }

        public ScheduleCreateOutputData(ScheduleEntity schedule)
        {
            Schedule = schedule;
        }
    }
}