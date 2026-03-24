# Proyecto Cinestar - Arquitectura Web API & MVC ASP.NET

## Descripción
Este proyecto es un sistema web diseñado para visualizar la información, sedes, cartelera de la cadena de cines Cinestar. 

El proyecto MVC cuenta con dos vías de ejecución totalmente independientes que pueden alternarse desde el enrutador principal `program.cs` :
1. **Modo Nativo:** * Utiliza el controlador principal (`CinestarController`).
   * Se conecta directamente a la base de datos a través de su propio DAO (`daoCinestar`) y ADO.NET.
2. **Modo Consumo:** * Utiliza el controlador de consumo (`CinestarConsApiController`).
   * No requiere conexión directa a la base de datos.
   * Utiliza `IHttpClientFactory` de forma asíncrona (`async/await`) para consumir los datos de un proyecto backend independiente (Web API).

## Arquitectura Implementada
* **Separación Backend/Frontend:** La aplicación se dividió en un proyecto de **Web API** (que gestiona los datos) y un proyecto **MVC** (que actúa únicamente como cliente consumidor).
* **Inyección de Dependencias (DI):** Se utiliza el contenedor IoC nativo de .NET Core (`builder.Services.AddScoped`) para inyectar la configuración y las clases de acceso a datos (DAO).
* **Consumo Asíncrono:** El Frontend MVC consume la Web API mediante `IHttpClientFactory` de forma totalmente asíncrona (`async/await`), evitando bloqueos en el hilo principal del servidor web.
* **ADO.NET Puro:** El acceso a datos se realiza de manera directa y optimizada utilizando procedimientos almacenados, protegiendo al sistema contra inyección SQL.

## Tecnologías Utilizadas
* **Backend:** ASP.NET Core Web API.
* **FullStack - Frontend:** ASP.NET Core MVC (Razor Views, HTML, CSS)
* **Base de Datos:** SQL Server / Azure SQL.
* **Acceso a Datos:** ADO.NET (Sin ORM) utilizando los procedimientos almacenados.

## Cómo ejecutar y probar los diferentes modos

Para probar la versión que consume la API, **ambos proyectos (Web API y MVC) deben estar en ejecución simultáneamente**.
**Paso 1: Configurar el modo de ejecución en el MVC**
Abrir el archivo `Program.cs` del proyecto MVC y cambia el comentario del modo cual desees evaluar:

* **Para evaluar el MVC Nativo:**
  `pattern: "{controller=Cinestar}/{action=Inicio}/{id?}"`
* **Para evaluar el consumo de la Web API:**
  `pattern: "{controller=CinestarConsApi}/{action=Inicio}/{id?}"`

**Paso 2: Ejecutar**
1. Configurar los **Proyectos de inicio múltiples** en Visual Studio para arrancar tanto la API como el MVC al mismo tiempo.
2. Verificar el archivo `appsettings.json` para asegurar que la cadena de conexión `CadenaSQLAzure` sea correcta o utilizar una cadena local.
3. Presionar `F5`. Dependiendo del controlador configurado en el Paso 1, la aplicación cargará los datos directamente desde SQL o a través de peticiones HTTP a la API.

## Endpoints Principales (Web API)
El proyecto expone las siguientes rutas para el consumo de datos:

* `GET api/cinestarapi/nuestrosCines` -> Lista de sedes Cinestar.
* `GET api/cinestarapi/nuestrosCines/{id}` -> Detalle de una sede específica.
* `GET api/cinestarapi/tarifas/{id}` -> Precios y días de promoción por cine.
* `GET api/cinestarapi/cartelera/{id}` -> Cartelera completa (Fotos y sinopsis).
* `GET api/cinestarapi/cartelera/pelicula/{id}` -> Horarios y salas de un cine específico.
