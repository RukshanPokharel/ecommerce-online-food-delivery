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
    public class BulkPushControllerTest
    {
        private readonly Mock<IBulkPushService> mockService;
        private readonly BulkPushController bulkPushCont;

        public BulkPushControllerTest()
        {
            mockService = new Mock<IBulkPushService>();
            bulkPushCont = new BulkPushController(mockService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = bulkPushCont.GetAllBulkPush();
            Assert.IsType<OkNegotiatedContentResult<List<BulkPush>>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllBulkPush()
        {
            // Arrange
            mockService.Setup(repo => repo.GetAllBulkPush()).Returns(new List<BulkPush>() { new BulkPush(), new BulkPush() });

            // Act
            var okResult = bulkPushCont.GetAllBulkPush();

            // Assert
            var bulkPush = Assert.IsType<OkNegotiatedContentResult<List<BulkPush>>>(okResult);
            Assert.Equal(2, bulkPush.Content.Count);

        }

        [Fact]
        public void Get_PassingValidId_ReturnsValidDriverTask()
        {
            // Arrange
            mockService.Setup(x => x.GetBulkPush(1))
                       .Returns(new BulkPush { Bulk_id = 1 });

            // Act
            var okResult = bulkPushCont.GetBulkPush(1);
            var bulkPush = Assert.IsType<OkNegotiatedContentResult<BulkPush>>(okResult);


            // Assert
            Assert.Equal(1, bulkPush.Content.Bulk_id);
        }

        [Fact]
        public void Get_PassingInValidId_ReturnsDriverTaskNotFound()
        {
            mockService.Setup(x => x.GetBulkPush(1))
                      .Returns(new BulkPush { Bulk_id = 1 });

            // Act
            IHttpActionResult actionResult = bulkPushCont.GetBulkPush(2);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }

        [Fact]
        public void Post_InvalidModelState_CreateBulkPushNeverExecutes()
        {
            bulkPushCont.ModelState.AddModelError("Bulk_id", "Bulk Id is required");

            var bulkPush = new BulkPushDto { Push_title = "fasdf", Push_message="fdaf", Date_created = DateTime.Now, Status = "success", Team_id = 1};

            bulkPushCont.AddBulkPush(bulkPush);

            mockService.Verify(x => x.AddBulkPush(It.IsAny<BulkPushDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewDriverTask()
        {
            BulkPushDto bulkPush = null;

            mockService.Setup(r => r.AddBulkPush(It.IsAny<BulkPushDto>())).Callback<BulkPushDto>(x => bulkPush = x);

            var bulkPushMock = new BulkPushDto { Bulk_id = 1, Push_title = "a", Push_message="a", Date_created = DateTime.Now, Status = "a", Team_id = 1};

            bulkPushCont.AddBulkPush(bulkPushMock);

            mockService.Verify(x => x.AddBulkPush(It.IsAny<BulkPushDto>()), Times.Once);

            Assert.Equal(bulkPush.Bulk_id, bulkPushMock.Bulk_id);
            Assert.Equal(bulkPush.Push_title, bulkPushMock.Push_title);
            Assert.Equal(bulkPush.Push_message, bulkPushMock.Push_message);
            Assert.Equal(bulkPush.Date_created, bulkPushMock.Date_created);
            Assert.Equal(bulkPush.Status, bulkPushMock.Status);
            Assert.Equal(bulkPush.Team_id, bulkPushMock.Team_id);
            
        }


        [Fact]
        public void Delete_InvalidId_ReturnsNotFoundRespose()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = bulkPushCont.DeleteBulkPush(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ValidId_ReturnsOkResult()
        {
            mockService.Setup(x => x.GetBulkPush(1))
                       .Returns(new BulkPush { Bulk_id = 1 });

            var bulkPush = bulkPushCont.DeleteBulkPush(1);

            Assert.IsType<OkNegotiatedContentResult<BulkPush>>(bulkPush);
        }

        [Fact]
        public void Update_ValidBulkPushIdAndDto_ComparisonShouldBeEqual()
        {
            var bulkPushMock = new BulkPushDto { Bulk_id = 1, Push_title = "a", Push_message = "a", Date_created = DateTime.Now, Status = "a", Team_id = 1 };

            var actionResult = bulkPushCont.PutBulkPush(1, bulkPushMock);
            var response = actionResult as OkNegotiatedContentResult<BulkPushDto>;

            Assert.NotNull(response);

            var newBulkPush = response.Content;
            Assert.Equal(1, newBulkPush.Bulk_id);
            Assert.Equal("a", newBulkPush.Push_title);
            Assert.Equal("a", newBulkPush.Push_message);
            //Assert.Equal(DateTime.Now, newBulkPush.Date_created);
            Assert.Equal("a", newBulkPush.Status);
            Assert.Equal(1, newBulkPush.Team_id);

        }

    }
}
