using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IDriverTeamsRepository : IRepository<DriverTeam>
    {
        string UpdateDriverTeam(int id, DriverTeamDto driverTeamDto);
        void AddDriverTeam(DriverTeamDto driverTeamDto);
        void DeleteDriverTeam(DriverTeam driverTeam);
    }
}