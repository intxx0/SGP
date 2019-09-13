namespace SGP
{
    partial class frmCadGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadGrupo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radInativo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcluirPermissao = new System.Windows.Forms.Button();
            this.btnAdicionarPermissao = new System.Windows.Forms.Button();
            this.dgvPermissoes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radInativo);
            this.groupBox1.Controls.Add(this.radAtivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Gerais";
            // 
            // radInativo
            // 
            this.radInativo.AutoSize = true;
            this.radInativo.Location = new System.Drawing.Point(168, 61);
            this.radInativo.Name = "radInativo";
            this.radInativo.Size = new System.Drawing.Size(57, 17);
            this.radInativo.TabIndex = 15;
            this.radInativo.TabStop = true;
            this.radInativo.Text = "Inativo";
            this.radInativo.UseVisualStyleBackColor = true;
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(113, 61);
            this.radAtivo.Name = "radAtivo";
            this.radAtivo.Size = new System.Drawing.Size(49, 17);
            this.radAtivo.TabIndex = 14;
            this.radAtivo.TabStop = true;
            this.radAtivo.Text = "Ativo";
            this.radAtivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Status:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(113, 35);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(339, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(270, 477);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(149, 477);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcluirPermissao);
            this.groupBox2.Controls.Add(this.btnAdicionarPermissao);
            this.groupBox2.Controls.Add(this.dgvPermissoes);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 336);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permissões de Acesso";
            // 
            // btnExcluirPermissao
            // 
            this.btnExcluirPermissao.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirPermissao.Image")));
            this.btnExcluirPermissao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluirPermissao.Location = new System.Drawing.Point(43, 19);
            this.btnExcluirPermissao.Name = "btnExcluirPermissao";
            this.btnExcluirPermissao.Size = new System.Drawing.Size(25, 23);
            this.btnExcluirPermissao.TabIndex = 23;
            this.btnExcluirPermissao.UseVisualStyleBackColor = true;
            this.btnExcluirPermissao.Click += new System.EventHandler(this.btnExcluirPermissao_Click);
            // 
            // btnAdicionarPermissao
            // 
            this.btnAdicionarPermissao.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarPermissao.Image")));
            this.btnAdicionarPermissao.Location = new System.Drawing.Point(12, 19);
            this.btnAdicionarPermissao.Name = "btnAdicionarPermissao";
            this.btnAdicionarPermissao.Size = new System.Drawing.Size(25, 23);
            this.btnAdicionarPermissao.TabIndex = 22;
            this.btnAdicionarPermissao.UseVisualStyleBackColor = true;
            this.btnAdicionarPermissao.Click += new System.EventHandler(this.btnAdicionarPermissao_Click);
            // 
            // dgvPermissoes
            // 
            this.dgvPermissoes.AllowUserToAddRows = false;
            this.dgvPermissoes.AllowUserToOrderColumns = true;
            this.dgvPermissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.modulo,
            this.recurso});
            this.dgvPermissoes.Location = new System.Drawing.Point(12, 48);
            this.dgvPermissoes.MultiSelect = false;
            this.dgvPermissoes.Name = "dgvPermissoes";
            this.dgvPermissoes.ReadOnly = true;
            this.dgvPermissoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissoes.Size = new System.Drawing.Size(455, 273);
            this.dgvPermissoes.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // modulo
            // 
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.Width = 150;
            // 
            // recurso
            // 
            this.recurso.HeaderText = "Recurso";
            this.recurso.Name = "recurso";
            this.recurso.Width = 245;
            // 
            // frmCadGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Grupo de Usuários";
            this.Load += new System.EventHandler(this.frmCadUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton radInativo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPermissoes;
        private System.Windows.Forms.Button btnExcluirPermissao;
        private System.Windows.Forms.Button btnAdicionarPermissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn recurso;
    }
}