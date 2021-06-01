
Create database COSO;

use COSO;

CREATE TABLE Riesgos(
 ID INT primary key identity(0 ,1 ),
 Nombre VARCHAR(50) ,
 Probabilidad varchar(50),
 Impacto varchar (50),
 Ocurrencia varchar(50)
)

CREATE TABLE Consecuencias(
 ID INT primary key identity (0 ,1 ),
 Descripcion VARCHAR(150) ,
 IdRiesgo int NOT NULL,
FOREIGN KEY (IdRiesgo) REFERENCES Riesgos(ID)
)

CREATE TABLE Controles(
 ID INT primary key identity (0 ,1 ),
 Descripcion VARCHAR(150),
 Eficiencia varchar(50),
 IdRiesgo int ,
FOREIGN KEY (IdRiesgo) REFERENCES Riesgos(ID)
)

Create table Cotingencia(
ID INT primary key identity (0 ,1 ),
 Descripcion VARCHAR(150),
 IdConsecuencia int not null ,
FOREIGN KEY (IdConsecuencia) REFERENCES Consecuencias(ID)
)