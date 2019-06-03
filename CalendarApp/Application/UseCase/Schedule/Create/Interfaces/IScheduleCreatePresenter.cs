using CalendarApp.ViewModels.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.UseCase.Schedule.Create.Interfaces
{
    public interface IScheduleCreatePresenter
    {
        ScheduleCreateViewModel CreateViewModel(ScheduleCreateOutputData outputData);
    }
}
