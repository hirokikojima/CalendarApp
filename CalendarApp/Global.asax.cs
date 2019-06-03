using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CalendarApp.Application.Infrastructure.Repositories;
using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Create;
using CalendarApp.Application.UseCase.Schedule.Create.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Delete;
using CalendarApp.Application.UseCase.Schedule.Delete.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Fetch;
using CalendarApp.Application.UseCase.Schedule.Fetch.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Update;
using CalendarApp.Application.UseCase.Schedule.Update.Interfaces;
using CalendarApp.Controllers;
using CalendarApp.Libraries.DependencyResolvers;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var serviceCollection = new ServiceCollection();

            // configure all of the services required for DI
#if DEBUG
            serviceCollection.AddTransient<IScheduleRepository, ScheduleRepositoryForInMemory>();
#else
            serviceCollection.AddTransient<IScheduleRepository, ScheduleRepositoryForSqlServer>();
#endif
            serviceCollection.AddTransient<IScheduleFetchUseCase, ScheduleFetchUseCase>();
            serviceCollection.AddTransient<IScheduleFetchPresenter, ScheduleFetchPresenter>();
            serviceCollection.AddTransient<IScheduleCreateUseCase, ScheduleCreateUseCase>();
            serviceCollection.AddTransient<IScheduleCreatePresenter, ScheduleCreatePresenter>();
            serviceCollection.AddTransient<IScheduleUpdateUseCase, ScheduleUpdateUseCase>();
            serviceCollection.AddTransient<IScheduleUpdatePresenter, ScheduleUpdatePresenter>();
            serviceCollection.AddTransient<IScheduleDeleteUseCase, ScheduleDeleteUseCase>();
            serviceCollection.AddTransient<IScheduleDeletePresenter, ScheduleDeletePresenter>();
            serviceCollection.AddTransient<ScheduleController>();

            // create new resolver from our own default implementation
            var resolver = new DefaultDependencyResolver(serviceCollection.BuildServiceProvider());

            // set the application resolver
            DependencyResolver.SetResolver(resolver);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
