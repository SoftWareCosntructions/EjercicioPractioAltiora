using Microsoft.EntityFrameworkCore.Migrations;

namespace Altiora.DataAccess.Migrations
{
    public partial class SeedDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Agregar Articulos
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_articulos ON " +
                     "  INSERT INTO alti_tab_articulos " +
                     "  (IdArticulo, CodigoArticulo, NombreArticulo, PrecioUnitarioArticulo)VALUES " +
                     "  (1, 'PROD001', 'Laptop DEL I5', 845.00), " +
                     "  (2, 'PROD002', 'Laptop HP I3', 625.00), " +
                     "  (3, 'PROD003', 'Laptop Lenovo AMD Ryzen 5', 632.00)" +
                    "SET IDENTITY_INSERT alti_tab_articulos OFF ");

            //Agregar Clientes 
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_clientes ON " +
                     "  INSERT INTO alti_tab_clientes " +
                     "  (IdCliente, DniCliente, Nombre, Apellido)VALUES " +
                     "  (1, '1717007197', 'Santiago', 'Almeida'), " +
                     "  (2, '1713824577', 'Irene', 'Villalobos'), " +
                     "  (3, '1800789745', 'Juan', 'Saltos')" +
                    "SET IDENTITY_INSERT alti_tab_clientes OFF ");

            //Agregar Ordenes
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_ordenes ON " +
                    "   INSERT INTO alti_tab_ordenes " +
                    "   (IdOrden, FechaOrden, IdCliente, NumeroOrden, Subtotal, MontoIva, MontoTotal)VALUES " +
                    "   (1, '20201208', 1, 'ORD00001', 845.00, 101.4, 946), " +
                    "   (2, '20201209', 2, 'ORD00002', 625.00, 75, 700) " +
                    "SET IDENTITY_INSERT alti_tab_ordenes OFF ");

            //Agregar DetallesOrden
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_detalles_orden ON " +
                "   INSERT INTO alti_tab_detalles_orden " +
                "   (IdDetalleOrden, IdOrden, IdArticulo, Cantidad, PrecioTotal)VALUES " +
                "   (1, 1, 1, 1, 845.00), " +
                "   (2, 2, 2, 1, 625.00) " +
                "SET IDENTITY_INSERT alti_tab_detalles_orden OFF ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM alti_tab_detalles_orden");

            migrationBuilder
                .Sql("DELETE FROM alti_tab_articulos");

            migrationBuilder
                .Sql("DELETE FROM alti_tab_ordenes");

            migrationBuilder
                .Sql("DELETE FROM alti_tab_clientes");
        }
    }
}
