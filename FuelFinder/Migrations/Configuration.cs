namespace FuelFinder.Migrations
{
    using FuelFinder.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FuelFinder.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FuelFinder.Models.ApplicationDbContext context)
        {
            //  Use the Entities Framework's implementation for role management
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            //Has the 'Admin' role already been created?
            IdentityRole role = context.Roles.FirstOrDefault(r => r.Name == "Admin");

            //If it is null, then create it and add it to the role manager
            if(role == null)
            {
                role = new IdentityRole();
                role.Name = "Admin";

                roleManager.Create(role);
            }


            //Use the Entity Framework's Implementation for the user management
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            //Has an admin account already been created?
            ApplicationUser adminUser = context.Users.FirstOrDefault(u => u.Email == "theKoolKid@ReeQ.com");

            //If it is null, then create it and assign it to the admin role
            if(adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    Email = "theKoolKid@ReeQ.com",
                    UserName = "theKoolKid@ReeQ.com"
                };

                userManager.Create(adminUser, "qwertyuiop");
                userManager.AddToRole(adminUser.Id, role.Name);
            }

            ApplicationUser regularUser = context.Users.FirstOrDefault(u => u.Email == "theKolesKid@ReeQ.com");

            //If it is null, then create the account
            if(regularUser == null)
            {
                regularUser = new ApplicationUser
                {
                    Email = "theKolesKid@ReeQ.com",
                    UserName = "theKolesKid@ReeQ.com"
                };

                userManager.Create(regularUser, "QWERTYUIOP");
            }
        }
    }
}
