using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_MP1.Migrations
{
    /// <inheritdoc />
    public partial class PlannerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventPlannerID",
                table: "Eveniment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventPlanner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlanner", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eveniment_EventPlannerID",
                table: "Eveniment",
                column: "EventPlannerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Eveniment_EventPlanner_EventPlannerID",
                table: "Eveniment",
                column: "EventPlannerID",
                principalTable: "EventPlanner",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eveniment_EventPlanner_EventPlannerID",
                table: "Eveniment");

            migrationBuilder.DropTable(
                name: "EventPlanner");

            migrationBuilder.DropIndex(
                name: "IX_Eveniment_EventPlannerID",
                table: "Eveniment");

            migrationBuilder.DropColumn(
                name: "EventPlannerID",
                table: "Eveniment");
        }
    }
}
