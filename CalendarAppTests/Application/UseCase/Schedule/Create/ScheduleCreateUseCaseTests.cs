using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarApp.Application.UseCase.Schedule.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.Domain.Entities;

namespace CalendarApp.Application.UseCase.Schedule.Create.Tests
{
    [TestClass()]
    public class ScheduleCreateUseCaseTests
    {
        private Mock<IScheduleRepository> _mockRepository;

        private readonly DateTime _from = new DateTime(2019, 5, 1);
        private readonly DateTime _to = new DateTime(2019, 5, 2);
        private readonly string _name = "Sample Schedule";

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IScheduleRepository>();

            _mockRepository.Setup(x => x.Create(_from, _to, _name))
                .Returns(new ScheduleEntity(1, _from, _to, _name));
        }

        [TestMethod()]
        public void HandleTest()
        {
            var usecase = new ScheduleCreateUseCase(_mockRepository.Object);

            var inputData = new ScheduleCreateInputData(_from, _to, _name);

            var outputData = usecase.Handle(inputData);

            try
            {
                // リポジトリが正しく呼び出されているかチェック
                _mockRepository.Verify(x => x.Create(_from, _to, _name), Times.Once());
            }
            catch (MockException e)
            {
                Assert.Fail(e.Message);
            }

            Assert.AreEqual(outputData.Schedule.DateTimeFrom, _from);
            Assert.AreEqual(outputData.Schedule.DateTimeTo, _to);
            Assert.AreEqual(outputData.Schedule.Name, _name);
        }
    }
}