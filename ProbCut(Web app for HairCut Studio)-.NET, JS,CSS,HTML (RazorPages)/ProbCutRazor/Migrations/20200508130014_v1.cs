using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProbCut.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frizeri",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    ime = table.Column<string>(maxLength: 30, nullable: false),
                    prezime = table.Column<string>(maxLength: 30, nullable: false),
                    username = table.Column<string>(maxLength: 30, nullable: false),
                    password = table.Column<string>(nullable: false),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    pol = table.Column<string>(nullable: true),
                    brojTelefona = table.Column<string>(nullable: true),
                    prosecnaOcena = table.Column<float>(nullable: false),
                    brojOcena = table.Column<int>(nullable: false),
                    polKojiSisa = table.Column<string>(nullable: false),
                    brojRealizovanihTermina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frizeri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sadrzaj = table.Column<string>(nullable: false),
                    vreme = table.Column<DateTime>(nullable: false),
                    idPrimaoca = table.Column<int>(nullable: false),
                    idPosiljaoca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vlasnici",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    ime = table.Column<string>(maxLength: 30, nullable: false),
                    prezime = table.Column<string>(maxLength: 30, nullable: false),
                    username = table.Column<string>(maxLength: 30, nullable: false),
                    password = table.Column<string>(nullable: false),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    pol = table.Column<string>(nullable: true),
                    brojTelefona = table.Column<string>(nullable: true),
                    poslednjiPutUlogovan = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlasnici", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    frizerid = table.Column<int>(nullable: false),
                    vreme = table.Column<DateTime>(nullable: false),
                    trajanjeUMinutima = table.Column<int>(nullable: false),
                    vrstaUsluge = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.id);
                    table.ForeignKey(
                        name: "FK_Termini_Frizeri_frizerid",
                        column: x => x.frizerid,
                        principalTable: "Frizeri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musterije",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    ime = table.Column<string>(maxLength: 30, nullable: false),
                    prezime = table.Column<string>(maxLength: 30, nullable: false),
                    username = table.Column<string>(maxLength: 30, nullable: false),
                    password = table.Column<string>(nullable: false),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    pol = table.Column<string>(nullable: true),
                    brojTelefona = table.Column<string>(nullable: true),
                    terminid = table.Column<int>(nullable: true),
                    brojRealizovanihTermina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musterije", x => x.id);
                    table.ForeignKey(
                        name: "FK_Musterije_Termini_terminid",
                        column: x => x.terminid,
                        principalTable: "Termini",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autorid = table.Column<int>(nullable: false),
                    frizerid = table.Column<int>(nullable: false),
                    sadrzaj = table.Column<string>(nullable: false),
                    vreme = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => x.id);
                    table.ForeignKey(
                        name: "FK_Komentari_Musterije_autorid",
                        column: x => x.autorid,
                        principalTable: "Musterije",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentari_Frizeri_frizerid",
                        column: x => x.frizerid,
                        principalTable: "Frizeri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_autorid",
                table: "Komentari",
                column: "autorid");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_frizerid",
                table: "Komentari",
                column: "frizerid");

            migrationBuilder.CreateIndex(
                name: "IX_Musterije_terminid",
                table: "Musterije",
                column: "terminid");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_frizerid",
                table: "Termini",
                column: "frizerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Vlasnici");

            migrationBuilder.DropTable(
                name: "Musterije");

            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "Frizeri");
        }
    }
}
