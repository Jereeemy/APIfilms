using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIfilms.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDFilmRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_E_FILM_FLM",
                columns: table => new
                {
                    flm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flm_titre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    flm_resume = table.Column<string>(type: "text", nullable: false),
                    flm_datesortie = table.Column<DateTime>(type: "date", nullable: false),
                    flm_duree = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    flm_genre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_film2", x => x.flm_id);
                });

            migrationBuilder.CreateTable(
                name: "T_E_UTILISATEUR_UTL",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_mobile = table.Column<string>(type: "char(10)", nullable: true),
                    utl_mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    utl_pwd = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    utl_rue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    utl_cp = table.Column<string>(type: "char(5)", nullable: true),
                    utl_ville = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_pays = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_latitude = table.Column<float>(type: "real", nullable: true),
                    utl_longitude = table.Column<float>(type: "real", nullable: true),
                    utl_datecreation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur2", x => x.utl_id);
                });

            migrationBuilder.CreateTable(
                name: "T_J_NOTATION_NOT",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    flm_id = table.Column<int>(type: "integer", nullable: false),
                    Film = table.Column<int>(type: "integer", nullable: false),
                    not_note = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notation", x => new { x.flm_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_notesfilm_film",
                        column: x => x.flm_id,
                        principalTable: "T_E_FILM_FLM",
                        principalColumn: "flm_id");
                    table.ForeignKey(
                        name: "fk_notesutilisateur_utilisateur",
                        column: x => x.Film,
                        principalTable: "T_E_UTILISATEUR_UTL",
                        principalColumn: "utl_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_E_UTILISATEUR_UTL_utl_mail",
                table: "T_E_UTILISATEUR_UTL",
                column: "utl_mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_J_NOTATION_NOT_Film",
                table: "T_J_NOTATION_NOT",
                column: "Film");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_J_NOTATION_NOT");

            migrationBuilder.DropTable(
                name: "T_E_FILM_FLM");

            migrationBuilder.DropTable(
                name: "T_E_UTILISATEUR_UTL");
        }
    }
}
