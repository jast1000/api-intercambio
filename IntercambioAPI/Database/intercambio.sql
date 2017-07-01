-- Tabla de Usuarios
CREATE TABLE Usuarios (
  IdUsuario VARCHAR(255) NOT NULL,
  Password VARCHAR(255),
  TipoUsuario INT
)
GO

ALTER TABLE Usuarios ADD CONSTRAINT PK_Usuarios PRIMARY KEY(IdUsuario)
GO

-- Tabla de Participantes
CREATE TABLE Participantes (
  IdPart VARCHAR(255) NOT NULL,
  Nombre VARCHAR(255),
  Edad INT,
  Sexo VARCHAR(255),
  Grado VARCHAR(255),
  Grupo VARCHAR(255),
  Area VARCHAR(255),
  Gustos TEXT,
  IdUsuario VARCHAR(255),
  OpcionesIntercambio TEXT
)
GO

ALTER TABLE Participantes ADD CONSTRAINT PK_Participantes PRIMARY KEY(IdPart)
GO

ALTER TABLE Participantes ADD CONSTRAINT FK_Participantes_IdUsuario FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario)
GO

-- Tabla de Intercambios
CREATE TABLE Reglas (
  IdRegla INT IDENTITY NOT NULL,
  Lugar VARCHAR(255),
  Fecha DATETIME,
  Monto FLOAT
)

ALTER TABLE Reglas ADD CONSTRAINT PK_Reglas PRIMARY KEY(IdRegla)
GO

--Tabla de Sugerencias por participante
CREATE TABLE Sugerencias (
  IdSuge INT IDENTITY NOT NULL,
  IdPart VARCHAR(255),
  Descripcion TEXT
)
GO

ALTER TABLE Sugerencias ADD CONSTRAINT PK_Sugerencias PRIMARY KEY(IdSuge)
GO

ALTER TABLE Sugerencias ADD CONSTRAINT FK_Sugerencias_IdPart FOREIGN KEY(IdPart) REFERENCES Participantes(IdPart)
GO

-- Tabla de asistencias de participante
CREATE TABLE Asistencia (
  IdPart VARCHAR(255) NOT NULL,
  Afirmacion BIT
)

ALTER TABLE Asistencia ADD CONSTRAINT PK_Asistencia PRIMARY KEY(IdPart)
GO

ALTER TABLE Asistencia ADD CONSTRAINT FK_Asistencia_IdPart FOREIGN KEY(IdPart) REFERENCES Participantes(IdPart)
GO

-- Tabla de sorteo
CREATE TABLE Sorteo (
  IdPart1 VARCHAR(255) NOT NULL,
  IdPartInter VARCHAR(255) NOT NULL,
  Fecha DATETIME
)
GO

ALTER TABLE Sorteo ADD CONSTRAINT PK_Sorteo PRIMARY KEY(IdPart1, IdPartInter)
GO

ALTER TABLE Sorteo ADD CONSTRAINT FK_Sorteo_IdPart1 FOREIGN KEY(IdPart1) REFERENCES Participantes(IdPart)
GO

ALTER TABLE Sorteo ADD CONSTRAINT FK_Sorteo_IdPartInter FOREIGN KEY(IdPartInter) REFERENCES Participantes(IdPart)
GO

-- Tabla de plantillas para envío de correos
CREATE TABLE plantilla_correo (
  id INT IDENTITY NOT NULL,
  plantilla TEXT NOT NULL,
  asunto TEXT NOT NULL,
)

ALTER TABLE plantilla_correo ADD CONSTRAINT PK_plantilla_correo PRIMARY KEY(id)
GO


INSERT INTO plantilla_correo(id, plantilla, asunto) values(1, 'Hola, tus cuentas de acceso a la plataformas de regalos es:
Usuario: %s
Password: %s
Accede a http://janiserver.servehttp.com/app-intercambio', 'Acceso a aplicación');

INSERT INTO plantilla_correo(plantilla, asunto) values('Hola, cuentas con una invitación para participar en un intercambio de regalos

Lugar: %s
Fecha: %s
Monto mínimo: $%.2f

Recuerda llenar tu perfil
Accede a plataforma para confirmar tu asistencia: http://janiserver.servehttp.com/app-intercambio', 'Invitación intercambio de regalos');

INSERT INTO plantilla_correo(plantilla, asunto) values('Hola, cuentas con una pareja para realizar tu intercambio

Nombre: %s
Edad: %d
Genero: %s
Gustos:
%s
Opciones de intercambio:
%s

Para ver más información, visita su perfil
Accede a plataforma: http://janiserver.servehttp.com/app-intercambio', 'Pareja de intercambio de regalos');

INSERT INTO plantilla_correo(plantilla, asunto) values('Hola, esta es la lista de parejas que participan en el intercambio:

%s', 'Parejas que participan en intercambio');

INSERT INTO plantilla_correo(plantilla, asunto) values('* %s - %s', ' ');




