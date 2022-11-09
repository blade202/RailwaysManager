using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainBackendApi.Migrations
{
    public partial class updaterefrestoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "RefreshTokens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "RefreshTokens");
        }
    }
}
