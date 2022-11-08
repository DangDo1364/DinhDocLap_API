using Microsoft.EntityFrameworkCore.Migrations;

namespace DinhDocLap_API.Migrations
{
    public partial class IniDBAddTbNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    IDN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x = table.Column<double>(type: "float", nullable: false),
                    y = table.Column<double>(type: "float", nullable: false),
                    z = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.IDN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Node");
        }
    }
}
