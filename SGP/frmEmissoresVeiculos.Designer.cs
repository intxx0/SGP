namespace Controle_balaca
{
    partial class frmEmissoresVeiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmissoresVeiculos));
            this.dgvVeiculosEmissores = new System.Windows.Forms.DataGridView();
            this.cmsVeiculosEmissores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNovoEmissor = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculosEmissores)).BeginInit();
            this.cmsVeiculosEmissores.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVeiculosEmissores
            // 
            this.dgvVeiculosEmissores.AllowUserToAddRows = false;
            this.dgvVeiculosEmissores.AllowUserToOrderColumns = true;
            this.dgvVeiculosEmissores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeiculosEmissores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nome,
            this.tipo,
            this.placa});
            this.dgvVeiculosEmissores.ContextMenuStrip = this.cmsVeiculosEmissores;
            this.dgvVeiculosEmissores.Location = new System.Drawing.Point(12, 55);
            this.dgvVeiculosEmissores.MultiSelect = false;
            this.dgvVeiculosEmissores.Name = "dgvVeiculosEmissores";
            this.dgvVeiculosEmissores.ReadOnly = true;
            this.dgvVeiculosEmissores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeiculosEmissores.Size = new System.Drawing.Size(445, 284);
            this.dgvVeiculosEmissores.TabIndex = 13;
            // 
            // cmsVeiculosEmissores
            // 
            this.cmsVeiculosEmissores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirToolStripMenuItem});
            this.cmsVeiculosEmissores.Name = "cmsUsuarios";
            this.cmsVeiculosEmissores.Size = new System.Drawing.Size(109, 26);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excluirToolStripMenuItem.Image")));
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.excluirToolStripMenuItem.Text = "E&xcluir";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 354);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(144, 13);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Nenhum registro encontrado.";
            // 
            // btnNovoEmissor
            // 
            this.btnNovoEmissor.Image = ((System.Drawing.Image)(resources.GetObject("btnNovoEmissor.Image")));
            this.btnNovoEmissor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoEmissor.Location = new System.Drawing.Point(12, 13);
            this.btnNovoEmissor.Name = "btnNovoEmissor";
            this.btnNovoEmissor.Size = new System.Drawing.Size(94, 26);
            this.btnNovoEmissor.TabIndex = 14;
            this.btnNovoEmissor.Text = "&Adicionar";
            this.btnNovoEmissor.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nome
            // 
            this.nome.HeaderText = "Veículo";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            this.nome.Width = 190;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // placa
            // 
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            // 
            // frmEmissoresVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 380);
            this.Controls.Add(this.dgvVeiculosEmissores);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnNovoEmissor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmissoresVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veículos de Emissores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculosEmissores)).EndInit();
            this.cmsVeiculosEmissores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVeiculosEmissores;
        private System.Windows.Forms.ContextMenuStrip cmsVeiculosEmissores;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNovoEmissor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
    }
}