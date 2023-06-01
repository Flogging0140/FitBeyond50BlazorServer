using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer2.Data.Migrations
{
    public partial class fkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentityUserId",
                table: "Commments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Commments");
        }
    }
}
