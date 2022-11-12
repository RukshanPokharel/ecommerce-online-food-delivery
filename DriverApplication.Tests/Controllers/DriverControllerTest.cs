using DriverApplication;
using DriverApplication.Controllers;
using DriverApplication.DTOs.Driver;
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

namespace DriverApplication.Tests
{
   public class DriverControllerTest
    {
        private readonly Mock<IDriverService> mockService;
        private readonly DriversController driverCont;

        public DriverControllerTest()
        {
            mockService = new Mock<IDriverService>();
            driverCont = new DriversController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // act
            var okResult = driverCont.GetDrivers();

            Assert.IsType<OkNegotiatedContentResult<List<Driver>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllDrivers()
        {
            // Arrange
            mockService.Setup(repo => repo.GetDrivers()).Returns(new List<Driver>() { new Driver(), new Driver()});

            // Act
            var okResult = driverCont.GetDrivers();

            // Assert
            var drivers = Assert.IsType<OkNegotiatedContentResult<List<Driver>>>(okResult);
            Assert.Equal(2, drivers.Content.Count);

        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidDriver()
        {
            // Arrange
            mockService.Setup(x => x.GetDriver(1))
                       .Returns(new Driver { Driver_id = 1});

            // Act
            var okResult = driverCont.GetDriver(1);
            var driver = Assert.IsType<OkNegotiatedContentResult<Driver>>(okResult);


            // Assert
            Assert.Equal(1, driver.Content.Driver_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsDriverNotFound()
        {
            mockService.Setup(x => x.GetDriver(1))
                      .Returns(new Driver { Driver_id = 1 });

            // Act
            IHttpActionResult actionResult = driverCont.GetDriver(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }

        [Fact]
        public void Post_InvalidModelState_CreateDriverNeverExecutes()
        {
            driverCont.ModelState.AddModelError("First_name", "Name is required");

            var driver = new DriverDto {Last_name = "fdsfa", Email = "fdsaf", Phone = "58522", Username="dfadf", Password="dfaf", Team_id = 1, Transport_type_id = "fdf", Transport_description = "dfa", Licence_plate="fdf", Color ="blue"  };

            driverCont.CreateDriver(driver);

            mockService.Verify(x => x.AddDriver(It.IsAny<DriverDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewDriver()
        {
            DriverDto driver = null;

            mockService.Setup( r => r.AddDriver(It.IsAny<DriverDto>())).Callback<DriverDto>(x => driver = x);

            var driverMock = new DriverDto {First_name = "Corazon", Last_name = "fdsfa", Email = "fdsaf", Phone = "58522", Username = "dfadf", Password = "dfaf", Team_id = 1, Transport_type_id = "fdf", Transport_description = "dfa", Licence_plate = "fdf", Color = "blue" };

            driverCont.CreateDriver(driverMock);

            mockService.Verify(x => x.AddDriver(It.IsAny<DriverDto>()), Times.Once);

            Assert.Equal(driver.First_name, driverMock.First_name);
            Assert.Equal(driver.Last_name, driverMock.Last_name);
            Assert.Equal(driver.Email, driverMock.Email);
            Assert.Equal(driver.Phone, driverMock.Phone);
            Assert.Equal(driver.Username, driverMock.Username);
            Assert.Equal(driver.Password, driverMock.Password);
            Assert.Equal(driver.Team_id, driverMock.Team_id);
            Assert.Equal(driver.Transport_type_id, driverMock.Transport_type_id);
            Assert.Equal(driver.Transport_description, driverMock.Transport_description);
            Assert.Equal(driver.Licence_plate, driverMock.Licence_plate);
            Assert.Equal(driver.Color, driverMock.Color);

        }


        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundRespose()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = driverCont.DeleteDriver(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ValidId_ReturnsOkResult()
        {
            mockService.Setup(x => x.GetDriver(1))
                       .Returns(new Driver { Driver_id = 1 });

            var driver = driverCont.DeleteDriver(1);

            Assert.IsType<OkNegotiatedContentResult<Driver>>(driver);
        }

        [Fact]
        public void Update_ValidDriverIdAndDto_ComparisonShouldBeEqual()
        {
            var driverMock = new DriverDto { First_name = "Corazon", Last_name = "Shady", Email = "fdsaf", Phone = "58522", Username = "dfadf", Password = "dfaf", Team_id = 1, Transport_type_id = "fdf", Transport_description = "dfa", Licence_plate = "fdf", Color = "blue" };

            var actionResult = driverCont.PutDriver(1, driverMock);
            var response = actionResult as OkNegotiatedContentResult<DriverDto>;

            Assert.NotNull(response);

            Assert.True(true);

            var newDriver = response.Content;
            //Assert.Equal(1, newDriver.id);
            Assert.Equal("Corazon", newDriver.First_name);
            Assert.Equal("Shady", newDriver.Last_name);
            Assert.Equal("fdsaf", newDriver.Email);
            Assert.Equal("58522", newDriver.Phone);
            Assert.Equal("dfadf", newDriver.Username);
            Assert.Equal("dfaf", newDriver.Password);
            Assert.Equal(1, newDriver.Team_id);
            Assert.Equal("fdf", newDriver.Transport_type_id);
            Assert.Equal("dfa", newDriver.Transport_description);
            Assert.Equal("fdf", newDriver.Licence_plate);
            Assert.Equal("blue", newDriver.Color);
        }




        //// if your action returns: NotFound()
        //IHttpActionResult actionResult = valuesController.Get(10);
        //Assert.IsType<NotFoundResult>(actionResult);

        //// if your action returns: Ok()
        //actionResult = valuesController.Get(11);
        //Assert.IsType<OkResult>(actionResult);

        //// if your action was returning data in the body like: Ok<string>("data: 12")
        //actionResult = valuesController.Get(12);
        //OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
        //Assert.Equal("data: 12", conNegResult.Content);

        //// if your action was returning data in the body like: Content<string>(HttpStatusCode.Accepted, "some updated data");
        //actionResult = valuesController.Get(13);
        //NegotiatedContentResult<string> negResult = Assert.IsType<NegotiatedContentResult<string>>(actionResult);
        //Assert.Equal(HttpStatusCode.Accepted, negResult.StatusCode);
        //Assert.Equal("some updated data", negResult.Content);

    }
}