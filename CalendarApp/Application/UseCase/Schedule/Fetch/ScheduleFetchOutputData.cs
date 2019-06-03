using CalendarApp.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Fetch
{
    public class ScheduleFetchOutputData
    {
        public IEnumerable<ScheduleEntity> Schedules { get; set; }

        public ScheduleFetchOutputData(IEnumerable<ScheduleEntity> schedules)
        {
            Schedules = schedules;
        }
    }
}