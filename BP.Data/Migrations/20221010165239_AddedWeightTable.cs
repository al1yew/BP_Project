using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Data.Migrations
{
    public partial class AddedWeightTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weight",
                table: "Weight");

            migrationBuilder.RenameTable(
                name: "Weight",
                newName: "Weights");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weights",
                table: "Weights",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weights",
                table: "Weights");

            migrationBuilder.RenameTable(
                name: "Weights",
                newName: "Weight");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight",
                table: "Weight",
                column: "Id");
        }
    }
}
