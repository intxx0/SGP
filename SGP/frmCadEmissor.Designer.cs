namespace SGP
{
    partial class frmCadEmissor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEmissor));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCidade = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbUf = new System.Windows.Forms.ComboBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoCliente = new System.Windows.Forms.ComboBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.txtIm = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIe = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.radInativo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExcluirVeiculo = new System.Windows.Forms.Button();
            this.btnAdicionarVeiculo = new System.Windows.Forms.Button();
            this.dgvEmissoresVeiculos = new System.Windows.Forms.DataGridView();
            this.IdVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExcluirResiduo = new System.Windows.Forms.Button();
            this.btnAdicionarResiduo = new System.Windows.Forms.Button();
            this.dgvEmissoresResiduos = new System.Windows.Forms.DataGridView();
            this.IdResiduo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Residuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoResiduo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissoresVeiculos)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissoresResiduos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(388, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(509, 558);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCidade);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbUf);
            this.groupBox2.Controls.Add(this.txtBairro);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.txtEndereco);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 133);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // cmbCidade
            // 
            this.cmbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCidade.FormattingEnabled = true;
            this.cmbCidade.Location = new System.Drawing.Point(257, 92);
            this.cmbCidade.Name = "cmbCidade";
            this.cmbCidade.Size = new System.Drawing.Size(195, 21);
            this.cmbCidade.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cidade:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "UF:";
            // 
            // cmbUf
            // 
            this.cmbUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUf.FormattingEnabled = true;
            this.cmbUf.Location = new System.Drawing.Point(113, 92);
            this.cmbUf.Name = "cmbUf";
            this.cmbUf.Size = new System.Drawing.Size(59, 21);
            this.cmbUf.TabIndex = 18;
            this.cmbUf.SelectedIndexChanged += new System.EventHandler(this.cmbUf_SelectedIndexChanged);
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(113, 64);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(255, 20);
            this.txtBairro.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Bairro:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(402, 36);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(50, 20);
            this.txtNumero.TabIndex = 16;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(113, 36);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(255, 20);
            this.txtEndereco.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nº:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Endereço:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razão Social:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(112, 171);
            this.txtObservacoes.MaxLength = 255;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(339, 63);
            this.txtObservacoes.TabIndex = 9;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(113, 35);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(339, 20);
            this.txtRazaoSocial.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoCliente);
            this.groupBox1.Controls.Add(this.txtCnpj);
            this.groupBox1.Controls.Add(this.txtIm);
            this.groupBox1.Controls.Add(this.txtCpf);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtIe);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtNomeFantasia);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.radInativo);
            this.groupBox1.Controls.Add(this.radAtivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtObservacoes);
            this.groupBox1.Controls.Add(this.txtRazaoSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 274);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Gerais";
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Items.AddRange(new object[] {
            "Público",
            "Privado"});
            this.cmbTipoCliente.Location = new System.Drawing.Point(320, 87);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new System.Drawing.Size(131, 21);
            this.cmbTipoCliente.TabIndex = 4;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(112, 117);
            this.txtCnpj.Mask = "99.999.999/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(166, 20);
            this.txtCnpj.TabIndex = 5;
            // 
            // txtIm
            // 
            this.txtIm.Location = new System.Drawing.Point(320, 143);
            this.txtIm.MaxLength = 20;
            this.txtIm.Name = "txtIm";
            this.txtIm.Size = new System.Drawing.Size(132, 20);
            this.txtIm.TabIndex = 8;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(320, 117);
            this.txtCpf.MaxLength = 14;
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(132, 20);
            this.txtCpf.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(284, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "IM:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(284, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "CPF:";
            // 
            // txtIe
            // 
            this.txtIe.Location = new System.Drawing.Point(112, 143);
            this.txtIe.MaxLength = 20;
            this.txtIe.Name = "txtIe";
            this.txtIe.Size = new System.Drawing.Size(166, 20);
            this.txtIe.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "IE:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "CNPJ:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Pessoa Jurídica",
            "Pessoa Física"});
            this.cmbTipo.Location = new System.Drawing.Point(112, 87);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(125, 21);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Tipo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(259, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Cliente:";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.Location = new System.Drawing.Point(112, 61);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(339, 20);
            this.txtNomeFantasia.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Nome Fantasia:";
            // 
            // radInativo
            // 
            this.radInativo.AutoSize = true;
            this.radInativo.Location = new System.Drawing.Point(169, 243);
            this.radInativo.Name = "radInativo";
            this.radInativo.Size = new System.Drawing.Size(57, 17);
            this.radInativo.TabIndex = 11;
            this.radInativo.Text = "Inativo";
            this.radInativo.UseVisualStyleBackColor = true;
            this.radInativo.Click += new System.EventHandler(this.radInativo_Click);
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(114, 243);
            this.radAtivo.Name = "radAtivo";
            this.radAtivo.Size = new System.Drawing.Size(49, 17);
            this.radAtivo.TabIndex = 10;
            this.radAtivo.Text = "Ativo";
            this.radAtivo.UseVisualStyleBackColor = true;
            this.radAtivo.Click += new System.EventHandler(this.radAtivo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtCelular);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTelefone);
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 101);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contato";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(259, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Celular:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(308, 62);
            this.txtCelular.Mask = "(99) 0000-0000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(144, 20);
            this.txtCelular.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Telefone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(114, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(338, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "E-Mail:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(113, 62);
            this.txtTelefone.Mask = "(99) 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(138, 20);
            this.txtTelefone.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExcluirVeiculo);
            this.groupBox4.Controls.Add(this.btnAdicionarVeiculo);
            this.groupBox4.Controls.Add(this.dgvEmissoresVeiculos);
            this.groupBox4.Location = new System.Drawing.Point(501, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 258);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Veículos";
            // 
            // btnExcluirVeiculo
            // 
            this.btnExcluirVeiculo.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirVeiculo.Image")));
            this.btnExcluirVeiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluirVeiculo.Location = new System.Drawing.Point(42, 19);
            this.btnExcluirVeiculo.Name = "btnExcluirVeiculo";
            this.btnExcluirVeiculo.Size = new System.Drawing.Size(25, 23);
            this.btnExcluirVeiculo.TabIndex = 21;
            this.btnExcluirVeiculo.UseVisualStyleBackColor = true;
            this.btnExcluirVeiculo.Click += new System.EventHandler(this.btnExcluirVeiculo_Click);
            // 
            // btnAdicionarVeiculo
            // 
            this.btnAdicionarVeiculo.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarVeiculo.Image")));
            this.btnAdicionarVeiculo.Location = new System.Drawing.Point(11, 19);
            this.btnAdicionarVeiculo.Name = "btnAdicionarVeiculo";
            this.btnAdicionarVeiculo.Size = new System.Drawing.Size(25, 23);
            this.btnAdicionarVeiculo.TabIndex = 20;
            this.btnAdicionarVeiculo.UseVisualStyleBackColor = true;
            this.btnAdicionarVeiculo.Click += new System.EventHandler(this.btnAdicionarVeiculo_Click);
            // 
            // dgvEmissoresVeiculos
            // 
            this.dgvEmissoresVeiculos.AllowUserToAddRows = false;
            this.dgvEmissoresVeiculos.AllowUserToOrderColumns = true;
            this.dgvEmissoresVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmissoresVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVeiculo,
            this.Veiculo,
            this.tipo,
            this.Placa});
            this.dgvEmissoresVeiculos.Location = new System.Drawing.Point(11, 47);
            this.dgvEmissoresVeiculos.MultiSelect = false;
            this.dgvEmissoresVeiculos.Name = "dgvEmissoresVeiculos";
            this.dgvEmissoresVeiculos.ReadOnly = true;
            this.dgvEmissoresVeiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmissoresVeiculos.Size = new System.Drawing.Size(416, 200);
            this.dgvEmissoresVeiculos.TabIndex = 22;
            // 
            // IdVeiculo
            // 
            this.IdVeiculo.HeaderText = "Id";
            this.IdVeiculo.Name = "IdVeiculo";
            this.IdVeiculo.ReadOnly = true;
            this.IdVeiculo.Visible = false;
            // 
            // Veiculo
            // 
            this.Veiculo.HeaderText = "Veículo";
            this.Veiculo.Name = "Veiculo";
            this.Veiculo.ReadOnly = true;
            this.Veiculo.Width = 155;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // Placa
            // 
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnExcluirResiduo);
            this.groupBox5.Controls.Add(this.btnAdicionarResiduo);
            this.groupBox5.Controls.Add(this.dgvEmissoresResiduos);
            this.groupBox5.Location = new System.Drawing.Point(501, 279);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(438, 256);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resíduos";
            // 
            // btnExcluirResiduo
            // 
            this.btnExcluirResiduo.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirResiduo.Image")));
            this.btnExcluirResiduo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluirResiduo.Location = new System.Drawing.Point(42, 19);
            this.btnExcluirResiduo.Name = "btnExcluirResiduo";
            this.btnExcluirResiduo.Size = new System.Drawing.Size(25, 23);
            this.btnExcluirResiduo.TabIndex = 24;
            this.btnExcluirResiduo.UseVisualStyleBackColor = true;
            this.btnExcluirResiduo.Click += new System.EventHandler(this.btnExcluirResiduo_Click);
            // 
            // btnAdicionarResiduo
            // 
            this.btnAdicionarResiduo.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarResiduo.Image")));
            this.btnAdicionarResiduo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarResiduo.Location = new System.Drawing.Point(11, 19);
            this.btnAdicionarResiduo.Name = "btnAdicionarResiduo";
            this.btnAdicionarResiduo.Size = new System.Drawing.Size(25, 23);
            this.btnAdicionarResiduo.TabIndex = 23;
            this.btnAdicionarResiduo.UseVisualStyleBackColor = true;
            this.btnAdicionarResiduo.Click += new System.EventHandler(this.btnAdicionarResiduo_Click);
            // 
            // dgvEmissoresResiduos
            // 
            this.dgvEmissoresResiduos.AllowUserToAddRows = false;
            this.dgvEmissoresResiduos.AllowUserToOrderColumns = true;
            this.dgvEmissoresResiduos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmissoresResiduos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdResiduo,
            this.Residuo,
            this.TipoResiduo});
            this.dgvEmissoresResiduos.Location = new System.Drawing.Point(11, 48);
            this.dgvEmissoresResiduos.MultiSelect = false;
            this.dgvEmissoresResiduos.Name = "dgvEmissoresResiduos";
            this.dgvEmissoresResiduos.ReadOnly = true;
            this.dgvEmissoresResiduos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmissoresResiduos.Size = new System.Drawing.Size(416, 197);
            this.dgvEmissoresResiduos.TabIndex = 25;
            // 
            // IdResiduo
            // 
            this.IdResiduo.HeaderText = "Id";
            this.IdResiduo.Name = "IdResiduo";
            this.IdResiduo.ReadOnly = true;
            this.IdResiduo.Visible = false;
            // 
            // Residuo
            // 
            this.Residuo.HeaderText = "Resíduo";
            this.Residuo.Name = "Residuo";
            this.Residuo.ReadOnly = true;
            this.Residuo.Width = 200;
            // 
            // TipoResiduo
            // 
            this.TipoResiduo.HeaderText = "Tipo";
            this.TipoResiduo.Name = "TipoResiduo";
            this.TipoResiduo.ReadOnly = true;
            this.TipoResiduo.Width = 155;
            // 
            // frmCadEmissor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 602);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadEmissor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Emissor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCadEmissor_FormClosed);
            this.Load += new System.EventHandler(this.frmCadEmissor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissoresVeiculos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissoresResiduos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbUf;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExcluirVeiculo;
        private System.Windows.Forms.Button btnAdicionarVeiculo;
        private System.Windows.Forms.DataGridView dgvEmissoresVeiculos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnExcluirResiduo;
        private System.Windows.Forms.Button btnAdicionarResiduo;
        private System.Windows.Forms.DataGridView dgvEmissoresResiduos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdResiduo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Residuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoResiduo;
        private System.Windows.Forms.TextBox txtIm;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIe;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.RadioButton radInativo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.ComboBox cmbTipoCliente;
    }
}