
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DevicePartConfiguration
        : IEntityTypeConfiguration<DevicePart>
    {
        public static List<DevicePart> DeviceParts { get; } =
            new List<DevicePart>
            {
                new DevicePart
                {
                    DeviceId = 1,
                    PartId = 3
                },
                new DevicePart
                {
                    DeviceId = 1,
                    PartId = 4
                },
                new DevicePart
                {
                    DeviceId = 2,
                    PartId = 4
                },
                new DevicePart
                {
                    DeviceId = 3,
                    PartId = 6
                },
                new DevicePart
                {
                    DeviceId = 5,
                    PartId = 1
                },
                new DevicePart
                {
                    DeviceId = 5,
                    PartId = 2
                }
            };

        public void Configure(EntityTypeBuilder<DevicePart> builder)
        {
            builder.HasData(DeviceParts);
        }
    }
}

