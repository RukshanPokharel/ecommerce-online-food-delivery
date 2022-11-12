using DriverApplication.DTOs.MapsApiLogs;
using DriverApplication.Models;
using DriverApplication.Services.MapsApiLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs.MapsApiLog
{
    public class MapsApiLogController : ApiController
    {
        private IMapsApiLogService mapsApiLogService;
        public MapsApiLogController(IMapsApiLogService mapsApiLogService)
        {
            this.mapsApiLogService = mapsApiLogService;
        }

        [HttpPost]
        [Route("mapsApiLogs")]
        [ResponseType(typeof(MapsApiCall))]
        public IHttpActionResult CreateDriverMapsApiLogs(MapsApiLogDto mapsApiCallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
            }
            if (mapsApiCallDto != null)
            {
                mapsApiLogService.AddDriverMapsApiLogs(mapsApiCallDto);
                mapsApiLogService.SaveDriverMapsApiLogs();
                return Ok(mapsApiCallDto);

            }

            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }

    }
}
