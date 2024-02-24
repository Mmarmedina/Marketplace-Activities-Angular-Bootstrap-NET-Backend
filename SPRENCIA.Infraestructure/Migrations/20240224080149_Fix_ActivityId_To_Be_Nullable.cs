using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPRENCIA.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_ActivityId_To_Be_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivityId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivityId",
                table: "Reviews",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivityId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivityId",
                table: "Reviews",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
