using reserva.user.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using reserva.payment.service.Models;

namespace reserva.user.backend.Infrastructure
{
    public class ReservaDbContext: IdentityDbContext<USER, USER_ROLE, int>
    {
        public ReservaDbContext()
        {
        }

        public ReservaDbContext(DbContextOptions<ReservaDbContext> options)
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
        public DbSet<CLIENT> client { get; set; }
        public DbSet<COMPANY_EMPLOYEE> company_employee { get; set; }
        public DbSet<COMPANY> company { get; set; }
        public DbSet<COMPANY_BRANCH> company_branch { get; set; }
        public DbSet<RESERVE> reserve { get; set; }
        public DbSet<STADIUM> stadium { get; set; }
        public DbSet<STADIUM_FULLIED> stadium_fullied { get; set; }
        public DbSet<STADIUM_PRICE> stadium_price { get; set; }
        public DbSet<STADIUM_TYPE> stadium_type { get; set; }
        public DbSet<STATIC_DATA> static_data { get; set; }
        public DbSet<TIME_TYPE> time_type { get; set; }

    }
}
