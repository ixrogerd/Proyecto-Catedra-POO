/* =========================================================================
Sistema de Gestion de Citas Medicas Online - POO104
Script COMPLETO para SQL Server (ejecutar en local)

COMO USARLO
1. Abrir SSMS y conectarse a su servidor local (Windows Authentication).
2. Abrir este archivo y ejecutarlo completo (F5).
3. Probar con los usuarios de prueba (al final del script).

ATENCION: si la base CitasMedicasDB ya existe, este script la ELIMINA
y la crea de nuevo (se pierden los datos que tenga).
========================================================================= */

USE master;
GO

IF DB_ID('CitasMedicasDB') IS NOT NULL
BEGIN
    ALTER DATABASE CitasMedicasDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CitasMedicasDB;
END
GO

CREATE DATABASE CitasMedicasDB;
GO
USE CitasMedicasDB;
GO

/* ---------- CATALOGOS (IDs fijos, los usa el codigo C#) ---------- */
CREATE TABLE Rol (
    ID_Rol    INT PRIMARY KEY,                    -- 1=Paciente, 2=Medico, 3=Administrador
    NombreRol VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE EstadoCita (
    ID_Estado INT PRIMARY KEY,                    -- 1=Pendiente, 2=Atendida, 3=Cancelada
    Nombre    VARCHAR(20) NOT NULL UNIQUE
);

INSERT INTO Rol (ID_Rol, NombreRol)
VALUES (1,'Paciente'), (2,'Medico'), (3,'Administrador');

INSERT INTO EstadoCita (ID_Estado, Nombre)
VALUES (1,'Pendiente'), (2,'Atendida'), (3,'Cancelada');

/* ---------- USUARIO (tabla base) ---------- */
CREATE TABLE Usuario (
    ID_Usuario         INT IDENTITY(1,1) PRIMARY KEY,
    Username           VARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash       VARCHAR(256) NOT NULL,
    ID_Rol             INT NOT NULL REFERENCES Rol(ID_Rol),
    Activo             BIT NOT NULL DEFAULT 1,
    FechaRegistro      DATETIME NOT NULL DEFAULT GETDATE(),
    FechaDesactivacion DATETIME NULL
);

/* ---------- ESPECIALIDAD ---------- */
CREATE TABLE Especialidad (
    ID_Especialidad    INT IDENTITY(1,1) PRIMARY KEY,
    NombreEspecialidad VARCHAR(80) NOT NULL UNIQUE,
    Descripcion        VARCHAR(200) NULL
);

/* ---------- SUBTIPOS DE USUARIO (PK = FK a Usuario) ---------- */
CREATE TABLE Paciente (
    ID_Paciente     INT PRIMARY KEY REFERENCES Usuario(ID_Usuario),
    Nombre          VARCHAR(60)  NOT NULL,
    Apellido        VARCHAR(60)  NOT NULL,
    FechaNacimiento DATE         NOT NULL,
    Telefono        VARCHAR(15)  NULL,
    Correo          VARCHAR(100) NULL
);
CREATE UNIQUE INDEX UX_Paciente_Correo ON Paciente(Correo) WHERE Correo IS NOT NULL;

CREATE TABLE Medico (
    ID_Medico       INT PRIMARY KEY REFERENCES Usuario(ID_Usuario),
    Nombre          VARCHAR(60)  NOT NULL,
    Apellido        VARCHAR(60)  NOT NULL,
    Telefono        VARCHAR(15)  NULL,
    Correo          VARCHAR(100) NULL,
    ID_Especialidad INT NOT NULL REFERENCES Especialidad(ID_Especialidad)
);
CREATE UNIQUE INDEX UX_Medico_Correo ON Medico(Correo) WHERE Correo IS NOT NULL;

CREATE TABLE Administrador (
    ID_Administrador INT PRIMARY KEY REFERENCES Usuario(ID_Usuario),
    Nombre           VARCHAR(60) NOT NULL,
    Apellido         VARCHAR(60) NOT NULL
);

/* ---------- HORARIO DEL MEDICO ---------- */
CREATE TABLE HorarioDisponible (
    ID_Horario INT IDENTITY(1,1) PRIMARY KEY,
    ID_Medico  INT NOT NULL REFERENCES Medico(ID_Medico),
    DiaSemana  TINYINT NOT NULL CHECK (DiaSemana BETWEEN 1 AND 7),  -- 1=Lunes ... 7=Domingo
    HoraInicio TIME NOT NULL,
    HoraFin    TIME NOT NULL,
    CONSTRAINT CK_Horario_Horas CHECK (HoraFin > HoraInicio)
);

/* ---------- CITA ---------- */
CREATE TABLE Cita (
    ID_Cita     INT IDENTITY(1,1) PRIMARY KEY,
    Fecha       DATE NOT NULL,
    Hora        TIME NOT NULL,
    Motivo      VARCHAR(200) NULL,
    Diagnostico   VARCHAR(500) NULL,
    Tratamiento   VARCHAR(500) NULL,
    Observaciones VARCHAR(500) NULL,
    ID_Estado   INT NOT NULL DEFAULT 1 REFERENCES EstadoCita(ID_Estado),
    ID_Paciente INT NOT NULL REFERENCES Paciente(ID_Paciente),
    ID_Medico   INT NOT NULL REFERENCES Medico(ID_Medico)
);
-- Evita la doble asignacion; una cita cancelada libera el horario
CREATE UNIQUE INDEX UX_Cita_Medico_Horario
    ON Cita (ID_Medico, Fecha, Hora) WHERE ID_Estado <> 3;

/* ---------- RECETA (1 cita : 0..1 receta) ---------- */
CREATE TABLE Receta (
    ID_Receta    INT IDENTITY(1,1) PRIMARY KEY,
    ID_Cita      INT NOT NULL UNIQUE REFERENCES Cita(ID_Cita),
    Descripcion  VARCHAR(500) NOT NULL,
    Indicaciones VARCHAR(500) NULL,
    FechaEmision DATETIME NOT NULL DEFAULT GETDATE()
);
GO

/* =========================================================================
    VISTAS (solo registros activos)
    ========================================================================= */
CREATE VIEW vw_PacientesActivos AS
SELECT p.*, u.Username
FROM Paciente p
JOIN Usuario u ON u.ID_Usuario = p.ID_Paciente
WHERE u.Activo = 1;
GO

CREATE VIEW vw_MedicosActivos AS
SELECT m.ID_Medico, m.Nombre, m.Apellido, m.Telefono, m.Correo,
        e.ID_Especialidad, e.NombreEspecialidad, u.Username
FROM Medico m
JOIN Usuario u      ON u.ID_Usuario = m.ID_Medico
JOIN Especialidad e ON e.ID_Especialidad = m.ID_Especialidad
WHERE u.Activo = 1;
GO

CREATE VIEW vw_CitasDetalle AS
SELECT c.ID_Cita, c.Fecha, c.Hora, c.Motivo, es.Nombre AS Estado,
        p.ID_Paciente, p.Nombre + ' ' + p.Apellido AS Paciente,
        m.ID_Medico,   m.Nombre + ' ' + m.Apellido AS Medico,
        e.NombreEspecialidad
FROM Cita c
JOIN EstadoCita es  ON es.ID_Estado = c.ID_Estado
JOIN Paciente p     ON p.ID_Paciente = c.ID_Paciente
JOIN Medico m       ON m.ID_Medico = c.ID_Medico
JOIN Especialidad e ON e.ID_Especialidad = m.ID_Especialidad;
GO

/* =========================================================================
    PROCEDIMIENTOS ALMACENADOS
    ========================================================================= */

/* ---- Registro (Usuario + subtipo en una sola transaccion) ---- */
CREATE PROCEDURE sp_RegistrarPaciente
    @Username VARCHAR(50), @PasswordHash VARCHAR(256),
    @Nombre VARCHAR(60), @Apellido VARCHAR(60),
    @FechaNacimiento DATE, @Telefono VARCHAR(15), @Correo VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        INSERT INTO Usuario (Username, PasswordHash, ID_Rol)
        VALUES (@Username, @PasswordHash, 1);

        DECLARE @Id INT = SCOPE_IDENTITY();

        INSERT INTO Paciente (ID_Paciente, Nombre, Apellido, FechaNacimiento, Telefono, Correo)
        VALUES (@Id, @Nombre, @Apellido, @FechaNacimiento, @Telefono, @Correo);
    COMMIT;
    SELECT @Id AS ID_Paciente;
END
GO

CREATE PROCEDURE sp_RegistrarMedico
    @Username VARCHAR(50), @PasswordHash VARCHAR(256),
    @Nombre VARCHAR(60), @Apellido VARCHAR(60),
    @Telefono VARCHAR(15), @Correo VARCHAR(100), @ID_Especialidad INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        INSERT INTO Usuario (Username, PasswordHash, ID_Rol)
        VALUES (@Username, @PasswordHash, 2);

        DECLARE @Id INT = SCOPE_IDENTITY();

        INSERT INTO Medico (ID_Medico, Nombre, Apellido, Telefono, Correo, ID_Especialidad)
        VALUES (@Id, @Nombre, @Apellido, @Telefono, @Correo, @ID_Especialidad);

        INSERT INTO HorarioDisponible (ID_Medico, DiaSemana, HoraInicio, HoraFin)
        SELECT @Id, d.Dia, t.Ini, t.Fin
        FROM (VALUES (1),(2),(3),(4),(5)) d(Dia)
        CROSS JOIN (VALUES ('08:00','12:00'),('13:00','17:00')) t(Ini, Fin);
    COMMIT;
    SELECT @Id AS ID_Medico;
END
GO

/* ---- Login: solo usuarios activos. Devuelve ID_Rol y nombre completo ---- */
CREATE PROCEDURE sp_Login
    @Username VARCHAR(50), @PasswordHash VARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.ID_Usuario,
            u.Username,
            u.ID_Rol,
            r.NombreRol AS Rol,
            COALESCE(p.Nombre + ' ' + p.Apellido,
                    m.Nombre + ' ' + m.Apellido,
                    a.Nombre + ' ' + a.Apellido) AS NombreCompleto
    FROM Usuario u
    JOIN Rol r                 ON r.ID_Rol = u.ID_Rol
    LEFT JOIN Paciente p       ON p.ID_Paciente = u.ID_Usuario
    LEFT JOIN Medico m         ON m.ID_Medico = u.ID_Usuario
    LEFT JOIN Administrador a  ON a.ID_Administrador = u.ID_Usuario
    WHERE u.Username = @Username
        AND u.PasswordHash = @PasswordHash
        AND u.Activo = 1;
END
GO

/* ---- Baja logica (sirve para paciente, medico o admin) ---- */
CREATE PROCEDURE sp_DesactivarUsuario @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        UPDATE Usuario
        SET Activo = 0, FechaDesactivacion = GETDATE()
        WHERE ID_Usuario = @ID_Usuario;

        -- Cancela sus citas pendientes; las atendidas y las recetas se conservan
        UPDATE Cita SET ID_Estado = 3
        WHERE ID_Estado = 1
            AND (ID_Paciente = @ID_Usuario OR ID_Medico = @ID_Usuario);
    COMMIT;
END
GO

CREATE PROCEDURE sp_ReactivarUsuario @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuario SET Activo = 1, FechaDesactivacion = NULL
    WHERE ID_Usuario = @ID_Usuario;
END
GO

/* ---- Agendar cita con validaciones ---- */
CREATE PROCEDURE sp_AgendarCita
    @ID_Paciente INT, @ID_Medico INT,
    @Fecha DATE, @Hora TIME, @Motivo VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET DATEFIRST 1;   -- 1 = Lunes

    IF NOT EXISTS (SELECT 1 FROM vw_PacientesActivos WHERE ID_Paciente = @ID_Paciente)
        THROW 50001, 'El paciente no existe o esta inactivo.', 1;

    IF NOT EXISTS (SELECT 1 FROM vw_MedicosActivos WHERE ID_Medico = @ID_Medico)
        THROW 50002, 'El medico no existe o esta inactivo.', 1;

    IF @Fecha < CAST(GETDATE() AS DATE)
        THROW 50003, 'No se puede agendar en una fecha pasada.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM HorarioDisponible
        WHERE ID_Medico = @ID_Medico
            AND DiaSemana = DATEPART(WEEKDAY, @Fecha)
            AND @Hora >= HoraInicio AND @Hora < HoraFin)
        THROW 50004, 'El medico no atiende en ese dia u hora.', 1;

    IF EXISTS (
        SELECT 1 FROM Cita
        WHERE ID_Medico = @ID_Medico AND Fecha = @Fecha
            AND Hora = @Hora AND ID_Estado <> 3)
        THROW 50005, 'Ese horario ya esta ocupado.', 1;

    INSERT INTO Cita (Fecha, Hora, Motivo, ID_Estado, ID_Paciente, ID_Medico)
    VALUES (@Fecha, @Hora, @Motivo, 1, @ID_Paciente, @ID_Medico);

    SELECT SCOPE_IDENTITY() AS ID_Cita;
