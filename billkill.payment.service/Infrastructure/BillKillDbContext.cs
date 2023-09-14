using billkill.payment.service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace billkill.payment.service.Infrastructure
{
    public class BillKillDbContext: IdentityDbContext<USER, EMPLOYEE_ROLE, int>
    {
        public BillKillDbContext()
        {
        }

        public BillKillDbContext(DbContextOptions<BillKillDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<USER>(b =>
            {
                b.ToTable("USER");
            });
            builder.Entity<EMPLOYEE_ROLE>(b =>
            {
                b.ToTable("EMPLOYEE_ROLE");
            });
        }

        public DbSet<USER> USER { get; set; }
        public DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public DbSet<EMPLOYEE_ROLE> EMPLOYEE_ROLE { get; set; }
        public DbSet<MANAGEMENT_COMPANY> MANAGEMENT_COMPANY { get; set; }
        public DbSet<BUILDING> BUILDING { get; set; }
        public DbSet<APARTMENT> APARTMENT { get; set; }
        public DbSet<PAYMENT_TYPE> PAYMENT_TYPE { get; set; }
        public DbSet<SERVICE> SERVICE { get; set; }
        public DbSet<SERVICE_PROVIDER> SERVICE_PROVIDER { get; set; }
        public DbSet<SP_ABONE> SP_ABONE { get; set; }
        public DbSet<PAYMENT> PAYMENT { get; set; }
        public DbSet<INVOICE> INVOICE { get; set; }
        public DbSet<SUBSCRIBER> SUBSCRIBER { get; set; }
        public DbSet<AGREEMENT_SERVICE> AGREEMENT_SERVICE { get; set; }
        public DbSet<API_KEY> API_KEY { get; set; }
        

    }
}
