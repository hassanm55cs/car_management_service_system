using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EnumsIsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Visit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Visit");
        }
    }
}
