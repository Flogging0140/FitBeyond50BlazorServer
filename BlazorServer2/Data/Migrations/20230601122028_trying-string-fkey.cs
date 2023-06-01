using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class tryingstringfkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Commments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Commments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Commments_UserId",
                table: "Commments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_AspNetUsers_UserId",
                table: "Commments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_AspNetUsers_UserId",
                table: "Commments");

            migrationBuilder.DropIndex(
                name: "IX_Commments_UserId",
                table: "Commments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Commments");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Commments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
