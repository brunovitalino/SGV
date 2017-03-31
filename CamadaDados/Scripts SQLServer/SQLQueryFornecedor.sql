--Procedimento Listar Fornecedor
create proc splistar_fornecedor
as
select top 100 *
from Fornecedor
order by razao_social asc
go

--Procedimento Buscar Fornecedor - Razao Social
create proc spbuscar_fornecedor_razao_social
@textobuscado varchar(50)
as
select *
from Fornecedor
where razao_social like @textobuscado + '%'
go

--Procedimento Buscar Fornecedor - Numero Documento
create proc spbuscar_fornecedor_num_doc
@textobuscado varchar(14)
as
select *
from Fornecedor
where num_documento like @textobuscado + '%'
go

--Procedimento Inserir Fornecedor
create proc spinserir_fornecedor
@idfornecedor int output,
@razao_social varchar(150),
@setor_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(14),
@endereco varchar(100),
@telefone varchar(10),
@email varchar(50),
@url varchar(100)
as
insert into Fornecedor(razao_social,setor_comercial,tipo_documento,num_documento,endereco,telefone,email,url)
values (@razao_social,@setor_comercial,@tipo_documento,@num_documento,@endereco,@telefone,@email,@url)
go

--Procedimento Editar Fornecedor
create proc speditar_fornecedor
@idfornecedor int output,
@razao_social varchar(150),
@setor_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(14),
@endereco varchar(100),
@telefone varchar(10),
@email varchar(50),
@url varchar(100)
as
update Fornecedor
set
razao_social=@razao_social,
setor_comercial=@setor_comercial,
tipo_documento=@tipo_documento,
num_documento=@num_documento,
endereco=@endereco,
telefone=@telefone,
email=@email,
url=@url
where idfornecedor=@idfornecedor
go

--Procedimento Remover Fornecedor
create proc spremover_fornecedor
@idfornecedor int
as
delete from Fornecedor
where idfornecedor=@idfornecedor
go