using FitnessAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace FitnessAPI.Helpers
{
    public class SeedData
    {
        internal static void SeedIdentities(ApplicationDbContext context)
        {

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "PT", "Nutritionist", "Gymgoer" };
            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    RoleManager.Create(new IdentityRole(roleName));
                }
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var PasswordHash = new PasswordHasher();
            if (UserManager.FindByEmail("admin@hotmail.com") == null && UserManager.FindByEmail("coach@hotmail.com") == null && UserManager.FindByEmail("nutritionist@hotmail.com") == null &&
                UserManager.FindByEmail("gymgoer@hotmail.com") == null && UserManager.FindByEmail("gymgoer2@hotmail.com") == null)
            {
                var user = new ApplicationUser { UserName = "admin@hotmail.com", Email = "admin@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456") };
                var user2 = new ApplicationUser { UserName = "coach@hotmail.com", Email = "coach@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456") };
                var user3 = new ApplicationUser { UserName = "nutritionist@hotmail.com", Email = "nutritionist@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456") };
                var user4 = new ApplicationUser { UserName = "gymgoer@hotmail.com", Email = "gymgoer@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456") };
                var user5 = new ApplicationUser { UserName = "gymgoer2@hotmail.com", Email = "gymgoer2@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456") };

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, roleNames.ElementAt(0));

                UserManager.Create(user2);
                UserManager.AddToRole(user2.Id, roleNames.ElementAt(1));

                UserManager.Create(user3);
                UserManager.AddToRole(user3.Id, roleNames.ElementAt(2));

                UserManager.Create(user4);
                UserManager.AddToRole(user4.Id, roleNames.ElementAt(3));

                UserManager.Create(user5);
                UserManager.AddToRole(user5.Id, roleNames.ElementAt(3));
            }

        }
    }
}