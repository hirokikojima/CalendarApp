using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.Domain.Entities
{
    public class ScheduleEntity
    {
        public int Id { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Name { get; set; }

        public ScheduleEntity(int id, DateTime dateTimeFrom, DateTime dateTimeTo, string name)
        {
            Id = id;
            DateTimeFrom = dateTimeFrom;
            DateTimeTo = dateTimeTo;
            Name = name;
        }
    }
}