using DriverApplication.Controllers.APIs;
using DriverApplication.DTOs.DriverAssignment;
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
   public class DriverAssignmentContollerTest
    {
        private readonly Mock<IDriverAssignmentService> mockService;
        private readonly DriverAssignmentsController driverCont;

        public DriverAssignmentContollerTest()
        {
            mockService = new Mock<IDriverAssignmentService>();
            driverCont = new DriverAssignmentsController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = driverCont.GetDriverAssignments();
            Assert.IsType<OkNegotiatedContentResult<List<DriverAssignment>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllDriverAssignment()
        {
            // Arrange
            mockService.Setup(repo => repo.GetDriverAssignments()).Returns(new List<DriverAssignment>() { new DriverAssignment(), new DriverAssignment() });

            // Act
            var okResult = driverCont.GetDriverAssignments();

            // Assert
            var driverAssignment = Assert.IsType<OkNegotiatedContentResult<List<DriverAssignment>>>(okResult);
            Assert.Equal(2, driverAssignment.Content.Count);

        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidDriverAssignment()
        {
            // Arrange
            mockService.Setup(x => x.GetDriverAssignment(1))
                       .Returns(new DriverAssignment { Assignment_id = 1 });

            // Act
            var okResult = driverCont.GetDriverAssignment(1);
            var driverAssignment = Assert.IsType<OkNegotiatedContentResult<DriverAssignment>>(okResult);


            // Assert
            Assert.Equal(1, driverAssignment.Content.Assignment_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsDriverAssignmentNotFound()
        {
            mockService.Setup(x => x.GetDriverAssignment(1))
                      .Returns(new DriverAssignment { Assignment_id = 1 });

            // Act
            IHttpActionResult actionResult = driverCont.GetDriverAssignment(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }

        [Fact]
        public void Post_InvalidModelState_CreateDriverAssignmentNeverExecutes()
        {
            driverCont.ModelState.AddModelError("Automatic_assign_type", "Automatic_assign_type is required");

            var driverAssignment = new DriverAssignmentDto {Task_id = 1, Driver_id = 1, First_name= "a", Last_name = "a", Status = "a", Task_status = "a"};

            driverCont.CreateDriverAssignment(driverAssignment);

            mockService.Verify(x => x.CreateDriverAssignment(It.IsAny<DriverAssignmentDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewDriverAssignment()
        {
            DriverAssignmentDto driverAssignment = null;

            mockService.Setup(r => r.CreateDriverAssignment(It.IsAny<DriverAssignmentDto>())).Callback<DriverAssignmentDto>(x => driverAssignment = x);

            var driverAssignmentMock = new DriverAssignmentDto { };

            driverCont.CreateDriverAssignment(driverAssignmentMock);

            mockService.Verify(x => x.CreateDriverAssignment(It.IsAny<DriverAssignmentDto>()), Times.Once);

            Assert.Equal(driverAssignment.Automatic_assign_type, driverAssignmentMock.Automatic_assign_type);
            Assert.Equal(driverAssignment.Task_id, driverAssignmentMock.Task_id);
            Assert.Equal(driverAssignment.Driver_id, driverAssignmentMock.Driver_id);
            Assert.Equal(driverAssignment.First_name, driverAssignmentMock.First_name);
            Assert.Equal(driverAssignment.Last_name, driverAssignmentMock.Last_name);
            Assert.Equal(driverAssignment.Status, driverAssignmentMock.Status);
            Assert.Equal(driverAssignment.Task_status, driverAssignmentMock.Task_status);
            
        }


        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundRespose()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = driverCont.DeleteDriverAssignment(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ValidId_ReturnsOkResult()
        {
            mockService.Setup(x => x.GetDriverAssignment(1))
                       .Returns(new DriverAssignment { Assignment_id = 1 });

            var driverAssignment = driverCont.DeleteDriverAssignment(1);

            Assert.IsType<OkNegotiatedContentResult<DriverAssignment>>(driverAssignment);
        }

        [Fact]
        public void Update_ValidDriverAssignmentIdAndDto_ComparisonShouldBeEqual()
        {
            var driverAssignmentMock = new DriverAssignmentDto { Automatic_assign_type = false, Task_id = 1, Driver_id = 1, First_name = "a", Last_name = "a", Status = "a", Task_status = "a" };

            var actionResult = driverCont.PutDriverAssignment(1, driverAssignmentMock);
            var response = actionResult as OkNegotiatedContentResult<DriverAssignmentDto>;

            Assert.NotNull(response);

            var newDriverAssignment = response.Content;
            //Assert.Equal(1, newDriver.id);
            Assert.Equal(false, newDriverAssignment.Automatic_assign_type);
            Assert.Equal(1, newDriverAssignment.Task_id);
            Assert.Equal(1, newDriverAssignment.Driver_id);
            Assert.Equal("a", newDriverAssignment.First_name);
            Assert.Equal("a", newDriverAssignment.Last_name);
            Assert.Equal("a", newDriverAssignment.Status);
            Assert.Equal("a", newDriverAssignment.Task_status);
            
        }

    }
}
