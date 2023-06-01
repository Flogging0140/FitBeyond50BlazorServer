using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class spellingontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_AspNetUsers_UserId",
                table: "Commments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commments",
                table: "Commments");

            migrationBuilder.RenameTable(
                name: "Commments",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Commments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Commments");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Commments",
                newName: "IX_Commments_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commments",
                table: "Commments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_AspNetUsers_UserId",
                table: "Commments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
