-- 1. Crear login a nivel servidor
CREATE LOGIN user_app WITH PASSWORD = 'P@n3c1ll0!';

-- 2. Usar la base de datos
USE TuBaseDeDatos;
GO

-- 3. Crear usuario dentro de la BD
CREATE USER user_app FOR LOGIN user_app;

-- 4. Dar permisos SOLO al schema Dinardap
ALTER ROLE db_datareader ADD MEMBER user_app;
ALTER ROLE db_datawriter ADD MEMBER user_app;

-- Quitar acceso a otros schemas (opcional pero recomendable)
DENY SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO user_app;

-- Permitir acceso solo al schema requerido
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::Dinardap TO user_app;