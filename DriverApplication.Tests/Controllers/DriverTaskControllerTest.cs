using DriverApplication.Controllers.APIs;
using DriverApplication.DTOs;
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
   public class DriverTaskControllerTest
    {
        private readonly Mock<IDriverTasksService> mockService;
        private readonly DriverTasksController driverTaskCont;

        public DriverTaskControllerTest()
        {
            mockService = new Mock<IDriverTasksService>();
            driverTaskCont = new DriverTasksController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = driverTaskCont.GetDriverTasks();
            Assert.IsType<OkNegotiatedContentResult<List<DriverTask>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllDriverTask()
        {
            // Arrange
            mockService.Setup(repo => repo.GetDriverTasks()).Returns(new List<DriverTask>() { new DriverTask(), new DriverTask() });

            // Act
            var okResult = driverTaskCont.GetDriverTasks();

            // Assert
            var driverTask = Assert.IsType<OkNegotiatedContentResult<List<DriverTask>>>(okResult);
            Assert.Equal(2, driverTask.Content.Count);

        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidDriverTask()
        {
            // Arrange
            mockService.Setup(x => x.GetDriverTask(1))
                       .Returns(new DriverTask { Task_id = 1 });

            // Act
            var okResult = driverTaskCont.GetDriverTask(1);
            var driverTask = Assert.IsType<OkNegotiatedContentResult<DriverTask>>(okResult);


            // Assert
            Assert.Equal(1, driverTask.Content.Task_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsDriverTaskNotFound()
        {
            mockService.Setup(x => x.GetDriverTask(1))
                      .Returns(new DriverTask { Task_id = 1 });

            // Act
            IHttpActionResult actionResult = driverTaskCont.GetDriverTask(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }

        [Fact]
        public void Post_InvalidModelState_CreateDriverTaskNeverExecutes()
        {
            driverTaskCont.ModelState.AddModelError("Order_id", "Order Id is required");

            var driverTask = new DriverTaskDto { Task_description = "a", Trans_type = "a", Contact_number = "77", Email_address = "a", Customer_name = "c", Team_id = 1, Delivery_date = DateTime.Now, Delivery_address = "a", Driver_id = 1, Dropoff_merchant = 1, Dropoff_contact_name = "A", Dropoff_contact_number = "a", Drop_address = "a", Recipient_name = "a" };

            driverTaskCont.CreateDriverTask(driverTask);

            mockService.Verify(x => x.CreateDriverTask(It.IsAny<DriverTaskDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewDriverTask()
        {
            DriverTaskDto driverTask = null;

            mockService.Setup(r => r.CreateDriverTask(It.IsAny<DriverTaskDto>())).Callback<DriverTaskDto>(x => driverTask = x);

            var driverTaskMock = new DriverTaskDto {Order_id=1,Task_description="a",Trans_type="a",Contact_number="77",Email_address="a",Customer_name="c",Team_id=1,Delivery_date= DateTime.Now, Delivery_address="a", Driver_id =1, Dropoff_merchant = 1 , Dropoff_contact_name="A", Dropoff_contact_number="a",Drop_address="a", Recipient_name="a"};

            driverTaskCont.CreateDriverTask(driverTaskMock);

            mockService.Verify(x => x.CreateDriverTask(It.IsAny<DriverTaskDto>()), Times.Once);

            Assert.Equal(driverTask.Order_id, driverTaskMock.Order_id);
            Assert.Equal(driverTask.Task_description, driverTaskMock.Task_description);
            Assert.Equal(driverTask.Trans_type, driverTaskMock.Trans_type);
            Assert.Equal(driverTask.Contact_number, driverTaskMock.Contact_number);
            Assert.Equal(driverTask.Email_address, driverTaskMock.Email_address);
            Assert.Equal(driverTask.Customer_name, driverTaskMock.Customer_name);
            Assert.Equal(driverTask.Team_id, driverTaskMock.Team_id);
            Assert.Equal(driverTask.Delivery_date, driverTaskMock.Delivery_date);
            Assert.Equal(driverTask.Delivery_address, driverTaskMock.Delivery_address);
            Assert.Equal(driverTask.Driver_id, driverTaskMock.Driver_id);
            Assert.Equal(driverTask.Dropoff_merchant, driverTaskMock.Dropoff_merchant);
            Assert.Equal(driverTask.Dropoff_contact_name, driverTaskMock.Dropoff_contact_name);
            Assert.Equal(driverTask.Dropoff_contact_number, driverTaskMock.Dropoff_contact_number);
            Assert.Equal(driverTask.Drop_address, driverTaskMock.Drop_address);
            Assert.Equal(driverTask.Recipient_name, driverTaskMock.Recipient_name);
        }


        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundRespose()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = driverTaskCont.DeleteDriverTask(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ValidId_ReturnsOkResult()
        {
            mockService.Setup(x => x.GetDriverTask(1))
                       .Returns(new DriverTask { Task_id = 1 });

            var driverTask = driverTaskCont.DeleteDriverTask(1);

            Assert.IsType<OkNegotiatedContentResult<DriverTask>>(driverTask);
        }

        [Fact]
        public void Update_ValidDriverTaskIdAndDto_ComparisonShouldBeEqual()
        {
            var driverTaskMock = new DriverTaskDto { Order_id = 1, Task_description = "a", Trans_type = "a", Contact_number = "77", Email_address = "a", Customer_name = "c", Team_id = 1, Delivery_date = DateTime.Now, Delivery_address = "a", Driver_id = 1, Dropoff_merchant = 1, Dropoff_contact_name = "A", Dropoff_contact_number = "a", Drop_address = "a", Recipient_name = "a" };

            var actionResult = driverTaskCont.PutDriverTask(1, driverTaskMock);
            var response = actionResult as OkNegotiatedContentResult<DriverTaskDto>;

            Assert.NotNull(response);

            var newDriverTask = response.Content;
            //Assert.Equal(1, newDriver.id);
            Assert.Equal(1, newDriverTask.Order_id);
            Assert.Equal("a", newDriverTask.Task_description);
            Assert.Equal("a", newDriverTask.Trans_type);
            Assert.Equal("77", newDriverTask.Contact_number);
            Assert.Equal("a", newDriverTask.Email_address);
            Assert.Equal("c", newDriverTask.Customer_name);
            Assert.Equal(1, newDriverTask.Team_id);
            //Assert.Equal(DateTime.Now, newDriverTask.Delivery_date);
            Assert.Equal("a", newDriverTask.Delivery_address);
            Assert.Equal(1, newDriverTask.Driver_id);
            Assert.Equal(1, newDriverTask.Dropoff_merchant);
            Assert.Equal("A", newDriverTask.Dropoff_contact_name);
            Assert.Equal("a", newDriverTask.Dropoff_contact_number);
            Assert.Equal("a", newDriverTask.Drop_address);
            Assert.Equal("a", newDriverTask.Recipient_name);
        }

    }
}
