-- Crear la base de datos BTG
CREATE DATABASE BTG;
GO

-- Usar la base de datos BTG
USE BTG;
GO

-- Crear la tabla 'cliente'
CREATE TABLE Cliente (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL
);
GO

-- Crear la tabla 'producto'
CREATE TABLE Producto (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    tipoProducto VARCHAR(100) NOT NULL
);
GO

-- Crear la tabla 'sucursal'
CREATE TABLE Sucursal (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL
);
GO

-- Crear la tabla 'inscripcion'
CREATE TABLE Inscripcion (
    idProducto INT NOT NULL,
    idCliente INT NOT NULL,
    PRIMARY KEY (idProducto, idCliente),
    FOREIGN KEY (idProducto) REFERENCES producto(id),
    FOREIGN KEY (idCliente) REFERENCES cliente(id)
);
GO

-- Crear la tabla 'disponibilidad'
CREATE TABLE Disponibilidad (
    idSucursal INT NOT NULL,
    idProducto INT NOT NULL,
    PRIMARY KEY (idSucursal, idProducto),
    FOREIGN KEY (idSucursal) REFERENCES sucursal(id),
    FOREIGN KEY (idProducto) REFERENCES producto(id)
);
GO

-- Crear la tabla 'visitan'
CREATE TABLE visitan (
    idSucursal INT NOT NULL,
    idCliente INT NOT NULL,
    fechaVisita DATE NOT NULL,
    PRIMARY KEY (idSucursal, idCliente),
    FOREIGN KEY (idSucursal) REFERENCES sucursal(id),
    FOREIGN KEY (idCliente) REFERENCES cliente(id)
);
GO


----Consulta de clientes 

SELECT DISTINCT c.nombre, c.apellidos
FROM cliente c
JOIN inscripcion i ON c.id = i.idCliente
JOIN visitan v ON c.id = v.idCliente
JOIN disponibilidad d ON v.idSucursal = d.idSucursal AND i.idProducto = d.idProducto
