using CalendarApp.Application.Domain.Entities;
using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CalendarApp.Application.Infrastructure.Repositories
{
    public class ScheduleRepositoryForSqlServer : IScheduleRepository
    {
        public ScheduleEntity Create(DateTime dateTimeFrom, DateTime dateTimeTo, string name)
        {
            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT IDENT_CURRENT('schedules') + 1";
                    int id = Convert.ToInt32(command.ExecuteScalar());

                    return new ScheduleEntity(id, dateTimeFrom, dateTimeTo, name);
                }
            }
        }

        public ScheduleEntity FindById(int id)
        {
            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM schedules WHERE id = @id";
                    command.Parameters.Add(new SqlParameter("@id", id));
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new ScheduleEntity(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToDateTime(reader["datetime_from"]),
                            Convert.ToDateTime(reader["datetime_to"]),
                            Convert.ToString(reader["name"])
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<ScheduleEntity> FindByPeriod(DateTime from, DateTime to)
        {
            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM schedules WHERE @from <= datetime_from AND datetime_to <= @to";
                    command.Parameters.Add(new SqlParameter("@from", from));
                    command.Parameters.Add(new SqlParameter("@to", to));
                    var results = new List<ScheduleEntity>();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new ScheduleEntity(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToDateTime(reader["datetime_from"]),
                            Convert.ToDateTime(reader["datetime_to"]),
                            Convert.ToString(reader["name"])
                        ));
                    }
                    return results;
                }
            }
        }

        public void Save(ScheduleEntity entity)
        {
            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open();

                var isExist = false;

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM schedules WHERE id = @id";
                    command.Parameters.Add(new SqlParameter("@id", entity.Id));
                    var reader = command.ExecuteReader();
                    isExist = reader.Read();
                    reader.Close();
                }

                using (var command = connection.CreateCommand())
                {
                    if (isExist)
                    {
                        command.CommandText = @"UPDATE 
                                                    schedules 
                                                SET 
                                                    datetime_from = @from,
                                                    datetime_to = @to, 
                                                    name = @name 
                                                WHERE 
                                                    id = @id";
                        command.Parameters.Add(new SqlParameter("@from", entity.DateTimeFrom));
                        command.Parameters.Add(new SqlParameter("@to", entity.DateTimeTo));
                        command.Parameters.Add(new SqlParameter("@name", entity.Name));
                        command.Parameters.Add(new SqlParameter("@id", entity.Id));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = @"INSERT INTO schedules (
                                                    datetime_from, 
                                                    datetime_to, 
                                                    name
                                                ) VALUES (
                                                    @from,
                                                    @to,
                                                    @name
                                                )";
                        command.Parameters.Add(new SqlParameter("@from", entity.DateTimeFrom));
                        command.Parameters.Add(new SqlParameter("@to", entity.DateTimeTo));
                        command.Parameters.Add(new SqlParameter("@name", entity.Name));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(ScheduleEntity entity)
        {
            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM schedules WHERE id = @id";
                    command.Parameters.Add(new SqlParameter("@id", entity.Id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}