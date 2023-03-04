# TiendaServicios

Migraciones:
Esto crea el codigo en C# para crear las tablas en base a la clase
dotnet ef migrations add MigracionPostgresInicial --project TiendaServicios.Api."Autor"
Esto envia el codigo a la base de datos (Segun el caso)
dotnet ef database update --project TiendaServicios.Api."Autor"


Para crear la base de datos en Mysql
use carritocompra;

Create table __EFMigrationsHistory(
MigrationId varchar(150) not null primary key,
ProductVersion varchar(32) not null);

Empezando con las pruebas de pipeline y jira
