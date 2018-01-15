using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Market.Data.Migrations
{
    public partial class OrderIsRecievedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Orders",
                newName: "WillSend");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecieved",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecieved",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WillSend",
                table: "Orders",
                newName: "IsApproved");
        }
    }
}
