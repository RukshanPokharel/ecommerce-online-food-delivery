using DriverApplication.Models.EmailLogs;
using DriverApplication.Services.EmailLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs.EmailLogs
{
    [Authorize]
    [Route("emailLog")]
    public class EmailLogController : ApiController
    {
        private IEmailLogService emailLogsService;
        public EmailLogController(IEmailLogService emailLogsService)
        {
            this.emailLogsService = emailLogsService;
        }

        [HttpGet]
        [Route("emailLog")]
        [ResponseType(typeof(EmailLogEntity))]
        public IHttpActionResult GetEmailLogs()
        {
            try
            {
                IEnumerable<EmailLogEntity> emailLog = emailLogsService.GetEmailBySubject();
                return Ok(emailLog.ToList());
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.NotFound, "Email Not Found");
            }

            //if (emailLogs == null)
            //{
            //    // exception handling using HttpError with HttpResponseException..
            //    var message = string.Format("your search subject is not availabe. try again with a valid email subject.", subjectName);
            //    throw new HttpResponseException(
            //        Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            //}

            //return Ok(emailLogs);
        }

    }
}
