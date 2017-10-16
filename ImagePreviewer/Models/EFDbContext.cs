using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ImagePreviewer.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public virtual ICollection<ImageModel> Images { get; set; }
        public ApplicationUser()
        {
            Images = new List<ImageModel>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

    }
    public class EFDbContext : IdentityDbContext<ApplicationUser>
    {   
        public DbSet<ImageModel> Image { get; set; }
        public DbSet<TagModel> Tag { get; set; }
        public DbSet<ImageTagModel> ImageTag { get; set; }
        public EFDbContext() : base("DBConnection")
        { }
        
        public static EFDbContext Create()
        {
            return new EFDbContext();
        }
    }
}