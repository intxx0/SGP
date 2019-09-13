namespace SGP
{
    partial class mdiPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiPrincipal));
            this.mnPrincipal = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.controlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesagemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pesagensRegistradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laboratorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emissoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resíduosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acessosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnPesagens = new System.Windows.Forms.Button();
            this.btnResiduos = new System.Windows.Forms.Button();
            this.btnEmissores = new System.Windows.Forms.Button();
            this.btnVeiculos = new System.Windows.Forms.Button();
            this.btnPesagem = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.mnPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.controlesToolStripMenuItem,
            this.laboratorioToolStripMenuItem,
            this.relatoriosToolStripMenuItem});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(943, 24);
            this.mnPrincipal.TabIndex = 1;
            this.mnPrincipal.Text = "menuStrip1";
            this.mnPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnPrincipal_ItemClicked);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSair});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // mnSair
            // 
            this.mnSair.Name = "mnSair";
            this.mnSair.Size = new System.Drawing.Size(152, 22);
            this.mnSair.Tag = "usuarios-sair";
            this.mnSair.Text = "&Sair";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // controlesToolStripMenuItem
            // 
            this.controlesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesagemToolStripMenuItem1,
            this.pesagensRegistradasToolStripMenuItem});
            this.controlesToolStripMenuItem.Name = "controlesToolStripMenuItem";
            this.controlesToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.controlesToolStripMenuItem.Text = "&Balança";
            // 
            // pesagemToolStripMenuItem1
            // 
            this.pesagemToolStripMenuItem1.Name = "pesagemToolStripMenuItem1";
            this.pesagemToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.pesagemToolStripMenuItem1.Tag = "pesagens-cadastrar";
            this.pesagemToolStripMenuItem1.Text = "&Pesagem";
            this.pesagemToolStripMenuItem1.Click += new System.EventHandler(this.pesagemToolStripMenuItem1_Click);
            // 
            // pesagensRegistradasToolStripMenuItem
            // 
            this.pesagensRegistradasToolStripMenuItem.Name = "pesagensRegistradasToolStripMenuItem";
            this.pesagensRegistradasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pesagensRegistradasToolStripMenuItem.Tag = "pesagens-listagem";
            this.pesagensRegistradasToolStripMenuItem.Text = "Pesagens &Registradas";
            this.pesagensRegistradasToolStripMenuItem.Click += new System.EventHandler(this.pesagensRegistradasToolStripMenuItem_Click);
            // 
            // laboratorioToolStripMenuItem
            // 
            this.laboratorioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analiseToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.veículosToolStripMenuItem,
            this.emissoresToolStripMenuItem,
            this.resíduosToolStripMenuItem});
            this.laboratorioToolStripMenuItem.Name = "laboratorioToolStripMenuItem";
            this.laboratorioToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.laboratorioToolStripMenuItem.Text = "&Cadastros";
            // 
            // analiseToolStripMenuItem
            // 
            this.analiseToolStripMenuItem.Name = "analiseToolStripMenuItem";
            this.analiseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.analiseToolStripMenuItem.Tag = "usuarios-listagem";
            this.analiseToolStripMenuItem.Text = "&Usuários";
            this.analiseToolStripMenuItem.Click += new System.EventHandler(this.analiseToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gruposToolStripMenuItem.Tag = "grupos-listagem";
            this.gruposToolStripMenuItem.Text = "&Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            this.veículosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.veículosToolStripMenuItem.Tag = "veiculos-listagem";
            this.veículosToolStripMenuItem.Text = "&Veículos";
            this.veículosToolStripMenuItem.Click += new System.EventHandler(this.veículosToolStripMenuItem_Click);
            // 
            // emissoresToolStripMenuItem
            // 
            this.emissoresToolStripMenuItem.Name = "emissoresToolStripMenuItem";
            this.emissoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emissoresToolStripMenuItem.Tag = "emissores-listagem";
            this.emissoresToolStripMenuItem.Text = "&Emissores";
            this.emissoresToolStripMenuItem.Click += new System.EventHandler(this.emissoresToolStripMenuItem_Click);
            // 
            // resíduosToolStripMenuItem
            // 
            this.resíduosToolStripMenuItem.Name = "resíduosToolStripMenuItem";
            this.resíduosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resíduosToolStripMenuItem.Tag = "residuos-listagem";
            this.resíduosToolStripMenuItem.Text = "&Resíduos";
            this.resíduosToolStripMenuItem.Click += new System.EventHandler(this.resíduosToolStripMenuItem_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesagemToolStripMenuItem,
            this.acessosToolStripMenuItem});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Text = "&Relatorios";
            // 
            // pesagemToolStripMenuItem
            // 
            this.pesagemToolStripMenuItem.Name = "pesagemToolStripMenuItem";
            this.pesagemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pesagemToolStripMenuItem.Tag = "pesagens-relatorios";
            this.pesagemToolStripMenuItem.Text = "&Pesagem";
            this.pesagemToolStripMenuItem.Click += new System.EventHandler(this.pesagemToolStripMenuItem_Click);
            // 
            // acessosToolStripMenuItem
            // 
            this.acessosToolStripMenuItem.Name = "acessosToolStripMenuItem";
            this.acessosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acessosToolStripMenuItem.Tag = "usuarios-acessos";
            this.acessosToolStripMenuItem.Text = "&Acessos";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user_24x32.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(943, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Usuário:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel2.Text = "(user)";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel3.Text = "Unidade:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel4.Text = "(unidade)";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnRelatorios);
            this.panelButtons.Controls.Add(this.btnPesagens);
            this.panelButtons.Controls.Add(this.btnResiduos);
            this.panelButtons.Controls.Add(this.btnEmissores);
            this.panelButtons.Controls.Add(this.btnVeiculos);
            this.panelButtons.Controls.Add(this.btnPesagem);
            this.panelButtons.Controls.Add(this.btnUsuarios);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 24);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(943, 64);
            this.panelButtons.TabIndex = 10;
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.BackgroundImage")));
            this.btnRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRelatorios.Location = new System.Drawing.Point(380, 6);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(57, 49);
            this.btnRelatorios.TabIndex = 16;
            this.btnRelatorios.Tag = "pesagens-relatorios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // btnPesagens
            // 
            this.btnPesagens.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesagens.BackgroundImage")));
            this.btnPesagens.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesagens.Location = new System.Drawing.Point(129, 6);
            this.btnPesagens.Name = "btnPesagens";
            this.btnPesagens.Size = new System.Drawing.Size(57, 49);
            this.btnPesagens.TabIndex = 15;
            this.btnPesagens.Tag = "pesagens-listagem";
            this.btnPesagens.UseVisualStyleBackColor = true;
            this.btnPesagens.Click += new System.EventHandler(this.btnPesagens_Click);
            // 
            // btnResiduos
            // 
            this.btnResiduos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResiduos.BackgroundImage")));
            this.btnResiduos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResiduos.Location = new System.Drawing.Point(317, 6);
            this.btnResiduos.Name = "btnResiduos";
            this.btnResiduos.Size = new System.Drawing.Size(57, 49);
            this.btnResiduos.TabIndex = 14;
            this.btnResiduos.Tag = "residuos-listagem";
            this.btnResiduos.UseVisualStyleBackColor = true;
            this.btnResiduos.Click += new System.EventHandler(this.btnResiduos_Click);
            // 
            // btnEmissores
            // 
            this.btnEmissores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmissores.BackgroundImage")));
            this.btnEmissores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEmissores.Location = new System.Drawing.Point(253, 6);
            this.btnEmissores.Name = "btnEmissores";
            this.btnEmissores.Size = new System.Drawing.Size(57, 49);
            this.btnEmissores.TabIndex = 12;
            this.btnEmissores.Tag = "emissores-listagem";
            this.btnEmissores.UseVisualStyleBackColor = true;
            this.btnEmissores.Click += new System.EventHandler(this.btnEmissores_Click);
            // 
            // btnVeiculos
            // 
            this.btnVeiculos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVeiculos.BackgroundImage")));
            this.btnVeiculos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVeiculos.Location = new System.Drawing.Point(192, 6);
            this.btnVeiculos.Name = "btnVeiculos";
            this.btnVeiculos.Size = new System.Drawing.Size(55, 49);
            this.btnVeiculos.TabIndex = 11;
            this.btnVeiculos.Tag = "veiculos-listagem";
            this.btnVeiculos.UseVisualStyleBackColor = true;
            this.btnVeiculos.Click += new System.EventHandler(this.btnVeiculos_Click);
            // 
            // btnPesagem
            // 
            this.btnPesagem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesagem.BackgroundImage")));
            this.btnPesagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesagem.Location = new System.Drawing.Point(68, 7);
            this.btnPesagem.Name = "btnPesagem";
            this.btnPesagem.Size = new System.Drawing.Size(55, 49);
            this.btnPesagem.TabIndex = 1;
            this.btnPesagem.Tag = "pesagens-cadastrar";
            this.btnPesagem.UseVisualStyleBackColor = true;
            this.btnPesagem.Click += new System.EventHandler(this.btnPesagem_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.BackgroundImage")));
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUsuarios.Location = new System.Drawing.Point(7, 6);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(55, 50);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Tag = "usuarios-listagem";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // mdiPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(943, 679);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnPrincipal;
            this.Name = "mdiPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestão de Pesagem";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mdiPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.mdiPrincipal_Load);
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnSair;
        private System.Windows.Forms.ToolStripMenuItem controlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laboratorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analiseToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnVeiculos;
        private System.Windows.Forms.Button btnPesagem;
        private System.Windows.Forms.Button btnEmissores;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Button btnResiduos;
        private System.Windows.Forms.ToolStripMenuItem veículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emissoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resíduosToolStripMenuItem;
        private System.Windows.Forms.Button btnPesagens;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.ToolStripMenuItem pesagemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pesagensRegistradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acessosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
    }
}