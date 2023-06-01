using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class postcommentsfix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_BlogPosts_BlogPostId1",
            //    table: "Comments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Comments_BlogPostId1",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "BlogPostId1",
            //    table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId1",
                table: "Comments",
                column: "BlogPostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId1",
                table: "Comments",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }
    }
}
