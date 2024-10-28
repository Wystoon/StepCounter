using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepCounter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StepCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CounterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MembersCountersIds = table.Column<string>(type: "TEXT", nullable: false),
                    TeamCounterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Counters",
                columns: new[] { "Id", "StepCount" },
                values: new object[] { new Guid("7c4fff6b-35da-481c-aef2-853496fa63c2"), 0 });

            migrationBuilder.InsertData(
                table: "GlobalScores",
                columns: new[] { "Id", "CounterId" },
                values: new object[] { new Guid("47fc1407-3b95-47fe-bbb7-cec7f0ee5f40"), new Guid("7c4fff6b-35da-481c-aef2-853496fa63c2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "GlobalScores");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
