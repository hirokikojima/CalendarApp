using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CalendarApp.ViewModels.Schedule
{
    [DataContract]
    public class ScheduleFetchViewModel
    {
        [DataMember(Name = "schedules")]
        public List<ScheduleViewModel> ScheduleViewModels { get; set; }
    }
}