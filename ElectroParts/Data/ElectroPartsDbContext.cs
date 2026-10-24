using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectroParts.Data
{
    public class ElectroPartsDbContext : IdentityDbContext
    {
        public ElectroPartsDbContext(DbContextOptions<ElectroPartsDbContext> options)
            : base(options)
        {
        }
    }
}
