using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync2._0.Migrations
{
    public partial class ProjectTableMoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectTables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Json",
                table: "ProjectTables",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "ProjectTables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "ProjectTables",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectTables");

            migrationBuilder.DropColumn(
                name: "Json",
                table: "ProjectTables");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ProjectTables");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "ProjectTables");
        }
    }
}
