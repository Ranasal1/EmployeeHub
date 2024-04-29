using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditToDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifierName",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ModifierName",
                table: "Department");
        }
    }
}
