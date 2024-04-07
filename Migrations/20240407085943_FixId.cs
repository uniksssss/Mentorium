using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class FixId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfoStacksStack",
                table: "StudentInfoStacksStack");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfoStacksStack_StudentInfoId",
                table: "StudentInfoStacksStack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorInfoStacks",
                table: "MentorInfoStacks");

            migrationBuilder.DropIndex(
                name: "IX_MentorInfoStacks_MentorInfoId",
                table: "MentorInfoStacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentInfoStacksStack");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MentorInfoStacks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TelegramUsers",
                newName: "TelegramUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentInfo",
                newName: "StudentInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stacks",
                newName: "MentoriumStacksId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MentorInfo",
                newName: "MentorInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GithubUsers",
                newName: "GithubUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfoStacksStack",
                table: "StudentInfoStacksStack",
                columns: new[] { "StudentInfoId", "StackId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorInfoStacks",
                table: "MentorInfoStacks",
                columns: new[] { "MentorInfoId", "StackId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfoStacksStack",
                table: "StudentInfoStacksStack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorInfoStacks",
                table: "MentorInfoStacks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TelegramUserId",
                table: "TelegramUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentInfoId",
                table: "StudentInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MentoriumStacksId",
                table: "Stacks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MentorInfoId",
                table: "MentorInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GithubUserId",
                table: "GithubUsers",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentInfoStacksStack",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MentorInfoStacks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfoStacksStack",
                table: "StudentInfoStacksStack",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorInfoStacks",
                table: "MentorInfoStacks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfoStacksStack_StudentInfoId",
                table: "StudentInfoStacksStack",
                column: "StudentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorInfoStacks_MentorInfoId",
                table: "MentorInfoStacks",
                column: "MentorInfoId");
        }
    }
}
