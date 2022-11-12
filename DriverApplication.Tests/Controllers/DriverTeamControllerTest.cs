using DriverApplication.Controllers.APIs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Models;
using DriverApplication.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
    public class DriverTeamControllerTest
    {
        private readonly Mock<IDriverTeamsService> mockService;
        private readonly DriverTeamsController driverTeamCont;

        public DriverTeamControllerTest()
        {
            mockService = new Mock<IDriverTeamsService>();
            driverTeamCont = new DriverTeamsController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = driverTeamCont.GetDriverTeams();
            Assert.IsType<OkNegotiatedContentResult<List<DriverTeam>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllDriverTeams()
        {
            // Arrange
            mockService.Setup(repo => repo.GetDriverTeams()).Returns(new List<DriverTeam>() { new DriverTeam(), new DriverTeam(), new DriverTeam() });

            // Act
            var okResult = driverTeamCont.GetDriverTeams();

            // Assert
            var driverTeam = Assert.IsType<OkNegotiatedContentResult<List<DriverTeam>>>(okResult);
            Assert.Equal(3, driverTeam.Content.Count);
        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidDriverTeam()
        {
            // Arrange
            mockService.Setup(x => x.GetDriverTeam(1))
                       .Returns(new DriverTeam { Team_id = 1 });

            // Act
            var okResult = driverTeamCont.GetDriverTeam(1);
            var driverTeam = Assert.IsType<OkNegotiatedContentResult<DriverTeam>>(okResult);


            // Assert
            Assert.Equal(1, driverTeam.Content.Team_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsDriverTeamNotFound()
        {
            mockService.Setup(x => x.GetDriverTeam(1))
                      .Returns(new DriverTeam { Team_id = 1 });

            // Act
            IHttpActionResult actionResult = driverTeamCont.GetDriverTeam(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }

        [Fact]
        public void Post_InvalidModelState_CreateDriverTeamNeverExecutes()
        {
            driverTeamCont.ModelState.AddModelError("Team_name", "Team_Name is required");

            var driverTeam = new DriverTeamDto { Location_accuracy = "aaa", Status = "success"};

            driverTeamCont.CreateDriverTeam(driverTeam);

            mockService.Verify(x => x.CreateDriverTeam(It.IsAny<DriverTeamDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewDriverTeam()
        {
            DriverTeamDto driverTeam = null;

            mockService.Setup(r => r.CreateDriverTeam(It.IsAny<DriverTeamDto>())).Callback<DriverTeamDto>(x => driverTeam = x);

            var driverTeamMock = new DriverTeamDto {Team_name="TeamCorazon", Location_accuracy = "aaa", Status = "success" };

            driverTeamCont.CreateDriverTeam(driverTeamMock);

            mockService.Verify(x => x.CreateDriverTeam(It.IsAny<DriverTeamDto>()), Times.Once);

            Assert.Equal(driverTeam.Team_name, driverTeamMock.Team_name);
            Assert.Equal(driverTeam.Location_accuracy, driverTeamMock.Location_accuracy);
            Assert.Equal(driverTeam.Status, driverTeamMock.Status);
            
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundRespose()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = driverTeamCont.DeleteDriverTeam(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ValidId_ReturnsOkResult()
        {
            mockService.Setup(x => x.GetDriverTeam(1))
                       .Returns(new DriverTeam { Team_id = 1 });

            var driverTeam = driverTeamCont.DeleteDriverTeam(1);

            Assert.IsType<OkNegotiatedContentResult<DriverTeam>>(driverTeam);
        }

        [Fact]
        public void Update_ValidDriverTeamIdAndDto_ComparisonShouldBeEqual()
        {
            var driverTeamMock = new DriverTeamDto { Team_name = "TeamCora", Location_accuracy ="kapan", Status = "Success"};

            var actionResult = driverTeamCont.PutDriverTeam(1, driverTeamMock);
            var response = actionResult as OkNegotiatedContentResult<DriverTeamDto>;

            Assert.NotNull(response);

            var newDriverTeam = response.Content;
            //Assert.Equal(1, newDriver.id);
            Assert.Equal("TeamCora", newDriverTeam.Team_name);
            Assert.Equal("kapan", newDriverTeam.Location_accuracy);
            Assert.Equal("Success", newDriverTeam.Status);
            
        }
    }
}
