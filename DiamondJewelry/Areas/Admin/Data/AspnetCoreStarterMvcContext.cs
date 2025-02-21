using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiamondJewelry.Data
{

    public class AspnetCoreStarterMvcContext : IdentityDbContext
    {
        public AspnetCoreStarterMvcContext(DbContextOptions<AspnetCoreStarterMvcContext> options)
            : base(options)
        {
        }

        public DbSet<DiamondJewelry.Areas.Admin.Models.Product> Product { get; set; } = default!;
    }
}