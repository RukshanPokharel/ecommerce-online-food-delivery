using DriverApplication.Models.EmailLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.EmailLogs
{
    public interface IDriverEmailLogsRepository : IRepository<EmailLogEntity>
    {
        IEnumerable<EmailLogEntity> GetEmailBySubject();
    }
}