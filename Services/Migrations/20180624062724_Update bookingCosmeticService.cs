using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Services.Migrations
{
    public partial class UpdatebookingCosmeticService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nameservice",
                table: "BookingCosmeticServices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BookingCosmeticServices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nameservice",
                table: "BookingCosmeticServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookingCosmeticServices");
        }
    }
}
