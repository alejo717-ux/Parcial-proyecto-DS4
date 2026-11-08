CREATE DATABASE IF NOT EXISTS TallerDB;
USE TallerDB;

-- 1. Tablas obligatorias de sistema
CREATE TABLE IF NOT EXISTS Usuarios (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Rol VARCHAR(30) NOT NULL,
    Estado VARCHAR(15) DEFAULT 'Activo'
);

CREATE TABLE IF NOT EXISTS Bitacora (
    IdLog INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario INT NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    FechaHora DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

-- 2. Tablas del tema (5 tablas relacionadas)
CREATE TABLE IF NOT EXISTS Clientes (
    IdCliente INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Correo VARCHAR(100) NULL,
    Direccion VARCHAR(150) NULL
);

CREATE TABLE IF NOT EXISTS Mecanicos (
    IdMecanico INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL,
    Especialidad VARCHAR(50) NULL,
    Telefono VARCHAR(20) NULL
);

CREATE TABLE IF NOT EXISTS CategoriasServicio (
    IdCategoria INT AUTO_INCREMENT PRIMARY KEY,
    NombreCategoria VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200) NULL
);

CREATE TABLE IF NOT EXISTS Servicios (
    IdServicio INT AUTO_INCREMENT PRIMARY KEY,
    NombreServicio VARCHAR(80) NOT NULL,
    IdCategoria INT NOT NULL,
    FOREIGN KEY (IdCategoria) REFERENCES CategoriasServicio(IdCategoria)
);

CREATE TABLE IF NOT EXISTS OrdenesReparacion (
    IdOrden INT AUTO_INCREMENT PRIMARY KEY,
    FechaIngreso DATE NOT NULL,
    IdCliente INT NOT NULL,
    IdMecanico INT NOT NULL,
    EstadoOrden VARCHAR(30) DEFAULT 'Pendiente',
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (IdMecanico) REFERENCES Mecanicos(IdMecanico)
);

-- Datos de prueba iniciales
INSERT INTO Usuarios (Username, Password, Rol) VALUES ('admin', '1234', 'Administrador');
INSERT INTO Clientes (Nombre, Telefono, Correo, Direccion) VALUES ('Carlos Mendoza', '6111-2222', 'carlos@mail.com', 'Panamá');
INSERT INTO Mecanicos (Nombre, Especialidad, Telefono) VALUES ('Roberto Perez', 'Motor y Transmisión', '6999-8888');
INSERT INTO CategoriasServicio (NombreCategoria, Descripcion) VALUES ('Mantenimiento', 'Cambio de aceite y filtros');