END
GO

/* =========================================================================
    DATOS DE PRUEBA

   Usuario         Contrasena      Rol
   admin           Admin1234       Administrador
   medico1         Medico1234      Medico (Medicina General, manana)
   medico2         Medico1234      Medico (Pediatria)
   medico3         Medico1234      Medico (Cardiologia: lun-mie-vie, tarde)
   medico4         Medico1234      Medico (Dermatologia: mar-jue, 2 bloques)
   medico5         Medico1234      Medico (Medicina General, tarde)
   medico6         Medico1234      Medico (Ginecologia)
   medico7         Medico1234      Medico (Oftalmologia: mie a sab)
   paciente1-6     Paciente1234    Paciente (paciente5 es menor de edad)
   paciente.baja / medico.baja     Cuentas inhabilitadas (no inician sesion)

   La contrasena se guarda como SHA-256 en hexadecimal minuscula,
   igual que lo calcula la clase Seguridad de C#.
   ========================================================================= */
SET DATEFIRST 1;

DECLARE @hAdmin VARCHAR(64) = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'Admin1234'), 2));
DECLARE @hMed   VARCHAR(64) = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'Medico1234'), 2));
DECLARE @hPac   VARCHAR(64) = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'Paciente1234'), 2));

-- Especialidades
INSERT INTO Especialidad (NombreEspecialidad, Descripcion) VALUES
    (N'Medicina General', N'Atención médica general'),
    (N'Pediatría',        N'Atención médica de niños y adolescentes'),
    (N'Cardiología',      N'Enfermedades del corazón'),
    (N'Dermatología',     N'Enfermedades de la piel');

