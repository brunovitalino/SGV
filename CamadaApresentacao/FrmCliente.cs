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
    public partial class FrmCliente : Form
    {
        private bool IsNovo = false;
        private bool IsEditar = false;

        public FrmCliente()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Informe o Nome do Cliente");
            this.ttMensagem.SetToolTip(this.cbSexo, "Informe o Sexo do Cliente");
            this.ttMensagem.SetToolTip(this.dtData_Nasc, "Informe a Data de Nascimento do Cliente");
            this.ttMensagem.SetToolTip(this.txtNum_Documento, "Informe o Númedo de Documento do Cliente");
            this.ttMensagem.SetToolTip(this.txtEndereco, "Informe o Endereço do Cliente");
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
            this.txtIdcliente.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.cbSexo.Text = string.Empty;
            //this.dtData_Nasc.Text =
            this.cbTipo_Documento.Text = "CPF";
            this.txtNum_Documento.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        //Habilitar os campos do formulário
        private void HabilitarCampos(bool valor)
        {
            //this.txtIdartigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.dtData_Nasc.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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
            this.dataListagem.DataSource = NCliente.Listar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Nome
        private void BuscarNome()
        {
            this.dataListagem.DataSource = NCliente.BuscarNome(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Número de Documento
        private void BuscarNum_Documento()
        {
            this.dataListagem.DataSource = NCliente.BuscarNum_Documento(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;
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
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
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
                            Resposta = NCliente.Remover(Convert.ToInt32(Id));

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
            this.txtIdcliente.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["idcliente"].Value);
            this.txtNome.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["nome"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["sexo"].Value);
            this.dtData_Nasc.Value = Convert.ToDateTime(this.dataListagem.CurrentRow.Cells["data_nasc"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["num_documento"].Value);
            this.txtEndereco.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["endereco"].Value);
            this.txtTelefone.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["telefone"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["email"].Value);

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resposta = "";
                if (this.txtNome.Text == string.Empty || this.cbSexo.Text == string.Empty ||
                    this.txtNum_Documento.Text == string.Empty || this.txtEndereco.Text == string.Empty)
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
                    if (this.txtNum_Documento.Text == string.Empty)
                    {
                        errorIcone.SetError(txtNum_Documento, "Informe o Número de Documento");
                    }
                    else
                    {
                        errorIcone.SetError(txtNum_Documento, null);
                    }
                    if (this.txtEndereco.Text == string.Empty)
                    {
                        errorIcone.SetError(txtEndereco, "Informe o Endereço");
                    }
                    else
                    {
                        errorIcone.SetError(txtEndereco, null);
                    }
                }
                else
                {
                    if (this.IsNovo)
                    {
                        resposta = NCliente.Inserir(this.txtNome.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtData_Nasc.Value, this.cbTipo_Documento.Text,
                            this.txtNum_Documento.Text.Trim().ToUpper(), this.txtEndereco.Text.Trim().ToUpper(),
                            this.txtTelefone.Text.Trim().ToUpper(), this.txtEmail.Text.Trim().ToUpper());
                    }
                    else
                    {
                        resposta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text),
                            this.txtNome.Text.Trim().ToUpper(), this.cbSexo.Text, this.dtData_Nasc.Value,
                            this.cbTipo_Documento.Text, this.txtNum_Documento.Text.Trim().ToUpper(),
                            this.txtEndereco.Text.Trim().ToUpper(), this.txtTelefone.Text.Trim().ToUpper(),
                            this.txtEmail.Text.Trim().ToUpper());
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
                        errorIcone.SetError(txtNum_Documento, null);
                        errorIcone.SetError(txtEndereco, null);
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
            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.HabilitarBotoes();
                this.HabilitarCampos(true);
            }
            else
            {
                this.MensagemError("Selecione primeiro o registo à ser modificado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNovo = false;
            this.IsEditar = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(false);
        }
    }
}
