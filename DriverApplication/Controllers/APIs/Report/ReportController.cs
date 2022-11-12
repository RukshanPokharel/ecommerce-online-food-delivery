using DriverApplication.DTOs.Report;
using DriverApplication.Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriverApplication.Controllers.APIs.ReportController
{
    public class ReportController : ApiController
    {
        private IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        [Route("report")]
        public ICollection<ReportDataDto> GetAllReports([FromUri]int? driverId = null, [FromUri]int? driverTeamId = null, [FromUri]DateTime? startDate = null, [FromUri]DateTime? endDate = null)
        {
                return reportService.GetAllReports(driverId, driverTeamId, startDate, endDate).ToList();
        }
    }
}
