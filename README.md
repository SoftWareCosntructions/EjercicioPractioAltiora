# Ejercicio Practico aplicacion Altiora
La aplicación debe gestionar un listado de Clientes, cada uno con Órdenes compuestas de
Artículos. Para el Cliente, interesa registrar su nombre y apellido; para una Orden, su fecha
y sus Artículos. Y para cada Artículo, un código, un nombre y un precio unitario. Para todas
las Entidades, debe existir una pantalla correspondiente para crear instancias de la Entidad;
sin embargo, solo para una de ellas, esa pantalla debe permitir modificar y eliminar además
de crear (es suficiente un solo ejemplo de CRUD completo).

## Instrucciones
Base de datos:
Para crear la base de datos, debe ir al proyecto Altiora.Service y en el archivo settings.json reemplazar la cadena de conección.
#### Para generar migraciones
dotnet ef --startup-project .\Altiora.Service\Altiora.Service.csproj migrations add InitialModel -p .\Altiora.DataAccess\Altiora.DataAccess.csproj

#### Para actualizar la base de datos  colocar la consola en la raiz del proyecto y ejecutar el siguiente comando:
dotnet ef --startup-project .\Altiora.Service\Altiora.Service.csproj database update

#### Para añadir datos en las tablas colocar la consola en la raiz del proyecto y ejecutar el siguiente comando:
dotnet ef --startup-project .\Altiora.Service\Altiora.Service.csproj migrations add SeedDataTable -p .\Altiora.DataAccess\Altiora.DataAccess.csproj

A continuacion en el archivo generado agregamos el siguiente codigo:

```C#
protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Agregar Articulos
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_articulos ON " +
                     "  INSERT INTO alti_tab_articulos " +
                     "  (CodigoArticulo, NombreArticulo, PrecioUnitarioArticulo)VALUES " +
                     "  (1, 'PROD001', 'Laptop DEL I5', 845.00), " +
                     "  (2, 'PROD002', 'Laptop HP I3', 625.00), " +
                     "  (3, 'PROD003', 'Laptop Lenovo AMD Ryzen 5', 632.00)" +
                    "SET IDENTITY_INSERT alti_tab_articulos OFF");

            //Agregar Clientes 
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_clientes ON " +
                     "  INSERT INTO alti_tab_clientes " +
                     "  (IdCliente, DniCliente, Nombre, Apellido)VALUES " +
                     "  (1, '1717007197', 'Santiago', 'Almeida'), " +
                     "  (2, '1713824577', 'Irene', 'Villalobos'), " +
                     "  (3, '1800789745', 'Juan', 'Saltos')" +
                    "SET IDENTITY_INSERT alti_tab_clientes OFF");

            //Agregar Ordenes
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_ordenes ON " +
                    "   INSERT INTO alti_tab_ordenes " +
                    "   (IdOrden, FechaOrden, IdCliente, NumeroOrden, Subtotal, MontoIva, MontoTotal)VALUES " +
                    "   (1, '20201208', 1, 'ORD00001', 845.00, 101.4, 946), " +
                    "   (2, '20201209', 2, 'ORD00002', 625.00, 75, 700) " +
                    "SET IDENTITY_INSERT alti_tab_ordenes OFF");

            //Agregar DetallesOrden
            migrationBuilder
                .Sql("SET IDENTITY_INSERT alti_tab_detalles_orden ON " +
                "   INSERT INTO alti_tab_detalles_orden " +
                "   (IdDetalleOrden, IdOrden, IdArticulo, Cantidad, PrecioTotal)VALUES " +
                "   (1, 1, 1, 1, 845.00), " +
                "   (2, 2, 2, 1, 625.00) " +
                "SET IDENTITY_INSERT alti_tab_detalles_orden OFF");
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
```
  
#### A continuación actualizamos la base de datos.
dotnet ef --startup-project .\Altiora.Service\Altiora.Service.csproj database update

#### LISTO!!!
Espero sea de su agrado

Santiago Almeida.
099998136
