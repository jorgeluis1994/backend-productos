using System.Reflection.Metadata;
using System;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using backend_products.src.services;
using backend_products.src.services.imp;

var builder = WebApplication.CreateBuilder(args);


// //Agregamo la conn 
// builder.Services.AddDbContext<AplicationDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("Conn")));

var connectionString = "Host=192.168.100.82;Port=5434;Database=postgres;Username=dev;Password=123";

// Verificamos si la cadena de conexión es válida
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("❌ Error: La cadena de conexión no se está cargando.");
}

Console.WriteLine($"✅ Conexión obtenida: {connectionString}");

// Registramos el DbContext con la cadena de conexión directa
builder.Services.AddDbContext<AplicationDbContext>(options =>
    options.UseNpgsql(connectionString));  // Aquí está "quemada" la cadena de conexión


//incorporamos el servico con su implementacion
builder.Services.AddScoped<IProductoService ,ProductoService>();

//servico de transacciones
builder.Services.AddScoped<ITransaccionService ,TransaccionService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", builder =>
    {
        builder
            .AllowAnyOrigin()   
            .AllowAnyHeader()   
            .AllowAnyMethod();  
    });
});


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("PermitirTodos");  // Aplica la política de CORS


app.MapControllers();

app.Run();
