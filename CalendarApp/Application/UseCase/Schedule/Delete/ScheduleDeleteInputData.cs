using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Delete
{
    public class ScheduleDeleteInputData
    {
        public int Id { get; set; }

        public ScheduleDeleteInputData(int id)
        {
            Id = id;
        }
    }
}