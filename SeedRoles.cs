using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CAImportWorkflow.Data;
using CAImportWorkflow.Data;

namespace CAImportWorkflow
{
    public static class SeedRoles
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                string[] roles = new string[] { "Admin", "User", "QC" };
                string[] thread = new string[] { "PreAlert", "HBL Processor", "Invoicing" };
                string[] users = new string[] { "supervisor", "user1", "user2", "user3" };


                var newrolelist = new List<IdentityRole>();
                foreach (string role in roles)
                {
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        newrolelist.Add(new IdentityRole(role));
                    }
                }


                var threadList = new List<ThreadMaster>();
                foreach (string t in thread)
                {
                    if (!context.ThreadMaster. Any(r => r.Name == t))
                    {
                        threadList.Add(new ThreadMaster { Name = t });
                    }
                }

                var newUserList = new List<IdentityUser>();
                foreach (string user in users)
                {
                    if (!context.Users.Any(r => r.UserName == user))
                    {
                        newUserList.Add(new IdentityUser(user));
                    }
                }


                //context.Roles.AddRange(newrolelist);
                context.SaveChanges();
            }
        }
    }
}
