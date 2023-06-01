using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class addedforeignkeysocantrackinobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_AspNetUsers_IdentityUserId",
                table: "Commments");

            migrationBuilder.DropIndex(
                name: "IX_Commments_IdentityUserId",
                table: "Commments");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "Commments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Commments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commments_IdentityUserId1",
                table: "Commments",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_AspNetUsers_IdentityUserId1",
                table: "Commments",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_AspNetUsers_IdentityUserId1",
                table: "Commments");

            migrationBuilder.DropIndex(
                name: "IX_Commments_IdentityUserId1",
                table: "Commments");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Commments");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Commments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Commments_IdentityUserId",
                table: "Commments",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_AspNetUsers_IdentityUserId",
                table: "Commments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
