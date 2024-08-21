# BancoFondos API

Este proyecto es una aplicación web construida con ASP.NET Core 6.0, que sigue una arquitectura por capas. La API expone funcionalidades relacionadas con transacciones financieras y la gestión de fondos.

## Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Configuración Inicial

### 1. Clonar el Repositorio


git clone https://github.com/tu-usuario/banco-fondos.git
cd banco-fondos

### 2. Configuración de la Base de Datos
En el archivo appsettings.json ubicado en el proyecto BancoFondos.WebApi, deberás configurar la cadena de conexión a tu instancia de SQL Server.

json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BancoFondosDb;User Id=sa;Password=your_password;"
  }
}
Asegúrate de reemplazar los valores Server, User Id, y Password con tus propios detalles de conexión.

### 3. Instalar Dependencias
Restaura las dependencias del proyecto utilizando el siguiente comando:

bash
Copiar código
dotnet restore
###4. Crear la Base de Datos y Aplicar Migraciones
4.1. Crear Migraciones
Para crear una nueva migración de la base de datos, abre la consola del Administrador de Paquetes (PMC) o usa la CLI de .NET, dependiendo de tus preferencias.

Usando la Consola del Administrador de Paquetes:



Add-Migration Inicial -Project BancoFondos.EntityFramework -StartupProject BancoFondos.WebApi
Usando la CLI de .NET:


dotnet ef migrations add Inicial --project BancoFondos.EntityFramework --startup-project BancoFondos.WebApi
4.2. Aplicar las Migraciones
Para aplicar las migraciones y crear las tablas en la base de datos:

Usando la Consola del Administrador de Paquetes:


Update-Database -Project BancoFondos.EntityFramework -StartupProject BancoFondos.WebApi
Usando la CLI de .NET:


dotnet ef database update --project BancoFondos.EntityFramework --startup-project BancoFondos.WebApi
Este comando aplicará las migraciones y creará las tablas necesarias en tu base de datos.

## Ejecución de la Aplicación
Una vez que las migraciones se hayan aplicado correctamente, puedes ejecutar la aplicación usando el siguiente comando:


dotnet run --project BancoFondos.WebApi
Esto levantará el servidor web y expondrá la API en http://localhost:5000 o la dirección configurada.
