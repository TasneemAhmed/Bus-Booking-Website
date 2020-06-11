using BusBookingSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusBookingSystem.Startup))]
namespace BusBookingSystem
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
           
        }
       
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.Fullname = "User Admin";
                user.Email = "User_admin@gmail.com";
                user.Address = "street1234";
                user.MobileNumber = "1234567";
                var check = userManager.Create(user, "Asmin@12345");
                if (check.Succeeded)
                { userManager.AddToRole(user.Id, "Admins"); }
            }
            if (!roleManager.RoleExists("Users"))
            {
                role = new IdentityRole();
                role.Name = "Users";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.Fullname = "User user";
                user.Email = "User_user@gmail.com";
                user.Address = "street1234";
                user.MobileNumber = "1234567";
                var check = userManager.Create(user, "user@12345");
                if (check.Succeeded)
                { userManager.AddToRole(user.Id, "Users"); }
            }
          
        }
    }
}
