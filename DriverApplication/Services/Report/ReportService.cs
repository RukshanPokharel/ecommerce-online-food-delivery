using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.Report;
using DriverApplication.Repositories.ReportGenerator;

namespace DriverApplication.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public ICollection<ReportDataDto> GetAllReports(int? driverId, int? driverTeamId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return reportRepository.GenerateReport(driverId, driverTeamId, startDate, endDate).ToList();
        }
    }
}