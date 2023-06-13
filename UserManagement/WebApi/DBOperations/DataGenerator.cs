using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.DataGenerator
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<UserDbContext>>()))
            {
                if (context.Users.Any())
                {
                    // Data already exists
                    return;
                }

                // Generate sample users
                var users = new User[]
                {
                    new User 
                    { 
                        Name = "John Doe", 
                        Email = "john.doe@example.com",
                        Role = "Administrator"
                    },
                    new User 
                    { 
                        Name = "Jane Smith", 
                        Email = "jane.smith@example.com" ,
                        Role = "Supervisor"
                    },
                    new User 
                    { 
                        Name = "Michael Johnson",
                        Email = "michael.johnson@example.com" ,
                        Role = "Staff"
                    }
                    // Add more sample users if needed
                };

                // Add users to the context and save changes
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
