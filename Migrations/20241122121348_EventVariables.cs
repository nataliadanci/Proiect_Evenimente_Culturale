using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MP1.Migrations
{
    /// <inheritdoc />
    public partial class EventVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInceput",
                table: "Eveniment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSfarsit",
                table: "Eveniment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Pret",
                table: "Eveniment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInceput",
                table: "Eveniment");

            migrationBuilder.DropColumn(
                name: "DataSfarsit",
                table: "Eveniment");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Eveniment");
        }
    }
}
