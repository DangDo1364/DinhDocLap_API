using Microsoft.EntityFrameworkCore.Migrations;

namespace DinhDocLap_API.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaceBlock_Block_blockIDB",
                table: "FaceBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceBlock_Face_faceIDF",
                table: "FaceBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Face_faceIDF",
                table: "FaceNode");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Node_nodeIDN",
                table: "FaceNode");

            migrationBuilder.DropIndex(
                name: "IX_FaceNode_faceIDF",
                table: "FaceNode");

            migrationBuilder.DropIndex(
                name: "IX_FaceNode_nodeIDN",
                table: "FaceNode");

            migrationBuilder.DropIndex(
                name: "IX_FaceBlock_blockIDB",
                table: "FaceBlock");

            migrationBuilder.DropIndex(
                name: "IX_FaceBlock_faceIDF",
                table: "FaceBlock");

            migrationBuilder.DropColumn(
                name: "faceIDF",
                table: "FaceNode");

            migrationBuilder.DropColumn(
                name: "nodeIDN",
                table: "FaceNode");

            migrationBuilder.DropColumn(
                name: "blockIDB",
                table: "FaceBlock");

            migrationBuilder.DropColumn(
                name: "faceIDF",
                table: "FaceBlock");

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_IDN",
                table: "FaceNode",
                column: "IDN");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_IDB",
                table: "FaceBlock",
                column: "IDB");

            migrationBuilder.AddForeignKey(
                name: "FK_FaceBlock_Face",
                table: "FaceBlock",
                column: "IDF",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceBlock_Node",
                table: "FaceBlock",
                column: "IDB",
                principalTable: "Block",
                principalColumn: "IDB",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode",
                column: "IDN",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Node",
                table: "FaceNode",
                column: "IDN",
                principalTable: "Node",
                principalColumn: "IDN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaceBlock_Face",
                table: "FaceBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceBlock_Node",
                table: "FaceBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode");

            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Node",
                table: "FaceNode");

            migrationBuilder.DropIndex(
                name: "IX_FaceNode_IDN",
                table: "FaceNode");

            migrationBuilder.DropIndex(
                name: "IX_FaceBlock_IDB",
                table: "FaceBlock");

            migrationBuilder.AddColumn<int>(
                name: "faceIDF",
                table: "FaceNode",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nodeIDN",
                table: "FaceNode",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "blockIDB",
                table: "FaceBlock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "faceIDF",
                table: "FaceBlock",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_faceIDF",
                table: "FaceNode",
                column: "faceIDF");

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_nodeIDN",
                table: "FaceNode",
                column: "nodeIDN");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_blockIDB",
                table: "FaceBlock",
                column: "blockIDB");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_faceIDF",
                table: "FaceBlock",
                column: "faceIDF");

            migrationBuilder.AddForeignKey(
                name: "FK_FaceBlock_Block_blockIDB",
                table: "FaceBlock",
                column: "blockIDB",
                principalTable: "Block",
                principalColumn: "IDB",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceBlock_Face_faceIDF",
                table: "FaceBlock",
                column: "faceIDF",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Face_faceIDF",
                table: "FaceNode",
                column: "faceIDF",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Node_nodeIDN",
                table: "FaceNode",
                column: "nodeIDN",
                principalTable: "Node",
                principalColumn: "IDN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
