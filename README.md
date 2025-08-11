# PruebaTecnica BookRadar
Paso para ejecutar la prueba:

## 1. clonar el repositorio:
Comando: git clone https://github.com/usuario/PruebaTecnica.git
comando dos: cd bookradar

## 2. Configurar la base de datos:

- Aseguar tener sql server instalado y corriendo

- crear la base de datos:
CREATE DATABASE BookRadarDB;

## Configurar el entorno:
- Instalar las herramientas de EF Core: 
comando: dotnet tool install --global dotnet-ef

- Instalar paquetes requeridos:
Comando: (dotnet add package Microsoft.EntityFrameworkCore.Design)   Este paquete contiene las herramientas necesarias para que EF Core pueda generar y ejecutar migraciones, así como para scaffolding de código (por ejemplo, crear modelos a partir de una base existente).

Comando: (dotnet add package Microsoft.EntityFrameworkCore.SqlServer)  Este paquete es el proveedor de base de datos que permite que EF Core trabaje con SQL Server.

- ahora verificamos en la terminal que se muestre asi la ejemplo: PS C:\.net\prueba tecnica\BookRadar>

## Ejecutar migraciones (si usa EF Core) 
Comando: (dotnet ef migrations add CrearHistorialBusquedas) Esto me creará un archivo en la carpeta Migrations/ con las instrucciones SQL para crear la tabla según tu modelo.
Comando: (dotnet ef database update) Esto conectará a BookRadarDB y creará la tabla automáticamente.




## 3. Configurar la cadena de conexion:
en el archivo appsettings.json  Remplazar los valores de la cadena de conexion por los de su entorno

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BookRadarDB;User Id=sa;Password=SuPassword123;TrustServerCertificate=True;"
}

## 4. Restaurar las dependencias:
comando: dotnet restore

## 5. Aplicar las migraciones ( si se usa EF Core )
Comando: dotnet ef database update

## 6. Ejecutar el proyecto o prueba
Comando: dotnet run        O TAMBIEN DAR CLICK EN LA FLECHA VERDE PARA INCIAR EN VISUAL STUDIO.

## DECISIONES DE DISEÑO:
elegi una paleta sobria para Bootstrap 5 para aseguar una buena legibilidad y consitencia visual sin distraer de la funcionalidad principal.

## UX/UI:
cree unos formularios simples y centrados en la funcionalidad principal: busqueda de autor.
- un boton secundario que me permitiera acceder al historial de busqueda facil mente.
- cree una validacion de campos vacios en cliente y servidor.

## Maquetado: di uso de layout compartido con emcabezado y pie de pagina coherentes el contenido principal se muestra en tarjetas (Bootstrap card) para mantener una estructura clara.

## Mejoras pendientes:

- implementar filtro avanzados (año de publicacion, editorial, idioma)
- mejorar el manejo de errores y mensajes para el usuario cuando la api externa no responde.
