using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.

builder.Services.AddControllers();
// Más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
 var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
 var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
 c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configurar la canalización de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
