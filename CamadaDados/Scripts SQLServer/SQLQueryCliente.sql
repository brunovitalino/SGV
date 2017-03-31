--Procedimento Listar Cliente
create proc splistar_cliente
as
select top 100 * from Cliente
order by nome asc
go

--Procedimento Buscar Cliente - Nome
create proc spbuscar_cliente_nome
@textobuscado varchar(50)
as
select * from Cliente
where nome like @textobuscado + '%'
go

--Procedimento Buscar Cliente - Numero Documento
create proc spbuscar_cliente_num_doc
@textobuscado varchar(11)
as
select *
from Cliente
where num_documento like @textobuscado + '%'
go

--Procedimento Inserir Cliente
create proc spinserir_cliente
@idcliente int output,
@nome varchar(50),
@sexo varchar(1),
@data_nasc date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@endereco varchar(100),
@telefone varchar(11),
@email varchar(50)
as
insert into Cliente(nome, sexo, data_nasc, tipo_documento, num_documento, endereco, telefone, email)
values (@nome, @sexo, @data_nasc, @tipo_documento, @num_documento, @endereco, @telefone, @email)
go

--Procedimento Editar Cliente
create proc speditar_cliente
@idcliente int,
@nome varchar(50),
@sexo varchar(1),
@data_nasc date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@endereco varchar(100),
@telefone varchar(11),
@email varchar(50)
as
update Cliente set nome=@nome, sexo=@sexo, data_nasc=@data_nasc, tipo_documento=@tipo_documento,
num_documento=@num_documento, endereco=@endereco, telefone=@telefone, email=@email
where idcliente=@idcliente
go

--Procedimento Remover Cliente
create proc spremover_cliente
@idcliente int
as
delete from Cliente
where idcliente=@idcliente
go