using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seconds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Positions_Name_Deleted",
                table: "Positions");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name_Deleted",
                table: "Positions",
                columns: new[] { "Name", "Deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Positions_Name_Deleted",
                table: "Positions");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name_Deleted",
                table: "Positions",
                columns: new[] { "Name", "Deleted" });
        }
    }
}
