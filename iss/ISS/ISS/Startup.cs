using ISS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISS.Startup))]
namespace ISS
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
             createRoles();
             createUsers();
        }
        private void createUsers()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Here we create a Admin super user who will maintain the website                 

            var user = new ApplicationUser();
            user.UserName = "obada";
            user.Email = "obada@gmail.com";

            string userPWD = "Obada123//";

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin  
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Admin");

            }

        }

        // In this method we will create default User roles and Admin user for login  
        private void createRoles()
        {
            

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
          
            // In Startup I am creating first Admin Role and creating a default Admin User   
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

            // creating Creating Manager role   
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating User role   
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
            // creating Creating Student role   
            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

            }

            // creating Creating Teacher role   
            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

            }
        }
    }
}
