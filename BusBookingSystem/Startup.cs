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
            //CreateRoles();
            //CreateUsers();
        }
        /*public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "jonjon@gmail.com";
            user.UserName = "Jonjon";
            var createdUser = userManager.Create(user, "Jonjon@123");
            if (createdUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("User"))
            {
                role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Driver"))
            {
                role = new IdentityRole();
                role.Name = "Driver";
                roleManager.Create(role);
            }
        }*/
    }
}
