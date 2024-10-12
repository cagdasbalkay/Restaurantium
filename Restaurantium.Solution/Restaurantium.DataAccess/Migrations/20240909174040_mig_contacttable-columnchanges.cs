using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurantium.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_contacttablecolumnchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapUrl",
                table: "Contacts",
                newName: "Subject");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Contacts",
                newName: "MapUrl");
        }
    }
}
