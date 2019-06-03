using CalendarApp.Application.Domain.Entities;
using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.Infrastructure.Repositories
{
    public class ScheduleRepositoryForInMemory : IScheduleRepository
    {
        private static int lastInsertId = 0;

        // Memo: staticを付けることでスタック領域にメモリが確保されて起動から停止までオブジェクトが保持される
        private static List<ScheduleEntity> data = new List<ScheduleEntity>();

        public ScheduleEntity Create(DateTime dateTimeFrom, DateTime dateTimeTo, string name)
        {
            lastInsertId++;

            return new ScheduleEntity(lastInsertId, dateTimeFrom, dateTimeTo, name);
        }

        public ScheduleEntity FindById(int id)
        {
            return data.Select(x => CloneSchedule(x)).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ScheduleEntity> FindByPeriod(DateTime from, DateTime to)
        {
            return data
                .Where(x => (from <= x.DateTimeFrom && x.DateTimeFrom <= to) 
                         || (from <= x.DateTimeTo && x.DateTimeTo <= to))
                .Select(x => CloneSchedule(x));
        }

        public void Save(ScheduleEntity entity)
        {
            var schedule = data.FirstOrDefault(x => x.Id == entity.Id);

            if (schedule == null)
            {
                // 追加の場合
                data.Add(CloneSchedule(entity));
            }
            else
            {
                // 更新の場合
                schedule.DateTimeFrom = entity.DateTimeFrom;
                schedule.DateTimeTo = entity.DateTimeTo;
                schedule.Name = entity.Name;
            }
        }

        public void Delete(ScheduleEntity entity)
        {
            data.RemoveAll(x => x.Id == entity.Id);
        }

        public ScheduleEntity CloneSchedule(ScheduleEntity schedule)
        {
            return new ScheduleEntity(schedule.Id, schedule.DateTimeFrom, schedule.DateTimeTo, schedule.Name);
        }
    }
}