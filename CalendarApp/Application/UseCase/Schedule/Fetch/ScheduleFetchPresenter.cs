using CalendarApp.Application.UseCase.Schedule.Fetch.Interfaces;
using CalendarApp.ViewModels.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Fetch
{
    public class ScheduleFetchPresenter : IScheduleFetchPresenter
    {
        public ScheduleFetchViewModel CreateViewModel(ScheduleFetchOutputData outputData)
        {
            List<ScheduleViewModel> scheduleViewModels = new List<ScheduleViewModel>();

            foreach (var schedule in outputData.Schedules)
            {
                scheduleViewModels.Add(new ScheduleViewModel()
                {
                    Id = schedule.Id,
                    DateTimeFrom = schedule.DateTimeFrom.ToString("yyyy-MM-dd"),
                    DateTimeTo = schedule.DateTimeTo.ToString("yyyy-MM-dd"),
                    Name = schedule.Name
                });
            }

            return new ScheduleFetchViewModel()
            {
                ScheduleViewModels = scheduleViewModels
            };
        }
    }
}