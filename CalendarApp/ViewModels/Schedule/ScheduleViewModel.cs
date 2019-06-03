using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CalendarApp.ViewModels.Schedule
{
    [DataContract]
    public class ScheduleViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "start")]
        public string DateTimeFrom { get; set; }

        [DataMember(Name = "end")]
        public string DateTimeTo { get; set; }

        [DataMember(Name = "title")]
        public string Name { get; set; }
    }
}