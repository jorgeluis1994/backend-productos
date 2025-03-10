using System.Reflection.Metadata;
using System;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using backend_products.src.services;
using backend_products.src.services.imp;

var builder = WebApplication.CreateBuilder(args);


//Agregamo la conn 
builder.Services.AddDbContext<AplicationDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("Conn")));
//incorporamos el servico con su implementacion
builder.Services.AddScoped<IProductoService ,ProductoService>();

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


app.MapControllers();

app.Run();