DECLARE @espGeneral INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Medicina General');
DECLARE @espPedia   INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Pediatría');

    INSERT INTO Especialidad (NombreEspecialidad, Descripcion)
SELECT v.Nombre, v.Descr
FROM (VALUES
    (N'Ginecología',  N'Salud de la mujer y atención prenatal'),
    (N'Oftalmología', N'Enfermedades de los ojos y la visión')
) v(Nombre, Descr)
WHERE NOT EXISTS (SELECT 1 FROM Especialidad e WHERE e.NombreEspecialidad = v.Nombre);

DECLARE @espCardio  INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Cardiología');
DECLARE @espDermato INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Dermatología');
DECLARE @espGineco  INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Ginecología');
DECLARE @espOftal   INT = (SELECT ID_Especialidad FROM Especialidad WHERE NombreEspecialidad = N'Oftalmología');

-- Administrador de prueba (la aplicacion no tiene pantalla para registrar administradores)
INSERT INTO Usuario (Username, PasswordHash, ID_Rol) VALUES ('admin', @hAdmin, 3);
INSERT INTO Administrador (ID_Administrador, Nombre, Apellido)
VALUES (SCOPE_IDENTITY(), N'Admin', N'Sistema');

-- Médicos (contraseña Medico1234)
EXEC sp_RegistrarMedico @Username='medico1', @PasswordHash=@hMed, @Nombre=N'Carlos', @Apellido=N'Martínez', 
        @Telefono='7000-0001', @Correo='carlos.martinez@correo.com', @ID_Especialidad=@espGeneral;
