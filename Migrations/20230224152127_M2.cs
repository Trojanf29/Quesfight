using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuesFight.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CollectionName",
                table: "QuesCollections",
                type: "NVARCHAR(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(45)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CollectionName",
                table: "QuesCollections",
                type: "NVARCHAR(45)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(45)",
                oldNullable: true);
        }
    }
}
