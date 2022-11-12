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
    [Route("bulkPush")]
    public class BulkPushController : ApiController
    {
        private IBulkPushService bulkPushService;
        public BulkPushController(IBulkPushService bulkPushService)
        {
            this.bulkPushService = bulkPushService;
        }

        
        [HttpGet]
        [Route("bulkPush")]
        public IHttpActionResult GetAllBulkPush()
        {
            try
            {
                IEnumerable<BulkPush> bulkPush = bulkPushService.GetAllBulkPush();
                return Ok(bulkPush.ToList());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, "Bulk Push Not Found");
            }
        }

        [HttpGet]
        [Route("bulkPush/{id}")]
        [ResponseType(typeof(BulkPush))]
        public IHttpActionResult GetBulkPush(int id)
        {
            BulkPush bulkPush = bulkPushService.GetBulkPush(id);

            if (bulkPush == null)
            {
                return NotFound();
                //var message = string.Format("your search id is not availabe. try again with a valid bulk push id.", id);
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            }

            return Ok(bulkPush);
        }

        [NotImplExceptionFilter]
        [HttpPost]
        [Route("bulkPush")]
        [ResponseType(typeof(BulkPush))]
        public IHttpActionResult AddBulkPush(BulkPushDto bulkPushDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
            }
            if (bulkPushDto != null)
            {
                bulkPushService.AddBulkPush(bulkPushDto);
                bulkPushService.SaveBulkPush();
                return Ok(bulkPushDto);

            }

            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }

        [HttpPut]
        [Route("bulkPush")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBulkPush(int id, BulkPushDto bulkPushDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bulkPushDto != null)
            {
                bulkPushService.PutBulkPush(id, bulkPushDto);
                bulkPushService.SaveBulkPush();

                return Ok(bulkPushDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }

        }

        [HttpDelete]
        [Route("bulkPush")]
        [ResponseType(typeof(BulkPush))]
        public IHttpActionResult DeleteBulkPush(int id)
        {
            BulkPush bulkPush = bulkPushService.GetBulkPush(id);
            if (bulkPush == null)
            {
                return NotFound();
            }

            bulkPushService.DeleteBulkPush(bulkPush);
            bulkPushService.SaveBulkPush();
           
            return Ok(bulkPush);
        }

    }
}