EXEC sp_RegistrarMedico @Username='medico2', @PasswordHash=@hMed, @Nombre=N'Laura', @Apellido=N'Hernández', 
        @Telefono='7000-0003', @Correo='laura.hernandez@correo.com', @ID_Especialidad=@espPedia;
EXEC sp_RegistrarMedico @Username='medico3', @PasswordHash=@hMed, @Nombre=N'Roberto', @Apellido=N'Alvarado',
        @Telefono='7000-0005', @Correo='roberto.alvarado@correo.com', @ID_Especialidad=@espCardio;
EXEC sp_RegistrarMedico @Username='medico4', @PasswordHash=@hMed, @Nombre=N'Sofía', @Apellido=N'Menjívar',
        @Telefono='7000-0006', @Correo='sofia.menjivar@correo.com', @ID_Especialidad=@espDermato;
EXEC sp_RegistrarMedico @Username='medico5', @PasswordHash=@hMed, @Nombre=N'José', @Apellido=N'Portillo',
        @Telefono='7000-0007', @Correo='jose.portillo@correo.com', @ID_Especialidad=@espGeneral;
EXEC sp_RegistrarMedico @Username='medico6', @PasswordHash=@hMed, @Nombre=N'Gabriela', @Apellido=N'Rivas',
        @Telefono='7000-0008', @Correo='gabriela.rivas@correo.com', @ID_Especialidad=@espGineco;
