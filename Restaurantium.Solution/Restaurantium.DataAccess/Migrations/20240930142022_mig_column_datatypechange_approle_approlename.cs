﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurantium.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_column_datatypechange_approle_approlename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppRoleName",
                table: "AppRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AppRoleName",
                table: "AppRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
