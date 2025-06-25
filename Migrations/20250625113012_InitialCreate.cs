using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlygplatsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flyg",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avgang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ankomst = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flygnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flygbolag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boarding = table.Column<bool>(type: "bit", nullable: false),
                    GateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flyg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flyg_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flyg_GateId",
                table: "Flyg",
                column: "GateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flyg");

            migrationBuilder.DropTable(
                name: "Gates");
        }
    }
}
