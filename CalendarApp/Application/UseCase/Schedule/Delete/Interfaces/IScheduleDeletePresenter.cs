using CalendarApp.Application.UseCase.Schedule.Delete;
using CalendarApp.ViewModels.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.UseCase.Schedule.Delete.Interfaces
{
    public interface IScheduleDeletePresenter
    {
        ScheduleDeleteViewModel CreateViewModel(ScheduleDeleteOutputData outputData);
    }
}
