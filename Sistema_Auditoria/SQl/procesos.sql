
use COSO;
go

create or alter proc sp_add_riesgo 
@nombre varchar(50),
@probabilidad varchar(50),
@impacto varchar(50),
@ocurrencia varchar(50)
as
begin
 insert into Riesgos(Nombre,Probabilidad,Impacto,Ocurrencia) values (@nombre,@probabilidad,@impacto,@ocurrencia);
end
go;
--------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_update_riesgo 
@id int,
@nombre varchar(50),
@probabilidad varchar(50),
@impacto varchar(50),
@ocurrencia varchar(50)
as
begin
	update Riesgos set Nombre=@nombre , Impacto=@impacto , Ocurrencia=@ocurrencia , Probabilidad=@probabilidad where ID=@id;
end
go;
-----------------------------------------------------------------------------------------------------------------------------------

create or alter proc  sp_show_riesgo
as
begin
	select * from Riesgos R inner join Consecuencias C on R.ID=C.IdRiesgo;
end
go;

----------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_add_control 
@idriesgo int,
@descripcion varchar(50),
@eficiencia varchar(50)
as
begin
 insert into Controles(Descripcion,Eficiencia,IdRiesgo) values (@descripcion,@eficiencia,@idriesgo);
end
go;
--------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_update_control
@id int,
@idRiesgo int,
@descripcion varchar(50),
@eficiencia varchar(50)
as
begin
	update Controles set Descripcion=@descripcion ,Eficiencia=@eficiencia where ID=@id;
end
go;
-----------------------------------------------------------------------------------------------------------------------------------

create or alter proc  sp_show_control
as
begin
	select * from Controles;
end
go;

----------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_add_contingencia
@idConsecuencia int,
@descripcion varchar(50)
as
begin
 insert into Cotingencia (IdConsecuencia,Descripcion ) values (@descripcion,@idConsecuencia);
end
go;
--------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_update_contingencia
@id int,
@idConsecuencia int,
@descripcion varchar(50)
as
begin
	update Controles set Descripcion=@descripcion where ID=@id;
end
go;
-----------------------------------------------------------------------------------------------------------------------------------

create or alter proc  sp_show_contingencia
as
begin
	select * from Cotingencia;
end
go;

----------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_add_consecuencia
@idRiesgo int,
@descripcion varchar(50)
as
begin
 insert into Consecuencias(Descripcion,IdRiesgo) values (@descripcion,@idriesgo);
end
go;
--------------------------------------------------------------------------------------------------------------------------------

create or alter proc sp_update_consecuencia
@id int,
@idRiesgo int,
@descripcion varchar(50)
as
begin
	update Controles set Descripcion=@descripcion  where ID=@id;
end
go;
-----------------------------------------------------------------------------------------------------------------------------------

create or alter proc  sp_show_consecuencia
as
begin
	select * from Consecuencias;
end
go;


select * from Riesgos R inner join Consecuencias C on R.ID=C.IdRiesgo 