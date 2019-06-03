using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.UseCase.Schedule.Create.Interfaces
{
    public interface IScheduleCreateUseCase
    {
        ScheduleCreateOutputData Handle(ScheduleCreateInputData inputData);
    }
}
