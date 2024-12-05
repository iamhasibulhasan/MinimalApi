using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class gradetablemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                schema: "public",
                table: "Grades",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeName",
                schema: "public",
                table: "Grades");
        }
    }
}
