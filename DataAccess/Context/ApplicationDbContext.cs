using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source = LAPTOP-JBUKPKDJ;
            //                             Initial Catalog = RentallyDataBase;
            //                             Integrated Security= true;Encrypt = false;");

            optionsBuilder.UseSqlServer("Data Source=45.42.197.224\\MSSQLSERVER2022;Initial Catalog=RentalyDb;User Id=RentalAdmin;Password=Ibrahim217@;Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Favourite> Favorites { get; set; }
        public DbSet<FavouriteItem> FavoriteItems { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<QA> QAs { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TeamBoard> TeamBoards { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
//RentalAdmin!@123  RentalAdmin
//RentalDb