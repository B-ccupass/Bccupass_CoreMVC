using Microsoft.EntityFrameworkCore.Migrations;

namespace Bccupass_CoreMVC.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuyerConpanyName",
                table: "TicketDetailOrderDetail",
                newName: "BuyerCompanyName");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Enum 線下活動: 活動地址(行政區)",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Enum 線下活動: 活動地址(行政區)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Activity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Enum 線下活動: 活動地址(縣市)",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Enum 線下活動: 活動地址(縣市)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuyerCompanyName",
                table: "TicketDetailOrderDetail",
                newName: "BuyerConpanyName");

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Activity",
                type: "int",
                nullable: true,
                comment: "Enum 線下活動: 活動地址(行政區)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Enum 線下活動: 活動地址(行政區)");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Activity",
                type: "int",
                nullable: true,
                comment: "Enum 線下活動: 活動地址(縣市)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Enum 線下活動: 活動地址(縣市)");
        }
    }
}
