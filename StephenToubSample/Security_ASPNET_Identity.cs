using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationUser : IdentityUser
{
    // You can add additional profile data for the user here
}

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext() : base("DefaultConnection")
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}
