using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class TranslateModelNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Musicas",
                newName: "Musics");

            migrationBuilder.RenameColumn(
                table: "Musics",
                name: "Nome",
                newName: "Name"
            );

            migrationBuilder.RenameColumn(
                table: "Musics",
                name: "AnoLancamento",
                newName: "PublishYear"
            );

            migrationBuilder.RenameColumn(
                table: "Musics",
                name: "ArtistaId",
                newName: "ArtistId"
            );

            migrationBuilder.RenameTable(
                name: "Artistas",
                newName: "Artists");

            migrationBuilder.RenameColumn(
                table: "Artists",
                name: "Nome",
                newName: "Name"
            );

            migrationBuilder.RenameColumn(
                table: "Artists",
                name: "FotoPerfil",
                newName: "ProfilePhoto"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Musics",
                newName: "Musicas");

            migrationBuilder.RenameColumn(
                table: "Musicas",
                name: "Name",
                newName: "Nome"
            );

            migrationBuilder.RenameColumn(
                table: "Musicas",
                name: "AnoLancamento",
                newName: "PublishYear"
            );

            migrationBuilder.RenameColumn(
                table: "Musicas",
                name: "ArtistaId",
                newName: "ArtistId"
            );

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artistas");

            migrationBuilder.RenameColumn(
                table: "Artistas",
                name: "Name",
                newName: "Nome"
            );

            migrationBuilder.RenameColumn(
                table: "Artistas",
                name: "ProfilePhoto",
                newName: "FotoPerfil"
            );
        }
    }
}
