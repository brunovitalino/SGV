using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NArtigo
    {
        //Método Inserir que chama o método Inserir da classe DArtigo da CamadaDados
        public static string Inserir(string codigo, string nome, string descricao)
        {
            DArtigo Obj = new DArtigo();
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);
        }

        //Método Editar que chama o método Editar da classe DArtigo da CamadaDados
        public static string Editar(int idartigo, string codigo, string nome, string descricao)
        {
            DArtigo Obj = new DArtigo();
            Obj.Idartigo = idartigo;
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);
        }

        //Método Remover que chama o método Remover da classe DArtigo da CamadaDados
        public static string Remover(int idartigo)
        {
            DArtigo Obj = new DArtigo();
            Obj.Idartigo = idartigo;
            return Obj.Remover(Obj);
        }

        //Método Listar que chama o método Listar da classe DArtigo da CamadaDados
        public static DataTable Listar()
        {
            DArtigo Obj = new DArtigo();
            return Obj.Listar();
        }

        //Método BuscarNome que chama o método BuscarNome da classe DArtigo da CamadaDados
        public static DataTable BuscarNome(string textoBuscado)
        {
            DArtigo Obj = new DArtigo();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarNome(Obj);
        }
    }
}
