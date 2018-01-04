using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace World_Travel_Blog.Migrations
{
    public partial class addpricetoexperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Experiences");
        }
    }
}
