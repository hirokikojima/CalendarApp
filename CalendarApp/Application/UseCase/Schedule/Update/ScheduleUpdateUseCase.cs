using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Update.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Update
{
    public class ScheduleUpdateUseCase : IScheduleUpdateUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleUpdateUseCase(
            IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleUpdateOutputData Handle(ScheduleUpdateInputData inputData)
        {
            var schedule = _scheduleRepository.FindById(inputData.Id);

            schedule.DateTimeFrom = inputData.DataTimeFrom;
            schedule.DateTimeTo = inputData.DataTimeTo;
            schedule.Name = inputData.Name;

            _scheduleRepository.Save(schedule);

            return new ScheduleUpdateOutputData(schedule);
        }
    }
}