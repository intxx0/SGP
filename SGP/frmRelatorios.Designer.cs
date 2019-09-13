namespace SGP
{
    partial class frmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorios));
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPesagens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data_saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_liquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_tara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_bruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.residuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPesagens = new System.Windows.Forms.DataGridView();
            this.emissor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gpParametros = new System.Windows.Forms.GroupBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.dtpTermino = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbResiduo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmissor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnidade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.cmsPesagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesagens)).BeginInit();
            this.gpParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripMenuItem.Image")));
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.imprimirToolStripMenuItem.Text = "&Imprimir";
            // 
            // cmsPesagens
            // 
            this.cmsPesagens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.cmsPesagens.Name = "cmsUsuarios";
            this.cmsPesagens.Size = new System.Drawing.Size(121, 48);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripMenuItem.Image")));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // data_saida
            // 
            this.data_saida.HeaderText = "Saída (Data/Hora)";
            this.data_saida.Name = "data_saida";
            this.data_saida.ReadOnly = true;
            this.data_saida.Width = 150;
            // 
            // data_entrada
            // 
            this.data_entrada.HeaderText = "Entrada (Data/Hora)";
            this.data_entrada.Name = "data_entrada";
            this.data_entrada.ReadOnly = true;
            this.data_entrada.Width = 150;
            // 
            // peso_liquido
            // 
            this.peso_liquido.HeaderText = "Peso Líquido (Kg)";
            this.peso_liquido.Name = "peso_liquido";
            this.peso_liquido.ReadOnly = true;
            this.peso_liquido.Width = 120;
            // 
            // peso_tara
            // 
            this.peso_tara.HeaderText = "Peso Tara (Kg)";
            this.peso_tara.Name = "peso_tara";
            this.peso_tara.ReadOnly = true;
            this.peso_tara.Width = 120;
            // 
            // peso_bruto
            // 
            this.peso_bruto.HeaderText = "Peso Bruto (Kg)";
            this.peso_bruto.Name = "peso_bruto";
            this.peso_bruto.ReadOnly = true;
            this.peso_bruto.Width = 120;
            // 
            // residuo
            // 
            this.residuo.HeaderText = "Resíduo";
            this.residuo.Name = "residuo";
            this.residuo.ReadOnly = true;
            this.residuo.Width = 200;
            // 
            // placa
            // 
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuário";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 128;
            // 
            // unidade
            // 
            this.unidade.HeaderText = "Unidade";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            this.unidade.Width = 150;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // dgvPesagens
            // 
            this.dgvPesagens.AllowUserToAddRows = false;
            this.dgvPesagens.AllowUserToOrderColumns = true;
            this.dgvPesagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.unidade,
            this.usuario,
            this.emissor,
            this.placa,
            this.residuo,
            this.peso_bruto,
            this.peso_tara,
            this.peso_liquido,
            this.data_entrada,
            this.data_saida});
            this.dgvPesagens.ContextMenuStrip = this.cmsPesagens;
            this.dgvPesagens.Location = new System.Drawing.Point(12, 100);
            this.dgvPesagens.MultiSelect = false;
            this.dgvPesagens.Name = "dgvPesagens";
            this.dgvPesagens.ReadOnly = true;
            this.dgvPesagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesagens.Size = new System.Drawing.Size(852, 452);
            this.dgvPesagens.TabIndex = 10;
            // 
            // emissor
            // 
            this.emissor.HeaderText = "Emissor";
            this.emissor.Name = "emissor";
            this.emissor.ReadOnly = true;
            this.emissor.Width = 200;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 565);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(144, 13);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Nenhum registro encontrado.";
            // 
            // gpParametros
            // 
            this.gpParametros.Controls.Add(this.btnProcurar);
            this.gpParametros.Controls.Add(this.dtpTermino);
            this.gpParametros.Controls.Add(this.label7);
            this.gpParametros.Controls.Add(this.dtpInicio);
            this.gpParametros.Controls.Add(this.label6);
            this.gpParametros.Controls.Add(this.cmbResiduo);
            this.gpParametros.Controls.Add(this.label5);
            this.gpParametros.Controls.Add(this.cmbPlaca);
            this.gpParametros.Controls.Add(this.label4);
            this.gpParametros.Controls.Add(this.cmbEmissor);
            this.gpParametros.Controls.Add(this.label3);
            this.gpParametros.Controls.Add(this.cmbUsuario);
            this.gpParametros.Controls.Add(this.label2);
            this.gpParametros.Controls.Add(this.cmbUnidade);
            this.gpParametros.Controls.Add(this.label1);
            this.gpParametros.Location = new System.Drawing.Point(12, 12);
            this.gpParametros.Name = "gpParametros";
            this.gpParametros.Size = new System.Drawing.Size(852, 77);
            this.gpParametros.TabIndex = 15;
            this.gpParametros.TabStop = false;
            this.gpParametros.Text = "Parâmetros";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar.Image")));
            this.btnProcurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcurar.Location = new System.Drawing.Point(746, 48);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(100, 23);
            this.btnProcurar.TabIndex = 14;
            this.btnProcurar.Text = "&Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // dtpTermino
            // 
            this.dtpTermino.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermino.Location = new System.Drawing.Point(664, 20);
            this.dtpTermino.Name = "dtpTermino";
            this.dtpTermino.Size = new System.Drawing.Size(127, 20);
            this.dtpTermino.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(645, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "à";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(509, 21);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(130, 20);
            this.dtpInicio.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Período:";
            // 
            // cmbResiduo
            // 
            this.cmbResiduo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResiduo.FormattingEnabled = true;
            this.cmbResiduo.Location = new System.Drawing.Point(508, 50);
            this.cmbResiduo.Name = "cmbResiduo";
            this.cmbResiduo.Size = new System.Drawing.Size(121, 21);
            this.cmbResiduo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Resíduo:";
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Location = new System.Drawing.Point(297, 51);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(121, 21);
            this.cmbPlaca.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Placa:";
            // 
            // cmbEmissor
            // 
            this.cmbEmissor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmissor.FormattingEnabled = true;
            this.cmbEmissor.Location = new System.Drawing.Point(297, 23);
            this.cmbEmissor.Name = "cmbEmissor";
            this.cmbEmissor.Size = new System.Drawing.Size(121, 21);
            this.cmbEmissor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Emissor:";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(87, 51);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(121, 21);
            this.cmbUsuario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuário:";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Location = new System.Drawing.Point(87, 23);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.Size = new System.Drawing.Size(121, 21);
            this.cmbUnidade.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidade:";
            // 
            // btnExportar
            // 
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(764, 560);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 23);
            this.btnExportar.TabIndex = 16;
            this.btnExportar.Tag = "pesagens-relatorios-exportacao";
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(660, 560);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(98, 23);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Tag = "pesagens-relatorios-impressao";
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 595);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gpParametros);
            this.Controls.Add(this.dgvPesagens);
            this.Controls.Add(this.lblTotal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios de Pesagens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRelatorios_FormClosing);
            this.Load += new System.EventHandler(this.frmRelatorios_Load);
            this.ResizeEnd += new System.EventHandler(this.frmRelatorios_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmRelatorios_SizeChanged);
            this.cmsPesagens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesagens)).EndInit();
            this.gpParametros.ResumeLayout(false);
            this.gpParametros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsPesagens;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_saida;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_liquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_tara;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_bruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn residuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridView dgvPesagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn emissor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox gpParametros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbResiduo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmissor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTermino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}