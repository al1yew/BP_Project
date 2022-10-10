using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Data.Migrations
{
    public partial class AddedWeightToDistanceToFrequencyRelationalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeightToDistanceToFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightId = table.Column<int>(nullable: false),
                    DistanceId = table.Column<int>(nullable: false),
                    FrequencyId = table.Column<int>(nullable: false)
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
        }
    }
}
