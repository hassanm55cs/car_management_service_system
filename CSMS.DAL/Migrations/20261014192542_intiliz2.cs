using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class intiliz2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customer_customerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drivers_driverId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employee_employeeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_customerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_driverId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_employeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "driverId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "driverId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_customerId",
                table: "AspNetUsers",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_driverId",
                table: "AspNetUsers",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_employeeId",
                table: "AspNetUsers",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customer_customerId",
                table: "AspNetUsers",
                column: "customerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Drivers_driverId",
                table: "AspNetUsers",
                column: "driverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employee_employeeId",
                table: "AspNetUsers",
                column: "employeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
