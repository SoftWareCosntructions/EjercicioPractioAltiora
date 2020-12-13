# Ejercicio Practico aplicacion Altiora
La aplicación debe gestionar un listado de Clientes, cada uno con Órdenes compuestas de
Artículos. Para el Cliente, interesa registrar su nombre y apellido; para una Orden, su fecha
y sus Artículos. Y para cada Artículo, un código, un nombre y un precio unitario. Para todas
las Entidades, debe existir una pantalla correspondiente para crear instancias de la Entidad;
sin embargo, solo para una de ellas, esa pantalla debe permitir modificar y eliminar además
de crear (es suficiente un solo ejemplo de CRUD completo).

## Instrucciones
Una vez clonado o descargado el repositorio, vamos a crear la base de datos, abriendo power shell en la raiz del proyecto y ejecutamos el siguiente comando:

```Power Shell
dotnet ef --startup-project .\Altiora.Service\Altiora.Service.csproj database update
```
A continuación abrimos visual studio y damos click derecho en la solución y click izquierdo en propiedades, damos click dentro de "Propiedades Comunes" en "Proyecto de Inicio", y luego tomamos la opción "Proyectos de inicio múltipes", Debajo de esto verá una tabla y a la derecha de esta unas flechas para cambiar el orden. Colocamos en la primera fila el proyecto "Altiora.Service", de esa fila la columna "Acción" seleccionamos "Iniciar" y en el segunda fila ponemos al proyecto "Altiora.ClienteWeb", de esa fila la columna "Acción" también seleccionamos "Iniciar", por último damos click en "Aceptar".

#### LISTO!!!
Espero sea de su agrado.

Santiago Almeida.
099998136
