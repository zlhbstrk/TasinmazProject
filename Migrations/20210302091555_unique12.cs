using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_IlId_IlceId_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.DropIndex(
                name: "IX_tblIl_Ad_Plaka",
                table: "tblIl");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_Adres_IlId_IlceId_MahalleId",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "Nitelik", "Adres", "IlId", "IlceId", "MahalleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblIl_Ad",
                table: "tblIl",
                column: "Ad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblIl_Plaka",
                table: "tblIl",
                column: "Plaka",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_Adres_IlId_IlceId_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.DropIndex(
                name: "IX_tblIl_Ad",
                table: "tblIl");

            migrationBuilder.DropIndex(
                name: "IX_tblIl_Plaka",
                table: "tblIl");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_IlId_IlceId_MahalleId",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "Nitelik", "IlId", "IlceId", "MahalleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblIl_Ad_Plaka",
                table: "tblIl",
                columns: new[] { "Ad", "Plaka" },
                unique: true);
        }
    }
}
