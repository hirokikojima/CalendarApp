using CalendarApp.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Application.Infrastructure.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        void Save(ScheduleEntity entity);
        void Delete(ScheduleEntity entity);
        ScheduleEntity Create(DateTime dateTimeFrom, DateTime dateTimeTo, string name);
        ScheduleEntity FindById(int id);
        IEnumerable<ScheduleEntity> FindByPeriod(DateTime from, DateTime to);
    }
}
