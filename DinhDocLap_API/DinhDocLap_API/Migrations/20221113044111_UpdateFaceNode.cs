using Microsoft.EntityFrameworkCore.Migrations;

namespace DinhDocLap_API.Migrations
{
    public partial class UpdateFaceNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode");

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode",
                column: "IDF",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode");

            migrationBuilder.AddForeignKey(
                name: "FK_FaceNode_Face",
                table: "FaceNode",
                column: "IDN",
                principalTable: "Face",
                principalColumn: "IDF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