EXEC sp_RegistrarMedico @Username='medico7', @PasswordHash=@hMed, @Nombre=N'Mauricio', @Apellido=N'Flores',
        @Telefono='7000-0009', @Correo='mauricio.flores@correo.com', @ID_Especialidad=@espOftal;


-- Pacientes (contraseña Paciente1234)
EXEC sp_RegistrarPaciente @Username='paciente1', @PasswordHash=@hPac, @Nombre=N'Ana', @Apellido=N'López', 
        @FechaNacimiento='2000-05-20', @Telefono='7000-0002', @Correo='ana.lopez@correo.com';
EXEC sp_RegistrarPaciente @Username='paciente2', @PasswordHash=@hPac, @Nombre=N'Luis', @Apellido=N'Ramírez',
        @FechaNacimiento='1995-11-02', @Telefono='7000-0004', @Correo='luis.ramirez@correo.com';
EXEC sp_RegistrarPaciente @Username='paciente3', @PasswordHash=@hPac, @Nombre=N'María Fernanda', @Apellido=N'Castillo',
        @FechaNacimiento='1988-03-14', @Telefono='7000-0011', @Correo='maria.castillo@correo.com';
EXEC sp_RegistrarPaciente @Username='paciente4', @PasswordHash=@hPac, @Nombre=N'José Ernesto', @Apellido=N'Cruz',
        @FechaNacimiento='1975-09-30', @Telefono='7000-0012', @Correo='jose.cruz@correo.com';
