using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHotelBeach.Migrations
{
    /// <inheritdoc />
    public partial class sendReservacionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadPersonas",
                table: "Reservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadPersonas",
                table: "Reservacion");
        }
    }
}
