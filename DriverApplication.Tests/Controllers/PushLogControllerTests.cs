using DriverApplication.Controllers.APIs;
using DriverApplication.Models;
using DriverApplication.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
   public class PushLogControllerTests
   {
        private readonly Mock<IPushLogService> mockService;
        private readonly PushLogController pushLogCont;

        public PushLogControllerTests()
        {
            mockService = new Mock<IPushLogService>();
            pushLogCont = new PushLogController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = pushLogCont.GetAllPushLog();
            Assert.IsType<OkNegotiatedContentResult<List<PushLog>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllPushLog()
        {
            // Arrange
            mockService.Setup(repo => repo.GetAllPushLog()).Returns(new List<PushLog>() { new PushLog(), new PushLog() });

            // Act
            var okResult = pushLogCont.GetAllPushLog();

            // Assert
            var pushLog = Assert.IsType<OkNegotiatedContentResult<List<PushLog>>>(okResult);
            Assert.Equal(2, pushLog.Content.Count);

        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidPushLog()
        {
            // Arrange
            mockService.Setup(x => x.GetPushLog(1))
                       .Returns(new PushLog { Push_id = 1 });

            // Act
            var okResult = pushLogCont.GetPushLog(1);
            var pushLog = Assert.IsType<OkNegotiatedContentResult<PushLog>>(okResult);


            // Assert
            Assert.Equal(1, pushLog.Content.Push_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsPushLogNotFound()
        {
            mockService.Setup(x => x.GetPushLog(1))
                      .Returns(new PushLog { Push_id = 1 });

            // Act
            IHttpActionResult actionResult = pushLogCont.GetPushLog(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }
    }
}
