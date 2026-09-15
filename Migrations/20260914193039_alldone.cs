using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_services.Migrations
{
    /// <inheritdoc />
    public partial class alldone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Car",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CurrentKM",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarsForRents",
                columns: table => new
                {
                    LicencePlate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    No_of_cylinders = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Engine_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manufactuare_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Car_Company = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsForRents", x => x.LicencePlate);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StartWorkDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_service_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "service_branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceByKm",
                columns: table => new
                {
                    ServiceByKmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KilometerInterval = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceByKm", x => x.ServiceByKmId);
                });

            migrationBuilder.CreateTable(
                name: "RentedCarCustomers",
                columns: table => new
                {
                    RentedCarCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceForRent = table.Column<double>(type: "float", nullable: false),
                    No_ofDays_ForRent = table.Column<int>(type: "int", nullable: false),
                    RentStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RentEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LicencsePlateRented = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedCarCustomers", x => x.RentedCarCustomerId);
                    table.ForeignKey(
                        name: "FK_RentedCarCustomers_CarsForRents_LicencsePlateRented",
                        column: x => x.LicencsePlateRented,
                        principalTable: "CarsForRents",
                        principalColumn: "LicencePlate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentedCarCustomers_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyRequests",
                columns: table => new
                {
                    EmergencyRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergenctTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Car_LicencePlate = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyRequests", x => x.EmergencyRequestId);
                    table.ForeignKey(
                        name: "FK_EmergencyRequests_Car_Car_LicencePlate",
                        column: x => x.Car_LicencePlate,
                        principalTable: "Car",
                        principalColumn: "Licences_Plate",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyRequests_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyTrucks",
                columns: table => new
                {
                    Licence_Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TruckCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manufactuare_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyTrucks", x => x.Licence_Plate);
                    table.ForeignKey(
                        name: "FK_EmergencyTrucks_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmergencyTrucks_service_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "service_branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_BranchId",
                table: "Drivers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Email",
                table: "Drivers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PhoneNumber",
                table: "Drivers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRequests_Car_LicencePlate",
                table: "EmergencyRequests",
                column: "Car_LicencePlate");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyRequests_DriverId",
                table: "EmergencyRequests",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyTrucks_BranchId",
                table: "EmergencyTrucks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyTrucks_DriverId",
                table: "EmergencyTrucks",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCarCustomers_CustomerId",
                table: "RentedCarCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCarCustomers_LicencsePlateRented",
                table: "RentedCarCustomers",
                column: "LicencsePlateRented");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyRequests");

            migrationBuilder.DropTable(
                name: "EmergencyTrucks");

            migrationBuilder.DropTable(
                name: "RentedCarCustomers");

            migrationBuilder.DropTable(
                name: "ServiceByKm");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "CarsForRents");

            migrationBuilder.DropColumn(
                name: "CurrentKM",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
