using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codecord_api.Migrations
{
    /// <inheritdoc />
    public partial class AddServerToCategoryRelationshipMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ServerId",
                table: "Category",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Server_ServerId",
                table: "Category",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Server_ServerId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ServerId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Category");
        }
    }
}
