using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotifyId = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreArtists",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreArtists", x => new { x.GenreId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_GenreArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreArtists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subgenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ParentGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subgenres_Genres_ParentGenreId",
                        column: x => x.ParentGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubgenreArtists",
                columns: table => new
                {
                    SubgenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubgenreArtists", x => new { x.SubgenreId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_SubgenreArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubgenreArtists_Subgenres_SubgenreId",
                        column: x => x.SubgenreId,
                        principalTable: "Subgenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Popularity",
                table: "Artists",
                column: "Popularity");

            migrationBuilder.CreateIndex(
                name: "IX_GenreArtists_ArtistId",
                table: "GenreArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SubgenreArtists_ArtistId",
                table: "SubgenreArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Subgenres_ParentGenreId",
                table: "Subgenres",
                column: "ParentGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreArtists");

            migrationBuilder.DropTable(
                name: "SubgenreArtists");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Subgenres");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
