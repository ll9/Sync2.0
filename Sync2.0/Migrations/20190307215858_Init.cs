using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync2._0.Migrations
{
    public partial class Init : Migration
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
                name: "ProjectTables",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTables", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ProjectTables_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchemaDefinitions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Columns = table.Column<string>(nullable: true),
                    ProjectTableName = table.Column<string>(nullable: true),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false)
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
                name: "IX_ProjectTables_ProjectId",
                table: "ProjectTables",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemaDefinitions_ProjectTableName",
                table: "SchemaDefinitions",
                column: "ProjectTableName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchemaDefinitions");

            migrationBuilder.DropTable(
                name: "ProjectTables");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
