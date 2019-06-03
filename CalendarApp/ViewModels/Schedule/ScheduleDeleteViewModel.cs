using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CalendarApp.ViewModels.Schedule
{
    [DataContract]
    public class ScheduleDeleteViewModel
    {
        [DataMember(Name = "schedule")]
        public ScheduleViewModel ScheduleViewModel;
    }
}