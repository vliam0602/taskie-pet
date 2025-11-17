using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskiePet.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreateAndEditByBaseColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DailyTask");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DailyTask");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "DailyTask",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "DailyTask",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"),
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });
        }
    }
}
