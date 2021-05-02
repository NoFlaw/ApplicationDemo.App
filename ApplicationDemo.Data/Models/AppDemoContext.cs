using System;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDemo.Data.Models
{
    public class AppDemoContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDemoContext(DbContextOptions<AppDemoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    Name = "Brenton Bates",
                    EmailAddress = "BrentonBates@gmail.com"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sean Livingston",
                    EmailAddress = "SeanLivingston@gmail.com"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    Name = "Stephon Johnson",
                    EmailAddress = "StephonJohnson@gmail.com"
                });
   
            base.OnModelCreating(modelBuilder);
        }
    }
}
