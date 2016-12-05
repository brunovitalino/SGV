using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DFornecedor
    {
        //Variáveis
        private int _Idfornecedor;
        private string _Razao_Social;
        private string _Setor_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _Url;
        private string _TextoBuscado;
        //private string _TipoBuscado;

        //Propriedades
        public int Idfornecedor
        {
            get { return _Idfornecedor; }
            set { _Idfornecedor = value; }
        }

        public string Razao_Social
        {
            get { return _Razao_Social; }
            set { _Razao_Social = value; }
        }

        public string Setor_Comercial
        {
            get { return _Setor_Comercial; }
            set { _Setor_Comercial = value; }
        }

        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public string Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        public string TextoBuscado
        {
            get { return _TextoBuscado; }
            set { _TextoBuscado = value; }
        }

        /*public string TipoBuscado
        {
            get { return _TipoBuscado; }
            set { _TipoBuscado = value; }
        }*/

        //Construtores
        public DFornecedor()
        {

        }

        public DFornecedor(int idfornecedor, string razao_social, string setor_comercial, string tipo_documento, string num_documento, string endereco, string telefone, string email, string url, string textoBuscado)
        {
            this.Idfornecedor = idfornecedor;
            this.Razao_Social = razao_social;
            this.Setor_Comercial = setor_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Url = url;
            this.TextoBuscado = textoBuscado;
        }

        //Método Inserir
        public string Inserir(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "spinserir_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdfornecedor);

                SqlParameter ParRazao_Social = new SqlParameter();
                ParRazao_Social.ParameterName = "@razao_social";
                ParRazao_Social.SqlDbType = SqlDbType.VarChar;
                ParRazao_Social.Size = 150;
                ParRazao_Social.Value = Fornecedor.Razao_Social;
                SqlCmd.Parameters.Add(ParRazao_Social);

                SqlParameter ParSetor_Comercial = new SqlParameter();
                ParSetor_Comercial.ParameterName = "@setor_comercial";
                ParSetor_Comercial.SqlDbType = SqlDbType.VarChar;
                ParSetor_Comercial.Size = 50;
                ParSetor_Comercial.Value = Fornecedor.Setor_Comercial;
                SqlCmd.Parameters.Add(ParSetor_Comercial);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Fornecedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 14;
                ParNum_Documento.Value = Fornecedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 10;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não inserido";
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

        //Método Editar
        public string Editar(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "speditar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Fornecedor.Idfornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);

                SqlParameter ParRazao_Social = new SqlParameter();
                ParRazao_Social.ParameterName = "@razao_social";
                ParRazao_Social.SqlDbType = SqlDbType.VarChar;
                ParRazao_Social.Size = 150;
                ParRazao_Social.Value = Fornecedor.Razao_Social;
                SqlCmd.Parameters.Add(ParRazao_Social);

                SqlParameter ParSetor_Comercial = new SqlParameter();
                ParSetor_Comercial.ParameterName = "@setor_comercial";
                ParSetor_Comercial.SqlDbType = SqlDbType.VarChar;
                ParSetor_Comercial.Size = 50;
                ParSetor_Comercial.Value = Fornecedor.Setor_Comercial;
                SqlCmd.Parameters.Add(ParSetor_Comercial);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Fornecedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 14;
                ParNum_Documento.Value = Fornecedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 10;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não atualizado";
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

        //Método Remover
        public string Remover(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "spremover_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Fornecedor.Idfornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);

                //Executaremos o comando
                resposta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não removido";
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
            DataTable DtResultado = new DataTable("Fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_fornecedor";
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

        //Método BuscarRazao_Social
        public DataTable BuscarRazao_Social(DFornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("Fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_razao_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 50;
                ParTextoBuscado.Value = Fornecedor.TextoBuscado;
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

        //Método BuscarNum_Documento
        public DataTable BuscarNum_Documento(DFornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("Fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_num_doc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 14;
                ParTextoBuscado.Value = Fornecedor.TextoBuscado;
                SqlCmd.Parameters.Add(ParTextoBuscado);

                /*SqlParameter ParTipoBuscado = new SqlParameter();
                ParTipoBuscado.ParameterName = "@tipobuscado";
                ParTipoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTipoBuscado.Size = 20;
                ParTipoBuscado.Value = Fornecedor.TipoBuscado;
                SqlCmd.Parameters.Add(ParTipoBuscado);*/

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
