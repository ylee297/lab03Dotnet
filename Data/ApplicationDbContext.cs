using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab03.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<City>().Property(m => m.CityId).IsRequired();
            builder.Entity<Province>().Property(m => m.ProvinceCode).IsRequired();
            builder.Entity<City>().HasKey(m => m.CityId);
            builder.Entity<Province>().HasKey(m => m.ProvinceCode);
            builder.Entity<Province>()
                .HasMany(b => b.Cities)
                .WithOne();
            
//            builder.Entity<City>().Property(m => m.ProvinceCode).IsRequired();


//            builder.Entity<Team>().Property(p => p.TeamName).HasMaxLength(30);

            builder.Entity<City>().ToTable("City");
            builder.Entity<Province>().ToTable("Province");
            
            builder.Seed();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
