using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Context
{
    public class RestaurantiumContext : DbContext
    {
   
        public RestaurantiumContext(DbContextOptions<RestaurantiumContext> options)
          : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<CompanySocialMedia> CompanySocialMedias { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FooterContact> FooterContacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
