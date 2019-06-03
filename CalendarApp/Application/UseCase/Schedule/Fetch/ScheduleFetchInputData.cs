using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Fetch
{
    public class ScheduleFetchInputData
    {
        public DateTime DataTimeFrom { get; set; }
        public DateTime DataTimeTo { get; set; }

        public ScheduleFetchInputData(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            DataTimeFrom = dateTimeFrom;
            DataTimeTo = dateTimeTo;
        }
    }
}