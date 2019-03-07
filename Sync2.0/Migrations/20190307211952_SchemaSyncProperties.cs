using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync2._0.Migrations
{
    public partial class SchemaSyncProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SchemaDefinitions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "SchemaDefinitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "SchemaDefinitions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SchemaDefinitions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SchemaDefinitions");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "SchemaDefinitions");
        }
    }
}
