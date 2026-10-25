
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DeviceTypeConfiguration
        : IEntityTypeConfiguration<DeviceType>
    {
        public static List<DeviceType> DeviceTypes { get; } =
            new List<DeviceType>
            {
                new DeviceType
                {
                    Id = 1,
                    Name = "Телевизор"
                },
                new DeviceType
                {
                    Id = 2,
                    Name = "Монитор"
                },
                new DeviceType
                {
                    Id = 3,
                    Name = "Захранващ блок"
                },
                new DeviceType
                {
                    Id = 4,
                    Name = "Аудио усилвател"
                },
                new DeviceType
                {
                    Id = 5,
                    Name = "DVD/Blu-ray плейър"
                },
                new DeviceType
                {
                    Id = 6,
                    Name = "Ресивър"
                }
            };

        public void Configure(EntityTypeBuilder<DeviceType> builder)
        {
            builder.HasData(DeviceTypes);
        }
    }
}

