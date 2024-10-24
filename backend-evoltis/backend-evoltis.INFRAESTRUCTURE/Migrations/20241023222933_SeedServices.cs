using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_evoltis.INFRAESTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class SeedServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Price" },
                values: new object[,]
                {
                    { new Guid("0d7d2fcb-4617-4611-8af4-b4608611266f"), new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6818), "Cybersecurity Monitoring", new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6818), 4500m },
                    { new Guid("22d4b2f5-af77-40c3-9fb2-83197b735c42"), new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6780), "Web Hosting Service", new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6790), 1200m },
                    { new Guid("51d8aac0-ea05-4002-9918-f3afcefc6a97"), new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6821), "Custom Software Development", new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6821), 6000m },
                    { new Guid("527034dc-9327-4fc3-9236-455aad87a9ce"), new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6815), "Cloud Storage Solutions", new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6816), 3000m },
                    { new Guid("e9843dd8-a09f-4feb-87bf-a49c93b5ab99"), new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6820), "Managed IT Support", new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6820), 2500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("0d7d2fcb-4617-4611-8af4-b4608611266f"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("22d4b2f5-af77-40c3-9fb2-83197b735c42"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("51d8aac0-ea05-4002-9918-f3afcefc6a97"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("527034dc-9327-4fc3-9236-455aad87a9ce"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e9843dd8-a09f-4feb-87bf-a49c93b5ab99"));
        }
    }
}
