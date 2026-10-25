
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DeviceConfiguration
        : IEntityTypeConfiguration<Device>
    {
        public static List<Device> Devices { get; } =
            new List<Device>
            {
                new Device
                {
                    Id = 1,
                    DeviceTypeId = 1,
                    Name = "Телевизор Samsung",
                    Model = "UE55AU7172",
                    ManufacturerId = 1,
                    Description = "LED телевизор за тестови цели.",
                    CreatedOn = new DateTime(2025, 1, 15)
                },
                new Device
                {
                    Id = 2,
                    DeviceTypeId = 1,
                    Name = "Телевизор LG",
                    Model = "OLED55C1",
                    ManufacturerId = 2,
                    Description = "OLED телевизор за тестови цели.",
                    CreatedOn = new DateTime(2025, 2, 10)
                },
                new Device
                {
                    Id = 3,
                    DeviceTypeId = 2,
                    Name = "Монитор Philips",
                    Model = "272E1GAJ",
                    ManufacturerId = 3,
                    Description = "Монитор за тестови цели.",
                    CreatedOn = new DateTime(2025, 3, 5)
                },
                new Device
                {
                    Id = 4,
                    DeviceTypeId = 3,
                    Name = "Захранващ блок Toshiba",
                    Model = "PSU-TEST-01",
                    ManufacturerId = 4,
                    Description = "Примерен захранващ блок за каталога.",
                    CreatedOn = new DateTime(2025, 4, 20)
                },
                new Device
                {
                    Id = 5,
                    DeviceTypeId = 4,
                    Name = "Аудио усилвател Panasonic",
                    Model = "AMP-TEST-01",
                    ManufacturerId = 6,
                    Description = "Примерен аудио усилвател за каталога.",
                    CreatedOn = new DateTime(2025, 5, 12)
                }
            };

        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(Devices);
        }
    }
}

