using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskiePet.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "LastModifiedBy", "LastModifiedDate", "PasswordHash" },
                values: new object[] { new Guid("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"), null, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com", null, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "YNVlhNyvL0xKNyE8GTr6a5s+F47FkuYYqCaawJxGn0lBgN0j" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"));
        }
    }
}
