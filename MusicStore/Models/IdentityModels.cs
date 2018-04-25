using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Models;

namespace MusicStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class MusicStoreDB : IdentityDbContext<ApplicationUser>
    {
        public MusicStoreDB()
            : base("MusicStoreDB", throwIfV1Schema: false)
        {
        }

        public static MusicStoreDB Create()
        {
            return new MusicStoreDB();
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Cart> ShoppingCarts { get; set; }
    }
}