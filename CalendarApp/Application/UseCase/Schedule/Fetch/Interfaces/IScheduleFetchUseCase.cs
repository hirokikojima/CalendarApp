using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.UseCase.Schedule.Fetch.Interfaces
{
    public interface IScheduleFetchUseCase
    {
        ScheduleFetchOutputData Handle(ScheduleFetchInputData inputData);
    }
}
