using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ItsDecidedDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PollTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomName = table.Column<string>(type: "text", nullable: false),
                    CustomDescription = table.Column<string>(type: "text", nullable: false),
                    PIN = table.Column<string>(type: "text", nullable: false),
                    PollTypeId = table.Column<int>(type: "integer", nullable: false),
                    PublicResults = table.Column<bool>(type: "boolean", nullable: false),
                    TotalSubmission = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PollTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Create a Poll and settle things once and for all!", "Ranking Poll" },
                    { 2, "Create a Poll and settle things once and for all!", "Flip-A-Coin" },
                    { 3, "A dice rolling simiulator", "Roll The Dice" },
                    { 4, "The digital form of drawing straws", "Pick A Number" }
                });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "CustomDescription", "CustomName", "PIN", "PollTypeId", "PublicResults", "TotalSubmission" },
                values: new object[] { 1, "CustomDescription", "Binos Poll", "3525", 1, false, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollTypes");

            migrationBuilder.DropTable(
                name: "Polls");
        }
    }
}
