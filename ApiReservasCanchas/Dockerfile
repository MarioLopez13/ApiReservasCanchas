# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia csproj y restaura dependencias
COPY *.sln .
COPY ApiReservasCanchas/*.csproj ./ApiReservasCanchas/
RUN dotnet restore

# Copia el resto de los archivos y publica
COPY . .
WORKDIR /app/ApiReservasCanchas
RUN dotnet publish -c Release -o out

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/ApiReservasCanchas/out .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ApiReservasCanchas.dll"]
