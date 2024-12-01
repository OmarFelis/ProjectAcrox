CREATE DATABASE ACROX_OG2;
USE ACROX_OG2;

CREATE TABLE Proveedor
(
    Cod_Proveedor        INT IDENTITY(1,1) PRIMARY KEY,
    Nomb_Proveedor       VARCHAR(120) NULL,
    Telf_Proveedor       VARCHAR(120) NULL,
    Dir_Proveedor        VARCHAR(120) NULL,
    Estado_Proveedor     VARCHAR(120) NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE()
);

CREATE TABLE Almacen
(
    Cod_Almacen          INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Almacen       VARCHAR(120) NULL,
    Lugar_Almacen        VARCHAR(120) UNIQUE NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE()
);

CREATE TABLE Beneficiario
(
    Cod_Beneficiario     INT IDENTITY(1,1) PRIMARY KEY,
    NombreC_Beneficiario VARCHAR(250) NULL,
    DNI_Beneficiario     VARCHAR(120) UNIQUE NULL,
    Estado_Beneficiario  VARCHAR(120) NULL,
    Fech__Beneficiario   DATE NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE()
);

CREATE TABLE Vivienda
(
    Cod_Vivienda         INT IDENTITY(1,1) PRIMARY KEY,
    Dir_Vivienda         VARCHAR(120) UNIQUE NULL,
    Area_Vivienda        VARCHAR(120) NULL,
    Estado_Vivienda      VARCHAR(120) NULL,
    Tipo_Vivienda        VARCHAR(120) NULL,
    Cod_Beneficiario     INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Beneficiario) REFERENCES Beneficiario (Cod_Beneficiario) ON DELETE SET NULL
);

CREATE TABLE Material
(
    Cod_Material         INT IDENTITY(1,1) PRIMARY KEY,
    Nomb_Material        VARCHAR(120) NULL,
    Descrp_Material      VARCHAR(120) NULL,
    Precio_Material      FLOAT NULL,
	Cod_Vivienda         INT NULL,
    Cod_Proveedor        INT NULL,
    Cod_Almacen          INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Proveedor) REFERENCES Proveedor (Cod_Proveedor) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Almacen) REFERENCES Almacen (Cod_Almacen) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda) ON DELETE SET NULL
);

CREATE TABLE Boleta
(
    Cod_Boleta           INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Boleta         DATE NULL,
    Total_Boleta         INTEGER NULL,
    Estado_Boleta        VARCHAR(150) NULL,
    Cod_Material         INT NULL,
    Cod_Vivienda         INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Material) REFERENCES Material (Cod_Material) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda) ON DELETE SET NULL
);


CREATE TABLE Pago_Boleta
(
    Cod_PagoB            INT IDENTITY(1,1) PRIMARY KEY,
    Fech_Pago            DATE NULL,
    Monto_Pago           INT NULL,
    Estado_Pago          VARCHAR(120) NULL,
    Cod_Boleta           INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Boleta) REFERENCES Boleta (Cod_Boleta) ON DELETE SET NULL
);

CREATE TABLE Detalle_Pago_Boleta
(
    Cod_Detalle          INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Boleta           INT NOT NULL,
    Cod_PagoB            INT NOT NULL,
    Descrp               VARCHAR(200) NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Boleta) REFERENCES Boleta (Cod_Boleta),
    FOREIGN KEY (Cod_PagoB) REFERENCES Pago_Boleta (Cod_PagoB)
);

CREATE TABLE Usuario
(
    Cod_Usuario          INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Usuario       VARCHAR(150) NULL,
    Clave_Usuario        VARCHAR(150) NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE()
);

CREATE TABLE Visita
(
    Cod_Visita           INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Visita         VARCHAR(150) NULL,
    Desp_Visita          VARCHAR(200) NULL,
    Cod_Beneficiario     INT NULL,
    Cod_Vivienda         INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Beneficiario) REFERENCES Beneficiario (Cod_Beneficiario) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda) ON DELETE SET NULL
);

CREATE TABLE Registro
(
    Cod_Registro         INT IDENTITY(1,1) PRIMARY KEY,
    Fech_Registro        DATE NULL,
    Descrp_Registro      VARCHAR(120) NULL,
    Tipo_Registro        VARCHAR(120) NULL,
    Cod_Vivienda         INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda) ON DELETE SET NULL
);

-- Corrección de múltiples columnas de identidad
CREATE TABLE Contrato
(
    Cod_Contrato         INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Vivienda         INT NOT NULL,
    Tipo_Contrato        VARCHAR(150) NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda)
);

CREATE TABLE Kardex
(
    Cod_Kardex           INT IDENTITY(1,1) PRIMARY KEY,
    Descrp_Kardex        VARCHAR(120) NULL,
    Cod_Proveedor        INT NULL,
    Cod_Material         INT NULL,
    Cod_Vivienda         INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Proveedor) REFERENCES Proveedor (Cod_Proveedor) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Material) REFERENCES Material (Cod_Material) ON DELETE SET NULL,
    FOREIGN KEY (Cod_Vivienda) REFERENCES Vivienda (Cod_Vivienda) ON DELETE SET NULL
);

CREATE TABLE Pago_Kardex
(
    Cod_PagoK            INT IDENTITY(1,1) PRIMARY KEY,
    Fech_Pago            DATE NULL,
    Monto_Pago           INT NULL,
    Estado_Pago          VARCHAR(120) NULL,
    Cod_Kardex           INT NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Kardex) REFERENCES Kardex (Cod_Kardex) ON DELETE SET NULL
);

-- Corrección de múltiples columnas de identidad
CREATE TABLE Detalle_Pago_Kardex
(
    Cod_Detalle          INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Kardex           INT NOT NULL,
    Cod_PagoK            INT NOT NULL,
    Descp                VARCHAR(200) NULL,
    fechaCreacion        DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Cod_Kardex) REFERENCES Kardex (Cod_Kardex),
    FOREIGN KEY (Cod_PagoK) REFERENCES Pago_Kardex (Cod_PagoK)
);

create login PryAcrox2 with password='123456789';
create user PryAcrox2 for login PryAcrox2;
exec sp_addrolemember 'db_datareader','PryAcrox2';
exec sp_addrolemember 'db_datawriter','PryAcrox2';
