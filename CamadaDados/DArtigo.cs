using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    public class DArtigo
    {
        private int _Idartigo;
        private string _Codigo;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscado;

        public int Idartigo
        {
            get { return _Idartigo; }
            set { _Idartigo = value; }
        }
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }
        public string TextoBuscado
        {
            get { return _TextoBuscado; }
            set { _TextoBuscado = value; }
        }

        //Construtor Vazio
        public DArtigo()
        {

        }

        //Construtor com parâmetros
        public DArtigo(int idartigo, string codigo, string nome, string descricao, string textoBuscado)
        {
            this.Idartigo = idartigo;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscado = textoBuscado;
        }

        //Método Inserir
        public string Inserir(DArtigo Artigo)
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
                SqlCmd.CommandText = "spinserir_artigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdartigo = new SqlParameter();
                ParIdartigo.ParameterName = "@idartigo"; 
                ParIdartigo.SqlDbType = SqlDbType.Int;
                ParIdartigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdartigo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Artigo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Artigo.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 1024;
                ParDescricao.Value = Artigo.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

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
        public string Editar(DArtigo Artigo)
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
                SqlCmd.CommandText = "speditar_artigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdartigo = new SqlParameter();
                ParIdartigo.ParameterName = "@idartigo";
                ParIdartigo.SqlDbType = SqlDbType.Int;
                ParIdartigo.Value = Artigo.Idartigo;
                SqlCmd.Parameters.Add(ParIdartigo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Artigo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Artigo.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 256;
                ParDescricao.Value = Artigo.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

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
        public string Remover(DArtigo Artigo)
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
                SqlCmd.CommandText = "spremover_artigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdartigo = new SqlParameter();
                ParIdartigo.ParameterName = "@idartigo";
                ParIdartigo.SqlDbType = SqlDbType.Int;
                ParIdartigo.Value = Artigo.Idartigo;
                SqlCmd.Parameters.Add(ParIdartigo);

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
            DataTable DtResultado = new DataTable("Artigo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_artigo"; //"splistar_funcionario";
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

        //Método BuscarNome
        public DataTable BuscarNome(DArtigo Artigo)
        {
            DataTable DtResultado = new DataTable("Artigo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_artigo_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 50;
                ParTextoBuscado.Value = Artigo.TextoBuscado;
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
