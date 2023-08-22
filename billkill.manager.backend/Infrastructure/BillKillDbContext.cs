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
            //builder.Entity<Role>(b => {
            //    b.ToTable("Roles");
            //});
            //builder.Entity<IdentityUserClaim<int>>(b => {
            //    b.ToTable("UserClaims");
            //});
            //builder.Entity<IdentityRoleClaim<int>>(b => {
            //    b.ToTable("RoleClaims");
            //});
            //builder.Entity<IdentityUserLogin<int>>(b => {
            //    b.ToTable("UserLogins");
            //});
            //builder.Entity<IdentityUserToken<int>>(b => {
            //    b.ToTable("UserTokens");
            //});
            //builder.Entity<IdentityUserRole<int>>(b => {
            //    b.ToTable("UserRoles");
            //});
        }

        public DbSet<USER> USER { get; set; }
        public DbSet<INVOICE_TYPE> INVOICE_TYPE { get; set; }
    }
}
