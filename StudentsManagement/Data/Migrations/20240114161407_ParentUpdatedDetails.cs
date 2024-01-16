using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class ParentUpdatedDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_GenderId",
                table: "Parents",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_SystemCodeDetails_GenderId",
                table: "Parents",
                column: "GenderId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_SystemCodeDetails_GenderId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_GenderId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
