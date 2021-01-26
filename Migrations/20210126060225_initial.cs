using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tasinmaz.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDurum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDurum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblIl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Plaka = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblIslemTip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIslemTip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblKullanici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Yetki = table.Column<byte>(type: "smallint", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Soyad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKullanici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblIlce",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlID = table.Column<int>(type: "integer", nullable: false),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIlce", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblIlce_tblIl_IlID",
                        column: x => x.IlID,
                        principalTable: "tblIl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciID = table.Column<int>(type: "integer", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DurumID = table.Column<int>(type: "integer", nullable: false),
                    IslemTipID = table.Column<int>(type: "integer", nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblLog_tblDurum_DurumID",
                        column: x => x.DurumID,
                        principalTable: "tblDurum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblLog_tblIslemTip_IslemTipID",
                        column: x => x.IslemTipID,
                        principalTable: "tblIslemTip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblLog_tblKullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "tblKullanici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMahalle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlceID = table.Column<int>(type: "integer", nullable: false),
                    Ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMahalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblMahalle_tblIlce_IlceID",
                        column: x => x.IlceID,
                        principalTable: "tblIlce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTasinmaz",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlID = table.Column<int>(type: "integer", nullable: false),
                    IlceID = table.Column<int>(type: "integer", nullable: false),
                    MahalleID = table.Column<int>(type: "integer", nullable: false),
                    Ada = table.Column<int>(type: "integer", nullable: false),
                    Parsel = table.Column<int>(type: "integer", nullable: false),
                    Nitelik = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTasinmaz", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblTasinmaz_tblIl_IlID",
                        column: x => x.IlID,
                        principalTable: "tblIl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTasinmaz_tblIlce_IlceID",
                        column: x => x.IlceID,
                        principalTable: "tblIlce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTasinmaz_tblMahalle_MahalleID",
                        column: x => x.MahalleID,
                        principalTable: "tblMahalle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblIlce_IlID",
                table: "tblIlce",
                column: "IlID");

            migrationBuilder.CreateIndex(
                name: "IX_tblLog_DurumID",
                table: "tblLog",
                column: "DurumID");

            migrationBuilder.CreateIndex(
                name: "IX_tblLog_IslemTipID",
                table: "tblLog",
                column: "IslemTipID");

            migrationBuilder.CreateIndex(
                name: "IX_tblLog_KullaniciID",
                table: "tblLog",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMahalle_IlceID",
                table: "tblMahalle",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_IlceID",
                table: "tblTasinmaz",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_IlID",
                table: "tblTasinmaz",
                column: "IlID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_MahalleID",
                table: "tblTasinmaz",
                column: "MahalleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblLog");

            migrationBuilder.DropTable(
                name: "tblTasinmaz");

            migrationBuilder.DropTable(
                name: "tblDurum");

            migrationBuilder.DropTable(
                name: "tblIslemTip");

            migrationBuilder.DropTable(
                name: "tblKullanici");

            migrationBuilder.DropTable(
                name: "tblMahalle");

            migrationBuilder.DropTable(
                name: "tblIlce");

            migrationBuilder.DropTable(
                name: "tblIl");
        }
    }
}
