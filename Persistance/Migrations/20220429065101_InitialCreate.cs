using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        // the up method is what we use to create our database
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: true),
                    EventCoordinator = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfParticipants = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.id);
                });
        }

        // we also have the down method that we use when we want to go to 
        // an earlier migration, we drop this particular table.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
