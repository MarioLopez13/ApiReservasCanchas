# Etapa de build con SDK de .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos la solución y el proyecto
COPY ApiReservasCanchas/ApiReservasCanchas.csproj ApiReservasCanchas/
COPY ApiReservasCanchas.sln .

# Restaurar dependencias
RUN dotnet restore ApiReservasCanchas.sln

# Copiar el resto del código
COPY . .

# Publicar la aplicación
WORKDIR /src/ApiReservasCanchas
RUN dotnet publish -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ApiReservasCanchas.dll"]
