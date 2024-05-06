using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class RenameTextColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "MessageText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "Text");
        }
    }
}
