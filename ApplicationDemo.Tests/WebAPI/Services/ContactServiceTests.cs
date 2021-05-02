using System.Linq;
using ApplicationDemo.Service;
using FluentAssertions;
using Xunit;

namespace ApplicationDemo.Tests.WebAPI.Services
{
    public class ContactServiceTests : IClassFixture<AppDemoDataFixture>
    {
        private readonly AppDemoDataFixture _fixture;
        public ContactServiceTests(AppDemoDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Service_GetMethod_ShouldReturn_IEnumerableContact()
        {
            //Arrange
            var expected = _fixture.InMemoryDbContext.Contacts;
            var contactService = new ContactService(_fixture.InMemoryDbContext);            

            //Act
            var actual = await contactService.Get();

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
