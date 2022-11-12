using DriverApplication.DTOs.DriverAssignment;
using DriverApplication.Filters;
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
    [Route("assignment")]
    public class DriverAssignmentsController : ApiController
    {
        private IDriverAssignmentService driverAssignmentService;
        public DriverAssignmentsController(IDriverAssignmentService driverAssignmentService)
        {
            this.driverAssignmentService = driverAssignmentService;
        }

        [HttpGet]
        [Route("assignment")]
        public IHttpActionResult GetDriverAssignments()
        {
            try
            {
                IEnumerable<DriverAssignment> driverAssignments = driverAssignmentService.GetDriverAssignments();
                return Ok(driverAssignments.ToList());
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.NotFound, "Driver Assignment Not Found");
            }
        }

        [HttpGet]
        [Route("assignment/{id}")]
        [ResponseType(typeof(DriverAssignment))]
        public IHttpActionResult GetDriverAssignment(int id)
        {
            DriverAssignment driverAssignment = driverAssignmentService.GetDriverAssignment(id);

            if (driverAssignment == null)
            {
                return NotFound();
                //var message = string.Format("your search id is not availabe. Try again with a valid driver assignment id.", id);
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            }

            return Ok(driverAssignment);
        }

        [NotImplExceptionFilter]
        [HttpPost]
        [Route("assignment")]
        [ResponseType(typeof(DriverAssignment))]
        public IHttpActionResult CreateDriverAssignment(DriverAssignmentDto driverAssignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                //// exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
            }
            if (driverAssignmentDto != null)
            {
                driverAssignmentService.CreateDriverAssignment(driverAssignmentDto);
                driverAssignmentService.SaveDriverAssignment();
                return Ok(driverAssignmentDto);

            }

            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }

        [HttpPut]
        [Route("assignment")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverAssignment(int id, DriverAssignmentDto driverAssignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverAssignmentDto != null)
            {
                string msg = driverAssignmentService.PutDriverAssignment(id, driverAssignmentDto);
                driverAssignmentService.SaveDriverAssignment();
                return Ok(driverAssignmentDto);

            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpDelete]
        [Route("assignment")]
        [ResponseType(typeof(DriverAssignment))]
        public IHttpActionResult DeleteDriverAssignment(int id)
        {
            DriverAssignment driverAssignment = driverAssignmentService.GetDriverAssignment(id);
            if (driverAssignment == null)
            {
                return NotFound();
            }

            driverAssignmentService.DeleteDriverAssignment(driverAssignment);
            driverAssignmentService.SaveDriverAssignment();
            
            return Ok(driverAssignment);
        }
    }
}
