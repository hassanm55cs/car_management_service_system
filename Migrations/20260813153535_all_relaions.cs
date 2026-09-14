using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_services.Migrations
{
    /// <inheritdoc />
    public partial class all_relaions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Car",
                columns: table => new
                {
                    Licences_Plate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No_of_cylinders = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Engine_type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    manufactuare_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Car_Company = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Licences_Plate);
                    table.ForeignKey(
                        name: "FK_Car_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
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
                    Years_of_experince = table.Column<int>(type: "int", maxLength: 2, nullable: false),
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
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    serviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Service_Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.serviceId);
                    table.ForeignKey(
                        name: "FK_service_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Licences_Plate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_service_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_service_service_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "service_branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_service_BranchId",
                table: "service",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_service_CarId",
                table: "service",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_service_EmployeeId",
                table: "service",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_service_branches_ManagerId",
                table: "service_branches",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_service_branches_BranchId",
                table: "Employee",
                column: "BranchId",
                principalTable: "service_branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_service_branches_BranchId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "service");

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
