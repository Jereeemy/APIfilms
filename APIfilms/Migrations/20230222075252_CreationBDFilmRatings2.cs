using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIfilms.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDFilmRatings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notesutilisateur_utilisateur",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.DropIndex(
                name: "IX_T_J_NOTATION_NOT_Film",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.DropPrimaryKey(
                name: "pk_utilisateur2",
                table: "T_E_UTILISATEUR_UTL");

            migrationBuilder.DropPrimaryKey(
                name: "pk_film2",
                table: "T_E_FILM_FLM");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                table: "T_E_UTILISATEUR_UTL",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "France",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                table: "T_E_UTILISATEUR_UTL",
                type: "date",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "pk_utl",
                table: "T_E_UTILISATEUR_UTL",
                column: "utl_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_E_FILM_FLM",
                table: "T_E_FILM_FLM",
                column: "flm_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_J_NOTATION_NOT_utl_id",
                table: "T_J_NOTATION_NOT",
                column: "utl_id");

            migrationBuilder.AddCheckConstraint(
                name: "ck_not_note",
                table: "T_J_NOTATION_NOT",
                sql: "not_note between 0 and 5");

            migrationBuilder.AddForeignKey(
                name: "fk_notesutilisateur_utilisateur",
                table: "T_J_NOTATION_NOT",
                column: "utl_id",
                principalTable: "T_E_UTILISATEUR_UTL",
                principalColumn: "utl_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notesutilisateur_utilisateur",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.DropIndex(
                name: "IX_T_J_NOTATION_NOT_utl_id",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.DropCheckConstraint(
                name: "ck_not_note",
                table: "T_J_NOTATION_NOT");

            migrationBuilder.DropPrimaryKey(
                name: "pk_utl",
                table: "T_E_UTILISATEUR_UTL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_E_FILM_FLM",
                table: "T_E_FILM_FLM");

            migrationBuilder.AddColumn<int>(
                name: "Film",
                table: "T_J_NOTATION_NOT",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                table: "T_E_UTILISATEUR_UTL",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "France");

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                table: "T_E_UTILISATEUR_UTL",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "now()");

            migrationBuilder.AddPrimaryKey(
                name: "pk_utilisateur2",
                table: "T_E_UTILISATEUR_UTL",
                column: "utl_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_film2",
                table: "T_E_FILM_FLM",
                column: "flm_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_J_NOTATION_NOT_Film",
                table: "T_J_NOTATION_NOT",
                column: "Film");

            migrationBuilder.AddForeignKey(
                name: "fk_notesutilisateur_utilisateur",
                table: "T_J_NOTATION_NOT",
                column: "Film",
                principalTable: "T_E_UTILISATEUR_UTL",
                principalColumn: "utl_id");
        }
    }
}