EXEC sp_RegistrarPaciente @Username='paciente5', @PasswordHash=@hPac, @Nombre=N'Valeria', @Apellido=N'Menéndez',
        @FechaNacimiento='2016-02-11', @Telefono='7000-0013', @Correo='valeria.menendez@correo.com';
EXEC sp_RegistrarPaciente @Username='paciente6', @PasswordHash=@hPac, @Nombre=N'Carlos Alberto', @Apellido=N'Mejía',
        @FechaNacimiento='1960-12-05', @Telefono='7000-0014', @Correo='carlos.mejia@correo.com';


--Horarios de médicos
DECLARE @idM3 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico3'),
        @idM4 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico4'),
        @idM5 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico5'),
        @idM6 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico6'),
        @idM7 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico7');

DELETE FROM HorarioDisponible WHERE ID_Medico IN (@idM3, @idM4, @idM5, @idM6, @idM7);

INSERT INTO HorarioDisponible (ID_Medico, DiaSemana, HoraInicio, HoraFin) VALUES
    -- medico3 Cardiología: lunes, miércoles y viernes, tarde
    (@idM3,1,'13:00','17:00'), (@idM3,3,'13:00','17:00'), (@idM3,5,'13:00','17:00'),
    -- medico4 Dermatología: martes y jueves, dos bloques por día
    (@idM4,2,'08:00','12:00'), (@idM4,2,'14:00','16:00'),
    (@idM4,4,'08:00','12:00'), (@idM4,4,'14:00','16:00'),
    -- medico5 Medicina General: lunes a viernes, tarde
    (@idM5,1,'13:00','17:00'), (@idM5,2,'13:00','17:00'), (@idM5,3,'13:00','17:00'),
    (@idM5,4,'13:00','17:00'), (@idM5,5,'13:00','17:00'),
    -- medico6 Ginecología: lunes a viernes, mañana
    (@idM6,1,'08:00','12:00'), (@idM6,2,'08:00','12:00'), (@idM6,3,'08:00','12:00'),
    (@idM6,4,'08:00','12:00'), (@idM6,5,'08:00','12:00'),
    -- medico7 Oftalmología: miércoles a sábado, mañana
    (@idM7,3,'08:00','12:00'), (@idM7,4,'08:00','12:00'),
    (@idM7,5,'08:00','12:00'), (@idM7,6,'08:00','12:00');


-- Cuentas inhabilitadas (para probar baja lógica y que no inician sesión)
EXEC sp_RegistrarPaciente @Username='paciente.baja', @PasswordHash=@hPac, @Nombre=N'Pedro', @Apellido=N'Alas',
        @FechaNacimiento='1992-06-21', @Telefono='7000-0015', @Correo='pedro.alas@correo.com';
EXEC sp_RegistrarMedico @Username='medico.baja', @PasswordHash=@hMed, @Nombre=N'Héctor', @Apellido=N'Ventura',
        @Telefono='7000-0016', @Correo='hector.ventura@correo.com', @ID_Especialidad=@espGeneral;

DECLARE @idBajaP INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente.baja');
DECLARE @idBajaM INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico.baja');
EXEC sp_DesactivarUsuario @idBajaP;
EXEC sp_DesactivarUsuario @idBajaM;


-- Citas de ejemplo
DECLARE @hoy    DATE = CAST(GETDATE() AS DATE);
DECLARE @lunes  DATE = DATEADD(DAY, 8 - DATEPART(WEEKDAY, @hoy), @hoy);
DECLARE @idP1 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente1');
DECLARE @idP2 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente2');
DECLARE @idM1 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico1');
DECLARE @idM2 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'medico2');

