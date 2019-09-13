namespace SGP
{
    partial class frmPesagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesagem));
            this.lblData = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPesoBruto = new System.Windows.Forms.TextBox();
            this.txtPesoTara = new System.Windows.Forms.TextBox();
            this.txtPesoLiquido = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbResiduo = new System.Windows.Forms.ComboBox();
            this.lblResiduo = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.cmbEmissor = new System.Windows.Forms.ComboBox();
            this.radTipoSaida = new System.Windows.Forms.RadioButton();
            this.radTipoEntrada = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(430, 24);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(120, 26);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "00/00/0000";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(556, 24);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(96, 26);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "00:00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Peso Bruto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(28, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tara:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(28, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 31);
            this.label8.TabIndex = 7;
            this.label8.Text = "Peso Líquido:";
            // 
            // txtPesoBruto
            // 
            this.txtPesoBruto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPesoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoBruto.ForeColor = System.Drawing.Color.Navy;
            this.txtPesoBruto.Location = new System.Drawing.Point(339, 320);
            this.txtPesoBruto.Name = "txtPesoBruto";
            this.txtPesoBruto.ReadOnly = true;
            this.txtPesoBruto.Size = new System.Drawing.Size(294, 38);
            this.txtPesoBruto.TabIndex = 12;
            this.txtPesoBruto.Text = "000000";
            this.txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPesoTara
            // 
            this.txtPesoTara.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPesoTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoTara.ForeColor = System.Drawing.Color.Navy;
            this.txtPesoTara.Location = new System.Drawing.Point(339, 368);
            this.txtPesoTara.Name = "txtPesoTara";
            this.txtPesoTara.ReadOnly = true;
            this.txtPesoTara.Size = new System.Drawing.Size(294, 38);
            this.txtPesoTara.TabIndex = 13;
            this.txtPesoTara.Text = "000000";
            this.txtPesoTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPesoLiquido
            // 
            this.txtPesoLiquido.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPesoLiquido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoLiquido.ForeColor = System.Drawing.Color.Navy;
            this.txtPesoLiquido.Location = new System.Drawing.Point(339, 416);
            this.txtPesoLiquido.Name = "txtPesoLiquido";
            this.txtPesoLiquido.ReadOnly = true;
            this.txtPesoLiquido.Size = new System.Drawing.Size(294, 38);
            this.txtPesoLiquido.TabIndex = 14;
            this.txtPesoLiquido.Text = "000000";
            this.txtPesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbResiduo);
            this.groupBox1.Controls.Add(this.lblResiduo);
            this.groupBox1.Controls.Add(this.cmbVeiculo);
            this.groupBox1.Controls.Add(this.cmbEmissor);
            this.groupBox1.Controls.Add(this.radTipoSaida);
            this.groupBox1.Controls.Add(this.radTipoEntrada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(34, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 208);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Emissor / Veículo";
            // 
            // cmbResiduo
            // 
            this.cmbResiduo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResiduo.FormattingEnabled = true;
            this.cmbResiduo.Location = new System.Drawing.Point(259, 157);
            this.cmbResiduo.Name = "cmbResiduo";
            this.cmbResiduo.Size = new System.Drawing.Size(277, 28);
            this.cmbResiduo.TabIndex = 5;
            this.cmbResiduo.TextChanged += new System.EventHandler(this.cmbResiduo_TextChanged);
            // 
            // lblResiduo
            // 
            this.lblResiduo.AutoSize = true;
            this.lblResiduo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResiduo.Location = new System.Drawing.Point(54, 157);
            this.lblResiduo.Name = "lblResiduo";
            this.lblResiduo.Size = new System.Drawing.Size(72, 20);
            this.lblResiduo.TabIndex = 19;
            this.lblResiduo.Text = "Resíduo:";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(259, 118);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(277, 28);
            this.cmbVeiculo.TabIndex = 4;
            this.cmbVeiculo.TextChanged += new System.EventHandler(this.cmbVeiculo_TextChanged);
            // 
            // cmbEmissor
            // 
            this.cmbEmissor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmissor.FormattingEnabled = true;
            this.cmbEmissor.Location = new System.Drawing.Point(259, 75);
            this.cmbEmissor.Name = "cmbEmissor";
            this.cmbEmissor.Size = new System.Drawing.Size(277, 28);
            this.cmbEmissor.TabIndex = 3;
            this.cmbEmissor.SelectedIndexChanged += new System.EventHandler(this.cmbEmissor_SelectedIndexChanged);
            this.cmbEmissor.TextChanged += new System.EventHandler(this.cmbEmissor_TextChanged);
            // 
            // radTipoSaida
            // 
            this.radTipoSaida.AutoSize = true;
            this.radTipoSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTipoSaida.Location = new System.Drawing.Point(369, 38);
            this.radTipoSaida.Name = "radTipoSaida";
            this.radTipoSaida.Size = new System.Drawing.Size(68, 24);
            this.radTipoSaida.TabIndex = 2;
            this.radTipoSaida.Text = "Saída";
            this.radTipoSaida.UseVisualStyleBackColor = true;
            this.radTipoSaida.Click += new System.EventHandler(this.radTipoSaida_Click);
            // 
            // radTipoEntrada
            // 
            this.radTipoEntrada.AutoSize = true;
            this.radTipoEntrada.Checked = true;
            this.radTipoEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTipoEntrada.Location = new System.Drawing.Point(259, 38);
            this.radTipoEntrada.Name = "radTipoEntrada";
            this.radTipoEntrada.Size = new System.Drawing.Size(84, 24);
            this.radTipoEntrada.TabIndex = 1;
            this.radTipoEntrada.TabStop = true;
            this.radTipoEntrada.Text = "Entrada";
            this.radTipoEntrada.UseVisualStyleBackColor = true;
            this.radTipoEntrada.Click += new System.EventHandler(this.radTipoEntrada_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Placa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Emissor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tipo:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(366, 512);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(220, 38);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(91, 512);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(220, 38);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(366, 512);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(220, 38);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir &Ticket";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciar.Image")));
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(366, 512);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(220, 38);
            this.btnIniciar.TabIndex = 6;
            this.btnIniciar.Text = "&Iniciar Pesagem";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // frmPesagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 591);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPesoLiquido);
            this.Controls.Add(this.txtPesoTara);
            this.Controls.Add(this.txtPesoBruto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesagem";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPesagem_FormClosing);
            this.Load += new System.EventHandler(this.frmPesagem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEmissor;
        private System.Windows.Forms.RadioButton radTipoSaida;
        private System.Windows.Forms.RadioButton radTipoEntrada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Label lblData;
        public System.Windows.Forms.Label lblHora;
        public System.Windows.Forms.TextBox txtPesoBruto;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        public System.Windows.Forms.TextBox txtPesoLiquido;
        private System.Windows.Forms.ComboBox cmbResiduo;
        private System.Windows.Forms.Label lblResiduo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnIniciar;
        public System.Windows.Forms.TextBox txtPesoTara;
    }
}