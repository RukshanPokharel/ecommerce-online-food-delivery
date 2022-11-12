using DriverApplication.DTOs.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services.Report
{
    public interface IReportService
    {
        ICollection<ReportDataDto> GetAllReports(int? driverId, int? driverTeamId, DateTime? startDate = null, DateTime? endDate = null);
    }
}