# PruebaTecnica BookRadar
Paso para ejecutar la prueba:

## 1. clonar el repositorio:
Comando: git clone https://github.com/usuario/PruebaTecnica.git
comando dos: cd bookradar

## 2. Configurar la base de datos:

- Aseguar tener sql server instalado y corriendo

- crear la base de dato llamada [BookRadarDB]

- Ejecutar el script: scripts/01_create_table.sql  incluido en este repo para crear la tabla [HistorialBusquedas]

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
