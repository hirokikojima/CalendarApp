using CalendarApp.Application.UseCase.Schedule.Create;
using CalendarApp.Application.UseCase.Schedule.Create.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Delete;
using CalendarApp.Application.UseCase.Schedule.Delete.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Fetch;
using CalendarApp.Application.UseCase.Schedule.Fetch.Interfaces;
using CalendarApp.Application.UseCase.Schedule.Update;
using CalendarApp.Application.UseCase.Schedule.Update.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarApp.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleFetchUseCase _scheduleFetchUseCase;
        private readonly IScheduleFetchPresenter _scheduleFetchPresenter;

        private readonly IScheduleCreateUseCase _scheduleCreateUseCase;
        private readonly IScheduleCreatePresenter _scheduleCreatePresenter;

        private readonly IScheduleUpdateUseCase _scheduleUpdateUseCase;
        private readonly IScheduleUpdatePresenter _scheduleUpdatePresenter;

        private readonly IScheduleDeleteUseCase _scheduleDeleteUseCase;
        private readonly IScheduleDeletePresenter _scheduleDeletePresenter;

        public ScheduleController(
            IScheduleFetchUseCase scheduleFetchUseCase,
            IScheduleFetchPresenter scheduleFetchPresenter,
            IScheduleCreateUseCase scheduleCreateUseCase,
            IScheduleCreatePresenter scheduleCreatePresenter,
            IScheduleUpdateUseCase scheduleUpdateUseCase,
            IScheduleUpdatePresenter scheduleUpDatePresenter,
            IScheduleDeleteUseCase scheduleDeleteUseCase,
            IScheduleDeletePresenter scheduleDeletePresenter)
        {
            _scheduleFetchUseCase = scheduleFetchUseCase;
            _scheduleFetchPresenter = scheduleFetchPresenter;
            _scheduleCreateUseCase = scheduleCreateUseCase;
            _scheduleCreatePresenter = scheduleCreatePresenter;
            _scheduleUpdateUseCase = scheduleUpdateUseCase;
            _scheduleUpdatePresenter = scheduleUpDatePresenter;
            _scheduleDeleteUseCase = scheduleDeleteUseCase;
            _scheduleDeletePresenter = scheduleDeletePresenter;
        }

        public ActionResult Fetch()
        {
            var from = Convert.ToDateTime(Request.Params["start"]);
            var to = Convert.ToDateTime(Request.Params["end"]);

            var inputData = new ScheduleFetchInputData(from, to);
            var outputData = _scheduleFetchUseCase.Handle(inputData);

            // 本来はPresenterはUseCaseに依存するようにしないといけないが
            // 但し、UseCaseはOutputDataを返却する必要がある
            // ViewModelを作るのはPresenterの責務じゃない？？
            var viewModel = _scheduleFetchPresenter.CreateViewModel(outputData);

            return Content(JsonConvert.SerializeObject(viewModel));
        }

        public ActionResult Create()
        {
            var from = Convert.ToDateTime(Request.Form["start"]);
            var to = Convert.ToDateTime(Request.Form["end"]);
            var name = Request.Form["title"];

            var inputData = new ScheduleCreateInputData(from, to, name);
            var outputData = _scheduleCreateUseCase.Handle(inputData);

            var viewModel = _scheduleCreatePresenter.CreateViewModel(outputData);

            return Content(JsonConvert.SerializeObject(viewModel));
        }

        public ActionResult Update()
        {
            var id = Convert.ToInt32(Request.Form["id"]);
            var from = Convert.ToDateTime(Request.Form["start"]);
            var to = Convert.ToDateTime(Request.Form["end"]);
            var name = Request.Form["title"];

            var inputData = new ScheduleUpdateInputData(id, from, to, name);
            var outputData = _scheduleUpdateUseCase.Handle(inputData);

            var viewModel = _scheduleUpdatePresenter.CreateViewModel(outputData);

            return Content(JsonConvert.SerializeObject(viewModel));
        }

        public ActionResult Delete()
        {
            var id = Convert.ToInt32(Request.Form["id"]);

            var inputData = new ScheduleDeleteInputData(id);
            var outputData = _scheduleDeleteUseCase.Handle(inputData);

            var viewModel = _scheduleDeletePresenter.CreateViewModel(outputData);

            return Content(JsonConvert.SerializeObject(viewModel));
        }
    }
}