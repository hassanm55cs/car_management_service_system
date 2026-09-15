using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_services.Migrations
{
    /// <inheritdoc />
    public partial class priceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceInEgp",
                table: "Car",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInEgp",
                table: "Car");
        }
    }
}
