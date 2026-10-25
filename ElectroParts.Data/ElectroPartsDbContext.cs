using ElectroParts.Data.Models;
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


        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;

        public virtual DbSet<PartType> PartTypes { get; set; } = null!;

        public virtual DbSet<Device> Devices { get; set; } = null!;

        public virtual DbSet<Part> Parts { get; set; } = null!;

        public virtual DbSet<DevicePart> DeviceParts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DevicePart>()
                .HasKey(dp => new { dp.DeviceId, dp.PartId });
        }

    }
}
