using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Create.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Create
{
    public class ScheduleCreateUseCase : IScheduleCreateUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleCreateUseCase(
            IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleCreateOutputData Handle(ScheduleCreateInputData inputData)
        {
            var schedule = _scheduleRepository.Create(inputData.DataTimeFrom, inputData.DataTimeTo, inputData.Name);

            _scheduleRepository.Save(schedule);

            return new ScheduleCreateOutputData(schedule);
        }
    }
}