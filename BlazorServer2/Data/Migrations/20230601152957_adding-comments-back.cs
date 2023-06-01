using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class addingcommentsback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_BlogPosts_BlogPostId",
            //    table: "Comments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Comments_BlogPostId",
            //    table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId",
                table: "Comments",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
