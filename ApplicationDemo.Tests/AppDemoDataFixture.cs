using System;
using ApplicationDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDemo.Tests
{
    public class AppDemoDataFixture : IDisposable
    {
        public AppDemoContext InMemoryDbContext { get; private set; }

        public AppDemoDataFixture()
        {
            var options = new DbContextOptionsBuilder<AppDemoContext>()
                .UseInMemoryDatabase("AppDemoInMemoryContext")
                .Options;

            InMemoryDbContext = new AppDemoContext(options);

            InMemoryDbContext.Database.EnsureDeleted();
            InMemoryDbContext.Database.EnsureCreated();

            InMemoryDbContext.SaveChanges();
        }

        public void Dispose()
        {
            InMemoryDbContext.Dispose();
        }
    }
}
