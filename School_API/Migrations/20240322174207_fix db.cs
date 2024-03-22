using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_API.Migrations
{
    public partial class fixdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stdents_Lector_LectorId",
                table: "stdents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stdents",
                table: "stdents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lector",
                table: "Lector");

            migrationBuilder.DropColumn(
                name: "LecotrId",
                table: "stdents");

            migrationBuilder.RenameTable(
                name: "stdents",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Lector",
                newName: "Lectors");

            migrationBuilder.RenameIndex(
                name: "IX_stdents_LectorId",
                table: "Students",
                newName: "IX_Students_LectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectors",
                table: "Lectors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lectors_LectorId",
                table: "Students",
                column: "LectorId",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lectors_LectorId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectors",
                table: "Lectors");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "stdents");

            migrationBuilder.RenameTable(
                name: "Lectors",
                newName: "Lector");

            migrationBuilder.RenameIndex(
                name: "IX_Students_LectorId",
                table: "stdents",
                newName: "IX_stdents_LectorId");

            migrationBuilder.AddColumn<int>(
                name: "LecotrId",
                table: "stdents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_stdents",
                table: "stdents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lector",
                table: "Lector",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_stdents_Lector_LectorId",
                table: "stdents",
                column: "LectorId",
                principalTable: "Lector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
