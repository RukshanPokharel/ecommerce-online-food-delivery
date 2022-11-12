using DriverApplication.DTOs.SMSLogs;
using DriverApplication.Models;
using DriverApplication.Services.SmsLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs.SmsLog
{
    [Authorize]
    [Route("smsLogs")]
    public class SmsLogsController : ApiController
    {
        private IDriverSmsLogsService driverSmsLogsService;
        public SmsLogsController(IDriverSmsLogsService driverSmsLogsService)
        {
            this.driverSmsLogsService = driverSmsLogsService;
        }

        [HttpPost]
        [Route("smsLogs")]
        [ResponseType(typeof(SmsLogs))]
        public IHttpActionResult CreateDriverSmsLogs(SmsLogsDto driverSmsLogsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
            }
            if (driverSmsLogsDto != null)
            {
                driverSmsLogsService.AddDriverSmsLogs(driverSmsLogsDto);
                driverSmsLogsService.SaveDriverSmsLogs();
                return Ok(driverSmsLogsDto);

            }

            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }

        }
}
