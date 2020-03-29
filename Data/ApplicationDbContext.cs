using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GitFit.Models;

namespace GitFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet <ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet <Activity> Activity { get; set; }
        public DbSet<Biometric> Biometric{ get; set; }
    }

}
