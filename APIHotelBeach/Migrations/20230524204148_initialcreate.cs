using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHotelBeach.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    IdPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    ProcentajePrima = table.Column<double>(type: "float", nullable: false),
                    NumMensualidades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.IdPaquete);
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    idReservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadNoches = table.Column<int>(type: "int", nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    PaqueteEscogido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    Prima = table.Column<double>(type: "float", nullable: false),
                    PagoMensual = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.idReservacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Restablecer = table.Column<int>(type: "int", nullable: false),
                    RolAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "Cedula", "CorreoElectronico", "Direccion", "NombreCompleto", "Telefono", "TipoCedula" },
                values: new object[] { 1, "504420978", "ejemplo@gmail.com", "hhh", "Luis", 222222, "Juridica" });

            migrationBuilder.InsertData(
                table: "Paquete",
                columns: new[] { "IdPaquete", "NombrePaquete", "NumMensualidades", "Precio", "ProcentajePrima" },
                values: new object[] { 1, "Todo Incluido", 24, 450.0, 0.45000000000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
