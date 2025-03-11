---------------------------------------------------------------------------------------------------------------------------
Backend (ASP.NET Core con Entity Framework): https://github.com/jorgeluis1994/backend-productos.git
---------------------------------------------------------------------------------------------------------------------------
Instalar dependencias del backend:

Abre una terminal en la carpeta del proyecto del backend y ejecuta:

dotnet restore
Configurar la conexión directamente en Program.cs:

En el archivo Program.cs de tu proyecto, configura la cadena de conexión directamente en el código sin usar appsettings.json:

builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=your_db_name;Username=your_username;Password=your_password"));
Reemplaza your_db_name, your_username y your_password con los valores correspondientes de tu base de datos.
Realizar la migración de la base de datos:

Si aún no has aplicado las migraciones, ejecuta los siguientes comandos para crear las tablas según tus entidades:

dotnet ef migrations add InitialCreate
dotnet ef database update
Levantar el backend:

![back](https://github.com/user-attachments/assets/29694f07-a2fd-4e30-bb57-c2d54f582899)

dotnet run


