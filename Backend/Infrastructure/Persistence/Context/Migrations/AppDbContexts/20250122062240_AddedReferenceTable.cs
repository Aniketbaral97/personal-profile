using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Context.Migrations.AppDbContexts
{
    /// <inheritdoc />
    public partial class AddedReferenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "personal_infos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "hobbies",
                table: "personal_infos",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "languages",
                table: "personal_infos",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "nationality",
                table: "personal_infos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "work_availability_status",
                table: "personal_infos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "references",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    personal_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    work_place = table.Column<string>(type: "text", nullable: false),
                    contact_info = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_references", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "references");

            migrationBuilder.DropColumn(
                name: "email",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "hobbies",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "languages",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "nationality",
                table: "personal_infos");

            migrationBuilder.DropColumn(
                name: "work_availability_status",
                table: "personal_infos");
        }
    }
}
