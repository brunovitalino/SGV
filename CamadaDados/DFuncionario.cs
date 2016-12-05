using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DFuncionario
    {
        //Variáveis
        private int _Idfuncionario;
        private string _Nome;
        private string _Sexo;
        private DateTime _Data_Nasc;
        private string _Cpf;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _Tipo_Usuario;
        private string _Usuario;
        private string _Senha;
        private string _TextoBuscado;

        //Propriedades
        public int Idfuncionario
        {
            get { return _Idfuncionario; }
            set { _Idfuncionario = value; }
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

        public string Cpf
        {
            get { return _Cpf; }
            set { _Cpf = value; }
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

        public string Tipo_Usuario
        {
            get { return _Tipo_Usuario; }
            set { _Tipo_Usuario = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        public string TextoBuscado
        {
            get { return _TextoBuscado; }
            set { _TextoBuscado = value; }
        }

        //Construtores
        public DFuncionario ()
        {

        }

        public DFuncionario (int idfuncionario, string nome, string sexo, DateTime data_nasc, string cpf,
            string endereco, string telefone, string email, string tipo_usuario, string usuario, string senha,
            string texto_buscado)
        {
            this.Idfuncionario = idfuncionario;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Data_Nasc = data_nasc;
            this.Cpf = cpf;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Tipo_Usuario = tipo_usuario;
            this.Usuario = usuario;
            this.Senha = senha;
            this.TextoBuscado = texto_buscado;
        }

        //MÉTODOS

        //Método Inserir
        public string Inserir(DFuncionario Funcionario)
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
                SqlCmd.CommandText = "spinserir_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfuncionario = new SqlParameter();
                ParIdfuncionario.ParameterName = "@idfuncionario";
                ParIdfuncionario.SqlDbType = SqlDbType.Int;
                ParIdfuncionario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdfuncionario);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 20;
                ParNome.Value = Funcionario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Funcionario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParData_Nasc = new SqlParameter();
                ParData_Nasc.ParameterName = "@data_nasc";
                ParData_Nasc.SqlDbType = SqlDbType.VarChar;
                ParData_Nasc.Size = 10;
                ParData_Nasc.Value = Funcionario.Data_Nasc;
                SqlCmd.Parameters.Add(ParData_Nasc);

                SqlParameter ParCpf = new SqlParameter();
                ParCpf.ParameterName = "@cpf";
                ParCpf.SqlDbType = SqlDbType.VarChar;
                ParCpf.Size = 11;
                ParCpf.Value = Funcionario.Cpf;
                SqlCmd.Parameters.Add(ParCpf);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Funcionario.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 11;
                ParTelefone.Value = Funcionario.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Funcionario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTipo_Usuario = new SqlParameter();
                ParTipo_Usuario.ParameterName = "@tipo_usuario";
                ParTipo_Usuario.SqlDbType = SqlDbType.VarChar;
                ParTipo_Usuario.Size = 20;
                ParTipo_Usuario.Value = Funcionario.Tipo_Usuario;
                SqlCmd.Parameters.Add(ParTipo_Usuario);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Funcionario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Funcionario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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
        public string Editar(DFuncionario Funcionario)
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
                SqlCmd.CommandText = "speditar_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfuncionario = new SqlParameter();
                ParIdfuncionario.ParameterName = "@idfuncionario";
                ParIdfuncionario.SqlDbType = SqlDbType.Int;
                ParIdfuncionario.Value = Funcionario.Idfuncionario;
                SqlCmd.Parameters.Add(ParIdfuncionario);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 20;
                ParNome.Value = Funcionario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Funcionario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParData_Nasc = new SqlParameter();
                ParData_Nasc.ParameterName = "@data_nasc";
                ParData_Nasc.SqlDbType = SqlDbType.VarChar;
                ParData_Nasc.Size = 10;
                ParData_Nasc.Value = Funcionario.Data_Nasc;
                SqlCmd.Parameters.Add(ParData_Nasc);

                SqlParameter ParCpf = new SqlParameter();
                ParCpf.ParameterName = "@cpf";
                ParCpf.SqlDbType = SqlDbType.VarChar;
                ParCpf.Size = 11;
                ParCpf.Value = Funcionario.Cpf;
                SqlCmd.Parameters.Add(ParCpf);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Funcionario.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 11;
                ParTelefone.Value = Funcionario.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Funcionario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTipo_Usuario = new SqlParameter();
                ParTipo_Usuario.ParameterName = "@tipo_usuario";
                ParTipo_Usuario.SqlDbType = SqlDbType.VarChar;
                ParTipo_Usuario.Size = 20;
                ParTipo_Usuario.Value = Funcionario.Tipo_Usuario;
                SqlCmd.Parameters.Add(ParTipo_Usuario);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Funcionario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Funcionario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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
        public string Remover(DFuncionario Funcionario)
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
                SqlCmd.CommandText = "spremover_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idfuncionario";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Funcionario.Idfuncionario;
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
            DataTable DtResultado = new DataTable("Funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splistar_funcionario";
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
        public DataTable BuscarNome(DFuncionario Funcionario)
        {
            DataTable DtResultado = new DataTable("Funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_funcionario_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 20;
                ParTextoBuscado.Value = Funcionario.TextoBuscado;
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

        //Método BuscarCpf
        public DataTable BuscarCpf(DFuncionario Funcionario)
        {
            DataTable DtResultado = new DataTable("Funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cs;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_funcionario_cpf";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscado = new SqlParameter();
                ParTextoBuscado.ParameterName = "@textobuscado";
                ParTextoBuscado.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscado.Size = 11;
                ParTextoBuscado.Value = Funcionario.TextoBuscado;
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
