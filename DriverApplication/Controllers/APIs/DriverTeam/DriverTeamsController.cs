using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Filters;
using DriverApplication.Models;
using DriverApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs
{
    [Authorize]
    [Route("teams")]
    public class DriverTeamsController : ApiController
    {
        private IDriverTeamsService driverTeamsService;       
        public DriverTeamsController (IDriverTeamsService driverTeamsService)
        {
            this.driverTeamsService = driverTeamsService;
        }

        [HttpGet]
        [Route("teams")]
        public async Task<IHttpActionResult> GetDriverTeams()
        {
            try
            {
                IEnumerable<DriverTeam> driverTeam = driverTeamsService.GetDriverTeams();
                return Ok(driverTeam.ToList());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, "Driver team Not Found");
            }
        }

        [HttpGet]
        [Route("teams/{id}")]
        [ResponseType(typeof(DriverTeam))]
        public IHttpActionResult GetDriverTeam(int id)
        {
            DriverTeam driverTeam = driverTeamsService.GetDriverTeam(id);

            if (driverTeam == null)
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
                //var message = string.Format("your search id is not availabe. try again with a valid driver team id.", id);
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));

            }

            return Ok(driverTeam);
        }


        [NotImplExceptionFilter]
        [HttpPost]
        [Route("teams")]
        [ResponseType(typeof(DriverTeam))]
        public IHttpActionResult CreateDriverTeam(DriverTeamDto driverTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                // exception handling using HttpError with HttpResponseException..
                //var message1 = string.Format("please try again with valid properties");
                //throw new HttpResponseException(
                //    Request.CreateErrorResponse(HttpStatusCode.NotFound, message1));

            }
            if (driverTeamDto != null)
            {
                driverTeamsService.CreateDriverTeam(driverTeamDto);
                driverTeamsService.SaveDriverTeam();
                return Ok(driverTeamDto);

            }
            var message = string.Format("please try again with valid properties");
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }


        [HttpPut]
        [Route("teams")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverTeam(int id, DriverTeamDto driverTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverTeamDto != null)
            {
                //driver.Driver_id = id;
                string msg = driverTeamsService.PutDriverTeam(id, driverTeamDto);
                driverTeamsService.SaveDriverTeam();

                return Ok(driverTeamDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpDelete]
        [Route("teams")]
        [ResponseType(typeof(DriverTeam))]
        public IHttpActionResult DeleteDriverTeam(int id)
        {
            DriverTeam driverTeam = driverTeamsService.GetDriverTeam(id);
            if (driverTeam == null)
            {
                return NotFound();
            }

                driverTeamsService.DeleteDriverTeam(driverTeam);
                driverTeamsService.SaveDriverTeam();

            return Ok(driverTeam);
        }
    }
}
