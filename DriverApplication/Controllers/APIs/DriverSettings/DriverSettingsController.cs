using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Services.DriverAssignmentSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriverApplication.Controllers.APIs.AssignmentSettings
{
    [Authorize]
    [Route("DriverSettings")]
    public class DriverSettingsController : ApiController
    {
        private IDriverSettingsService driverSettingsService;
        public DriverSettingsController(IDriverSettingsService driverSettingsService)
        {
            this.driverSettingsService = driverSettingsService;
        }

        [HttpPut]
        [Route("DriverSettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverAssignmentSettings(DriverAssignmentSettingsDto driverAssignmentSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (driverAssignmentSettingsDto != null)
            {
                driverSettingsService.UpdateDriverAssignmentSettings(driverAssignmentSettingsDto);
                driverSettingsService.SaveDriverAssignmentSettings();
                return Ok(driverAssignmentSettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpPut]
        [Route("DriverNotificationSettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverNotificationSettings(DriverNotificationSettingsDto driverNotificationSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverNotificationSettingsDto != null)
            {
                driverSettingsService.UpdateDriverNotificationSettings(driverNotificationSettingsDto);
                driverSettingsService.SaveDriverNotificationSettings();
                return Ok(driverNotificationSettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpPut]
        [Route("DriverGeneralSettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverGeneralSettings(DriverGeneralSettingsDto driverGeneralSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverGeneralSettingsDto != null)
            {
                driverSettingsService.UpdateDriverGeneralSettings(driverGeneralSettingsDto);
                driverSettingsService.SaveDriverGeneralSettings();
                return Ok(driverGeneralSettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpPut]
        [Route("DriverMapApiKeySettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverMapApiKeySettings(int id, DriverMapApiKeySettingsDto driverMapApiKeySettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverMapApiKeySettingsDto != null)
            {
                driverSettingsService.UpdateDriverMapApiKeySettings(id,driverMapApiKeySettingsDto);
                driverSettingsService.SaveDriverMapApiSettings();
                return Ok(driverMapApiKeySettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpPut]
        [Route("DriverMapSettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverMapSettings(int id, DriverMapSettingsDto driverMapSettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverMapSettingsDto != null)
            {
                driverSettingsService.UpdateDriverMapSettings(id,driverMapSettingsDto);
                driverSettingsService.SaveDriverMapSettings();
                return Ok(driverMapSettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        [HttpPut]
        [Route("DriverPushLegacySettings")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverPushLegacySettings(int id, DriverPushLegacySettingsDto driverPushLegacySettingsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (driverPushLegacySettingsDto != null)
            {
                driverSettingsService.UpdateDriverPushLegacySettings(id, driverPushLegacySettingsDto);
                driverSettingsService.SaveDriverPushLegacySettings();
                return Ok(driverPushLegacySettingsDto);
            }
            else
            {
                var message = string.Format("please try again with valid properties");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

    }
}
