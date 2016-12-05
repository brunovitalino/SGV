using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NEntrada
    {
        //Método Inserir que chama o método Inserir da classe DEntrada com DEntrada_Item da CamadaDados
        public static string Inserir(int idfuncionario, int idfornecedor, DateTime data, string tipo_pgto,
            string numero, decimal icms, string estado, DataTable dtItem)
        {
            DEntrada Obj = new DEntrada();
            Obj.Idfuncionario=idfuncionario;
            Obj.Idfornecedor=idfornecedor;
            Obj.Data = data;
            Obj.Tipo_Pgto = tipo_pgto;
            Obj.Numero = numero;
            Obj.Icms = icms;
            Obj.Estado = estado;
            List<DEntrada_Item> itens = new List<DEntrada_Item>();
            foreach (DataRow row in dtItem.Rows)
            {
                DEntrada_Item item = new DEntrada_Item();
                item.Idartigo = Convert.ToInt32(row["idartigo"].ToString());
                item.Preco_Compra = Convert.ToDecimal(row["preco_compra"].ToString());
                item.Preco_Venda = Convert.ToDecimal(row["preco_venda"].ToString());
                item.Quantidade = Convert.ToInt32(row["quantidade"].ToString());
                item.Data_Producao = Convert.ToDateTime(row["data_producao"].ToString());
                itens.Add(item);
            }
            return Obj.Inserir(Obj, itens);
        }

        //Método Remover que chama o método Anular da classe DEntrada da CamadaDados
        public static string Anular(int identrada)
        {
            DEntrada Obj = new DEntrada();
            Obj.Identrada = identrada;
            return Obj.Anular(Obj);
        }

        //Método Listar que chama o método Listar da classe DEntrada com DEntrada_Item da CamadaDados
        public static DataTable Listar()
        {
            return new DEntrada().Listar();
        }

        //Método BuscarDatas que chama o método BuscarDatas da classe DEntrada da CamadaDados
        public static DataTable BuscarDatas(string textoBuscado, string textoBuscado2)
        {
            DEntrada Obj = new DEntrada();
            return Obj.BuscarDatas(textoBuscado, textoBuscado2);
        }

        //Método ListarItem que chama o método ListarEntrada_Item da classe DEntrada da CamadaDados
        public static DataTable ListarEntrada_Item(string textoBuscado)
        {
            DEntrada Obj = new DEntrada();
            return Obj.ListarEntrada_Item(textoBuscado);
        }
    }
}
