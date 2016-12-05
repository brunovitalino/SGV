using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NCliente
    {
        //Método Inserir que chama o método Inserir da classe DCliente da CamadaDados
        public static string Inserir(string nome, string sexo, DateTime data_nasc, string tipo_documento,
            string num_documento, string endereco, string telefone, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nome = nome;
            Obj.Sexo = sexo;
            Obj.Data_Nasc = data_nasc;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            return Obj.Inserir(Obj);
        }

        //Método Editar que chama o método Editar da classe DCliente da CamadaDados
        public static string Editar(int idcliente, string nome, string sexo, DateTime data_nasc, string tipo_documento,
            string num_documento, string endereco, string telefone, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nome = nome;
            Obj.Sexo = sexo;
            Obj.Data_Nasc = data_nasc;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        //Método Remover que chama o método Remover da classe DCliente da CamadaDados
        public static string Remover(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Remover(Obj);
        }

        //Método Listar que chama o método Listar da classe DCliente da CamadaDados
        public static DataTable Listar()
        {
            return new DCliente().Listar();
        }

        //Método BuscarNome que chama o método BuscarNome da classe DCliente da CamadaDados
        public static DataTable BuscarNome(string textoBuscado)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarNome(Obj);
        }

        //Método BuscarNum_Documento que chama o método BuscarNum_Documento da classe DCliente da CamadaDados
        public static DataTable BuscarNum_Documento(string textoBuscado)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
