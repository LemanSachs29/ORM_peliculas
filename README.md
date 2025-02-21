Proyecto de Gestión de Películas
Este proyecto consiste en un sistema de gestión de películas que incluye una base de datos, un servicio web API REST y un cliente web sencillo. El objetivo es proporcionar una interfaz para consultar, agregar, modificar y eliminar películas en una base de datos MySQL.

Tecnologías Utilizadas
Backend: .NET Core 8

Base de Datos: MySQL (creada con MySQL Workbench)

ORM: Entity Framework Core (o cualquier otro ORM que hayas utilizado)

API REST: ASP.NET Core Web API

Frontend: HTML, CSS, JavaScript

Gestión de Dependencias: NuGet (para .NET), npm (si se usa para el frontend)

Requisitos Previos
Antes de iniciar el proyecto, asegúrate de tener instalado lo siguiente:

.NET SDK 8: Descargar e instalar .NET SDK

MySQL Server: Descargar e instalar MySQL

MySQL Workbench (opcional, pero recomendado para gestionar la base de datos): Descargar MySQL Workbench

Visual Studio 2022 o Visual Studio Code: Descargar Visual Studio o Descargar Visual Studio Code

Configuración del Proyecto
1. Clonar el Repositorio
Primero, clona el repositorio del proyecto en tu máquina local:

bash
Copy
git clone <URL_DEL_REPOSITORIO>
cd <NOMBRE_DEL_PROYECTO>
2. Configurar la Base de Datos
Abre MySQL Workbench y conéctate a tu servidor MySQL.

Ejecuta el script SQL que se encuentra en la carpeta Database del proyecto para crear la base de datos y las tablas necesarias.

Asegúrate de que el archivo de configuración del proyecto (por ejemplo, appsettings.json en el proyecto de la API) tenga las credenciales correctas para conectarse a la base de datos.

3. Configurar el Proyecto .NET
Abre la solución .sln en Visual Studio o Visual Studio Code.

Restaura las dependencias de NuGet si es necesario.

Asegúrate de que el proyecto de la API esté configurado como proyecto de inicio.

4. Iniciar los Proyectos
Base de Datos: Asegúrate de que MySQL esté en ejecución.

API REST: Ejecuta el proyecto de la API desde Visual Studio o usando el siguiente comando en la terminal:

bash
Copy
dotnet run --project <RUTA_DEL_PROYECTO_API>
La API debería estar disponible en http://localhost:5000 o http://localhost:5001 (dependiendo de la configuración).

Cliente Web: Abre el archivo index.html en la carpeta del cliente web en tu navegador. Asegúrate de que el cliente esté configurado para apuntar a la URL correcta de la API.

Estructura del Proyecto
Database: Contiene el script SQL para crear la base de datos.

API: Proyecto de la API REST que interactúa con la base de datos.

Client: Carpeta con el cliente web (HTML, CSS, JS).

ORM: Proyecto que contiene el mapeo de la base de datos usando Entity Framework Core (o el ORM que hayas utilizado).

Uso
Una vez que todo esté configurado y en ejecución, puedes usar el cliente web para:

Ver la lista de películas.

Agregar una nueva película.

Modificar los detalles de una película existente.

Eliminar una película.
