using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_IlId_IlceId_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_IlId_IlceId_MahalleId_Nitelik",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "IlId", "IlceId", "MahalleId", "Nitelik" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_IlId_IlceId_MahalleId_Nitelik",
                table: "tblTasinmaz");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel_IlId_IlceId_MahalleId",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel", "IlId", "IlceId", "MahalleId" },
                unique: true);
        }
    }
}
