using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codecord_api.Migrations
{
    /// <inheritdoc />
    public partial class AddServerRelationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Server",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Server_UserId",
                table: "Server",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Server_User_UserId",
                table: "Server",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Server_User_UserId",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Server_UserId",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Server");
        }
    }
}
