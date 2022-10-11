using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Data.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weight",
                table: "Weight");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Weight");

            migrationBuilder.RenameTable(
                name: "Weight",
                newName: "Weights");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Weights",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weights",
                table: "Weights",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Distances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightToDistanceToFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightId = table.Column<int>(nullable: false),
                    DistanceId = table.Column<int>(nullable: false),
                    FrequencyId = table.Column<int>(nullable: false),
                    NeedToAssess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightToDistanceToFrequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightToDistanceToFrequencies_Distances_DistanceId",
                        column: x => x.DistanceId,
                        principalTable: "Distances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeightToDistanceToFrequencies_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeightToDistanceToFrequencies_Weights_WeightId",
                        column: x => x.WeightId,
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightToDistanceToFrequencies_DistanceId",
                table: "WeightToDistanceToFrequencies",
                column: "DistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightToDistanceToFrequencies_FrequencyId",
                table: "WeightToDistanceToFrequencies",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightToDistanceToFrequencies_WeightId",
                table: "WeightToDistanceToFrequencies",
                column: "WeightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeightToDistanceToFrequencies");

            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weights",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Weights");

            migrationBuilder.RenameTable(
                name: "Weights",
                newName: "Weight");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Weight",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight",
                table: "Weight",
                column: "Id");
        }
    }
}
