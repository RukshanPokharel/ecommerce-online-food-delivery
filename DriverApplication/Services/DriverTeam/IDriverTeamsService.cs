using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services
{
    public interface IDriverTeamsService
    {
        IEnumerable<DriverTeam> GetDriverTeams();
        DriverTeam GetDriverTeam(int id);
        void CreateDriverTeam(DriverTeamDto driverTeamDto);
        string PutDriverTeam(int id, DriverTeamDto driverTeamDto);
        void SaveDriverTeam();
        void DeleteDriverTeam(DriverTeam driverTeam);
    }
}