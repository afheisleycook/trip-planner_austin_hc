using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trip_planner_austin_hc.Migrations
{
    /// <inheritdoc />
    public partial class email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "acommodationphone",
                table: "trips",
                newName: "AccommodationPhone");

            migrationBuilder.RenameColumn(
                name: "acommodationemail",
                table: "trips",
                newName: "AccommodationEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccommodationPhone",
                table: "trips",
                newName: "acommodationphone");

            migrationBuilder.RenameColumn(
                name: "AccommodationEmail",
                table: "trips",
                newName: "acommodationemail");
        }
    }
}
