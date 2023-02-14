# TiendaServicios

Migraciones:
Esto crea el codigo en C# para crear las tablas en base a la clase
dotnet ef migrations add MigracionPostgresInicial --project TiendaServicios.Api."Autor"
Esto envia el codigo a la base de datos (Segun el caso)
dotnet ef database update --project TiendaServicios.Api."Autor"

