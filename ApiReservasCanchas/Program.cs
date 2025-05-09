using ApiReservasCanchas.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Cargo appsettings + appsettings.{Env}.json + env vars
builder.Configuration
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
       .AddEnvironmentVariables(); // aquí lee ConnectionStrings__MySqlConnection

// 2) Leo la cadena (de env var en producción o de appsettings.json en local)
var conn = builder.Configuration.GetConnectionString("MySqlConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseMySql(conn, ServerVersion.AutoDetect(conn))
);

// 3) Agrego controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4) CORS: dev local + tu front estático en Render + tu API en Render
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", p =>
{
    p.WithOrigins(
        "http://localhost:4200",                         // Angular en local
        "https://apireservascanchas-1.onrender.com",     // tu front estático
        "https://apireservascanchas.onrender.com"        // consumido desde otros clientes
    )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));

var app = builder.Build();

// 5) En dev mostramos detalles de excepción
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// 6) Habilito Swagger siempres
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Reservas V1");
    c.RoutePrefix = "swagger";  // accederás en /swagger/index.html
});

// 7) HTTPS redirection y CORS
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
