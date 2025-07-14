using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "VehicleTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VehicleTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "SharedFlights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SharedFlights",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Flights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Flights",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "FlightRoutes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FlightRoutes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "ConnectingFlights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ConnectingFlights",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Airports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Airports",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "SharedFlights");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SharedFlights");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "FlightRoutes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FlightRoutes");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "ConnectingFlights");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ConnectingFlights");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Airports");
        }
    }
}
