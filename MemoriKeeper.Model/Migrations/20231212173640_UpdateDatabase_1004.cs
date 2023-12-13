using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoriKeeper.Model.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase_1004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Diaryentries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "Diaryentries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Diaryentries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Diaryentries");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "Diaryentries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Diaryentries");
        }
    }
}
