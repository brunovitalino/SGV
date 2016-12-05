using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DEntrada_Item
    {
        //Variáveis
        private int _Identrada_Item;
        private int _Identrada;
        private int _Idartigo;
        private decimal _Preco_Compra;
        private decimal _Preco_Venda;
        private int _Quantidade;
        private DateTime _Data_Producao;

        //Propriedades
        public int Identrada_Item
        {
            get { return _Identrada_Item; }
            set { _Identrada_Item = value; }
        }

        public int Identrada
        {
            get { return _Identrada; }
            set { _Identrada = value; }
        }

        public int Idartigo
        {
            get { return _Idartigo; }
            set { _Idartigo = value; }
        }

        public decimal Preco_Compra
        {
            get { return _Preco_Compra; }
            set { _Preco_Compra = value; }
        }

        public decimal Preco_Venda
        {
            get { return _Preco_Venda; }
            set { _Preco_Venda = value; }
        }

        public int Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public DateTime Data_Producao
        {
            get { return _Data_Producao; }
            set { _Data_Producao = value; }
        }

        //Construtores

        public DEntrada_Item ()
        {

        }

        public DEntrada_Item (int identrada_item, int identrada, int idartigo, decimal preco_compra,
            decimal preco_venda, int quantidade, DateTime data_producao)
        {
            this.Identrada_Item = identrada_item;
            this.Identrada = identrada;
            this.Idartigo = idartigo;
            this.Preco_Compra = preco_compra;
            this.Preco_Venda = preco_venda;
            this.Quantidade = quantidade;
            this.Data_Producao = data_producao;
        }

        //Método Inserir
        public string Inserir(DEntrada_Item Entrada_Item, ref SqlConnection SqlCon, ref SqlTransaction SqlTrans)
        {
            string resposta = "";
            try
            {
                //Definição do comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTrans;
                SqlCmd.CommandText = "spinserir_entrada_item";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrada_Item = new SqlParameter();
                ParIdentrada_Item.ParameterName = "@identrada_item";
                ParIdentrada_Item.SqlDbType = SqlDbType.Int;
                ParIdentrada_Item.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdentrada_Item);

                SqlParameter ParIdentrada = new SqlParameter();
                ParIdentrada.ParameterName = "@identrada";
                ParIdentrada.SqlDbType = SqlDbType.Int;
                ParIdentrada.Value = Entrada_Item.Identrada;
                SqlCmd.Parameters.Add(ParIdentrada);

                SqlParameter ParIdartigo = new SqlParameter();
                ParIdartigo.ParameterName = "@idartigo";
                ParIdartigo.SqlDbType = SqlDbType.Int;
                ParIdartigo.Value = Entrada_Item.Idartigo;
                SqlCmd.Parameters.Add(ParIdartigo);

                SqlParameter ParPreco_Compra = new SqlParameter();
                ParPreco_Compra.ParameterName = "@preco_compra";
                ParPreco_Compra.SqlDbType = SqlDbType.Money;
                ParPreco_Compra.Value = Entrada_Item.Preco_Compra;
                SqlCmd.Parameters.Add(ParPreco_Compra);

                SqlParameter ParPreco_Venda = new SqlParameter();
                ParPreco_Venda.ParameterName = "@preco_venda";
                ParPreco_Venda.SqlDbType = SqlDbType.Money;
                ParPreco_Venda.Value = Entrada_Item.Preco_Venda;
                SqlCmd.Parameters.Add(ParPreco_Venda);

                SqlParameter ParQuantidade = new SqlParameter();
                ParQuantidade.ParameterName = "@quantidade";
                ParQuantidade.SqlDbType = SqlDbType.Int;
                ParQuantidade.Value = Entrada_Item.Quantidade;
                SqlCmd.Parameters.Add(ParQuantidade);

                SqlParameter ParData_Producao = new SqlParameter();
                ParData_Producao.ParameterName = "@data_producao";
                ParData_Producao.SqlDbType = SqlDbType.Date;
                ParData_Producao.Value = Entrada_Item.Data_Producao;
                SqlCmd.Parameters.Add(ParData_Producao);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não inserido";
            }
            catch (Exception ex)
            {
                resposta = ex.Message;
            }
            return resposta;
        }
    }
}
