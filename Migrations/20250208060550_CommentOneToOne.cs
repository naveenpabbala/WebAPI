using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class CommentOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_comments_AppUserId",
                table: "comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_AppUserId",
                table: "comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_AppUserId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_AppUserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "comments");
        }
    }
}
