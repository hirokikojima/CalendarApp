using CalendarApp.Application.UseCase.Schedule.Delete.Interfaces;
using CalendarApp.ViewModels.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Delete
{
    public class ScheduleDeletePresenter : IScheduleDeletePresenter
    {
        public ScheduleDeleteViewModel CreateViewModel(ScheduleDeleteOutputData outputData)
        {
            var scheduleViewModel = new ScheduleViewModel()
            {
                Id = outputData.Schedule.Id,
                DateTimeFrom = outputData.Schedule.DateTimeFrom.ToString("yyyy-MM-dd"),
                DateTimeTo = outputData.Schedule.DateTimeTo.ToString("yyyy-MM-dd"),
                Name = outputData.Schedule.Name
            };

            return new ScheduleDeleteViewModel()
            {
                ScheduleViewModel = scheduleViewModel
            };
        }
    }
}