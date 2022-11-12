using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class DriverTeamsService : IDriverTeamsService
    {
        private readonly IDriverTeamsRepository driversTeamsRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverTeamsService(IDriverTeamsRepository driversTeamsRepository, IUnitOfWork unitOfWork)
        {
            this.driversTeamsRepository = driversTeamsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDriverTeam(DriverTeamDto driverTeamDto)
        {
            driversTeamsRepository.AddDriverTeam(driverTeamDto);
        }

        public void DeleteDriverTeam(DriverTeam driverTeam)
        {
             driversTeamsRepository.DeleteDriverTeam(driverTeam);

        }

        public DriverTeam GetDriverTeam(int id)
        {
            return driversTeamsRepository.GetById(id);
        }

        public IEnumerable<DriverTeam> GetDriverTeams()
        {
            return driversTeamsRepository.GetAll();
        }

        public string PutDriverTeam(int id, DriverTeamDto driverTeamDto)
        {
            return driversTeamsRepository.UpdateDriverTeam(id, driverTeamDto);
        }

        public void SaveDriverTeam()
        {
            unitOfWork.Commit();
        }
    }
}