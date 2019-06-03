using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Fetch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Fetch
{
    public class ScheduleFetchUseCase : IScheduleFetchUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleFetchUseCase(
            IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleFetchOutputData Handle(ScheduleFetchInputData inputData)
        {
            var schedules = _scheduleRepository.FindByPeriod(inputData.DataTimeFrom, inputData.DataTimeTo);

            return new ScheduleFetchOutputData(schedules);
        }
    }
}