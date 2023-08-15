using billkill.manager.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace billkill.manager.backend.Infrastructure
{
    public class BillKillDbContext: IdentityDbContext<USER, IdentityRole<int>, int>
    {
        public BillKillDbContext(DbContextOptions<BillKillDbContext> options)
           : base(options)
        {
        }

        public DbSet<USER> USER { get; set; }
        //public DbSet<InvoiceType> InvoiceTypes { get; set; }
    }
}
