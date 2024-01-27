using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codecord_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCatToChannelRelationshipMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextChatChannel",
                table: "Channel");

            migrationBuilder.RenameColumn(
                name: "VoiceChatChannel",
                table: "Channel",
                newName: "Topic");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Channel",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Channel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Channel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Channel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Channel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Channel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsText",
                table: "Channel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoice",
                table: "Channel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Channel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Channel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channel_CategoryId",
                table: "Channel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channel_Category_CategoryId",
                table: "Channel",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channel_Category_CategoryId",
                table: "Channel");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Channel_CategoryId",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "IsText",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "IsVoice",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Channel");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Channel",
                newName: "VoiceChatChannel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Channel",
                newName: "ChannelId");

            migrationBuilder.AddColumn<string>(
                name: "TextChatChannel",
                table: "Channel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
