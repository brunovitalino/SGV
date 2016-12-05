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
    public partial class FrmVerArtigo_Entrada : Form
    {
        public FrmVerArtigo_Entrada()
        {
            InitializeComponent();
        }

        private void FrmVerArtigo_Entrada_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void dataListagem_DoubleClick(object sender, EventArgs e)
        {
            FrmEntrada form = FrmEntrada.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListagem.CurrentRow.Cells["idartigo"].Value);
            par2 = Convert.ToString(this.dataListagem.CurrentRow.Cells["nome"].Value);
            form.setArtigo(par1, par2);
            this.Hide();
        }
    }
}
