using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarPicker.Controllers;
using CalendarPicker.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CalendarPicker.Tests
{
    public class ControllerTests
    {
        private DateSelection SetupEntity()
        {
            return new DateSelection
            {
                SelectedDates = new[]
                    {DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3), DateTime.Now.AddDays(5)}
            };
        }

        private IEnumerable<DateSelection> SetupEntitySet()
        {
            return new[] {SetupEntity(), SetupEntity(), SetupEntity()};
        }

        private DateSelection SetupEmptyEntity()
        {
            return new DateSelection
            {
                SelectedDates = Array.Empty<DateTime>()
            };
        }

        [Fact]
        public async Task StoredDatesController_Add_Success()
        {
            var repositoryMoq = new Mock<IRepository<DateSelection>>();
            repositoryMoq.Setup(x => x.Add(It.IsAny<DateSelection>())).Returns(Task.CompletedTask).Verifiable();
            var controller = new StoredDatesController(repositoryMoq.Object);
            var baseresult = await controller.AddDateSelection(SetupEntity());
            var result = Assert.IsType<OkResult>(baseresult);
            Assert.Equal(200, result.StatusCode);
            repositoryMoq.Verify();
        }

        [Fact]
        public async Task StoredDatesController_Add_Not_Success()
        {
            var repositoryMoq = new Mock<IRepository<DateSelection>>();
            repositoryMoq.Setup(x => x.Add(It.IsAny<DateSelection>())).Returns(Task.CompletedTask);
            var controller = new StoredDatesController(repositoryMoq.Object);
            var baseresult = await controller.AddDateSelection(SetupEmptyEntity());
            var result = Assert.IsType<BadRequestResult>(baseresult);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task StoredDatesController_GetAll_Success()
        {
            var repositoryMoq = new Mock<IRepository<DateSelection>>();
            repositoryMoq.Setup(x => x.GetAll()).ReturnsAsync(SetupEntitySet()).Verifiable();
            var controller = new StoredDatesController(repositoryMoq.Object);
            var baseresult = await controller.GetDateSelections();
            Assert.NotNull(baseresult);
            Assert.True(baseresult.Any());
            repositoryMoq.Verify();
        }
    }
}
