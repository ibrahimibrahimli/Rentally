using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP-JBUKPKDJ; Initial Catalog = RentallyDataBase; Integrated Security= true;Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Favourite> Favorites { get; set; }
        public DbSet<Feature> Features {  get; set; }
        public DbSet<QA> QAs {  get; set; }
        public DbSet<New> News {  get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<TeamBoard> TeamBoards { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<About> WeExperiences { get; set; }
    }
}
