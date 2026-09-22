using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class serviceByKmproductsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceByKmProducts",
                columns: table => new
                {
                    serviceByKmId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceByKmProducts", x => new { x.productId, x.serviceByKmId });
                    table.ForeignKey(
                        name: "FK_ServiceByKmProducts_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceByKmProducts_ServiceByKm_serviceByKmId",
                        column: x => x.serviceByKmId,
                        principalTable: "ServiceByKm",
                        principalColumn: "ServiceByKmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceByKmProducts_serviceByKmId",
                table: "ServiceByKmProducts",
                column: "serviceByKmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceByKmProducts");
        }
    }
}
