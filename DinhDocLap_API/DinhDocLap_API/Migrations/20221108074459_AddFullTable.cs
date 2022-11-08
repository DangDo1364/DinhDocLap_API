using Microsoft.EntityFrameworkCore.Migrations;

namespace DinhDocLap_API.Migrations
{
    public partial class AddFullTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockType",
                columns: table => new
                {
                    IDBT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colorEdge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockType", x => x.IDBT);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    IDBD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buildingDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.IDBD);
                });

            migrationBuilder.CreateTable(
                name: "Face",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Face", x => x.IDF);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    IDB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBT = table.Column<int>(type: "int", nullable: false),
                    blockDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDBD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.IDB);
                    table.ForeignKey(
                        name: "FK_Block_BlockType_IDBT",
                        column: x => x.IDBT,
                        principalTable: "BlockType",
                        principalColumn: "IDBT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Block_Building_IDBD",
                        column: x => x.IDBD,
                        principalTable: "Building",
                        principalColumn: "IDBD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceNode",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false),
                    IDN = table.Column<int>(type: "int", nullable: false),
                    seq = table.Column<int>(type: "int", nullable: false),
                    faceIDF = table.Column<int>(type: "int", nullable: true),
                    nodeIDN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceNode", x => new { x.IDF, x.IDN });
                    table.ForeignKey(
                        name: "FK_FaceNode_Face_faceIDF",
                        column: x => x.faceIDF,
                        principalTable: "Face",
                        principalColumn: "IDF",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceNode_Node_nodeIDN",
                        column: x => x.nodeIDN,
                        principalTable: "Node",
                        principalColumn: "IDN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaceBlock",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false),
                    IDB = table.Column<int>(type: "int", nullable: false),
                    faceIDF = table.Column<int>(type: "int", nullable: true),
                    blockIDB = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceBlock", x => new { x.IDF, x.IDB });
                    table.ForeignKey(
                        name: "FK_FaceBlock_Block_blockIDB",
                        column: x => x.blockIDB,
                        principalTable: "Block",
                        principalColumn: "IDB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceBlock_Face_faceIDF",
                        column: x => x.faceIDF,
                        principalTable: "Face",
                        principalColumn: "IDF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_IDBD",
                table: "Block",
                column: "IDBD");

            migrationBuilder.CreateIndex(
                name: "IX_Block_IDBT",
                table: "Block",
                column: "IDBT");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_blockIDB",
                table: "FaceBlock",
                column: "blockIDB");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_faceIDF",
                table: "FaceBlock",
                column: "faceIDF");

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_faceIDF",
                table: "FaceNode",
                column: "faceIDF");

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_nodeIDN",
                table: "FaceNode",
                column: "nodeIDN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaceBlock");

            migrationBuilder.DropTable(
                name: "FaceNode");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Face");

            migrationBuilder.DropTable(
                name: "BlockType");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
