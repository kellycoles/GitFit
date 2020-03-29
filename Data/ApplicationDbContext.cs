using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GitFit.Models;
using Microsoft.AspNetCore.Identity;

namespace GitFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Biometric> Biometric { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.

            // Make database tables singular
            //=========================================
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<Biometric>().ToTable("Biometric");


            //Seed Database
            //=====================================================

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //Create Activity
            modelBuilder.Entity<Activity>().HasData(
                new Activity()
                {
                    ActivityId = 1,
                    EntryId = 1,
                    UserId = user.Id,
                    Type = "walking",
                    Duration = 30,
                    Intensity = "moderate"
                }
            );

            //Create Entry
            modelBuilder.Entity<Entry>().HasData(
                new Entry()
                {
                    EntryId = 1,
                    UserId = user.Id,
                    Date = new DateTime(2020, 3, 15),
                    Notes = "walked in the neighborhood"
                }
            );

            //Create Biometric
            modelBuilder.Entity<Biometric>().HasData(
                new Biometric()
                {
                    BiometricId = 1,
                    UserId = user.Id,
                    Height = 66,
                    Weight = 130,
                    Age = 52,
                    Sex = "female"
                }
            );

        }
    }

}
