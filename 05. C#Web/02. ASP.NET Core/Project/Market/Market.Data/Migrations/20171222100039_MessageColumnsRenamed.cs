using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Market.Data.Migrations
{
    public partial class MessageColumnsRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_FirstParticipantId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SecondParticipantId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SecondParticipantId",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "FirstParticipantId",
                table: "Messages",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SecondParticipantId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FirstParticipantId",
                table: "Messages",
                newName: "IX_Messages_RecieverId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TextSentDate",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RecieverId",
                table: "Messages",
                column: "RecieverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RecieverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TextSentDate",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "SecondParticipantId");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "Messages",
                newName: "FirstParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                newName: "IX_Messages_SecondParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverId",
                table: "Messages",
                newName: "IX_Messages_FirstParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_FirstParticipantId",
                table: "Messages",
                column: "FirstParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SecondParticipantId",
                table: "Messages",
                column: "SecondParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
