using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurantium.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_columns_added_companysocialmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialMediaUrl",
                table: "CompanySocialMedias",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "CompanySocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "CompanySocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "CompanySocialMedias");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "CompanySocialMedias");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "CompanySocialMedias",
                newName: "SocialMediaUrl");
        }
    }
}
