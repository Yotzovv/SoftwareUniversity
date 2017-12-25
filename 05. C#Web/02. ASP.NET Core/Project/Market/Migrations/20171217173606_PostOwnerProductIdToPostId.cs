using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Market.Data.Migrations
{
    public partial class PostOwnerProductIdToPostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostOwner_Post_PostId",
                table: "PostOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostOwner",
                table: "PostOwner");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PostOwner");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostOwner",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostOwner",
                table: "PostOwner",
                columns: new[] { "OwnerId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostOwner_Post_PostId",
                table: "PostOwner",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostOwner_Post_PostId",
                table: "PostOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostOwner",
                table: "PostOwner");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostOwner",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PostOwner",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostOwner",
                table: "PostOwner",
                columns: new[] { "OwnerId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostOwner_Post_PostId",
                table: "PostOwner",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
