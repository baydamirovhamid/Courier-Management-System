using courier.management.system.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace courier.management.system.Infrastructure
{
    public class CourierManagementDbContext: IdentityDbContext<USER, USER_ROLE, int>
    {
        public CourierManagementDbContext()
        {
        }

        public CourierManagementDbContext(DbContextOptions<CourierManagementDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<USER>(b =>
            {
                b.ToTable("user");
            });

            builder.Entity<USER_ROLE>(b =>
            {
                b.ToTable("user_role");
            });
        }

        public DbSet<USER> user { get; set; }
        public DbSet<USER_ROLE> user_role { get; set; }
        public DbSet<CUSTOMER> customer { get; set; }
        public DbSet<COURIER> courier { get; set; }
        public DbSet<PACKAGE> package { get; set; }
        public DbSet<PAYMENT> payment { get; set; }
       

    }
}
