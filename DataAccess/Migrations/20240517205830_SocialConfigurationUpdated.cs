using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SocialConfigurationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Socials_TeamBoardId_Deleted_FacebookUrl_TwitterUrl_PinterestUrl_LinkedinUrl",
                table: "Socials");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_TeamBoardId_Deleted",
                table: "Socials",
                columns: new[] { "TeamBoardId", "Deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Socials_TeamBoardId_Deleted",
                table: "Socials");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_TeamBoardId_Deleted_FacebookUrl_TwitterUrl_PinterestUrl_LinkedinUrl",
                table: "Socials",
                columns: new[] { "TeamBoardId", "Deleted", "FacebookUrl", "TwitterUrl", "PinterestUrl", "LinkedinUrl" },
                unique: true);
        }
    }
}
