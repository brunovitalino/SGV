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
    public partial class FrmFornecedor : Form
    {
        private bool IsNovo = false;
        private bool IsEditar = false;

        public FrmFornecedor()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtRazao_Social, "Informe a Razão Social do Fornecedor");
            this.ttMensagem.SetToolTip(this.cbSetor_Comercial, "Informe o Setor Comercial do Fornecedor");
            this.ttMensagem.SetToolTip(this.txtNum_Documento, "Informe o Númedo de Documento do Fornecedor");
            this.ttMensagem.SetToolTip(this.txtEndereco, "Informe o Endereço do Fornecedor");
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
            this.txtIdfornecedor.Text = string.Empty;
            this.txtRazao_Social.Text = string.Empty;
            this.cbSetor_Comercial.Text = string.Empty;
            this.cbTipo_Documento.Text = "CNPJ";
            this.txtNum_Documento.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
        }

        //Habilitar os campos do formulário
        private void HabilitarCampos(bool valor)
        {
            //this.txtIdartigo.ReadOnly = !valor;
            this.txtRazao_Social.ReadOnly = !valor;
            this.cbSetor_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
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
            this.dataListagem.DataSource = NFornecedor.Listar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Razão Social
        private void BuscarRazao_Social()
        {
            this.dataListagem.DataSource = NFornecedor.BuscarRazao_Social(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por Número de Documento
        private void BuscarNum_Documento()
        {
            this.dataListagem.DataSource = NFornecedor.BuscarNum_Documento(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;
            this.Listar();
            this.HabilitarCampos(false);
            this.HabilitarBotoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
            else if (cbBuscar.Text.Equals("Razão Social"))
            {
                this.BuscarRazao_Social();
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
                            Resposta = NFornecedor.Remover(Convert.ToInt32(Id));

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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.IsNovo = true;
            this.IsEditar = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(true);
            this.txtRazao_Social.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resposta = "";
                if (this.txtRazao_Social.Text == string.Empty || this.cbSetor_Comercial.Text == string.Empty ||
                    this.txtNum_Documento.Text == string.Empty || this.txtEndereco.Text == string.Empty)
                {
                    MensagemError("Preencha os campos obrigatórios");
                    if (this.txtRazao_Social.Text == string.Empty)
                    {
                        errorIcone.SetError(txtRazao_Social, "Informe a Razão Social");
                    }
                    else
                    {
                        errorIcone.SetError(txtRazao_Social, null);
                    }
                    if (this.cbSetor_Comercial.Text == string.Empty)
                    {
                        errorIcone.SetError(cbSetor_Comercial, "Informe o Setor Comercial");
                    }
                    else
                    {
                        errorIcone.SetError(cbSetor_Comercial, null);
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
                        resposta = NFornecedor.Inserir(this.txtRazao_Social.Text.Trim().ToUpper(),
                            this.cbSetor_Comercial.Text, this.cbTipo_Documento.Text,
                            this.txtNum_Documento.Text.Trim().ToUpper(), this.txtEndereco.Text.Trim().ToUpper(),
                            this.txtTelefone.Text.Trim().ToUpper(), this.txtEmail.Text.Trim().ToUpper(),
                            this.txtUrl.Text.Trim().ToUpper());
                    }
                    else
                    {
                        resposta = NFornecedor.Editar(Convert.ToInt32(this.txtIdfornecedor.Text),
                            this.txtRazao_Social.Text.Trim().ToUpper(), this.cbSetor_Comercial.Text,
                            this.cbTipo_Documento.Text, this.txtNum_Documento.Text.Trim().ToUpper(),
                            this.txtEndereco.Text.Trim().ToUpper(), this.txtTelefone.Text.Trim().ToUpper(),
                            this.txtEmail.Text.Trim().ToUpper(), this.txtUrl.Text.Trim().ToUpper());
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
                        errorIcone.SetError(txtRazao_Social, null);
                        errorIcone.SetError(cbSetor_Comercial, null);
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
            if (!this.txtIdfornecedor.Text.Equals(""))
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
            this.txtIdfornecedor.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["idfornecedor"].Value);
            this.txtRazao_Social.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["razao_social"].Value);
            this.cbSetor_Comercial.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["setor_comercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["num_documento"].Value);
            this.txtEndereco.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["endereco"].Value);
            this.txtTelefone.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["telefone"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["url"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
