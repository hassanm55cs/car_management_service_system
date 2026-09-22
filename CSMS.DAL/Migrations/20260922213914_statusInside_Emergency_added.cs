using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class statusInside_Emergency_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusEmergency",
                table: "EmergencyRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusEmergency",
                table: "EmergencyRequests");
        }
    }
}
