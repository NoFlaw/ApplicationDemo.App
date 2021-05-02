using System;
using System.Collections.Generic;
using System.Text;
using ApplicationDemo.Data.Models;
using ApplicationDemo.Service;
using ApplicationDemo.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;

namespace ApplicationDemo.Tests.WebAPI.Controllers
{
    public class ContactControllerTests
    {
        [Fact]
        public async void Controller_GetAction_ShouldReturn_ActionResult_IEnumerableContact()
        {
            //Arrange
            var expected = new List<Contact>
            {
                new Contact { Id = Guid.NewGuid(), Name = "Brenton Bates", EmailAddress = "brentonbates@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Sean Livingston", EmailAddress = "seanlivingston@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Stephon Johnson", EmailAddress = "stephonjohnson@gmail.com" }
            };

            var mockContactService = new Mock<IContactService>(MockBehavior.Default);
            var mockLoggerService = new Mock<ILogger<ContactController>>(MockBehavior.Default);
            
            mockContactService
                .Setup(x => x.Get())
                .ReturnsAsync(expected);

            var controller = new ContactController(mockLoggerService.Object, mockContactService.Object);

            //Act
            var actionResult = await controller.Get();
            var okObjectResult = actionResult.Result as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(okObjectResult);
            Assert.True(typeof(ActionResult<IEnumerable<Contact>>).IsAssignableFrom(actionResult.GetType()));
            var actual = Assert.IsAssignableFrom<IEnumerable<Contact>>(okObjectResult.Value);
            expected.Should().BeEquivalentTo(actual);            
        }

    }
}
