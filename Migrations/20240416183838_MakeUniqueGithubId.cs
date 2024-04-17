using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class MakeUniqueGithubId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriotion",
                table: "Users",
                newName: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GithubId",
                table: "Users",
                column: "GithubId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_GithubId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Users",
                newName: "Descriotion");
        }
    }
}
