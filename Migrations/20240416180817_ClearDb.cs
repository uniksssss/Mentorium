using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class ClearDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MentorInfo_MentorInfoId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentInfo_StudentInfoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "GithubUsers");

            migrationBuilder.DropTable(
                name: "MentorInfoStacks");

            migrationBuilder.DropTable(
                name: "StudentInfoStacksStack");

            migrationBuilder.DropTable(
                name: "TelegramUsers");

            migrationBuilder.DropTable(
                name: "MentorInfo");

            migrationBuilder.DropTable(
                name: "Stacks");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropIndex(
                name: "IX_Users_MentorInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MentorInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentInfoId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Descriotion",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "GithubId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramId",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GithubId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Descriotion",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorInfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentInfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GithubUsers",
                columns: table => new
                {
                    GithubUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubUsers", x => x.GithubUserId);
                    table.ForeignKey(
                        name: "FK_GithubUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorInfo",
                columns: table => new
                {
                    MentorInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorInfo", x => x.MentorInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Stacks",
                columns: table => new
                {
                    MentoriumStackId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stacks", x => x.MentoriumStackId);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    StudentInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.StudentInfoId);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUsers",
                columns: table => new
                {
                    TelegramUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUsers", x => x.TelegramUserId);
                    table.ForeignKey(
                        name: "FK_TelegramUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorInfoStacks",
                columns: table => new
                {
                    MentorInfoId = table.Column<int>(type: "integer", nullable: false),
                    MentoriumStackId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorInfoStacks", x => new { x.MentorInfoId, x.MentoriumStackId });
                    table.ForeignKey(
                        name: "FK_MentorInfoStacks_MentorInfo_MentorInfoId",
                        column: x => x.MentorInfoId,
                        principalTable: "MentorInfo",
                        principalColumn: "MentorInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorInfoStacks_Stacks_MentoriumStackId",
                        column: x => x.MentoriumStackId,
                        principalTable: "Stacks",
                        principalColumn: "MentoriumStackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfoStacksStack",
                columns: table => new
                {
                    StudentInfoId = table.Column<int>(type: "integer", nullable: false),
                    MentoriumStackId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfoStacksStack", x => new { x.StudentInfoId, x.MentoriumStackId });
                    table.ForeignKey(
                        name: "FK_StudentInfoStacksStack_Stacks_MentoriumStackId",
                        column: x => x.MentoriumStackId,
                        principalTable: "Stacks",
                        principalColumn: "MentoriumStackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInfoStacksStack_StudentInfo_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "StudentInfo",
                        principalColumn: "StudentInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MentorInfoId",
                table: "Users",
                column: "MentorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentInfoId",
                table: "Users",
                column: "StudentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GithubUsers_UserId",
                table: "GithubUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorInfoStacks_MentoriumStackId",
                table: "MentorInfoStacks",
                column: "MentoriumStackId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfoStacksStack_MentoriumStackId",
                table: "StudentInfoStacksStack",
                column: "MentoriumStackId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUsers_UserId",
                table: "TelegramUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MentorInfo_MentorInfoId",
                table: "Users",
                column: "MentorInfoId",
                principalTable: "MentorInfo",
                principalColumn: "MentorInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentInfo_StudentInfoId",
                table: "Users",
                column: "StudentInfoId",
                principalTable: "StudentInfo",
                principalColumn: "StudentInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
