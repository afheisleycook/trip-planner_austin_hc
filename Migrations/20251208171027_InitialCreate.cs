using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trip_planner_austin_hc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "AccommodationEmail",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "AccommodationPhone",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Activity1",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Activity2",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Activity3",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "trips");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTrip",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    TripsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTrip", x => new { x.ActivitiesId, x.TripsTripId });
                    table.ForeignKey(
                        name: "FK_ActivityTrip_Activity_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityTrip_trips_TripsTripId",
                        column: x => x.TripsTripId,
                        principalTable: "trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trips_AccommodationId",
                table: "trips",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_DestinationId",
                table: "trips",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTrip_TripsTripId",
                table: "ActivityTrip",
                column: "TripsTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_trips_Accommodation_AccommodationId",
                table: "trips",
                column: "AccommodationId",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_Destination_DestinationId",
                table: "trips",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trips_Accommodation_AccommodationId",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_Destination_DestinationId",
                table: "trips");

            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "ActivityTrip");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_trips_AccommodationId",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_DestinationId",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "trips");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccommodationEmail",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationPhone",
                table: "trips",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
