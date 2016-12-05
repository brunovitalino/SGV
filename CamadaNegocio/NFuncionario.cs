using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NFuncionario
    {
        //Método Inserir que chama o método Inserir da classe DFuncionario da CamadaDados
        public static string Inserir(string nome, string sexo, DateTime data_nasc, string cpf,
            string endereco, string telefone, string email, string tipo_usuario, string usuario, string senha)
        {
            DFuncionario Obj = new DFuncionario();
            Obj.Nome = nome;
            Obj.Sexo = sexo;
            Obj.Data_Nasc = data_nasc;
            Obj.Cpf = cpf;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Tipo_Usuario = tipo_usuario;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Inserir(Obj);
        }

        //Método Editar que chama o método Editar da classe DFuncionario da CamadaDados
        public static string Editar(int idfuncionario, string nome, string sexo, DateTime data_nasc, string cpf,
            string endereco, string telefone, string email, string tipo_usuario, string usuario, string senha)
        {
            DFuncionario Obj = new DFuncionario();
            Obj.Idfuncionario = idfuncionario;
            Obj.Nome = nome;
            Obj.Sexo = sexo;
            Obj.Data_Nasc = data_nasc;
            Obj.Cpf = cpf;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Tipo_Usuario = tipo_usuario;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Editar(Obj);
        }

        //Método Remover que chama o método Remover da classe DFuncionario da CamadaDados
        public static string Remover(int idfuncionario)
        {
            DFuncionario Obj = new DFuncionario();
            Obj.Idfuncionario = idfuncionario;
            return Obj.Remover(Obj);
        }

        //Método Listar que chama o método Listar da classe DFuncionario da CamadaDados
        public static DataTable Listar()
        {
            return new DFuncionario().Listar();
        }

        //Método BuscarNome que chama o método BuscarNome da classe DFuncionario da CamadaDados
        public static DataTable BuscarNome(string textoBuscado)
        {
            DFuncionario Obj = new DFuncionario();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarNome(Obj);
        }

        //Método BuscarCpf que chama o método BuscarCpf da classe DFuncionario da CamadaDados
        public static DataTable BuscarCpf(string textoBuscado)
        {
            DFuncionario Obj = new DFuncionario();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarCpf(Obj);
        }
    }
}
