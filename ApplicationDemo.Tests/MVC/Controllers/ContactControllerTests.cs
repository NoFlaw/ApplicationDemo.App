using ApplicationDemo.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using ApplicationDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDemo.Mvc.Services;
using AutoMapper;
using ApplicationDemo.Mvc.Models;
using System.Linq;
using FluentAssertions;
using ApplicationDemo.Mvc.Profiles;

namespace ApplicationDemo.Tests.MVC.Controllers
{
    public class ContactControllerTests
    {        
        [Fact]
        public async void Controller_IndexAction_ShouldReturn_ActionResult_IEnumerableContactViewModel()
        {
            //Arrange
            var expected = new List<Contact>
            {
                new Contact { Id = Guid.NewGuid(), Name = "Brenton Bates", EmailAddress = "brentonbates@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Sean Livingston", EmailAddress = "seanlivingston@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Stephon Johnson", EmailAddress = "stephonjohnson@gmail.com" }
            };

            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContactProfile());
            });

            var mockMapperService = mockMapperConfig.CreateMapper();
            var mockLoggerService = new Mock<ILogger<ContactController>>(MockBehavior.Default);
            var mockContactService = new Mock<IContactService>(MockBehavior.Default); 

            mockContactService
                .Setup(x => x.GetContactsAsync(It.IsAny<string>()))
                .ReturnsAsync(expected);

            var controller = new ContactController(mockLoggerService.Object, mockContactService.Object, mockMapperService);

            //Act
            var actionResult = await controller.Index();
            var viewResult = actionResult.Result as ViewResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(viewResult);
            Assert.True(typeof(ActionResult<IEnumerable<ContactViewModel>>).IsAssignableFrom(actionResult.GetType()));
            var actual = Assert.IsAssignableFrom<IEnumerable<ContactViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(expected.Count(), actual.Count());
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
