using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync2._0.Migrations
{
    public partial class Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchemaDefinitions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Columns = table.Column<string>(nullable: true),
                    ProjectTableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemaDefinitions_ProjectTables_ProjectTableName",
                        column: x => x.ProjectTableName,
                        principalTable: "ProjectTables",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchemaDefinitions_ProjectTableName",
                table: "SchemaDefinitions",
                column: "ProjectTableName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SchemaDefinitions");
        }
    }
}
