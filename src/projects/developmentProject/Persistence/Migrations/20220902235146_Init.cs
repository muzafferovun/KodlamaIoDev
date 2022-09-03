using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, ".net CSharp", "C#" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Java Springboot", "Java" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingLanguages");
        }
    }
}
