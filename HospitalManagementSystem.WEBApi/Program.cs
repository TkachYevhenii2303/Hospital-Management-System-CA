using Hospital_Management_System_Applications.Extensions;
using Hospital_Management_System_Infrastructure.Extensions;
using Hospital_Management_System_Persistence.Extensions;
using Hospital_Management_System_WEB_API.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddPresentationLayer();
builder.Services.AddControllers();

var app = builder.Build();

app.AddWebApplicationLayer();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();