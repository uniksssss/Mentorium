using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class AddIsMentorColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMentor",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMentor",
                table: "Users");
        }
    }
}
