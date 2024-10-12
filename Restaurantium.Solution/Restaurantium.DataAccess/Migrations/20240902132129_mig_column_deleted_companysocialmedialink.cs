using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurantium.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_column_deleted_companysocialmedialink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "CompanySocialMedias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "CompanySocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
