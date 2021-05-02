using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApplicationDemo.Data.Models;
using ApplicationDemo.Mvc.Helpers;
using ApplicationDemo.Mvc.Services;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using Xunit;
namespace ApplicationDemo.Tests.MVC.Services
{
    public class ContactServiceTests
    {
        [Fact]
        public async Task Service_GetMethod_ShouldReturn_IEnumerableContact()
        {
            //Arrange
            const string url = "http://localhost:5000/api/contact";

            var expected = new List<Contact>
            {
                new Contact { Id = Guid.NewGuid(), Name = "Brenton Bates", EmailAddress = "brentonbates@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Sean Livingston", EmailAddress = "seanlivingston@gmail.com" },
                new Contact { Id = Guid.NewGuid(), Name = "Stephon Johnson", EmailAddress = "stephonjohnson@gmail.com" }
            };

            var json = JsonConvert.SerializeObject(expected);

            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var mockIConfiguration = new Mock<IConfiguration>(MockBehavior.Default);
            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>(MockBehavior.Default);

            mockHttpClientWrapper
                .Setup(t => t.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(httpResponse);

            ContactService service = new ContactService(mockHttpClientWrapper.Object, mockIConfiguration.Object);

            //Act
            var actual = await service.GetContactsAsync(url);

            //Assert
            Assert.NotNull(actual);
            Assert.Contains(actual, a => a.Name == "Brenton Bates");
            Assert.Contains(actual, a => a.Name == "Sean Livingston");
            Assert.Contains(actual, a => a.Name == "Stephon Johnson");
            Assert.Equal(expected.Count(), actual.Count());
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
