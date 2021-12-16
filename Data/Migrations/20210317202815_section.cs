using Microsoft.EntityFrameworkCore.Migrations;

namespace pallada.Data.Migrations
{
    public partial class section : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "categoryModel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categoryModel",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "sectionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sectionModel_categoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sectionModel_CategoryId",
                table: "sectionModel",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sectionModel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categoryModel",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categoryModel",
                newName: "id");
        }
    }
}
