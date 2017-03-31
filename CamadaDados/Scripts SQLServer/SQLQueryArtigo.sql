--Procedimento Listar Artigo
create proc splistar_artigo
as
SELECT top 100 dbo.Artigo.idartigo, dbo.Artigo.codigo, dbo.Artigo.nome,
dbo.Artigo.descricao
FROM dbo.Artigo
order by dbo.Artigo.idartigo desc
go

--Procedimento Buscar Artigo - Nome
create proc spbuscar_artigo_nome
@textobuscado varchar(50)
as
SELECT *
FROM dbo.Artigo
where nome like @textobuscado + '%'
go

--Procedimento Inserir Artigo
create proc spinserir_artigo
@idartigo int output,
@codigo varchar(50),
@nome varchar(50),
@descricao varchar(1024)
as
insert into Artigo (codigo, nome, descricao)
values (@codigo,@nome,@descricao)
go

--Procedimento Editar Artigo
create proc speditar_artigo
@idartigo int,
@codigo varchar(50),
@nome varchar(50),
@descricao varchar(1024)
as
update Artigo
set
codigo=@codigo,
nome=@nome,
descricao=@descricao
where idartigo=@idartigo
go

--Procedimento Remover Artigo
create proc spremover_artigo
@idartigo int
as
delete from Artigo
where idartigo=@idartigo
go