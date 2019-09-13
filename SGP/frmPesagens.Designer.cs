namespace SGP
{
    partial class frmPesagens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesagens));
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.dgvPesagens = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emissor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.residuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_bruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_tara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso_liquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPesagens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesagens)).BeginInit();
            this.cmsPesagens.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 519);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(144, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Nenhum registro encontrado.";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(773, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Tag = "pesagens-listagem";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(598, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(169, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnNovoUsuario.Image")));
            this.btnNovoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoUsuario.Location = new System.Drawing.Point(12, 12);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(87, 26);
            this.btnNovoUsuario.TabIndex = 6;
            this.btnNovoUsuario.Tag = "pesagens-cadastrar";
            this.btnNovoUsuario.Text = "Novo";
            this.btnNovoUsuario.UseVisualStyleBackColor = true;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
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
            this.dgvPesagens.Location = new System.Drawing.Point(12, 54);
            this.dgvPesagens.MultiSelect = false;
            this.dgvPesagens.Name = "dgvPesagens";
            this.dgvPesagens.ReadOnly = true;
            this.dgvPesagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesagens.Size = new System.Drawing.Size(789, 452);
            this.dgvPesagens.TabIndex = 5;
            this.dgvPesagens.DoubleClick += new System.EventHandler(this.dgvPesagens_DoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // unidade
            // 
            this.unidade.HeaderText = "Unidade";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            this.unidade.Width = 150;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuário";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 128;
            // 
            // emissor
            // 
            this.emissor.HeaderText = "Emissor";
            this.emissor.Name = "emissor";
            this.emissor.ReadOnly = true;
            this.emissor.Width = 200;
            // 
            // placa
            // 
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            // 
            // residuo
            // 
            this.residuo.HeaderText = "Resíduo";
            this.residuo.Name = "residuo";
            this.residuo.ReadOnly = true;
            this.residuo.Width = 200;
            // 
            // peso_bruto
            // 
            this.peso_bruto.HeaderText = "Peso Bruto (Kg)";
            this.peso_bruto.Name = "peso_bruto";
            this.peso_bruto.ReadOnly = true;
            this.peso_bruto.Width = 120;
            // 
            // peso_tara
            // 
            this.peso_tara.HeaderText = "Peso Tara (Kg)";
            this.peso_tara.Name = "peso_tara";
            this.peso_tara.ReadOnly = true;
            this.peso_tara.Width = 120;
            // 
            // peso_liquido
            // 
            this.peso_liquido.HeaderText = "Peso Líquido (Kg)";
            this.peso_liquido.Name = "peso_liquido";
            this.peso_liquido.ReadOnly = true;
            this.peso_liquido.Width = 120;
            // 
            // data_entrada
            // 
            this.data_entrada.HeaderText = "Entrada (Data/Hora)";
            this.data_entrada.Name = "data_entrada";
            this.data_entrada.ReadOnly = true;
            this.data_entrada.Width = 150;
            // 
            // data_saida
            // 
            this.data_saida.HeaderText = "Saída (Data/Hora)";
            this.data_saida.Name = "data_saida";
            this.data_saida.ReadOnly = true;
            this.data_saida.Width = 150;
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
            this.editarToolStripMenuItem.Tag = "pesagens-alterar";
            this.editarToolStripMenuItem.Text = "&Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripMenuItem.Image")));
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.imprimirToolStripMenuItem.Tag = "pesagens-impressao";
            this.imprimirToolStripMenuItem.Text = "&Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // frmPesagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 543);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnNovoUsuario);
            this.Controls.Add(this.dgvPesagens);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPesagens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesagens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPesagens_FormClosing);
            this.Load += new System.EventHandler(this.frmPesagens_Load);
            this.ResizeEnd += new System.EventHandler(this.frmPesagens_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmPesagens_SizeChanged);
            this.Enter += new System.EventHandler(this.frmPesagens_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesagens)).EndInit();
            this.cmsPesagens.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnNovoUsuario;
        private System.Windows.Forms.DataGridView dgvPesagens;
        private System.Windows.Forms.ContextMenuStrip cmsPesagens;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn emissor;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn residuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_bruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_tara;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso_liquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_saida;
    }
}