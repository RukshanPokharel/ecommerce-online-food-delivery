using DriverApplication.Controllers.APIs.MapsApiLog;
using DriverApplication.DTOs.MapsApiLogs;
using DriverApplication.Services.MapsApiLog;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
    public class MapsApiLogControllerTests
    {
        private readonly Mock<IMapsApiLogService> mockService;
        private readonly MapsApiLogController mapApiCont;

        public MapsApiLogControllerTests()
        {
            mockService = new Mock<IMapsApiLogService>();
            mapApiCont = new MapsApiLogController(mockService.Object);
        }

        [Fact]
        public void Post_InvalidModelState_CreateMapApiNeverExecutes()
        {
            mapApiCont.ModelState.AddModelError("Map_provider", "provider is required");

            var mapsApiLogDto = new MapsApiLogDto {Api_functions = "a", Api_response ="a"};

            mapApiCont.CreateDriverMapsApiLogs(mapsApiLogDto);

            mockService.Verify(x => x.AddDriverMapsApiLogs(It.IsAny<MapsApiLogDto>()), Times.Never);

        }

        [Fact]
        public void Post_ModelStateValid_AddNewMapApi()
        {
            MapsApiLogDto mapApiLog = null;

            mockService.Setup(r => r.AddDriverMapsApiLogs(It.IsAny<MapsApiLogDto>())).Callback<MapsApiLogDto>(x => mapApiLog = x);

            var mapApiLogMock = new MapsApiLogDto { Map_provider = "a", Api_functions ="a", Api_response = "a"};

            mapApiCont.CreateDriverMapsApiLogs(mapApiLogMock);

            mockService.Verify(x => x.AddDriverMapsApiLogs(It.IsAny<MapsApiLogDto>()), Times.Once);

            Assert.Equal(mapApiLog.Map_provider, mapApiLogMock.Map_provider);
            Assert.Equal(mapApiLog.Api_functions, mapApiLogMock.Api_functions);
            Assert.Equal(mapApiLog.Api_response, mapApiLogMock.Api_response);
            
        }
    }
}
