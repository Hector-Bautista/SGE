-- Script para crear la base de datos del Sistema de Gestión de Empleados (SGE)

-- 1. Crear la base de datos
CREATE DATABASE SGE_Database;
GO

USE SGE_Database;
GO

-- 2. Crear tabla de Departamentos
CREATE TABLE Departamentos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- 3. Crear tabla de Empleados
CREATE TABLE Empleados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(200) NOT NULL,
    FechaContratacion DATE NOT NULL,
    Cargo NVARCHAR(100) NOT NULL,
    Salario DECIMAL(10,2) NOT NULL CHECK (Salario >= 0),
    DepartamentoID INT NOT NULL,
    Estado BIT DEFAULT 1, -- 1 = Activo, 0 = Inactivo
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DepartamentoID) REFERENCES Departamentos(ID)
);

-- 4. Crear índices para mejorar rendimiento
CREATE INDEX IX_Empleados_NombreCompleto ON Empleados(NombreCompleto);
CREATE INDEX IX_Empleados_DepartamentoID ON Empleados(DepartamentoID);
CREATE INDEX IX_Empleados_Estado ON Empleados(Estado);

-- 5. Insertar datos de ejemplo - Departamentos
INSERT INTO Departamentos (Nombre, Descripcion) VALUES 
('Recursos Humanos', 'Gestión de personal y desarrollo organizacional'),
('Tecnología', 'Desarrollo de software y soporte técnico'),
('Ventas', 'Gestión comercial y atención al cliente'),
('Contabilidad', 'Gestión financiera y contable'),
('Marketing', 'Publicidad y comunicaciones');

-- 6. Insertar datos de ejemplo - Empleados
INSERT INTO Empleados (NombreCompleto, FechaContratacion, Cargo, Salario, DepartamentoID) VALUES 
('Juan Carlos Pérez González', '2023-01-15', 'Gerente de RRHH', 4500000.00, 1),
('María Elena Rodríguez López', '2023-03-20', 'Desarrolladora Senior', 3800000.00, 2),
('Carlos Alberto Martínez Silva', '2023-02-10', 'Ejecutivo de Ventas', 2800000.00, 3),
('Ana Sofía García Herrera', '2023-04-05', 'Contadora', 3200000.00, 4),
('Luis Fernando Torres Morales', '2023-05-12', 'Especialista en Marketing', 2900000.00, 5),
('Sandra Patricia Jiménez Castro', '2023-06-18', 'Analista de Sistemas', 3400000.00, 2),
('Diego Alejandro Vargas Ruiz', '2023-07-22', 'Supervisor de Ventas', 3100000.00, 3),
('Pedro Pablo Perez Pinto', '2025-09-18', 'Desarrollador Junior', 1800000.00, 2);

-- 7. Crear procedimientos almacenados para operaciones CRUD

-- Procedimiento para listar todos los empleados
CREATE PROCEDURE sp_ListarEmpleados
AS
BEGIN
    SELECT 
        e.ID,
        e.NombreCompleto,
        e.FechaContratacion,
        e.Cargo,
        e.Salario,
        d.Nombre AS Departamento,
        e.Estado
    FROM Empleados e
    INNER JOIN Departamentos d ON e.DepartamentoID = d.ID
    WHERE e.Estado = 1
    ORDER BY e.ID, e.NombreCompleto;
END
GO

-- Procedimiento para buscar empleados
CREATE PROCEDURE sp_BuscarEmpleados
    @Termino NVARCHAR(200)
AS
BEGIN
    SELECT 
        e.ID,
        e.NombreCompleto,
        e.FechaContratacion,
        e.Cargo,
        e.Salario,
        d.Nombre AS Departamento,
        e.Estado
    FROM Empleados e
    INNER JOIN Departamentos d ON e.DepartamentoID = d.ID
    WHERE e.Estado = 1 
        AND (e.NombreCompleto LIKE '%' + @Termino + '%' 
             OR CAST(e.ID AS NVARCHAR) = @Termino)
    ORDER BY e.NombreCompleto;
END
GO

-- Procedimiento para obtener un empleado por ID
CREATE PROCEDURE sp_ObtenerEmpleadoPorID
    @ID INT
AS
BEGIN
    SELECT 
        e.ID,
        e.NombreCompleto,
        e.FechaContratacion,
        e.Cargo,
        e.Salario,
        e.DepartamentoID,
        d.Nombre AS Departamento,
        e.Estado
    FROM Empleados e
    INNER JOIN Departamentos d ON e.DepartamentoID = d.ID
    WHERE e.ID = @ID;
END
GO

-- Procedimiento para insertar empleado
CREATE PROCEDURE sp_InsertarEmpleado
    @NombreCompleto NVARCHAR(200),
    @FechaContratacion DATE,
    @Cargo NVARCHAR(100),
    @Salario DECIMAL(10,2),
    @DepartamentoID INT
AS
BEGIN
    INSERT INTO Empleados (NombreCompleto, FechaContratacion, Cargo, Salario, DepartamentoID)
    VALUES (@NombreCompleto, @FechaContratacion, @Cargo, @Salario, @DepartamentoID);
    
    SELECT SCOPE_IDENTITY() AS NuevoID;
END
GO

-- Procedimiento para actualizar empleado
CREATE PROCEDURE sp_ActualizarEmpleado
    @ID INT,
    @NombreCompleto NVARCHAR(200),
    @FechaContratacion DATE,
    @Cargo NVARCHAR(100),
    @Salario DECIMAL(10,2),
    @DepartamentoID INT
AS
BEGIN
    UPDATE Empleados 
    SET 
        NombreCompleto = @NombreCompleto,
        FechaContratacion = @FechaContratacion,
        Cargo = @Cargo,
        Salario = @Salario,
        DepartamentoID = @DepartamentoID,
        FechaModificacion = GETDATE()
    WHERE ID = @ID;
END
GO

-- Procedimiento para eliminar empleado (eliminación lógica)
CREATE PROCEDURE sp_EliminarEmpleado
    @ID INT
AS
BEGIN
    UPDATE Empleados 
    SET Estado = 0, FechaModificacion = GETDATE()
    WHERE ID = @ID;
END
GO

-- Procedimiento para listar departamentos
CREATE PROCEDURE sp_ListarDepartamentos
AS
BEGIN
    SELECT ID, Nombre 
    FROM Departamentos
    ORDER BY Nombre;
END
GO

-- 8. Crear vistas útiles
CREATE VIEW vw_EmpleadosCompleto AS
SELECT 
    e.ID,
    e.NombreCompleto,
    e.FechaContratacion,
    e.Cargo,
    FORMAT(e.Salario, 'C', 'es-CO') AS SalarioFormateado,
    e.Salario,
    d.Nombre AS Departamento,
    CASE WHEN e.Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS EstadoTexto,
    DATEDIFF(YEAR, e.FechaContratacion, GETDATE()) AS AnosServicio
FROM Empleados e
INNER JOIN Departamentos d ON e.DepartamentoID = d.ID;
GO