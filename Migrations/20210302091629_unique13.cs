using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_Adres_IlId_IlceId_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_IlId_IlceId_MahalleId",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "Nitelik", "IlId", "IlceId", "MahalleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_IlId_IlceId_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_Nitelik_Adres_IlId_IlceId_MahalleId",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "Nitelik", "Adres", "IlId", "IlceId", "MahalleId" },
                unique: true);
        }
    }
}
