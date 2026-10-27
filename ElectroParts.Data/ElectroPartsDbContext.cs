using ElectroParts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectroParts.Data
{
    using Microsoft.AspNetCore.Identity;
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

            builder.Entity<DevicePart>()
                .HasOne(dp => dp.Device)
                .WithMany()
                .HasForeignKey(dp => dp.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DevicePart>()
                .HasOne(dp => dp.Part)
                .WithMany()
                .HasForeignKey(dp => dp.PartId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Device>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Part>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Device>()
                .HasOne(d => d.Manufacturer)
                .WithMany()
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Part>()
                .HasOne(p => p.Manufacturer)
                .WithMany()
                .HasForeignKey(p => p.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Device>()
                .HasOne(d => d.DeviceType)
                .WithMany()
                .HasForeignKey(d => d.DeviceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Part>()
                .HasOne(p => p.PartType)
                .WithMany()
                .HasForeignKey(p => p.PartTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfigurationsFromAssembly(typeof(ElectroPartsDbContext).Assembly);

        }

    }
}
