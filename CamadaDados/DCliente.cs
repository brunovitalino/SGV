using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DCliente
    {
        //Variáveis
        private int _Idcliente;
        private string _Nome;
        private string _Sexo;
        private DateTime _Data_Nasc;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _TextoBuscado;

        //Propriedades
        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public DateTime Data_Nasc
        {
            get { return _Data_Nasc; }
            set { _Data_Nasc = value; }
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

        public string TextoBuscado
        {
            get { return _TextoBuscado; }
            set { _TextoBuscado = value; }
        }

        //Construtores

        public DCliente ()
        {

        }

        public DCliente (int idcliente, string nome, string sexo, DateTime data_nasc, string tipo_documento,
            string num_documento, string endereco, string telefone, string email, string textoBuscado)
        {
            this.Idcliente = idcliente;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Data_Nasc = data_nasc;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.TextoBuscado = textoBuscado;
        }

        //MÉTODOS

        //Método Inserir
        public string Inserir(DCliente Cliente)
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
                SqlCmd.CommandText = "spinserir_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Cliente.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParData_Nasc = new SqlParameter();
                ParData_Nasc.ParameterName = "@data_nasc";
                ParData_Nasc.SqlDbType = SqlDbType.VarChar;
                ParData_Nasc.Size = 10;
                ParData_Nasc.Value = Cliente.Data_Nasc;
                SqlCmd.Parameters.Add(ParData_Nasc);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Cliente.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Cliente.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Cliente.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 11;
                ParTelefone.Value = Cliente.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Editar(DCliente Cliente)
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
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Cliente.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParData_Nasc = new SqlParameter();
                ParData_Nasc.ParameterName = "@data_nasc";
                ParData_Nasc.SqlDbType = SqlDbType.VarChar;
                ParData_Nasc.Size = 10;
                ParData_Nasc.Value = Cliente.Data_Nasc;
                SqlCmd.Parameters.Add(ParData_Nasc);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Cliente.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 14;
                ParNum_Documento.Value = Cliente.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Cliente.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 10;
                ParTelefone.Value = Cliente.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Remover(DCliente Cliente)
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
                SqlCmd.CommandText = "spremover_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

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
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_cliente";
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
        public DataTable BuscarNome(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 50;
                ParTextoBuscado.Value = Cliente.TextoBuscado;
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
        public DataTable BuscarNum_Documento(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_num_doc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 11;
                ParTextoBuscado.Value = Cliente.TextoBuscado;
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
