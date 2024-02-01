using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codecord_api.Migrations
{
    /// <inheritdoc />
    public partial class AddServerUserListMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ServerId",
                table: "User",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Server_ServerId",
                table: "User",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Server_ServerId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ServerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "User");
        }
    }
}
