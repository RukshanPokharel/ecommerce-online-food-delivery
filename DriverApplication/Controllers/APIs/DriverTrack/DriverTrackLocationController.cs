using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Models;
using DriverApplication.Services.DriverTrack;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs.DriverTrack
{
    [Authorize]
    [Route("driverTrackLocation")]
    public class DriverTrackLocationController : ApiController
    {
        private IDriverTrackService driverTrackService;
        public DriverTrackLocationController(IDriverTrackService driverTrackService)
        {
            this.driverTrackService = driverTrackService;
        }

        [HttpPost]
        [Route("driverTrackLocation")]
        [ResponseType(typeof(TrackLocation))]
        public IHttpActionResult CreateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));

            }
            if (driverTrackLocationDto != null)
            {

                driverTrackService.CreateDriverTrackLocation(driverTrackLocationDto);
                driverTrackService.SaveDriverTrackLocation();
                return Ok(driverTrackLocationDto);

            }
            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }
    }
}
