using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync2._0.Migrations
{
    public partial class ProjectTableChangeset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTableChangeSets",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false),
                    Json = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTableChangeSets", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTableChangeSets");
        }
    }
}
