using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoriKeeper.Model.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase_1002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "FileTypes",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Diaryentries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FileTypes",
                newName: "TypeName");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Diaryentries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
