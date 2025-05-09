# Sistema de Gestión de Reservas de Canchas Deportivas

## Descripción

Un sistema para gestionar reservas de canchas deportivas (fútbol, tenis, vóley, etc.), con:

* **Back‑End** en .NET 8 + EF Core + MySQL
* **Front‑End** en Angular 16
* **Autenticación** y **roles** (admin/usuario)
* **Validaciones server‑side** (máximo 2 reservas diarias, no duplicados)
* **Promociones automáticas** en horarios de baja ocupación
* **Deploy** de API y cliente en Render

## Tabla de Contenidos

1. [Características](#características)
2. [Arquitectura](#arquitectura)
3. [Requisitos Previos](#requisitos-previos)
4. [Instalación y Ejecución Local](#instalación-y-ejecución-local)

   * [Back‑End](#back-end)
   * [Front‑End](#front-end)
5. [Configuración de Variables de Entorno](#configuración-de-variables-de-entorno)
6. [Validaciones y Flujo Clave](#validaciones-y-flujo-clave)
7. [Deploy en Render](#deploy-en-render)
8. [Contribuir](#contribuir)
9. [Licencia](#licencia)

## Características

* **Consulta de Disponibilidad** en tiempo real.
* **Reservas CRUD**: crear, leer, modificar, cancelar.
* **Historial de Reservas** por usuario.
* **Reglas de Negocio**:

  * No se permiten 2+ reservas diarias por usuario.
  * No duplicar una misma cancha/hora.
* **Promociones Dinámicas**: descuentos automáticos según ocupación histórica.
* **Gestión Admin**: canchas, horarios, promociones.
* **Swagger UI** para explorar y probar la API.

## Arquitectura

```
Usuario/ Admin
    ↓ Angular (SPA)
    ↓ HTTP (CORS)
ASP.NET Core API ←→ MySQL (Railway)
```

* **Angular**: componentes en `src/app/pages`, servicios en `src/app/services`.
* **.NET**: controladores en `Controllers/`, `Program.cs` config, `ApplicationDbContext` en `Data/`.
* **DB**: tablas `Canchas`, `Horarios`, `Reservas`, `Promociones`, `Usuarios`.

## Requisitos Previos

* [.NET 8 SDK](https://dotnet.microsoft.com)
* [Node.js 18+](https://nodejs.org)
* [Angular CLI](https://angular.io/cli)
* Cuenta en Render (gratis)
* Cuenta en Railway (MySQL)

## Instalación y Ejecución Local

### Back‑End

```bash
# 1. Clonar repo y moverse al proyecto
git clone https://github.com/MarioLopez13/ApiReservasCanchas.git
cd ApiReservasCanchas

# 2. Restaurar y ejecutar
dotnet restore
# Configurar cadena en appsettings.json
dotnet run
# Swagger: https://localhost:5001/swagger/index.html
```

### Front‑End

```bash
# 1. Clonar o usar carpeta existente
cd GestionReservasApp
npm install
# 2. Configurar base URL en src/environments/environment.ts
#    export const environment = { apiUrl: 'https://localhost:5001/api' };

# 3. Levantar en dev
ng serve
# Navegar a http://localhost:4200
```

## Configuración de Variables de Entorno

### API (.NET)

* **ConnectionStrings\_\_MySqlConnection**: cadena de conexión MySQL (Railway).
* **ASPNETCORE\_ENVIRONMENT**: `Development` o `Production`.

> Ejemplo en Render > Environment:
>
> ```text
> ConnectionStrings__MySqlConnection = "Server=mysql.railway.internal;Port=3306;Database=railway;Uid=root;Pwd=<tu_password>;"
> ASPNETCORE_ENVIRONMENT = Production
> ```

### Cliente (Angular)

* En `src/environments/environment.prod.ts`:

  ```ts
  export const environment = {
    production: true,
    apiUrl: 'https://apireservascanchas.onrender.com/api'
  };
  ```

## Validaciones y Flujo Clave

1. **Máximo 2 reservas por día**: en el controlador de reservas se consulta cuántas reservas ya tiene el usuario para la fecha, y si es ≥2 se retorna 400.
2. **Sin duplicados**: antes de crear, se verifica si ya existe una reserva con misma `UsuarioId`, `CanchaId` y `HorarioId`.
3. **Dropdowns**: para crear reservas, el front carga:

   * Lista de **canchas** (`GET /api/Cancha`)
   * Cuando el usuario elige una, carga **horarios disponibles** (`GET /api/Horario/porCancha/{id}`)

Estas validaciones son **server‑side** y no se confían sólo a JS en el cliente.

## Deploy en Render

### API (.NET)

1. Crear un **Web Service** en Render con Dockerfile.
2. Agregar `ConnectionStrings__MySqlConnection` en **Environment**.
3. `Manual Deploy` → listo.

URL: [`https://apireservascanchas.onrender.com`](https://apireservascanchas.onrender.com/swagger/index.html)

### Front‑End (Angular)

1. Crear **Static Site** en Render apuntando a la rama `Angular`.
2. **Build Command**: `npm run build -- --configuration production`
3. **Publish Directory**: `dist/gestion-reservas-app/browser`

URL: `https://apireservascanchas-1.onrender.com`


