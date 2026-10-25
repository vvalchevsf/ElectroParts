
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ManufacturerConfiguration
        : IEntityTypeConfiguration<Manufacturer>
    {
        public static List<Manufacturer> Manufacturers { get; } =
            new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "Samsung",
                    Address = "Suwon, South Korea",
                    Url = "https://www.samsung.com"
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "LG",
                    Address = "Seoul, South Korea",
                    Url = "https://www.lg.com"
                },
                new Manufacturer
                {
                    Id = 3,
                    Name = "Philips",
                    Address = "Amsterdam, Netherlands",
                    Url = "https://www.philips.com"
                },
                new Manufacturer
                {
                    Id = 4,
                    Name = "Toshiba",
                    Address = "Tokyo, Japan",
                    Url = "https://www.global.toshiba"
                },
                new Manufacturer
                {
                    Id = 5,
                    Name = "Texas Instruments",
                    Address = "Dallas, Texas, USA",
                    Url = "https://www.ti.com"
                },
                new Manufacturer
                {
                    Id = 6,
                    Name = "Panasonic",
                    Address = "Osaka, Japan",
                    Url = "https://www.panasonic.com"
                },
                new Manufacturer
                {
                    Id = 7,
                    Name = "ON Semiconductor",
                    Address = "Scottsdale, Arizona, USA",
                    Url = "https://www.onsemi.com"
                },
                new Manufacturer
                {
                    Id = 8,
                    Name = "Vishay",
                    Address = "Malvern, Pennsylvania, USA",
                    Url = "https://www.vishay.com"
                }
            };

        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(Manufacturers);
        }
    }
}

