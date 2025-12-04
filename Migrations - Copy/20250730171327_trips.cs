using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trip_planner_austin_hc.Migrations
{
    /// <inheritdoc />
    public partial class trips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    acommodationphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acommodationemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activityone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activitytwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activitythree = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.TripId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trips");
        }
    }
}
