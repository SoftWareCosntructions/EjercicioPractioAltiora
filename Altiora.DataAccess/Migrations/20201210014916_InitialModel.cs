using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Altiora.DataAccess.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alti_tab_articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoArticulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NombreArticulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrecioUnitarioArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alti_tab_articulos", x => x.IdArticulo);
                });

            migrationBuilder.CreateTable(
                name: "alti_tab_clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniCliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alti_tab_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "alti_tab_ordenes",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroOrden = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoIva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alti_tab_ordenes", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_alti_tab_ordenes_alti_tab_clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "alti_tab_clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alti_tab_detalles_orden",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alti_tab_detalles_orden", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_alti_tab_detalles_orden_alti_tab_articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "alti_tab_articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alti_tab_detalles_orden_alti_tab_ordenes_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "alti_tab_ordenes",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alti_tab_detalles_orden_IdArticulo",
                table: "alti_tab_detalles_orden",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_alti_tab_detalles_orden_IdOrden",
                table: "alti_tab_detalles_orden",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_alti_tab_ordenes_IdCliente",
                table: "alti_tab_ordenes",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alti_tab_detalles_orden");

            migrationBuilder.DropTable(
                name: "alti_tab_articulos");

            migrationBuilder.DropTable(
                name: "alti_tab_ordenes");

            migrationBuilder.DropTable(
                name: "alti_tab_clientes");
        }
    }
}
