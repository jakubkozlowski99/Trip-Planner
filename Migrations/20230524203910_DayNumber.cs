using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_web_app.Migrations
{
    /// <inheritdoc />
    public partial class DayNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayNumber",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayNumber",
                table: "Days");
        }
    }
}
