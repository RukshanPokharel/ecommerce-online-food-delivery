using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.Filters;
using DriverApplication.Models;
using DriverApplication.Services;
using DriverApplication.Utilities;

namespace DriverApplication.Controllers
{
    //[Authorize]
    [NotImplExceptionFilter]
    [Route("drivers")]
    public class DriversController : ApiController
    {
        private DBContext db = new DBContext();

        private IDriverService driverService;
        public DriversController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        /// <summary>
        /// Get all available drivers 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("drivers")]
        public async Task<IHttpActionResult> GetDrivers()
        {
            try
            {
                IEnumerable<Driver> drivers = driverService.GetDrivers();
                return Ok(drivers.ToList());
            }
            catch (ArgumentException)
            {
                return Content(HttpStatusCode.NotFound, "Drivers Not Found");
            }
        }

        /// <summary>
        ///  get single driver with a particular id
        /// </summary>
        /// <param name="id">
        /// this is driver unique id
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("drivers/{id}")]
        [ResponseType(typeof(Driver))]
        public IHttpActionResult GetDriver(int id)
        {
            Driver driver = driverService.GetDriver(id);

            //Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                // exception handling using HttpResponseException..
                //var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent(string.Format("your search id is not availabe. try again with a valid driver id.")),
                //    ReasonPhrase = "Driver not found"
                //};

                //throw new HttpResponseException(msg);

                // exception handling using HttpError with HttpResponseException..
                //var message = string.Format("your search id is not availabe. try again with a valid driver id.", id);
                //throw new HttpResponseException(

                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            return NotFound();
            }

            return Ok(driver);
        }

        /// <summary>
        /// update existing driver by passing respective driver id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driverDto"></param>
        /// <returns></returns>    
        [HttpPut]
        [Route("drivers")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriver(int id, DriverDto driverDto)
        {
            if (!ModelState.IsValid)
            {   
                return BadRequest(ModelState);
            }

            if (driverDto != null)
            {
                driverService.PutDriver(id,driverDto);
                driverService.SaveDriver();

                return Ok(driverDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }           
        }

        /// <summary>
        /// Add new driver into database
        /// </summary>
        /// <param name="driverDto"></param>
        /// <returns></returns>
        [NotImplExceptionFilter]
        [HttpPost]
        [Route("drivers")]
        [ResponseType(typeof(Driver))]
        public IHttpActionResult CreateDriver(DriverDto driverDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                //// exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
            }

            if(driverDto != null)
            {
                driverService.AddDriver(driverDto);
                driverService.SaveDriver();
                return Ok(driverDto);

            }

            var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }

        //[HttpPost]
        //[Route("driversLogin")]
        //[ResponseType(typeof(Driver))]
        //public IHttpActionResult DriverLogin(DriverLoginDto driverLoginDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //return BadRequest(ModelState);
        //        // exception handling using HttpError with HttpResponseException..
        //        var message1 = string.Format("please try again with valid properties");
        //        throw new HttpResponseException(
        //            Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));
        //    }

        //    if(driverLoginDto != null)
        //    {
        //        string token = driverService.DriverLogin(driverLoginDto);
        //        driverLoginDto.token = token;
        //        return Ok(driverLoginDto);

        //    }

        //    var message = string.Format("please try again with valid properties");
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        //}

        /// <summary>
        /// delete driver using particular driver id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("drivers")]
        [ResponseType(typeof(Driver))]
        public IHttpActionResult DeleteDriver(int id)
        {
            Driver driver = driverService.GetDriver(id);
            if (driver == null)
            {
                return NotFound();
            }

            driverService.DeleteDriver(driver);
            driverService.SaveDriver();
            
            return Ok(driver);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DriverExists(int id)
        //{
        //    return db.mt_driver.Count(e => e.Driver_id == id) > 0;
        //}
    }
}