using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class tumIdDuzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblIlce_tblIl_IlID",
                table: "tblIlce");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblDurum_DurumID",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblIslemTip_IslemTipID",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblKullanici_KullaniciID",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMahalle_tblIlce_IlceID",
                table: "tblMahalle");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblIl_IlID",
                table: "tblTasinmaz");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblIlce_IlceID",
                table: "tblTasinmaz");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblMahalle_MahalleID",
                table: "tblTasinmaz");

            migrationBuilder.RenameColumn(
                name: "MahalleID",
                table: "tblTasinmaz",
                newName: "MahalleId");

            migrationBuilder.RenameColumn(
                name: "IlceID",
                table: "tblTasinmaz",
                newName: "IlceId");

            migrationBuilder.RenameColumn(
                name: "IlID",
                table: "tblTasinmaz",
                newName: "IlId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_MahalleID",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_MahalleId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_IlID",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_IlId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_IlceID",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_IlceId");

            migrationBuilder.RenameColumn(
                name: "IlceID",
                table: "tblMahalle",
                newName: "IlceId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMahalle_IlceID",
                table: "tblMahalle",
                newName: "IX_tblMahalle_IlceId");

            migrationBuilder.RenameColumn(
                name: "KullaniciID",
                table: "tblLog",
                newName: "KullaniciId");

            migrationBuilder.RenameColumn(
                name: "IslemTipID",
                table: "tblLog",
                newName: "IslemTipId");

            migrationBuilder.RenameColumn(
                name: "DurumID",
                table: "tblLog",
                newName: "DurumId");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_KullaniciID",
                table: "tblLog",
                newName: "IX_tblLog_KullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_IslemTipID",
                table: "tblLog",
                newName: "IX_tblLog_IslemTipId");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_DurumID",
                table: "tblLog",
                newName: "IX_tblLog_DurumId");

            migrationBuilder.RenameColumn(
                name: "IlID",
                table: "tblIlce",
                newName: "IlId");

            migrationBuilder.RenameIndex(
                name: "IX_tblIlce_IlID",
                table: "tblIlce",
                newName: "IX_tblIlce_IlId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblIlce_tblIl_IlId",
                table: "tblIlce",
                column: "IlId",
                principalTable: "tblIl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblDurum_DurumId",
                table: "tblLog",
                column: "DurumId",
                principalTable: "tblDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblIslemTip_IslemTipId",
                table: "tblLog",
                column: "IslemTipId",
                principalTable: "tblIslemTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblKullanici_KullaniciId",
                table: "tblLog",
                column: "KullaniciId",
                principalTable: "tblKullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMahalle_tblIlce_IlceId",
                table: "tblMahalle",
                column: "IlceId",
                principalTable: "tblIlce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblIl_IlId",
                table: "tblTasinmaz",
                column: "IlId",
                principalTable: "tblIl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblIlce_IlceId",
                table: "tblTasinmaz",
                column: "IlceId",
                principalTable: "tblIlce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblMahalle_MahalleId",
                table: "tblTasinmaz",
                column: "MahalleId",
                principalTable: "tblMahalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblIlce_tblIl_IlId",
                table: "tblIlce");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblDurum_DurumId",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblIslemTip_IslemTipId",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblLog_tblKullanici_KullaniciId",
                table: "tblLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMahalle_tblIlce_IlceId",
                table: "tblMahalle");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblIl_IlId",
                table: "tblTasinmaz");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblIlce_IlceId",
                table: "tblTasinmaz");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblMahalle_MahalleId",
                table: "tblTasinmaz");

            migrationBuilder.RenameColumn(
                name: "MahalleId",
                table: "tblTasinmaz",
                newName: "MahalleID");

            migrationBuilder.RenameColumn(
                name: "IlceId",
                table: "tblTasinmaz",
                newName: "IlceID");

            migrationBuilder.RenameColumn(
                name: "IlId",
                table: "tblTasinmaz",
                newName: "IlID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_MahalleId",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_MahalleID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_IlId",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_IlID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTasinmaz_IlceId",
                table: "tblTasinmaz",
                newName: "IX_tblTasinmaz_IlceID");

            migrationBuilder.RenameColumn(
                name: "IlceId",
                table: "tblMahalle",
                newName: "IlceID");

            migrationBuilder.RenameIndex(
                name: "IX_tblMahalle_IlceId",
                table: "tblMahalle",
                newName: "IX_tblMahalle_IlceID");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "tblLog",
                newName: "KullaniciID");

            migrationBuilder.RenameColumn(
                name: "IslemTipId",
                table: "tblLog",
                newName: "IslemTipID");

            migrationBuilder.RenameColumn(
                name: "DurumId",
                table: "tblLog",
                newName: "DurumID");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_KullaniciId",
                table: "tblLog",
                newName: "IX_tblLog_KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_IslemTipId",
                table: "tblLog",
                newName: "IX_tblLog_IslemTipID");

            migrationBuilder.RenameIndex(
                name: "IX_tblLog_DurumId",
                table: "tblLog",
                newName: "IX_tblLog_DurumID");

            migrationBuilder.RenameColumn(
                name: "IlId",
                table: "tblIlce",
                newName: "IlID");

            migrationBuilder.RenameIndex(
                name: "IX_tblIlce_IlId",
                table: "tblIlce",
                newName: "IX_tblIlce_IlID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblIlce_tblIl_IlID",
                table: "tblIlce",
                column: "IlID",
                principalTable: "tblIl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblDurum_DurumID",
                table: "tblLog",
                column: "DurumID",
                principalTable: "tblDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblIslemTip_IslemTipID",
                table: "tblLog",
                column: "IslemTipID",
                principalTable: "tblIslemTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblLog_tblKullanici_KullaniciID",
                table: "tblLog",
                column: "KullaniciID",
                principalTable: "tblKullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMahalle_tblIlce_IlceID",
                table: "tblMahalle",
                column: "IlceID",
                principalTable: "tblIlce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblIl_IlID",
                table: "tblTasinmaz",
                column: "IlID",
                principalTable: "tblIl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblIlce_IlceID",
                table: "tblTasinmaz",
                column: "IlceID",
                principalTable: "tblIlce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblMahalle_MahalleID",
                table: "tblTasinmaz",
                column: "MahalleID",
                principalTable: "tblMahalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
