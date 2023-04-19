using EventMgt.API.Controllers;
using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using EventMgt.Service.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventAPITest.Systems.Controllers
{
    public class TestEventController
    {

        [Fact]
        public async Task ListOfCurrentUsersEvent_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockEventService = new Mock<IEventService>();

            var eventDto = new ListOfCurrentUsersEventDTO
            {
                UserId = 1,
            };
            var expectedResponse = GetEventsResponse();

            mockEventService
                .Setup(service => service.ListOfCurrentUsersEvent(eventDto))
                .ReturnsAsync(expectedResponse);

            var sut = new EventController(mockEventService.Object);
            
            //Act
            var result = (OkObjectResult)await sut.ListOfCurrentUsersEvent(eventDto);
            
            //Assert
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        private ResponseModel GetEventsResponse()
        {
            var response = new ResponseModel
            {
                StatusCode = HttpStatusCode.OK,
                Msg = "User Events Loaded Successfully",
                Data = new List<Event>()
                {
                    new Event
                    {
                        EventId = 3,
                        EventCreatorId=2,
                        EventStartDate= new DateTime(),
                        EventDescription = "Description",
                        EventTitle = "Experience2023"
                    }
                }
            };
            return response;
        }

    }
}
