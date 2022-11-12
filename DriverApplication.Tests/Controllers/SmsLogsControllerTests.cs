using DriverApplication.Controllers.APIs.SmsLog;
using DriverApplication.DTOs.SMSLogs;
using DriverApplication.Services.SmsLog;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
    public class SmsLogsControllerTests
    {
        private readonly Mock<IDriverSmsLogsService> mockService;
        private readonly SmsLogsController smsLogsCont;

        public SmsLogsControllerTests()
        {
            mockService = new Mock<IDriverSmsLogsService>();
            smsLogsCont = new SmsLogsController(mockService.Object);
        }

        [Fact]
        public void Post_InvalidModelState_CreateSmsLogsNeverExecutes()
        {
            smsLogsCont.ModelState.AddModelError("Contact_phone", "phone is required");

            var smsLogDto = new SmsLogsDto { Sms_message = "a", Status = "a", Gateway = "a", Gateway_response = "a" };

            smsLogsCont.CreateDriverSmsLogs(smsLogDto);

            mockService.Verify(x => x.AddDriverSmsLogs(It.IsAny<SmsLogsDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewSmsLogs()
        {
            SmsLogsDto smsLog = null;

            mockService.Setup(r => r.AddDriverSmsLogs(It.IsAny<SmsLogsDto>())).Callback<SmsLogsDto>(x => smsLog = x);

            var smsLogMock = new SmsLogsDto { Contact_phone = "a", Sms_message = "a", Status = "a", Gateway = "a", Gateway_response = "a" };

            smsLogsCont.CreateDriverSmsLogs(smsLogMock);

            mockService.Verify(x => x.AddDriverSmsLogs(It.IsAny<SmsLogsDto>()), Times.Once);

            Assert.Equal(smsLog.Contact_phone, smsLogMock.Contact_phone);
            Assert.Equal(smsLog.Sms_message, smsLogMock.Sms_message);
            Assert.Equal(smsLog.Status, smsLogMock.Status);
            Assert.Equal(smsLog.Gateway, smsLogMock.Gateway);
            Assert.Equal(smsLog.Gateway_response, smsLogMock.Gateway_response);

        }

    }
}
