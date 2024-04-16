using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorium.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorInfoStacks_Stacks_StackId",
                table: "MentorInfoStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfoStacksStack_Stacks_StackId",
                table: "StudentInfoStacksStack");

            migrationBuilder.RenameColumn(
                name: "StackId",
                table: "StudentInfoStacksStack",
                newName: "MentoriumStackId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentInfoStacksStack_StackId",
                table: "StudentInfoStacksStack",
                newName: "IX_StudentInfoStacksStack_MentoriumStackId");

            migrationBuilder.RenameColumn(
                name: "MentoriumStacksId",
                table: "Stacks",
                newName: "MentoriumStackId");

            migrationBuilder.RenameColumn(
                name: "StackId",
                table: "MentorInfoStacks",
                newName: "MentoriumStackId");

            migrationBuilder.RenameIndex(
                name: "IX_MentorInfoStacks_StackId",
                table: "MentorInfoStacks",
                newName: "IX_MentorInfoStacks_MentoriumStackId");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorInfoStacks_Stacks_MentoriumStackId",
                table: "MentorInfoStacks",
                column: "MentoriumStackId",
                principalTable: "Stacks",
                principalColumn: "MentoriumStackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfoStacksStack_Stacks_MentoriumStackId",
                table: "StudentInfoStacksStack",
                column: "MentoriumStackId",
                principalTable: "Stacks",
                principalColumn: "MentoriumStackId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorInfoStacks_Stacks_MentoriumStackId",
                table: "MentorInfoStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfoStacksStack_Stacks_MentoriumStackId",
                table: "StudentInfoStacksStack");

            migrationBuilder.RenameColumn(
                name: "MentoriumStackId",
                table: "StudentInfoStacksStack",
                newName: "StackId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentInfoStacksStack_MentoriumStackId",
                table: "StudentInfoStacksStack",
                newName: "IX_StudentInfoStacksStack_StackId");

            migrationBuilder.RenameColumn(
                name: "MentoriumStackId",
                table: "Stacks",
                newName: "MentoriumStacksId");

            migrationBuilder.RenameColumn(
                name: "MentoriumStackId",
                table: "MentorInfoStacks",
                newName: "StackId");

            migrationBuilder.RenameIndex(
                name: "IX_MentorInfoStacks_MentoriumStackId",
                table: "MentorInfoStacks",
                newName: "IX_MentorInfoStacks_StackId");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorInfoStacks_Stacks_StackId",
                table: "MentorInfoStacks",
                column: "StackId",
                principalTable: "Stacks",
                principalColumn: "MentoriumStacksId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfoStacksStack_Stacks_StackId",
                table: "StudentInfoStacksStack",
                column: "StackId",
                principalTable: "Stacks",
                principalColumn: "MentoriumStacksId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
