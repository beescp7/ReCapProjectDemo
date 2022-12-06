using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DenemeRentCar;Trusted_Connection=true");
            
        }
        public DbSet<Car> Cars { get; set; }       
        public DbSet<Color> Colors { get; set; }       
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Customer>().ToTable("Customers");
           modelBuilder.Entity<Customer>().Property(p=>p.UserId).HasColumnName("UserId");
           modelBuilder.Entity<Customer>().Property(p=>p.CompanyName).HasColumnName("CompanyName");
                    
        }
    }
}
