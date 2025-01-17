using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Context.Migrations.AppDbContexts
{
    /// <inheritdoc />
    public partial class UpdatedPersonalInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "date_of_birth",
                table: "personal_infos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "personal_infos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "middlename",
                table: "personal_infos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "experiences",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_current",
                table: "educations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "middlename",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "title",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "is_current",
                table: "educations");
        }
    }
}
