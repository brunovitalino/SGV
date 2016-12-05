using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CamadaNegocio;

namespace CamadaApresentacao
{
    public partial class FrmFuncionario : Form
    {
        private bool IsNovo = false;
        private bool IsEditar = false;

        public FrmFuncionario()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Informe o Nome do Funcionário");
            this.ttMensagem.SetToolTip(this.cbSexo, "Informe o Sexo do Funcionário");
            this.ttMensagem.SetToolTip(this.dtData_Nasc, "Informe a Data de Nascimento do Funcionário");
            this.ttMensagem.SetToolTip(this.txtCpf, "Informe o Númedo de Documento do Funcionário");
            this.ttMensagem.SetToolTip(this.txtEndereco, "Informe o Endereço do Funcionário");
            this.ttMensagem.SetToolTip(this.cbTipo_Usuario, "Informe o Endereço do Funcionário");
            this.ttMensagem.SetToolTip(this.txtUsuario, "Informe o Endereço do Funcionário");
            this.ttMensagem.SetToolTip(this.txtSenha, "Informe o Endereço do Funcionário");
        }

        //Mostrar mensagem de confirmação
        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema de Vendas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensagem de error
        private void MensagemError(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema de Vendas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpar todos os camposdo formulário
        private void LimparCampos()
        {
            this.txtIdfuncionario.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.cbSexo.Text = string.Empty;
            this.dtData_Nasc.Text = DateTime.Now.ToString();
            this.txtCpf.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cbTipo_Usuario.Text = "Administrador";
            this.txtUsuario.Text = string.Empty;
            this.txtSenha.Text = string.Empty;
        }

        //Habilitar os campos do formulário
        private void HabilitarCampos(bool valor)
        {
            //this.txtIdartigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.dtData_Nasc.Enabled = valor;
            this.txtCpf.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbTipo_Usuario.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtSenha.ReadOnly = !valor;
        }

        //Habilitar os botões do formulário
        private void HabilitarBotoes()
        {
            if (IsNovo || IsEditar)
            {
                this.HabilitarCampos(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.HabilitarCampos(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Método para Ocultar colunas
        private void OcultarColunas()
        {
            this.dataListagem.Columns[0].Visible = false;
            this.dataListagem.Columns[1].Visible = false;
        }

        //Método Listar itens da tabela
        private void Listar()
        {
            this.dataListagem.DataSource = NFuncionario.Listar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Nome
        private void BuscarNome()
        {
            this.dataListagem.DataSource = NFuncionario.BuscarNome(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Cpf
        private void BuscarCpf()
        {
            this.dataListagem.DataSource = NFuncionario.BuscarCpf(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            //
            this.Listar();
            this.HabilitarCampos(false);
            this.HabilitarBotoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nome"))
            {
                this.BuscarNome();
            }
            else if (cbBuscar.Text.Equals("CPF"))
            {
                this.BuscarCpf();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Tem certeza que deseja remover o(s) registro(s) selecionado(s)", "Sistema de Vendas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcao == DialogResult.OK)
                {
                    string Id;
                    string Resposta = "";

                    foreach (DataGridViewRow row in dataListagem.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Id = Convert.ToString(row.Cells[1].Value);
                            Resposta = NFuncionario.Remover(Convert.ToInt32(Id));

                            if (Resposta.Equals("OK"))
                            {
                                this.MensagemOk("Registro(s) removido(s)");
                            }
                            else
                            {
                                this.MensagemError(Resposta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkRemover_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemover.Checked)
            {
                this.dataListagem.Columns[0].Visible = true;
            }
            else
            {
                this.dataListagem.Columns[0].Visible = false;
            }
        }

        private void dataListagem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListagem.Columns["Remover"].Index)
            {
                DataGridViewCheckBoxCell ChkRemover = (DataGridViewCheckBoxCell)dataListagem.Rows[e.RowIndex].Cells["Remover"];
                ChkRemover.Value = !Convert.ToBoolean(ChkRemover.Value);
            }
        }

        private void dataListagem_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdfuncionario.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["idfuncionario"].Value);
            this.txtNome.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["nome"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["sexo"].Value);
            this.dtData_Nasc.Value = Convert.ToDateTime(this.dataListagem.CurrentRow.Cells["data_nasc"].Value);
            this.txtCpf.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["cpf"].Value);
            this.txtEndereco.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["endereco"].Value);
            this.txtTelefone.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["telefone"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["email"].Value);
            this.cbTipo_Usuario.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["tipo_usuario"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["usuario"].Value);
            this.txtSenha.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["senha"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.IsNovo = true;
            this.IsEditar = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(true);
            this.txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNovo = false;
            this.IsEditar = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resposta = "";
                if (this.txtNome.Text==string.Empty || this.cbSexo.Text==string.Empty ||
                    this.txtCpf.Text==string.Empty || this.txtEndereco.Text==string.Empty ||
                    this.cbTipo_Usuario.Text==string.Empty || this.txtUsuario.Text==string.Empty ||
                    this.txtSenha.Text==string.Empty)
                {
                    MensagemError("Preencha os campos obrigatórios");
                    if (this.txtNome.Text == string.Empty)
                    {
                        errorIcone.SetError(txtNome, "Informe a Razão Social");
                    }
                    else
                    {
                        errorIcone.SetError(txtNome, null);
                    }

                    if (this.cbSexo.Text == string.Empty)
                    {
                        errorIcone.SetError(cbSexo, "Informe o Sexo");
                    }
                    else
                    {
                        errorIcone.SetError(cbSexo, null);
                    }

                    if (this.txtCpf.Text == string.Empty)
                    {
                        errorIcone.SetError(txtCpf, "Informe o CPF");
                    }
                    else
                    {
                        errorIcone.SetError(txtCpf, null);
                    }

                    if (this.txtEndereco.Text == string.Empty)
                    {
                        errorIcone.SetError(txtEndereco, "Informe o Endereço");
                    }
                    else
                    {
                        errorIcone.SetError(txtEndereco, null);
                    }

                    if (this.txtUsuario.Text == string.Empty)
                    {
                        errorIcone.SetError(txtUsuario, "Informe o Usuário");
                    }
                    else
                    {
                        errorIcone.SetError(txtUsuario, null);
                    }

                    if (this.txtSenha.Text == string.Empty)
                    {
                        errorIcone.SetError(txtSenha, "Informe a Senha");
                    }
                    else
                    {
                        errorIcone.SetError(txtSenha, null);
                    }
                }
                else
                {
                    if (this.IsNovo)
                    {
                        resposta = NFuncionario.Inserir(this.txtNome.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtData_Nasc.Value, this.txtCpf.Text,
                            this.txtEndereco.Text.Trim().ToUpper(), this.txtTelefone.Text.Trim().ToUpper(),
                            this.txtEmail.Text.Trim().ToLower(), this.cbTipo_Usuario.Text,
                            this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim());
                    }
                    else
                    {
                        resposta = NFuncionario.Editar(Convert.ToInt32(this.txtIdfuncionario.Text),
                            this.txtNome.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtData_Nasc.Value, this.txtCpf.Text,
                            this.txtEndereco.Text.Trim().ToUpper(), this.txtTelefone.Text.Trim().ToUpper(),
                            this.txtEmail.Text.Trim().ToLower(), this.cbTipo_Usuario.Text,
                            this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim());
                    }

                    if (resposta.Equals("OK"))
                    {
                        if (this.IsNovo)
                        {
                            this.MensagemOk("Novo registro cadastrado");
                        }
                        else
                        {
                            this.MensagemOk("Registro atualizado");
                        }
                        errorIcone.SetError(txtNome, null);
                        errorIcone.SetError(cbSexo, null);
                        errorIcone.SetError(txtCpf, null);
                        errorIcone.SetError(txtEndereco, null);
                        errorIcone.SetError(txtUsuario, null);
                        errorIcone.SetError(txtSenha, null);
                    }
                    else
                    {
                        this.MensagemError(resposta);
                    }

                    this.IsNovo = false;
                    this.IsEditar = false;
                    this.LimparCampos();
                    this.HabilitarBotoes();
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdfuncionario.Text.Equals(""))
            {
                this.IsNovo = false;
                this.IsEditar = true;
                this.HabilitarBotoes();
                this.HabilitarCampos(true);
            }
            else
            {
                this.MensagemError("Selecione primeiro o registo à ser modificado");
            }
        }
    }
}
