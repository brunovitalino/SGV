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
    public partial class FrmArtigo : Form
    {
        private bool IsNovo = false;
        private bool IsEditar = false;

        public FrmArtigo()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtCodigo, "Informe o código do Artigo");
            this.ttMensagem.SetToolTip(this.txtNome, "Informe o nome do Artigo");
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
            this.txtIdartigo.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Habilitar os campos do formulário
        private void HabilitarCampos(bool valor)
        {
            //this.txtIdartigo.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
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
            this.dataListagem.DataSource = NArtigo.Listar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método Buscar por nome
        private void BuscarNome()
        {
            this.dataListagem.DataSource = NArtigo.BuscarNome(this.txtTextoBuscado.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        private void FrmArtigo_Load(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;

            this.Listar();
            this.HabilitarCampos(false);
            this.HabilitarBotoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.IsNovo = true;
            this.IsEditar = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(true);
            this.txtCodigo.Focus();
        }

        private void txtTextoBuscado_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resposta = "";
                if (this.txtCodigo.Text == string.Empty || this.txtNome.Text == string.Empty)
                {
                    MensagemError("Preencha os campos obrigatórios");
                    if (this.txtCodigo.Text == string.Empty)
                    {
                        errorIcone.SetError(txtCodigo, "Insira o código");
                    }
                    else
                    {
                        errorIcone.SetError(txtCodigo, null);
                    }
                    if (this.txtNome.Text==string.Empty)
                    {
                        errorIcone.SetError(txtNome, "Insira o nome");
                    }
                    else
                    {
                        errorIcone.SetError(txtNome, null);
                    }
                }
                else
                {
                    if (this.IsNovo)
                    {
                        resposta = NArtigo.Inserir(this.txtCodigo.Text.Trim().ToUpper(),
                            this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim().ToUpper());                        
                    }
                    else
                    {
                        resposta = NArtigo.Editar(Convert.ToInt32(this.txtIdartigo.Text), 
                            this.txtCodigo.Text.Trim().ToUpper(), this.txtNome.Text.Trim().ToUpper(),
                            this.txtDescricao.Text.Trim().ToUpper());                        
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
                        errorIcone.SetError(txtCodigo, null);
                        errorIcone.SetError(txtNome, null);
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

        private void dataListagem_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdartigo.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["idartigo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["codigo"].Value);
            this.txtNome.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["descricao"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdartigo.Text.Equals(""))
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
            if (e.ColumnIndex==dataListagem.Columns["Remover"].Index)
            {
                DataGridViewCheckBoxCell ChkRemover = (DataGridViewCheckBoxCell)dataListagem.Rows[e.RowIndex].Cells["Remover"];
                ChkRemover.Value = !Convert.ToBoolean(ChkRemover.Value);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Tem certeza que deseja remover o(s) registro(s) selecionado(s)", "Sistema de Vendas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
                if (Opcao==DialogResult.OK)
                {
                    string Id;
                    string Resposta = "";

                    foreach (DataGridViewRow row in dataListagem.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Id = Convert.ToString(row.Cells[1].Value);
                            Resposta = NArtigo.Remover(Convert.ToInt32(Id));

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
    }
}
