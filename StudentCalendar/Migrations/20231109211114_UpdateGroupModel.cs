using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCalendar.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroupModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Course",
                table: "Groups",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
