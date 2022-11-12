using DriverApplication.Models;
using DriverApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs
{
    [Authorize]
    [Route("pushLog")]
    public class PushLogController : ApiController
    {
        private IPushLogService pushLogService;
        public PushLogController(IPushLogService pushLogService)

        {
            this.pushLogService = pushLogService;
        }

        [HttpGet]
        [Route("pushLog")]
        public IHttpActionResult GetAllPushLog()
        {
            try
            {
                IEnumerable<PushLog> pushLog = pushLogService.GetAllPushLog();
                return Ok(pushLog.ToList());
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.NotFound, "Driver Assignment Not Found");
            }
        }

        [HttpGet]
        [Route("pushLog/{id}")]
        [ResponseType(typeof(PushLog))]
        public IHttpActionResult GetPushLog(int id)
        {
            PushLog pushLog = pushLogService.GetPushLog(id);

            if (pushLog == null)
            {
                return NotFound();
                //var message = string.Format("your search id is not availabe. try again with a valid push log id.", id);
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }

            return Ok(pushLog);
        }


    }
}
