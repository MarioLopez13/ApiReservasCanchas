using ApiReservasCanchas.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Configuración de archivos + env vars
builder.Configuration
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
       .AddEnvironmentVariables();

// 2) Registro de DbContext con la cadena correcta
var conn = builder.Configuration.GetConnectionString("MySqlConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseMySql(conn, ServerVersion.AutoDetect(conn))
);

// 3) Web API + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4) CORS: permitimos local y ambos dominios prod (API y Front)
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", p =>
{
    p.WithOrigins(
        "http://localhost:4200",                         // Angular dev
        "https://apireservascanchas-1.onrender.com",     // tu front en Render
        "https://apireservascanchas.onrender.com"        // tu API en Render (si la consumen otros clientes)
    )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));

var app = builder.Build();

// 5) Solo en Dev mostrar exception page
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// 6) Swagger siempre disponible
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Reservas V1");
    c.RoutePrefix = "swagger";
});

// 7) HTTPS redirection y CORS
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
