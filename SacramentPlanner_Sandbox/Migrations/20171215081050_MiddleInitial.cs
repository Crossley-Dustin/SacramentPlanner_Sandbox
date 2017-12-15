using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner_Sandbox.Migrations
{
    public partial class MiddleInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Person",
                newName: "MiddleInitial");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "MiddleInitial",
                table: "Person",
                newName: "FirstMidName");
        }
    }
}
