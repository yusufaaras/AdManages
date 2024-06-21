using AdManage.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdManage.Persistence.DbContexts
{
    public class AdManageDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AdManageDbContext()
        : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OnionAdManageDb;User Id=testDbUser;Password=8520;TrustServerCertificate=True");
        }
        public DbSet<BronzePackages> BronzePackages { get; set; }
        public DbSet<GoldPackages> GoldPackages { get; set; }
        public DbSet<SilverPackages> SilverPackages { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
  
}
