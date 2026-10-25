using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroParts.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCatalogSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Телевизор" },
                    { 2, "Монитор" },
                    { 3, "Захранващ блок" },
                    { 4, "Аудио усилвател" },
                    { 5, "DVD/Blu-ray плейър" },
                    { 6, "Ресивър" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Address", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Suwon, South Korea", "Samsung", "https://www.samsung.com" },
                    { 2, "Seoul, South Korea", "LG", "https://www.lg.com" },
                    { 3, "Amsterdam, Netherlands", "Philips", "https://www.philips.com" },
                    { 4, "Tokyo, Japan", "Toshiba", "https://www.global.toshiba" },
                    { 5, "Dallas, Texas, USA", "Texas Instruments", "https://www.ti.com" },
                    { 6, "Osaka, Japan", "Panasonic", "https://www.panasonic.com" },
                    { 7, "Scottsdale, Arizona, USA", "ON Semiconductor", "https://www.onsemi.com" },
                    { 8, "Malvern, Pennsylvania, USA", "Vishay", "https://www.vishay.com" }
                });

            migrationBuilder.InsertData(
                table: "PartTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Интегрална схема" },
                    { 2, "Електронна платка" },
                    { 3, "LED подсветка" },
                    { 4, "Кондензатор" },
                    { 5, "Транзистор" },
                    { 6, "Диод" },
                    { 7, "Резистор" },
                    { 8, "Трансформатор" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Description", "DeviceTypeId", "ManufacturerId", "Model", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "LED телевизор за тестови цели.", 1, 1, "UE55AU7172", "Телевизор Samsung" },
                    { 2, null, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "OLED телевизор за тестови цели.", 1, 2, "OLED55C1", "Телевизор LG" },
                    { 3, null, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Монитор за тестови цели.", 2, 3, "272E1GAJ", "Монитор Philips" },
                    { 4, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Примерен захранващ блок за каталога.", 3, 4, "PSU-TEST-01", "Захранващ блок Toshiba" },
                    { 5, null, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Примерен аудио усилвател за каталога.", 4, 6, "AMP-TEST-01", "Аудио усилвател Panasonic" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Description", "ManufacturerId", "Name", "PartTypeId", "ShortDescription" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Интегрална схема за аудио усилватели.", 5, "TDA7294", 1, "Интегрална схема за аудио усилвател." },
                    { 2, null, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Интегрална схема за таймери и генератори на импулси.", 5, "NE555", 1, "Таймерна интегрална схема." },
                    { 3, null, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Примерна основна електронна платка за телевизор Samsung.", 1, "TV Main Board", 2, "Основна платка за телевизор." },
                    { 4, null, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Примерен комплект LED ленти за телевизионен панел.", 2, "LED Backlight 55", 3, "LED подсветка за телевизор." },
                    { 5, null, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Универсален транзистор за електронни схеми.", 7, "2N2222", 5, "NPN биполярен транзистор." },
                    { 6, null, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Примерен резистор със съпротивление 1 kΩ.", 8, "1 kΩ Resistor", 7, "Резистор 1 kΩ." }
                });

            migrationBuilder.InsertData(
                table: "DeviceParts",
                columns: new[] { "DeviceId", "PartId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 6 },
                    { 5, 1 },
                    { 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DeviceParts",
                keyColumns: new[] { "DeviceId", "PartId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PartTypes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
