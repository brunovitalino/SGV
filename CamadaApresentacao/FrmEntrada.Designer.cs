namespace CamadaApresentacao
{
    partial class FrmEntrada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataListagem = new System.Windows.Forms.DataGridView();
            this.Remover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtIcms = new System.Windows.Forms.TextBox();
            this.chkAnular = new System.Windows.Forms.CheckBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataListagemItem2 = new System.Windows.Forms.DataGridView();
            this.dtData2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtData1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal_Pago = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataListagemItem = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPreco_Venda = new System.Windows.Forms.TextBox();
            this.dtData_Producao = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPreco_Compra = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBuscarArtigo = new System.Windows.Forms.Button();
            this.txtArtigo = new System.Windows.Forms.TextBox();
            this.txtIdartigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.cbTipo_Pgto = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarFornecedor = new System.Windows.Forms.Button();
            this.txtIdfornecedor = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdentrada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ttMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcone = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListagem)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListagemItem2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListagemItem)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(361, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataListagem
            // 
            this.dataListagem.AllowUserToAddRows = false;
            this.dataListagem.AllowUserToDeleteRows = false;
            this.dataListagem.AllowUserToOrderColumns = true;
            this.dataListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remover});
            this.dataListagem.Location = new System.Drawing.Point(19, 99);
            this.dataListagem.MultiSelect = false;
            this.dataListagem.Name = "dataListagem";
            this.dataListagem.ReadOnly = true;
            this.dataListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListagem.Size = new System.Drawing.Size(941, 180);
            this.dataListagem.TabIndex = 7;
            this.dataListagem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListagem_CellContentClick);
            this.dataListagem.DoubleClick += new System.EventHandler(this.dataListagem_DoubleClick);
            // 
            // Remover
            // 
            this.Remover.HeaderText = "Remover";
            this.Remover.Name = "Remover";
            this.Remover.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(548, 77);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(96, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total de Registros:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo de PGTO:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(811, 430);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(602, 26);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(682, 430);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 23);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(551, 430);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 23);
            this.btnNovo.TabIndex = 6;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtIcms
            // 
            this.txtIcms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIcms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIcms.Location = new System.Drawing.Point(585, 95);
            this.txtIcms.Name = "txtIcms";
            this.txtIcms.ReadOnly = true;
            this.txtIcms.Size = new System.Drawing.Size(150, 20);
            this.txtIcms.TabIndex = 4;
            // 
            // chkAnular
            // 
            this.chkAnular.AutoSize = true;
            this.chkAnular.Location = new System.Drawing.Point(19, 76);
            this.chkAnular.Name = "chkAnular";
            this.chkAnular.Size = new System.Drawing.Size(56, 17);
            this.chkAnular.TabIndex = 5;
            this.chkAnular.Text = "Anular";
            this.chkAnular.UseVisualStyleBackColor = true;
            this.chkAnular.CheckedChanged += new System.EventHandler(this.chkAnular_CheckedChanged);
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(483, 26);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(100, 23);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "&Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(986, 539);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.dataListagemItem2);
            this.tabPage1.Controls.Add(this.dtData2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dtData1);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dataListagem);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkAnular);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(978, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Disponíveis";
            // 
            // dataListagemItem2
            // 
            this.dataListagemItem2.AllowUserToAddRows = false;
            this.dataListagemItem2.AllowUserToDeleteRows = false;
            this.dataListagemItem2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListagemItem2.Location = new System.Drawing.Point(19, 285);
            this.dataListagemItem2.Name = "dataListagemItem2";
            this.dataListagemItem2.Size = new System.Drawing.Size(941, 222);
            this.dataListagemItem2.TabIndex = 25;
            // 
            // dtData2
            // 
            this.dtData2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData2.Location = new System.Drawing.Point(175, 25);
            this.dtData2.Name = "dtData2";
            this.dtData2.Size = new System.Drawing.Size(100, 20);
            this.dtData2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Data Final:";
            // 
            // dtData1
            // 
            this.dtData1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData1.Location = new System.Drawing.Point(19, 29);
            this.dtData1.Name = "dtData1";
            this.dtData1.Size = new System.Drawing.Size(100, 20);
            this.dtData1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Inicial::";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(978, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Entrada";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal_Pago);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dataListagemItem);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtHora);
            this.groupBox1.Controls.Add(this.cbTipo_Pgto);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtData);
            this.groupBox1.Controls.Add(this.btnBuscarFornecedor);
            this.groupBox1.Controls.Add(this.txtIdfornecedor);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.txtIcms);
            this.groupBox1.Controls.Add(this.txtIdentrada);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(19, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 473);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entradas Estoque";
            // 
            // lblTotal_Pago
            // 
            this.lblTotal_Pago.AutoSize = true;
            this.lblTotal_Pago.Location = new System.Drawing.Point(101, 430);
            this.lblTotal_Pago.Name = "lblTotal_Pago";
            this.lblTotal_Pago.Size = new System.Drawing.Size(22, 13);
            this.lblTotal_Pago.TabIndex = 30;
            this.lblTotal_Pago.Text = "0.0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 430);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Total Pago: S/.";
            // 
            // dataListagemItem
            // 
            this.dataListagemItem.AllowUserToAddRows = false;
            this.dataListagemItem.AllowUserToDeleteRows = false;
            this.dataListagemItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListagemItem.Location = new System.Drawing.Point(15, 217);
            this.dataListagemItem.Name = "dataListagemItem";
            this.dataListagemItem.Size = new System.Drawing.Size(896, 194);
            this.dataListagemItem.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemover);
            this.groupBox2.Controls.Add(this.btnAdicionar);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtPreco_Venda);
            this.groupBox2.Controls.Add(this.dtData_Producao);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtPreco_Compra);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnBuscarArtigo);
            this.groupBox2.Controls.Add(this.txtArtigo);
            this.groupBox2.Controls.Add(this.txtIdartigo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(15, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 91);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(725, 51);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(80, 23);
            this.btnRemover.TabIndex = 34;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(610, 51);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(80, 23);
            this.btnAdicionar.TabIndex = 24;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(613, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Data Produção:";
            // 
            // txtPreco_Venda
            // 
            this.txtPreco_Venda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPreco_Venda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreco_Venda.Location = new System.Drawing.Point(408, 54);
            this.txtPreco_Venda.Name = "txtPreco_Venda";
            this.txtPreco_Venda.ReadOnly = true;
            this.txtPreco_Venda.Size = new System.Drawing.Size(150, 20);
            this.txtPreco_Venda.TabIndex = 33;
            // 
            // dtData_Producao
            // 
            this.dtData_Producao.Enabled = false;
            this.dtData_Producao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData_Producao.Location = new System.Drawing.Point(699, 21);
            this.dtData_Producao.Name = "dtData_Producao";
            this.dtData_Producao.Size = new System.Drawing.Size(100, 20);
            this.dtData_Producao.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Preço Venda:";
            // 
            // txtPreco_Compra
            // 
            this.txtPreco_Compra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPreco_Compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreco_Compra.Location = new System.Drawing.Point(408, 21);
            this.txtPreco_Compra.Name = "txtPreco_Compra";
            this.txtPreco_Compra.ReadOnly = true;
            this.txtPreco_Compra.Size = new System.Drawing.Size(150, 20);
            this.txtPreco_Compra.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(325, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Preço Compra:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.Location = new System.Drawing.Point(80, 54);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = true;
            this.txtQuantidade.Size = new System.Drawing.Size(150, 20);
            this.txtQuantidade.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Quantidade:";
            // 
            // btnBuscarArtigo
            // 
            this.btnBuscarArtigo.Location = new System.Drawing.Point(236, 16);
            this.btnBuscarArtigo.Name = "btnBuscarArtigo";
            this.btnBuscarArtigo.Size = new System.Drawing.Size(50, 23);
            this.btnBuscarArtigo.TabIndex = 27;
            this.btnBuscarArtigo.Text = "Buscar";
            this.btnBuscarArtigo.UseVisualStyleBackColor = true;
            this.btnBuscarArtigo.Click += new System.EventHandler(this.btnBuscarArtigo_Click);
            // 
            // txtArtigo
            // 
            this.txtArtigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtArtigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArtigo.Location = new System.Drawing.Point(80, 19);
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.ReadOnly = true;
            this.txtArtigo.Size = new System.Drawing.Size(150, 20);
            this.txtArtigo.TabIndex = 25;
            // 
            // txtIdartigo
            // 
            this.txtIdartigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdartigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdartigo.Location = new System.Drawing.Point(15, 0);
            this.txtIdartigo.Name = "txtIdartigo";
            this.txtIdartigo.ReadOnly = true;
            this.txtIdartigo.Size = new System.Drawing.Size(50, 20);
            this.txtIdartigo.TabIndex = 26;
            this.txtIdartigo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Artigo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(772, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Hora:";
            this.label11.Visible = false;
            // 
            // dtHora
            // 
            this.dtHora.Enabled = false;
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHora.Location = new System.Drawing.Point(811, 94);
            this.dtHora.Name = "dtHora";
            this.dtHora.Size = new System.Drawing.Size(100, 20);
            this.dtHora.TabIndex = 21;
            this.dtHora.Visible = false;
            // 
            // cbTipo_Pgto
            // 
            this.cbTipo_Pgto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbTipo_Pgto.FormattingEnabled = true;
            this.cbTipo_Pgto.Items.AddRange(new object[] {
            "Boleto",
            "Cupom",
            "Fatura"});
            this.cbTipo_Pgto.Location = new System.Drawing.Point(95, 93);
            this.cbTipo_Pgto.Name = "cbTipo_Pgto";
            this.cbTipo_Pgto.Size = new System.Drawing.Size(150, 21);
            this.cbTipo_Pgto.TabIndex = 20;
            this.cbTipo_Pgto.Text = "Boleto";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Location = new System.Drawing.Point(317, 95);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(200, 20);
            this.txtNumero.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Número:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(772, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Data:";
            // 
            // dtData
            // 
            this.dtData.Enabled = false;
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData.Location = new System.Drawing.Point(811, 57);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(100, 20);
            this.dtData.TabIndex = 16;
            // 
            // btnBuscarFornecedor
            // 
            this.btnBuscarFornecedor.Location = new System.Drawing.Point(251, 57);
            this.btnBuscarFornecedor.Name = "btnBuscarFornecedor";
            this.btnBuscarFornecedor.Size = new System.Drawing.Size(50, 23);
            this.btnBuscarFornecedor.TabIndex = 15;
            this.btnBuscarFornecedor.Text = "Buscar";
            this.btnBuscarFornecedor.UseVisualStyleBackColor = true;
            this.btnBuscarFornecedor.Click += new System.EventHandler(this.btnBuscarFornecedor_Click);
            // 
            // txtIdfornecedor
            // 
            this.txtIdfornecedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdfornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdfornecedor.Location = new System.Drawing.Point(195, 27);
            this.txtIdfornecedor.Name = "txtIdfornecedor";
            this.txtIdfornecedor.ReadOnly = true;
            this.txtIdfornecedor.Size = new System.Drawing.Size(50, 20);
            this.txtIdfornecedor.TabIndex = 14;
            this.txtIdfornecedor.Visible = false;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFornecedor.Location = new System.Drawing.Point(95, 60);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(150, 20);
            this.txtFornecedor.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fornecedor:";
            // 
            // txtIdentrada
            // 
            this.txtIdentrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdentrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentrada.Location = new System.Drawing.Point(95, 26);
            this.txtIdentrada.Name = "txtIdentrada";
            this.txtIdentrada.ReadOnly = true;
            this.txtIdentrada.Size = new System.Drawing.Size(50, 20);
            this.txtIdentrada.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "ICMS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID:";
            // 
            // ttMensagem
            // 
            this.ttMensagem.IsBalloon = true;
            // 
            // errorIcone
            // 
            this.errorIcone.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(36, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entradas Estoque";
            // 
            // FrmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 627);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciamento de Entradas no Estoque";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEntrada_FormClosed);
            this.Load += new System.EventHandler(this.FrmEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListagem)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListagemItem2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListagemItem)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataListagem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtIcms;
        private System.Windows.Forms.CheckBox chkAnular;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtData2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtData1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdentrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip ttMensagem;
        private System.Windows.Forms.ErrorProvider errorIcone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtHora;
        private System.Windows.Forms.ComboBox cbTipo_Pgto;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.Button btnBuscarFornecedor;
        private System.Windows.Forms.TextBox txtIdfornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscarArtigo;
        private System.Windows.Forms.TextBox txtArtigo;
        private System.Windows.Forms.TextBox txtIdartigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPreco_Venda;
        private System.Windows.Forms.DateTimePicker dtData_Producao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPreco_Compra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal_Pago;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataListagemItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Remover;
        private System.Windows.Forms.DataGridView dataListagemItem2;
    }
}