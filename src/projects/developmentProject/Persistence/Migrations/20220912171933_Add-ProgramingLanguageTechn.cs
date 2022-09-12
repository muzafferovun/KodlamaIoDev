using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddProgramingLanguageTechn : Migration
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

            migrationBuilder.CreateTable(
                name: "ProgramingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramingLanguageTechnologies_ProgramingLanguages_ProgramingLanguageId",
                        column: x => x.ProgramingLanguageId,
                        principalTable: "ProgramingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, ".net CSharp", "C#" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Java Springboot", "Java" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "JavaScript", "JavaScript" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[,]
                {
                    { 1, "WPF", 1 },
                    { 2, "Asp.net", 1 },
                    { 3, "Spring", 2 },
                    { 4, "JSP", 2 },
                    { 5, "Vue", 3 },
                    { 6, "React", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramingLanguageTechnologies_ProgramingLanguageId",
                table: "ProgramingLanguageTechnologies",
                column: "ProgramingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingLanguageTechnologies");

            migrationBuilder.DropTable(
                name: "ProgramingLanguages");
        }
    }
}
