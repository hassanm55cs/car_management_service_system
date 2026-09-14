using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_services.Migrations
{
    /// <inheritdoc />
    public partial class update_the_engine_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Engine_type",
                table: "Car",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Engine_type",
                table: "Car",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
