using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevLexicon.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTechTermModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentationLink",
                table: "TechTerm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentationLink",
                table: "TechTerm");
        }
    }
}
