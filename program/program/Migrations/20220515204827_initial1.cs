using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace program.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookss",
                table: "Bookss");

            migrationBuilder.RenameTable(
                name: "Bookss",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Bookss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookss",
                table: "Bookss",
                column: "Id");
        }
    }
}
