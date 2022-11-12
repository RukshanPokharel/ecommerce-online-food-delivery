using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.Report;

namespace DriverApplication.Repositories.ReportGenerator
{
    public interface IReportRepository
    {
        ICollection<ReportDataDto> GenerateReport(int? driverId, int? driverTeamId, DateTime? startDate, DateTime? endDate);
    }
}