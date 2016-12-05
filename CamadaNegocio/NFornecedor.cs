using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NFornecedor
    {
        //Método Inserir que chama o método Inserir da classe DFornecedor da CamadaDados
        public static string Inserir(string razao_social, string setor_comercial, string tipo_documento,
            string num_documento, string endereco, string telefone, string email, string url)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.Razao_Social = razao_social;
            Obj.Setor_Comercial = setor_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Inserir(Obj);
        }

        //Método Editar que chama o método Editar da classe DFornecedor da CamadaDados
        public static string Editar(int idfornecedor, string razao_social, string setor_comercial, string tipo_documento,
            string num_documento, string endereco, string telefone, string email, string url)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.Idfornecedor = idfornecedor;
            Obj.Razao_Social = razao_social;
            Obj.Setor_Comercial = setor_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Remover que chama o método Remover da classe DFornecedor da CamadaDados
        public static string Remover(int idfornecedor)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.Idfornecedor = idfornecedor;
            return Obj.Remover(Obj);
        }

        //Método Listar que chama o método Listar da classe DFornecedor da CamadaDados
        public static DataTable Listar()
        {
            return new DFornecedor().Listar();
        }

        //Método BuscarRazao_Social que chama o método BuscarRazao_Social da classe DFornecedor da CamadaDados
        public static DataTable BuscarRazao_Social(string textoBuscado)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.TextoBuscado = textoBuscado;
            return Obj.BuscarRazao_Social(Obj);
        }

        //Método BuscarNum_Documento que chama o método BuscarNum_Documento da classe DFornecedor da CamadaDados
        public static DataTable BuscarNum_Documento(string textoBuscado) //, string tipoBuscado)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.TextoBuscado = textoBuscado;
            //Obj.TipoBuscado = tipoBuscado;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
