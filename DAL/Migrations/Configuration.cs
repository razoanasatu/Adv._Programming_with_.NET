namespace DAL.Migrations
{
    using DAL.EF.TableModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.EContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.EF.EContext context)
        {

          
            var adminUser = new User
            {
                Username = "Admin",
                Password = "123",
                Email = "admin@gmail.com",
                Role = "Admin"
            };
            context.Users.AddOrUpdate(u => u.Username, adminUser);
            context.SaveChanges(); 

           
            for (int i = 1; i <= 5; i++)
            {
                var user = new User
                {
                    Username = $"User-{i}",
                    Password = "password123",
                    Email = $"user{i}@gmail.com",
                    Role = "User"
                };
                context.Users.AddOrUpdate(u => u.Username, user);
            }
            context.SaveChanges();

            for (int i = 1; i <= 5; i++)
            {
                context.Events.AddOrUpdate(e => e.Title,
                    new Event
                    {
                        Title = $"Event {i}",
                        Date = DateTime.Now.AddDays(i),
                        Description = $"Description for Event {i}",
                        Location = $"Location {i}",
                        AdminId = adminUser.UserId 
                    });
            }

            context.SaveChanges(); 

        }
        
    }
}
