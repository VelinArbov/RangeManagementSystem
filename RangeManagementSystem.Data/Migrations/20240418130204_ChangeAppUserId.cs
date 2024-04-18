using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RangeManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId1",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingEvents_AspNetUsers_ApplicationUserId1",
                table: "ShootingEvents");

            migrationBuilder.DropIndex(
                name: "IX_ShootingEvents_ApplicationUserId1",
                table: "ShootingEvents");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ApplicationUserId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ShootingEvents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShootingEvents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ShootingEvents_ApplicationUserId",
                table: "ShootingEvents",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingEvents_AspNetUsers_ApplicationUserId",
                table: "ShootingEvents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShootingEvents_AspNetUsers_ApplicationUserId",
                table: "ShootingEvents");

            migrationBuilder.DropIndex(
                name: "IX_ShootingEvents_ApplicationUserId",
                table: "ShootingEvents");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ShootingEvents",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ShootingEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShootingEvents_ApplicationUserId1",
                table: "ShootingEvents",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId1",
                table: "Reservations",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId1",
                table: "Reservations",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShootingEvents_AspNetUsers_ApplicationUserId1",
                table: "ShootingEvents",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
