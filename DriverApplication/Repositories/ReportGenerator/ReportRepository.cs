using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.Report;
using DriverApplication.Models;
using DriverApplication.Utilities;

namespace DriverApplication.Repositories.ReportGenerator
{
    public class ReportRepository : RepositoryBase<DriverTask>, IReportRepository
    {
        public ReportRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ICollection<ReportDataDto> GenerateReport(int? driverId, int? driverTeamId, DateTime? startDate, DateTime? endDate)
        {

            List<ReportDataDto> reportDataDtoList = new List<ReportDataDto>();

            var task = this.DbContext.mt_driver_task.Where(o => (o.Date_created >= startDate && o.Date_created <= endDate && driverId == null && driverTeamId == null) || ((o.Date_created >= startDate && o.Date_created <= endDate) && (o.Team_id == driverTeamId || (o.Team_id == driverTeamId && o.Driver_id == driverId)))).GroupBy(s => (s.Status))
                .Select(x => new
                {
                    Status = x.Key,
                    Total = x.Count()

                }).ToList();

            foreach (var items in task)
            {
                ReportDataDto reportDataDto = new ReportDataDto();
                reportDataDto.status = items.Status;
                reportDataDto.totalTasks = items.Total;

                reportDataDtoList.Add(reportDataDto);
            }

            return reportDataDtoList;
        }

    }
}