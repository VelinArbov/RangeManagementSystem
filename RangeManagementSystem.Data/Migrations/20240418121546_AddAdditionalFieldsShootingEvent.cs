using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RangeManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalFieldsShootingEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "ShootingEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinParticipants",
                table: "ShootingEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "ShootingEvents");

            migrationBuilder.DropColumn(
                name: "MinParticipants",
                table: "ShootingEvents");
        }
    }
}
