using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DEntrada
    {
        //Variáveis
        private int _Identrada;
        private int _Idfuncionario;
        private int _Idfornecedor;
        private DateTime _Data;
        private DateTime _Hora;
        private string _Tipo_Pgto;
        private string _Numero;
        private decimal _Icms;
        private string _Estado;

        //Propriedades
        public int Identrada
        {
            get { return _Identrada; }
            set { _Identrada = value; }
        }

        public int Idfuncionario
        {
            get { return _Idfuncionario; }
            set { _Idfuncionario = value; }
        }

        public int Idfornecedor
        {
            get { return _Idfornecedor; }
            set { _Idfornecedor = value; }
        }

        public DateTime Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public DateTime Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        public string Tipo_Pgto
        {
            get { return _Tipo_Pgto; }
            set { _Tipo_Pgto = value; }
        }

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public decimal Icms
        {
            get { return _Icms; }
            set { _Icms = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        //Construtores
        public DEntrada ()
        {

        }

        public DEntrada (int identrada, int idfuncionario, int idfornecedor, DateTime data, DateTime hora,
            string tipo_pgto, string numero, decimal icms, string estado)
        {
            this.Identrada = identrada;
            this.Idfuncionario = idfuncionario;
            this.Idfornecedor = idfornecedor;
            this.Data = data;
            this.Hora = hora;
            this.Tipo_Pgto = tipo_pgto;
            this.Numero = numero;
            this.Icms = icms;
            this.Estado = estado;
        }

        //MÉTODOS

        //Método Inserir
        public string Inserir(DEntrada Entrada, List<DEntrada_Item> Item)
        {
            string resposta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCon.Open();
                //Definição da transação
                SqlTransaction SqlTrans = SqlCon.BeginTransaction();
                //Definição do comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTrans;
                SqlCmd.CommandText = "spinserir_entrada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrada = new SqlParameter();
                ParIdentrada.ParameterName = "@identrada";
                ParIdentrada.SqlDbType = SqlDbType.Int;
                ParIdentrada.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdentrada);

                SqlParameter ParIdfuncionario = new SqlParameter();
                ParIdfuncionario.ParameterName = "@idfuncionario";
                ParIdfuncionario.SqlDbType = SqlDbType.Int;
                ParIdfuncionario.Value = Entrada.Idfuncionario;
                SqlCmd.Parameters.Add(ParIdfuncionario);

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Entrada.Idfornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);

                SqlParameter ParData = new SqlParameter();
                ParData.ParameterName = "@data";
                ParData.SqlDbType = SqlDbType.Date;
                ParData.Value = Entrada.Data;
                SqlCmd.Parameters.Add(ParData);

                SqlParameter ParTipo_Pgto = new SqlParameter();
                ParTipo_Pgto.ParameterName = "@tipo_pgto";
                ParTipo_Pgto.SqlDbType = SqlDbType.VarChar;
                ParTipo_Pgto.Size = 20;
                ParTipo_Pgto.Value = Entrada.Tipo_Pgto;
                SqlCmd.Parameters.Add(ParTipo_Pgto);

                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 48;
                ParNumero.Value = Entrada.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParIcms = new SqlParameter();
                ParIcms.ParameterName = "@icms";
                ParIcms.SqlDbType = SqlDbType.Decimal;
                ParIcms.Precision = 4;
                ParIcms.Scale = 2;
                ParIcms.Value = Entrada.Icms;
                SqlCmd.Parameters.Add(ParIcms);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Entrada.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não inserido";

                if (resposta.Equals("OK"))
                {
                    //Obter o código de entrada gerado
                    this.Identrada = Convert.ToInt32(SqlCmd.Parameters["@identrada"].Value);
                    foreach (DEntrada_Item ite in Item)
                    {
                        ite.Identrada = this.Identrada;
                        //Chamar o método inserir da classe DEntrada_Item
                        resposta = ite.Inserir(ite, ref SqlCon, ref SqlTrans);
                        if (!resposta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (resposta.Equals("OK"))
                {
                    SqlTrans.Commit();
                }
                else
                {
                    SqlTrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                resposta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resposta;
        }

        //Método Anular
        public string Anular(DEntrada Entrada)
        {
            string resposta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCon.Open();
                //Definição do comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spanular_entrada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrada = new SqlParameter();
                ParIdentrada.ParameterName = "@idartigo";
                ParIdentrada.SqlDbType = SqlDbType.Int;
                ParIdentrada.Value = Entrada.Identrada;
                SqlCmd.Parameters.Add(ParIdentrada);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não anulado";
            }
            catch (Exception ex)
            {
                resposta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resposta;
        }

        //Método Listar
        public DataTable Listar()
        {
            DataTable DtResultado = new DataTable("Entrada");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_entrada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDadp = new SqlDataAdapter(SqlCmd);
                SqlDadp.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método BuscarDatas
        public DataTable BuscarDatas(String TextoBuscado, String TextoBuscado2)
        {
            DataTable DtResultado = new DataTable("Entrada");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_entrada_data";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 20;
                ParTextoBuscado.Value = TextoBuscado;
                SqlCmd.Parameters.Add(ParTextoBuscado);

                SqlParameter ParTextoBuscado2 = new SqlParameter();
                ParTextoBuscado2.ParameterName = "@textobuscado2";
                ParTextoBuscado2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado2.Size = 20;
                ParTextoBuscado2.Value = TextoBuscado2;
                SqlCmd.Parameters.Add(ParTextoBuscado2);

                SqlDataAdapter SqlDadp = new SqlDataAdapter(SqlCmd);
                SqlDadp.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método ListarEntrada_Item
        public DataTable ListarEntrada_Item(String TextoBuscado)
        {
            DataTable DtResultado = new DataTable("Entrada_Item");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_entrada_item";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 20;
                ParTextoBuscado.Value = TextoBuscado;
                SqlCmd.Parameters.Add(ParTextoBuscado);

                SqlDataAdapter SqlDadp = new SqlDataAdapter(SqlCmd);
                SqlDadp.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
