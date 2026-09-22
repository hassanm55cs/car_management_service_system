using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changed_servicetovisit_addproduct_branchProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsForRents",
                columns: table => new
                {
                    LicencePlate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    No_of_cylinders = table.Column<int>(type: "int", nullable: false),
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
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Full_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarrantyMonths = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
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
                name: "Car",
                columns: table => new
                {
                    Licences_Plate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    No_of_cylinders = table.Column<int>(type: "int", nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Engine_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manufactuare_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Car_Company = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    PriceInEgp = table.Column<double>(type: "float", nullable: false),
                    CurrentKM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Licences_Plate);
                    table.ForeignKey(
                        name: "FK_Car_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
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
                    LicencsePlateRented = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedCarCustomers", x => x.RentedCarCustomerId);
                    table.ForeignKey(
                        name: "FK_RentedCarCustomers_CarsForRents_LicencsePlateRented",
                        column: x => x.LicencsePlateRented,
                        principalTable: "CarsForRents",
                        principalColumn: "LicencePlate");
                    table.ForeignKey(
                        name: "FK_RentedCarCustomers_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "BranchProducts",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchProducts", x => new { x.BranchId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BranchProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "EmergencyRequests",
                columns: table => new
                {
                    EmergencyRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergenctTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Car_LicencePlate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
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
                        principalColumn: "DriverId");
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
                        principalColumn: "DriverId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Facultly = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Years_of_experince = table.Column<int>(type: "int", nullable: false),
                    Starting_work_date = table.Column<DateOnly>(type: "date", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "service_branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Open_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Close_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Opening_date = table.Column<DateOnly>(type: "date", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_service_branches_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Service_Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Licences_Plate");
                    table.ForeignKey(
                        name: "FK_Visit_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Visit_service_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "service_branches",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchProduct_BranchId",
                table: "BranchProducts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProduct_ProductId",
                table: "BranchProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Customer_Id",
                table: "Car",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Phone",
                table: "Customer",
                column: "Phone",
                unique: true);

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
                name: "IX_Employee_BranchId",
                table: "Employee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Phone_number",
                table: "Employee",
                column: "Phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentedCarCustomers_CustomerId",
                table: "RentedCarCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCarCustomers_LicencsePlateRented",
                table: "RentedCarCustomers",
                column: "LicencsePlateRented");

            migrationBuilder.CreateIndex(
                name: "IX_service_branches_ManagerId",
                table: "service_branches",
                column: "ManagerId",
                unique: true,
                filter: "([ManagerId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProductId",
                table: "Services",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VisitId",
                table: "Services",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_service_BranchId",
                table: "Visit",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_service_CarId",
                table: "Visit",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_service_EmployeeId",
                table: "Visit",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_service_branches_BranchId",
                table: "BranchProducts",
                column: "BranchId",
                principalTable: "service_branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_service_branches_BranchId",
                table: "Drivers",
                column: "BranchId",
                principalTable: "service_branches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyTrucks_service_branches_BranchId",
                table: "EmergencyTrucks",
                column: "BranchId",
                principalTable: "service_branches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_service_branches_BranchId",
                table: "Employee",
                column: "BranchId",
                principalTable: "service_branches",
                principalColumn: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_service_branches_BranchId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "BranchProducts");

            migrationBuilder.DropTable(
                name: "EmergencyRequests");

            migrationBuilder.DropTable(
                name: "EmergencyTrucks");

            migrationBuilder.DropTable(
                name: "RentedCarCustomers");

            migrationBuilder.DropTable(
                name: "ServiceByKm");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "CarsForRents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "service_branches");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
