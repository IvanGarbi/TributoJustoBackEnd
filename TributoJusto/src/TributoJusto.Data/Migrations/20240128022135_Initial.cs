using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TributoJusto.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Year = table.Column<string>(type: "VARCHAR(4)", nullable: false),
                    Genre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Director = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Writer = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Actors = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Plot = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ImdbRating = table.Column<string>(type: "VARCHAR(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    CurrencyCode = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    Saleability = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CountrySale = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Authors = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    Categories = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Publisher = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    PageCount = table.Column<int>(type: "INT", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmeId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    LivroId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritos_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_FilmeId",
                table: "Favoritos",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_LivroId",
                table: "Favoritos",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
