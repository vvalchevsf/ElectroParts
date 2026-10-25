
namespace ElectroParts.Data.Configuration
{
    using ElectroParts.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartTypeConfiguration
        : IEntityTypeConfiguration<PartType>
    {
        public static List<PartType> PartTypes { get; } =
            new List<PartType>
            {
                new PartType
                {
                    Id = 1,
                    Name = "Интегрална схема"
                },
                new PartType
                {
                    Id = 2,
                    Name = "Електронна платка"
                },
                new PartType
                {
                    Id = 3,
                    Name = "LED подсветка"
                },
                new PartType
                {
                    Id = 4,
                    Name = "Кондензатор"
                },
                new PartType
                {
                    Id = 5,
                    Name = "Транзистор"
                },
                new PartType
                {
                    Id = 6,
                    Name = "Диод"
                },
                new PartType
                {
                    Id = 7,
                    Name = "Резистор"
                },
                new PartType
                {
                    Id = 8,
                    Name = "Трансформатор"
                }
            };

        public void Configure(EntityTypeBuilder<PartType> builder)
        {
            builder.HasData(PartTypes);
        }
    }
}
