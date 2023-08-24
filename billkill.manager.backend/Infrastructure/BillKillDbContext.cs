using billkill.manager.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace billkill.manager.backend.Infrastructure
{
    public class BillKillDbContext: IdentityDbContext<USER, EMPLOYEE_ROLE, int>
    {
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
        public DbSet<INVOICE_TYPE> INVOICE_TYPE { get; set; }
        public DbSet<SERVICE> SERVICE { get; set; }
    }
}
