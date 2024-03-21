using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPRENCIA.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_entity_name_ActivitiesSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySchedule");

            migrationBuilder.CreateTable(
                name: "ActivitiesSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesSchedules_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesSchedules_ActivityId",
                table: "ActivitiesSchedules",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesSchedules_ScheduleId",
                table: "ActivitiesSchedules",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesSchedules");

            migrationBuilder.CreateTable(
                name: "ActivitySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySchedule_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySchedule_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySchedule_ActivityId",
                table: "ActivitySchedule",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySchedule_ScheduleId",
                table: "ActivitySchedule",
                column: "ScheduleId");
        }
    }
}
