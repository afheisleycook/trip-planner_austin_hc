using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trip_planner_austin_hc.Migrations
{
    /// <inheritdoc />
    public partial class activity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activityone",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "activitythree",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "activitytwo",
                table: "trips");

            migrationBuilder.AlterColumn<string>(
                name: "AccommodationPhone",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccommodationEmail",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Activity1",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activity2",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activity3",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity1",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Activity2",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Activity3",
                table: "trips");

            migrationBuilder.AlterColumn<string>(
                name: "AccommodationPhone",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccommodationEmail",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "activityone",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "activitythree",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "activitytwo",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
