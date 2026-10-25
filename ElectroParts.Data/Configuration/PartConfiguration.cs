
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartConfiguration
        : IEntityTypeConfiguration<Part>
    {
        public static List<Part> Parts { get; } =
            new List<Part>
            {
                new Part
                {
                    Id = 1,
                    PartTypeId = 1,
                    Name = "TDA7294",
                    ManufacturerId = 5,
                    ShortDescription = "Интегрална схема за аудио усилвател.",
                    Description = "Интегрална схема за аудио усилватели.",
                    CreatedOn = new DateTime(2025, 1, 20)
                },
                new Part
                {
                    Id = 2,
                    PartTypeId = 1,
                    Name = "NE555",
                    ManufacturerId = 5,
                    ShortDescription = "Таймерна интегрална схема.",
                    Description = "Интегрална схема за таймери и генератори на импулси.",
                    CreatedOn = new DateTime(2025, 2, 15)
                },
                new Part
                {
                    Id = 3,
                    PartTypeId = 2,
                    Name = "TV Main Board",
                    ManufacturerId = 1,
                    ShortDescription = "Основна платка за телевизор.",
                    Description = "Примерна основна електронна платка за телевизор Samsung.",
                    CreatedOn = new DateTime(2025, 3, 10)
                },
                new Part
                {
                    Id = 4,
                    PartTypeId = 3,
                    Name = "LED Backlight 55",
                    ManufacturerId = 2,
                    ShortDescription = "LED подсветка за телевизор.",
                    Description = "Примерен комплект LED ленти за телевизионен панел.",
                    CreatedOn = new DateTime(2025, 4, 5)
                },
                new Part
                {
                    Id = 5,
                    PartTypeId = 5,
                    Name = "2N2222",
                    ManufacturerId = 7,
                    ShortDescription = "NPN биполярен транзистор.",
                    Description = "Универсален транзистор за електронни схеми.",
                    CreatedOn = new DateTime(2025, 5, 1)
                },
                new Part
                {
                    Id = 6,
                    PartTypeId = 7,
                    Name = "1 kΩ Resistor",
                    ManufacturerId = 8,
                    ShortDescription = "Резистор 1 kΩ.",
                    Description = "Примерен резистор със съпротивление 1 kΩ.",
                    CreatedOn = new DateTime(2025, 6, 12)
                }
            };

        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(Parts);
        }
    }
}

