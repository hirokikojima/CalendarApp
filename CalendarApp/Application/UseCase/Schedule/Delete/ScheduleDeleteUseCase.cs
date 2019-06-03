using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Delete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.UseCase.Schedule.Delete
{
    public class ScheduleDeleteUseCase : IScheduleDeleteUseCase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleDeleteUseCase(
            IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleDeleteOutputData Handle(ScheduleDeleteInputData inputData)
        {
            var schedule = _scheduleRepository.FindById(inputData.Id);

            _scheduleRepository.Delete(schedule);

            return new ScheduleDeleteOutputData(schedule);
        }
    }
}