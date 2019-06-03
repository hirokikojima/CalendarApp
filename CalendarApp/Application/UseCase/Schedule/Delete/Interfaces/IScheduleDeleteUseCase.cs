using CalendarApp.Application.UseCase.Schedule.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.UseCase.Schedule.Delete.Interfaces
{
    public interface IScheduleDeleteUseCase
    {
        ScheduleDeleteOutputData Handle(ScheduleDeleteInputData inputData);
    }
}
