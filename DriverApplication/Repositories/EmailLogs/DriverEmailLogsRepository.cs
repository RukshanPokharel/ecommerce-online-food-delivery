using DriverApplication.Models.EmailLogs;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.EmailLogs
{
    public class DriverEmailLogsRepository : RepositoryBase<EmailLogEntity>, IDriverEmailLogsRepository
    {
        public DriverEmailLogsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<EmailLogEntity> GetEmailBySubject()
        {
            //return this.DbContext.mt_email_log.Where(el => el.Subject == subjectName).ToList();
            return this.DbContext.mt_email_log.Where(el => (el.Subject == "ASSIGN TASK") && (el.Subject == "DELIVERY SUCCESSFUL")).ToList();
            //return this.DbContext.mt_email_log.Where(el => el.Subject.Equals(subjectName.Equals("ASSIGN TASK") || subjectName.Equals("DELIVERY SUCCESSFUL"))).ToList();
        }
    }
}