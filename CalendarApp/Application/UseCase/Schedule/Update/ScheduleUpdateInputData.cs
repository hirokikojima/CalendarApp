using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Update
{
    public class ScheduleUpdateInputData
    {
        public int Id { get; set; }
        public DateTime DataTimeFrom { get; set; }
        public DateTime DataTimeTo { get; set; }
        public string Name { get; set; }

        public ScheduleUpdateInputData(int id, DateTime from, DateTime to, string name)
        {
            Id = id;
            DataTimeFrom = from;
            DataTimeTo = to;
            Name = name;
        }
    }
}