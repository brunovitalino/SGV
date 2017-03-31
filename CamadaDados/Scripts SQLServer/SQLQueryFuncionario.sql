--Procedimento Listar Funcionario
create proc splistar_funcionario
as
select top 100 * from Funcionario
order by nome asc
go

--Procedimento Buscar Funcionario - Nome
create proc spbuscar_funcionario_nome
@textobuscado varchar(50)
as
select * from Funcionario
where nome like @textobuscado + '%'
order by nome asc
go

--Procedimento Buscar Funcionario - CPF
create proc spbuscar_funcionario_cpf
@textobuscado varchar(11)
as
select * from Funcionario
where cpf like @textobuscado + '%'
go

--Procedimento Inserir Funcionario
create proc spinserir_funcionario
@idfuncionario int output,
@nome varchar(20),
@sexo varchar(1),
@data_nasc date,
@cpf varchar(11),
@endereco varchar(100),
@telefone varchar(50),
@email varchar(50),
@tipo_usuario varchar(20),
@usuario varchar(20),
@senha varchar(20)
as
insert into Funcionario(nome, sexo, data_nasc, cpf, endereco, telefone, email, tipo_usuario, usuario, senha)
values (@nome, @sexo, @data_nasc, @cpf, @endereco, @telefone, @email, @tipo_usuario, @usuario, @senha)
go

--Procedimento Editar Funcionario
create proc speditar_funcionario
@idfuncionario int,
@nome varchar(20),
@sexo varchar(1),
@data_nasc date,
@cpf varchar(11),
@endereco varchar(100),
@telefone varchar(50),
@email varchar(50),
@tipo_usuario varchar(20),
@usuario varchar(20),
@senha varchar(20)
as
update Funcionario set nome=@nome, sexo=@sexo, data_nasc=@data_nasc, cpf=@cpf, endereco=@endereco,
telefone=@telefone, email=@email, @tipo_usuario=tipo_usuario, @usuario=usuario, @senha=senha
where idfuncionario=@idfuncionario
go

--Procedimento Remover Funcionario
create proc spremover_funcionario
@idfuncionario int
as
delete from Funcionario
where idfuncionario=@idfuncionario
go