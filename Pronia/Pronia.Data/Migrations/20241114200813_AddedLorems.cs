using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLorems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lorems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lorems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lorems");
        }
    }
}
