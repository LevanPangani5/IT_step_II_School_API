using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_API.Migrations
{
    public partial class addslectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecotrId",
                table: "stdents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectorId",
                table: "stdents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lector", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stdents_LectorId",
                table: "stdents",
                column: "LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_stdents_Lector_LectorId",
                table: "stdents",
                column: "LectorId",
                principalTable: "Lector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stdents_Lector_LectorId",
                table: "stdents");

            migrationBuilder.DropTable(
                name: "Lector");

            migrationBuilder.DropIndex(
                name: "IX_stdents_LectorId",
                table: "stdents");

            migrationBuilder.DropColumn(
                name: "LecotrId",
                table: "stdents");

            migrationBuilder.DropColumn(
                name: "LectorId",
                table: "stdents");
        }
    }
}
