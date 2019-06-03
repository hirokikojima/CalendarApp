using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarApp.Application.UseCase.Schedule.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CalendarApp.Application.Infrastructure.Repositories.Interfaces;
using CalendarApp.Application.Domain.Entities;

namespace CalendarApp.Application.UseCase.Schedule.Update.Tests
{
    [TestClass()]
    public class ScheduleUpdateUseCaseTests
    {
        private Mock<IScheduleRepository> _mockRepository;

        private readonly int _id = 1;
        private readonly DateTime _from = new DateTime(2019, 5, 1);
        private readonly DateTime _to = new DateTime(2019, 5, 2);
        private readonly string _name = "Sample Schedule";

        private readonly DateTime _updateFrom = new DateTime(2019, 5, 3);
        private readonly DateTime _updateTo = new DateTime(2019, 5, 4);
        private readonly string _updateName = "Updated Schedule";

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IScheduleRepository>();

            _mockRepository.Setup(x => x.FindById(_id))
                .Returns(new ScheduleEntity(_id, _from, _to, _name));

            _mockRepository.Setup(x => x.Save(new ScheduleEntity(_id, _updateFrom, _updateTo, _updateName)));
        }

        [TestMethod()]
        public void HandleTest()
        {
            var usecase = new ScheduleUpdateUseCase(_mockRepository.Object);

            var inputData = new ScheduleUpdateInputData(_id, _updateFrom, _updateTo, _updateName);

            var outputData = usecase.Handle(inputData);

            try
            {
                // リポジトリが正しく呼び出されているかチェック
                _mockRepository.Verify(x => x.FindById(_id), Times.Once());
                _mockRepository.Verify(x => x.Save(It.Is<ScheduleEntity>(p => 
                    p.DateTimeFrom.Equals(_updateFrom) 
                    && p.DateTimeTo.Equals(_updateTo) 
                    && p.Name == _updateName)), Times.Once());
            }
            catch (MockException e)
            {
                Assert.Fail(e.Message);
            }

            Assert.AreEqual(outputData.Schedule.DateTimeFrom, _updateFrom);
            Assert.AreEqual(outputData.Schedule.DateTimeTo, _updateTo);
            Assert.AreEqual(outputData.Schedule.Name, _updateName);
        }
    }
}