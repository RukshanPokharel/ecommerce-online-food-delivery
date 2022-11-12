using DriverApplication.Controllers.APIs.EmailLogs;
using DriverApplication.Models.EmailLogs;
using DriverApplication.Services.EmailLogs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
    public class EmailLogControllerTest
    {
        private readonly Mock<IEmailLogService> mockService;
        private readonly EmailLogController emailLogCont;

        public EmailLogControllerTest()
        {
            mockService = new Mock<IEmailLogService>();
            emailLogCont = new EmailLogController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // act
            var okResult = emailLogCont.GetEmailLogs();

            Assert.IsType<OkNegotiatedContentResult<List<EmailLogEntity>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllEmailLog()
        {
            // Arrange
            mockService.Setup(repo => repo.GetEmailBySubject()).Returns(new List<EmailLogEntity>() { new EmailLogEntity(), new EmailLogEntity() });

            // Act
            var okResult = emailLogCont.GetEmailLogs();

            // Assert
            var emailLog = Assert.IsType<OkNegotiatedContentResult<List<EmailLogEntity>>>(okResult);
            Assert.Equal(2, emailLog.Content.Count);

        }


    }
}
