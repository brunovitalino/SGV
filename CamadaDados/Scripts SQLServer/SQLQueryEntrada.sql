--Adicionar a coluna Estado à tabela Entrada
alter table Entrada
add estado varchar(7) not null
go
--Stored Procedure pra listar as entradas
create proc splistar_entrada
as
select top 100 e.identrada, u.nome as funcionario, f.razao_social as fornecedor,
e.data, e.hora, e.tipo_pgto, e.numero, e.estado, sum(i.preco_compra*i.quantidade) as total
from Entrada_Item i
inner join Entrada e on i.identrada=e.identrada
inner join Fornecedor f on e.idfornecedor=f.idfornecedor
inner join Funcionario u on e.idfuncionario=u.idfuncionario
group by
e.identrada, u.nome, f.razao_social,
e.data, e.hora, e.tipo_pgto, e.numero, e.estado
order by e.identrada desc
go

--Stored Procedure para listar entradas entre datas
create proc spbuscar_entrada_data
@textobuscado varchar(20),
@textobuscado2 varchar(20)
as
select e.identrada, u.nome as funcionario, f.razao_social as fornecedor,
e.data, e.hora, e.tipo_pgto, e.numero, e.estado, sum(i.preco_compra*i.quantidade) as total
from Entrada_Item i
inner join Entrada e on i.identrada=e.identrada
inner join Fornecedor f on e.idfornecedor=f.idfornecedor
inner join Funcionario u on e.idfuncionario=u.idfuncionario
group by
e.identrada, u.nome, f.razao_social,
e.data, e.hora, e.tipo_pgto, e.numero, e.estado
having e.data>=@textobuscado and e.data<=@textobuscado2
go

--Procedimento Inserir Entrada
create proc spinserir_entrada
@identrada int=null output,
@idfuncionario int,
@idfornecedor int,
@data date,
@hora time(7),
@tipo_pgto varchar(20),
@numero varchar(48),
@icms decimal(4,2),
@estado varchar(7)
as
insert into Entrada (idfuncionario, idfornecedor, data, hora, tipo_pgto, numero, icms, estado)
values (@idfuncionario, @idfornecedor, @data, @hora, @tipo_pgto, @numero, @icms, @estado)
--Obter o código autogerado
SET @identrada=@@IDENTITY
go

--Procedimento Anular Entrada
create proc spanular_entrada
@identrada int
as
update Entrada set estado='ANULADO'
where identrada=@identrada
go

--Procedimento Inserir Itens de Entrada
create proc spinserir_entrada_item
@identrada_item int output,
@identrada int,
@idartigo int,
@preco_compra money,
@preco_venda money,
@quantidade int,
@data_producao date
as
insert into Entrada_Item (identrada, idartigo, preco_compra, preco_venda, quantidade, data_producao)
values (@identrada, @idartigo, @preco_compra, @preco_venda, @quantidade, @data_producao)
go

--Procedimento Listar Itens de Entrada
create proc splistar_entrada_item
@textobuscado varchar(20)
as
select i.idartigo as id, a.nome as artigo, i.preco_compra, i.preco_venda, i.quantidade, i.data_producao,
(i.quantidade*i.preco_compra) as subtotal
from Entrada_Item i
inner join Artigo a on i.idartigo=a.idartigo
where i.identrada=@textobuscado
go