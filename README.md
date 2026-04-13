# Sistema Web de Gestión de Servicios y Citas

Aplicación web desarrollada como proyecto académico, que permite la gestión integral de usuarios, clientes, servicios y citas dentro de una organización de servicios.

## Tecnologías utilizadas
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Arquitectura por capas (MVC)

## Funcionalidades principales

### Roles
- Control de acceso por roles (Administrador y Usuario)


###  Gestión de usuarios (Administrador)
- Crear, editar y eliminar usuarios
- Asignación de roles
- Activación e inactivación de usuarios

### Gestión de clientes
- Registro, edición y eliminación de clientes
- Consulta de información

### Gestión de servicios (Administrador)
- Crear y administrar servicios
- Activar / desactivar servicios
- Definir duración y costo

###  Gestión de citas
- Registro de citas para clientes
- Edición y cancelación de citas
- Control de citas por usuario
- Administración total de citas (Administrador)

### Dashboard de estadísticas
- Estadísticas globales (Administrador)
- Estadísticas por usuario (Operativo)
- Consultas en tiempo real desde la base de datos

## Reglas de negocio implementadas
- No se pueden agendar citas con servicios inactivos
- No se permiten citas en fechas pasadas
- Las citas canceladas no pueden modificarse
- Restricción de acceso según rol

## Objetivo del proyecto
Aplicar conceptos de desarrollo web utilizando el patrón Modelo-Vista-Controlador (MVC), programación por capas y manejo de bases de datos con Entity Framework.

## Estado del proyecto
Finalizado / Académico

## Autor
Jefferson Martinez