EXEC sp_AgendarCita @ID_Paciente=@idP1, @ID_Medico=@idM1, @Fecha=@lunes, @Hora='08:00', @Motivo='Control general';
EXEC sp_AgendarCita @ID_Paciente=@idP2, @ID_Medico=@idM1, @Fecha=@lunes, @Hora='09:00', @Motivo='Dolor de cabeza';
EXEC sp_AgendarCita @ID_Paciente=@idP1, @ID_Medico=@idM2, @Fecha=@lunes, @Hora='10:00', @Motivo='Consulta pediatrica';
    
DECLARE @idP3 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente3'),
    @idP4 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente4'),
    @idP5 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente5'),
    @idP6 INT = (SELECT ID_Usuario FROM Usuario WHERE Username = 'paciente6');
DECLARE @martes DATE = DATEADD(DAY, 1, @lunes),
        @miercoles DATE = DATEADD(DAY, 2, @lunes),
        @jueves DATE = DATEADD(DAY, 3, @lunes);

EXEC sp_AgendarCita @ID_Paciente=@idP6, @ID_Medico=@idM3, @Fecha=@lunes,     @Hora='13:00', @Motivo=N'Dolor en el pecho';
EXEC sp_AgendarCita @ID_Paciente=@idP4, @ID_Medico=@idM3, @Fecha=@miercoles, @Hora='14:30', @Motivo=N'Control de presión arterial';
EXEC sp_AgendarCita @ID_Paciente=@idP3, @ID_Medico=@idM4, @Fecha=@martes,    @Hora='09:00', @Motivo=N'Manchas en la piel';
EXEC sp_AgendarCita @ID_Paciente=@idP4, @ID_Medico=@idM5, @Fecha=@lunes,     @Hora='13:30', @Motivo=N'Chequeo anual';
EXEC sp_AgendarCita @ID_Paciente=@idP5, @ID_Medico=@idM2, @Fecha=@martes,    @Hora='08:30', @Motivo=N'Control de niño sano';
EXEC sp_AgendarCita @ID_Paciente=@idP3, @ID_Medico=@idM6, @Fecha=@miercoles, @Hora='10:00', @Motivo=N'Control ginecológico';
EXEC sp_AgendarCita @ID_Paciente=@idP6, @ID_Medico=@idM7, @Fecha=@jueves,    @Hora='08:00', @Motivo=N'Revisión de la vista';

DECLARE @lunesPasado DATE = DATEADD(DAY, -14, @lunes);   -- siempre un lunes ya pasado

-- (a) Atendida CON receta (medico1 / paciente1)
INSERT INTO Cita (Fecha, Hora, Motivo, Diagnostico, Tratamiento, Observaciones, ID_Estado, ID_Paciente, ID_Medico)
VALUES (@lunesPasado, '09:00', N'Fiebre y malestar general', N'Faringitis aguda',
        N'Antibiótico y reposo por 7 días', N'Volver a control si la fiebre persiste', 2, @idP1, @idM1);
DECLARE @cita1 INT = SCOPE_IDENTITY();
INSERT INTO Receta (ID_Cita, Descripcion, Indicaciones, FechaEmision)
VALUES (@cita1,
        N'1. Amoxicilina | 500 mg | cada 8 horas | 7 días' + CHAR(13) + CHAR(10) +
        N'2. Paracetamol | 500 mg | cada 8 horas | 3 días',
        N'Tomar con alimentos y beber abundante líquido.',
        DATEADD(HOUR, 10, CAST(@lunesPasado AS DATETIME)));

-- (b) Atendida SIN receta (medico1 / paciente2): aparece en FrmReceta para emitirla en vivo
INSERT INTO Cita (Fecha, Hora, Motivo, Diagnostico, Tratamiento, Observaciones, ID_Estado, ID_Paciente, ID_Medico)
VALUES (@lunesPasado, '10:00', N'Dolor de cabeza frecuente', N'Cefalea tensional',
        N'Analgésicos y manejo del estrés', N'Control en un mes', 2, @idP2, @idM1);

