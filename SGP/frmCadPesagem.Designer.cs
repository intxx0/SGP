namespace SGP
{
    partial class frmCadPesagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadPesagem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbResiduo = new System.Windows.Forms.ComboBox();
            this.lblResiduo = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.cmbEmissor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numPesoLiquido = new System.Windows.Forms.NumericUpDown();
            this.numPesoTara = new System.Windows.Forms.NumericUpDown();
            this.numPesoBruto = new System.Windows.Forms.NumericUpDown();
            this.dtSaida = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEntrada = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoLiquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoTara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoBruto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbResiduo);
            this.groupBox1.Controls.Add(this.lblResiduo);
            this.groupBox1.Controls.Add(this.cmbVeiculo);
            this.groupBox1.Controls.Add(this.cmbEmissor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Emissor";
            // 
            // cmbResiduo
            // 
            this.cmbResiduo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResiduo.FormattingEnabled = true;
            this.cmbResiduo.Location = new System.Drawing.Point(144, 103);
            this.cmbResiduo.Name = "cmbResiduo";
            this.cmbResiduo.Size = new System.Drawing.Size(311, 21);
            this.cmbResiduo.TabIndex = 3;
            // 
            // lblResiduo
            // 
            this.lblResiduo.AutoSize = true;
            this.lblResiduo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResiduo.Location = new System.Drawing.Point(26, 106);
            this.lblResiduo.Name = "lblResiduo";
            this.lblResiduo.Size = new System.Drawing.Size(51, 13);
            this.lblResiduo.TabIndex = 25;
            this.lblResiduo.Text = "Resíduo:";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(144, 67);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(311, 21);
            this.cmbVeiculo.TabIndex = 2;
            // 
            // cmbEmissor
            // 
            this.cmbEmissor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmissor.FormattingEnabled = true;
            this.cmbEmissor.Location = new System.Drawing.Point(144, 29);
            this.cmbEmissor.Name = "cmbEmissor";
            this.cmbEmissor.Size = new System.Drawing.Size(311, 21);
            this.cmbEmissor.TabIndex = 1;
            this.cmbEmissor.SelectedIndexChanged += new System.EventHandler(this.cmbEmissor_SelectedIndexChanged);
            this.cmbEmissor.TextChanged += new System.EventHandler(this.cmbEmissor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Placa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Emissor:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numPesoLiquido);
            this.groupBox2.Controls.Add(this.numPesoTara);
            this.groupBox2.Controls.Add(this.numPesoBruto);
            this.groupBox2.Controls.Add(this.dtSaida);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtEntrada);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtObservacoes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 315);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados de Pesagem";
            // 
            // numPesoLiquido
            // 
            this.numPesoLiquido.Location = new System.Drawing.Point(144, 171);
            this.numPesoLiquido.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPesoLiquido.Name = "numPesoLiquido";
            this.numPesoLiquido.Size = new System.Drawing.Size(144, 20);
            this.numPesoLiquido.TabIndex = 28;
            // 
            // numPesoTara
            // 
            this.numPesoTara.Location = new System.Drawing.Point(144, 135);
            this.numPesoTara.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPesoTara.Name = "numPesoTara";
            this.numPesoTara.Size = new System.Drawing.Size(144, 20);
            this.numPesoTara.TabIndex = 27;
            // 
            // numPesoBruto
            // 
            this.numPesoBruto.Location = new System.Drawing.Point(144, 100);
            this.numPesoBruto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPesoBruto.Name = "numPesoBruto";
            this.numPesoBruto.Size = new System.Drawing.Size(144, 20);
            this.numPesoBruto.TabIndex = 26;
            // 
            // dtSaida
            // 
            this.dtSaida.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSaida.Location = new System.Drawing.Point(144, 64);
            this.dtSaida.Name = "dtSaida";
            this.dtSaida.Size = new System.Drawing.Size(144, 20);
            this.dtSaida.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Data Saída:";
            // 
            // dtEntrada
            // 
            this.dtEntrada.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEntrada.Location = new System.Drawing.Point(144, 32);
            this.dtEntrada.Name = "dtEntrada";
            this.dtEntrada.Size = new System.Drawing.Size(144, 20);
            this.dtEntrada.TabIndex = 4;
            this.dtEntrada.Value = new System.DateTime(2014, 2, 3, 15, 56, 44, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Data Entrada:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacoes.Location = new System.Drawing.Point(144, 209);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(311, 78);
            this.txtObservacoes.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Observações:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(23, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Peso Líquido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tara:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Peso Bruto:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(156, 506);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(277, 506);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmCadPesagem
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(519, 550);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadPesagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Pesagem";
            this.Load += new System.EventHandler(this.frmCadPesagem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoLiquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoTara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPesoBruto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbResiduo;
        private System.Windows.Forms.Label lblResiduo;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.ComboBox cmbEmissor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker dtSaida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPesoBruto;
        private System.Windows.Forms.NumericUpDown numPesoLiquido;
        private System.Windows.Forms.NumericUpDown numPesoTara;
    }
}