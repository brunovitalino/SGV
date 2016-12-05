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
    public partial class FrmVerFornecedor_Entrada : Form
    {
        public FrmVerFornecedor_Entrada()
        {
            InitializeComponent();
        }

        private void FrmVerFornecedor_Entrada_Load(object sender, EventArgs e)
        {
            this.Listar();
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

        private void dataListagem_DoubleClick(object sender, EventArgs e)
        {
            FrmEntrada form = FrmEntrada.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListagem.CurrentRow.Cells["idfornecedor"].Value);
            par2 = Convert.ToString(this.dataListagem.CurrentRow.Cells["razao_social"].Value);
            form.setFornecedor(par1, par2);
            this.Hide();
        }
    }
}
