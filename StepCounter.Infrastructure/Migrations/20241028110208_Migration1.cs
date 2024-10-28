using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepCounter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
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
                values: new object[] { new Guid("2e76c467-716b-49ea-adc9-444ea003b115"), 0 });

            migrationBuilder.InsertData(
                table: "GlobalScores",
                columns: new[] { "Id", "CounterId" },
                values: new object[] { new Guid("46f7af77-91ce-4374-8368-b96fe18d09ea"), new Guid("2e76c467-716b-49ea-adc9-444ea003b115") });
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
