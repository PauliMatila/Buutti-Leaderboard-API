using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leaderboard_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying", nullable: false),
                    country_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time_stamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    time_in_seconds = table.Column<int>(type: "integer", nullable: false),
                    high_score = table.Column<int>(type: "integer", nullable: false),
                    player_id = table.Column<int>(type: "integer", nullable: false),
                    level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.id);
                    table.ForeignKey(
                        name: "scores_level_id_fkey",
                        column: x => x.level_id,
                        principalTable: "levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "scores_player_id_fkey",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scores_level_id",
                table: "scores",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_scores_player_id",
                table: "scores",
                column: "player_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "levels");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