-- (c) Atendida CON receta (medico3 Cardiología / paciente6)
INSERT INTO Cita (Fecha, Hora, Motivo, Diagnostico, Tratamiento, Observaciones, ID_Estado, ID_Paciente, ID_Medico)
VALUES (@lunesPasado, '13:00', N'Palpitaciones', N'Hipertensión arterial leve',
        N'Control de la dieta y medicación', N'Medir la presión todos los días', 2, @idP6, @idM3);
DECLARE @cita3 INT = SCOPE_IDENTITY();
INSERT INTO Receta (ID_Cita, Descripcion, Indicaciones, FechaEmision)
VALUES (@cita3, N'1. Losartán | 50 mg | cada 24 horas | 30 días',
        N'Tomar por la mañana y reducir el consumo de sal.',
        DATEADD(HOUR, 14, CAST(@lunesPasado AS DATETIME)));

-- (d) Cancelada (medico2 / paciente2)
INSERT INTO Cita (Fecha, Hora, Motivo, ID_Estado, ID_Paciente, ID_Medico)
VALUES (DATEADD(DAY, 1, @lunesPasado), '09:00', N'Control de rutina', 3, @idP2, @idM2);

/* =========================================================================
    VERIFICACION
    ========================================================================= */
SELECT u.ID_Usuario, u.Username, r.NombreRol, u.Activo
FROM Usuario u JOIN Rol r ON r.ID_Rol = u.ID_Rol;

SELECT * FROM vw_CitasDetalle;

-- sp_Login con admin / Admin1234: debe devolver 1 fila con ID_Rol = 3
DECLARE @h VARCHAR(64) = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'Admin1234'), 2));
EXEC sp_Login 'admin', @h;
GO

    /* =========================================================================
       CREACIÓN DE JOB SEMANAL PARA RESPALDO DE BASE DE DATOS (GENERADO POR SSMS)
       ========================================================================= */
USE [msdb]
GO
IF EXISTS (SELECT job_id FROM msdb.dbo.sysjobs WHERE name = N'Respaldo_CitasMedicas')
BEGIN
    EXEC msdb.dbo.sp_delete_job @job_name = N'Respaldo_CitasMedicas';
END
GO
/****** Objeto: Job [Respaldo_CitasMedicas] Fecha de script: 30/10/2026 22:34:24 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Objeto: JobCategory [Database Maintenance] Fecha de script: 30/10/2026 22:34:24 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Respaldo_CitasMedicas', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Objeto: Step [Respaldo] Fecha de script: 30/10/2026 22:34:25 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Respaldo', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'-- 1. Almacenar la fecha y hora actual en una variable al inicio
DECLARE @FechaActual DATETIME = GETDATE();

-- 2. Crear la carpeta de respaldos automáticamente si no existe
EXEC xp_create_subdir ''C:\CitasMedicasBackups'';

-- 3. Generar el nombre del archivo de respaldo usando la variable
DECLARE @NombreArchivo NVARCHAR(255);
SET @NombreArchivo = N''C:\CitasMedicasBackups\CitasMedicasDB_Full_'' + 
    CONVERT(VARCHAR(8), @FechaActual, 112) + ''_'' + 
    REPLACE(CONVERT(VARCHAR(8), @FechaActual, 108), '':'', '''') + ''.bak'';

-- 4. Ejecutar el respaldo completo de la base de datos
BACKUP DATABASE [CitasMedicasDB] 
TO DISK = @NombreArchivo
WITH FORMAT, 
     INIT, 
     NAME = N''CitasMedicasDB-Respaldo Completo Semanal'', 
     SKIP, 
     NOREWIND, 
     NOUNLOAD, 
     STATS = 10;
GO', 
		@database_name=N'CitasMedicasDB', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Respaldo_Semanal', 
		@enabled=1, 
		@freq_type=8, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20261030, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'd00cf56b-bf88-4d42-94fe-e1db33a6add7'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO

