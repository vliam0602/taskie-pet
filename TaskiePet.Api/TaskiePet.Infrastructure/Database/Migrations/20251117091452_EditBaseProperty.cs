using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskiePet.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class EditBaseProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "User",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "User",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "DailyTask",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "DailyTask",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "DailyTask",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedAt",
                table: "DailyTask",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "User",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "User",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "DailyTask",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "DailyTask",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "DailyTask",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedAt",
                table: "DailyTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
