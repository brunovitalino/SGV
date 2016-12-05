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
    public partial class FrmEntrada : Form
    {
        private static FrmEntrada _instancia;
        private bool IsNovo;
        private DataTable dtItem;
        private decimal totalPago = 0;

        public static FrmEntrada GetInstancia()
        {
            if(_instancia==null)
            {
                _instancia = new FrmEntrada();
            }
            return _instancia;
        }

        public void setFornecedor(string idfornecedor, string nome)
        {
            this.txtIdfornecedor.Text = idfornecedor;
            this.txtFornecedor.Text = nome;
        }

        public void setArtigo(string idartigo, string nome)
        {
            this.txtIdartigo.Text = idartigo;
            this.txtArtigo.Text = nome;
        }

        public FrmEntrada()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtFornecedor, "Informe o Fornecedor");
            this.ttMensagem.SetToolTip(this.txtNumero, "Informe o Número do pagamento");
            this.ttMensagem.SetToolTip(this.txtArtigo, "Informe o Artigo");
            this.ttMensagem.SetToolTip(this.txtQuantidade, "Informe a Quantidade do pagamento");
            this.ttMensagem.SetToolTip(this.txtPreco_Compra, "Informe o Preço de Compra");
            this.ttMensagem.SetToolTip(this.txtPreco_Venda, "Informe o Preço de Venda");
            this.txtIdartigo.Visible = false;
            this.txtIdfornecedor.Visible = false;
            this.txtFornecedor.ReadOnly = true;
            this.txtArtigo.ReadOnly = true;
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
            this.txtIdentrada.Text = string.Empty;
            this.txtIdfornecedor.Text = string.Empty;
            this.txtFornecedor.Text = string.Empty;
            this.cbTipo_Pgto.Text = string.Empty;
            this.txtNumero.Text = string.Empty;
            this.txtIcms.Text = string.Empty;
            this.dtData.Text = DateTime.Now.ToString();
            this.dtHora.Text = DateTime.Now.ToString();
            this.lblTotal_Pago.Text = "0,0";
            this.txtIcms.Text = "12";
            this.criarTabela();
        }

        private void LimparItem()
        {
            this.txtIdartigo.Text = string.Empty;
            this.txtArtigo.Text = string.Empty;
            this.txtQuantidade.Text = string.Empty;
            this.txtPreco_Compra.Text = string.Empty;
            this.txtPreco_Venda.Text = string.Empty;
            this.dtData_Producao.Text = DateTime.Now.ToString();

        }

        //Habilitar os campos do formulário
        private void HabilitarCampos(bool valor)
        {
            //this.txtIdartigo.ReadOnly = !valor;
            this.txtIdartigo.ReadOnly = !valor;
            this.txtNumero.ReadOnly = !valor;
            this.txtIcms.ReadOnly = !valor;
            this.dtData.Enabled = valor;
            this.cbTipo_Pgto.Enabled = valor;
            this.txtQuantidade.ReadOnly = !valor;
            this.txtPreco_Compra.ReadOnly = !valor;
            this.txtPreco_Venda.ReadOnly = !valor;
            this.dtData_Producao.Enabled = valor;

            this.btnBuscarArtigo.Enabled = valor;
            this.btnBuscarFornecedor.Enabled = valor;
            this.btnRemover.Enabled = valor;
            this.btnAdicionar.Enabled = valor;
        }

        //Habilitar os botões do formulário
        private void HabilitarBotoes()
        {
            if (IsNovo)
            {
                this.HabilitarCampos(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.HabilitarCampos(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
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
            this.dataListagem.DataSource = NEntrada.Listar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método BuscarDatas
        private void BuscarDatas()
        {
            this.dataListagem.DataSource = NEntrada.BuscarDatas(this.dtData1.Value.ToString("dd/MM/yyyy"),
                this.dtData2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListagem.Rows.Count);
        }

        //Método ListarItem
        private void ListarItem()
        {
            this.dataListagemItem.DataSource = NEntrada.ListarEntrada_Item(this.txtIdentrada.Text);
            this.dataListagemItem2.DataSource = NEntrada.ListarEntrada_Item(this.txtIdentrada.Text);
        }

        private void criarTabela()
        {
            this.dtItem = new DataTable("Item");
            this.dtItem.Columns.Add("idartigo", System.Type.GetType("System.Int32"));
            this.dtItem.Columns.Add("artigo", System.Type.GetType("System.String"));
            this.dtItem.Columns.Add("preco_compra", System.Type.GetType("System.Decimal"));
            this.dtItem.Columns.Add("preco_venda", System.Type.GetType("System.Decimal"));
            this.dtItem.Columns.Add("quantidade", System.Type.GetType("System.Int32"));
            this.dtItem.Columns.Add("data_vencimento", System.Type.GetType("System.DateTime"));
            this.dtItem.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nosso DataGridView com nosso DataTable
            this.dataListagemItem.DataSource = this.dtItem;
            this.dataListagemItem2.DataSource = this.dtItem;
        }

        private void FrmEntrada_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.HabilitarCampos(false);
            this.HabilitarBotoes();
            this.criarTabela();
        }

        private void FrmEntrada_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarFornecedor_Click(object sender, EventArgs e)
        {
            FrmVerFornecedor_Entrada ver = new FrmVerFornecedor_Entrada();
            ver.ShowDialog();
        }

        private void btnBuscarArtigo_Click(object sender, EventArgs e)
        {
            FrmVerArtigo_Entrada ver = new FrmVerArtigo_Entrada();
            ver.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarDatas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Tem certeza que deseja Anular o(s) registro(s) selecionado(s)", "Sistema de Vendas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcao == DialogResult.OK)
                {
                    string Id;
                    string Resposta = "";

                    foreach (DataGridViewRow row in dataListagem.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Id = Convert.ToString(row.Cells[1].Value);
                            Resposta = NEntrada.Anular(Convert.ToInt32(Id));

                            if (Resposta.Equals("OK"))
                            {
                                this.MensagemOk("Registro(s) Anulado(s)");
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

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.IsNovo = true;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(true);
            this.txtNumero.Focus();
            this.LimparItem();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNovo = false;
            this.HabilitarBotoes();
            this.LimparCampos();
            this.HabilitarCampos(false);
            this.LimparItem();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resposta = "";
                if (this.txtFornecedor.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                    this.txtIcms.Text == string.Empty)
                {
                    MensagemError("Preencha os campos obrigatórios");
                    if (this.txtFornecedor.Text == string.Empty)
                    {
                        errorIcone.SetError(txtFornecedor, "Insira o Fornecedor");
                    }
                    else
                    {
                        errorIcone.SetError(txtFornecedor, null);
                    }
                    if (this.txtNumero.Text == string.Empty)
                    {
                        errorIcone.SetError(txtNumero, "Insira o Numero");
                    }
                    else
                    {
                        errorIcone.SetError(txtNumero, null);
                    }
                    if (this.txtIcms.Text == string.Empty)
                    {
                        errorIcone.SetError(txtIcms, "Insira o ICMS");
                    }
                    else
                    {
                        errorIcone.SetError(txtIcms, null);
                    }
                }
                else
                {
                    if (this.IsNovo)
                    {
                        resposta = NEntrada.Inserir(6, Convert.ToInt32(this.txtIdfornecedor.Text.Trim()),
                            this.dtData.Value, this.cbTipo_Pgto.Text.Trim().ToUpper(), this.txtNumero.Text.Trim(),
                            Convert.ToDecimal(this.txtIcms.Text.Trim().ToUpper()), "EMITIDO", dtItem);
                    }

                    if (resposta.Equals("OK"))
                    {
                        if (this.IsNovo)
                        {
                            this.MensagemOk("Novo registro cadastrado");
                        }
                        errorIcone.SetError(txtFornecedor, null);
                        errorIcone.SetError(txtNumero, null);
                        errorIcone.SetError(txtArtigo, null);
                        errorIcone.SetError(txtQuantidade, null);
                        errorIcone.SetError(txtPreco_Compra, null);
                        errorIcone.SetError(txtPreco_Venda, null);
                    }
                    else
                    {
                        this.MensagemError(resposta);
                    }

                    this.IsNovo = false;
                    this.HabilitarBotoes();
                    this.LimparCampos();
                    this.LimparItem();
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtArtigo.Text == string.Empty || this.txtQuantidade.Text == string.Empty ||
                    this.txtPreco_Compra.Text == string.Empty || this.txtPreco_Venda.Text == string.Empty)
                {
                    MensagemError("Preencha os campos obrigatórios");
                    if (this.txtArtigo.Text == string.Empty)
                    {
                        errorIcone.SetError(txtArtigo, "Insira o Artigo");
                    }
                    else
                    {
                        errorIcone.SetError(txtArtigo, null);
                    }
                    if (this.txtQuantidade.Text == string.Empty)
                    {
                        errorIcone.SetError(txtQuantidade, "Insira a Quantidade");
                    }
                    else
                    {
                        errorIcone.SetError(txtQuantidade, null);
                    }
                    if (this.txtPreco_Compra.Text == string.Empty)
                    {
                        errorIcone.SetError(txtPreco_Compra, "Insira o Preço de Compra");
                    }
                    else
                    {
                        errorIcone.SetError(txtPreco_Compra, null);
                    }
                    if (this.txtPreco_Venda.Text == string.Empty)
                    {
                        errorIcone.SetError(txtPreco_Venda, "Insira o Preço de Venda");
                    }
                    else
                    {
                        errorIcone.SetError(txtPreco_Venda, null);
                    }
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtItem.Rows)
                    {
                        if (Convert.ToInt32(row["idartigo"])==Convert.ToInt32(this.txtIdartigo.Text))
                        {
                            registrar = false;
                            this.MensagemError("O Artigo já se encontra na lista de itens");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtQuantidade.Text) * Convert.ToDecimal(this.txtPreco_Compra.Text);
                        totalPago = totalPago + subTotal;
                        this.lblTotal_Pago.Text = totalPago.ToString("#0.00#");
                        //Adicionar esse item à dataListagemItem
                        DataRow row = this.dtItem.NewRow();
                        row["idartigo"] = Convert.ToInt32(this.txtIdartigo.Text);
                        row["artigo"] = this.txtArtigo.Text;
                        row["preco_compra"] = Convert.ToDecimal(this.txtPreco_Compra.Text);
                        row["preco_venda"] = Convert.ToDecimal(this.txtPreco_Venda.Text);
                        row["quantidade"] = Convert.ToInt32(this.txtQuantidade.Text);
                        row["data_producao"] = dtData_Producao.Value;
                        row["subtotal"] = subTotal;
                        this.dtItem.Rows.Add(row);
                        this.LimparItem();
                    }
                    


                    errorIcone.SetError(txtFornecedor, null);
                    errorIcone.SetError(txtNumero, null);
                    errorIcone.SetError(txtArtigo, null);
                    errorIcone.SetError(txtQuantidade, null);
                    errorIcone.SetError(txtPreco_Compra, null);
                    errorIcone.SetError(txtPreco_Venda, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListagemItem.CurrentCell.RowIndex;
                DataRow row = this.dtItem.Rows[indiceFila];
                //Diminuir o TotalPago
                this.totalPago = this.totalPago - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pago.Text = totalPago.ToString("#0.00#");
                //Removemos a fila
                this.dtItem.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensagemError("Não existe fila para remover");
            }
        }

        private void dataListagem_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdentrada.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["identrada"].Value);
            this.txtFornecedor.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["fornecedor"].Value);
            this.dtData.Value = Convert.ToDateTime(this.dataListagem.CurrentRow.Cells["data"].Value);
            this.cbTipo_Pgto.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["tipo_pgto"].Value);
            this.txtNumero.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["numero"].Value);
            this.lblTotal_Pago.Text = Convert.ToString(this.dataListagem.CurrentRow.Cells["total"].Value);
            this.ListarItem();
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
