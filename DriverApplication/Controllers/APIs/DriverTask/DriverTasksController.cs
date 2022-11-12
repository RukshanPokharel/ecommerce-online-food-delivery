using DriverApplication.DTOs;
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
    [Route("tasks")]
    public class DriverTasksController : ApiController
    {
        private IDriverTasksService driverTaskService;
        public DriverTasksController(IDriverTasksService driverTaskService)
        {
            this.driverTaskService = driverTaskService;
        }

        // GET all driverTasks.
        [HttpGet]
        [Route("tasks")]
        public IHttpActionResult GetDriverTasks()
        {
            try
            {
                IEnumerable<DriverTask> driverTask = driverTaskService.GetDriverTasks();
                return Ok(driverTask.ToList());

            }
            catch (Exception)
            {

                return Content(HttpStatusCode.NotFound, "Driver team Not Found");
            }
        }


        // GET: api/DriverTask/5
        [HttpGet]
        [Route("tasks/{id}")]
        [ResponseType(typeof(DriverTask))]
        public IHttpActionResult GetDriverTask(int id)
        {
            DriverTask driverTask = driverTaskService.GetDriverTask(id);

            if (driverTask == null)
            {
                return NotFound();

                // exception handling using HttpResponseException..
                //var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent(string.Format("your search id is not availabe. try again with a valid driver task id.")),
                //    ReasonPhrase = "DriverTask not found"
                //};

                //throw new HttpResponseException(msg);


                // exception handling using HttpError with HttpResponseException..
                //var message = string.Format("your search id is not availabe. try again with a valid driver task id.", id);
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            }

            return Ok(driverTask);
        }

        // POST: api/DriversTask
        [NotImplExceptionFilter]
        [HttpPost]
        [Route("tasks")]
        [ResponseType(typeof(DriverTask))]
        public IHttpActionResult CreateDriverTask(DriverTaskDto driverTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));

            }
            if (driverTaskDto != null)
            {
                driverTaskService.CreateDriverTask(driverTaskDto);
                driverTaskService.SaveDriverTask();
                return Ok(driverTaskDto);

            }

            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

        }

        [HttpPut]
        [Route("tasks")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverTask(int id, DriverTaskDto driverTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (driverTaskDto != null)
            {
                driverTaskService.PutDriverTask(id, driverTaskDto);
                driverTaskService.SaveDriverTask();

                return Ok(driverTaskDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            
        }

        [HttpPut]
        [Route("tasksStatus")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverTaskStatus(int id, string status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (status != null)
            {
                driverTaskService.PutDriverTaskStatus(id, status);
                driverTaskService.SaveDriverTaskStatus();

                return Ok(status);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }   
        }

        [HttpPut]
        [Route("reassignTask")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateDriverReassignTask(int id, int driverTeamId, int driverId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (driverTeamId != 0 && driverId != 0)
            {
                //driver.Driver_id = id;
                driverTaskService.UpdateDriverReassignTask(id, driverTeamId, driverId);
                driverTaskService.SaveDriverReassignTask();

                return Ok();
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpDelete]
        [Route("tasks")]
        [ResponseType(typeof(DriverTask))]
        public IHttpActionResult DeleteDriverTask(int id)
        {
            DriverTask driverTask = driverTaskService.GetDriverTask(id);
            if (driverTask == null)
            {
                return NotFound();
            }

            driverTaskService.DeleteDriverTask(driverTask);
            driverTaskService.SaveDriverTask();
            
            return Ok(driverTask);
        }
    }
}
