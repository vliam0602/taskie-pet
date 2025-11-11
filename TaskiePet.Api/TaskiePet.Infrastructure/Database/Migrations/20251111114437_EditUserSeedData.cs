using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskiePet.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class EditUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"),
                column: "PasswordHash",
                value: "wMn+rPq2Ffj9KJkzl8+ErLXpL8CE9mDeErGJD+kJGOo2gKRa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"),
                column: "PasswordHash",
                value: "YNVlhNyvL0xKNyE8GTr6a5s+F47FkuYYqCaawJxGn0lBgN0j");
        }
    }
}
