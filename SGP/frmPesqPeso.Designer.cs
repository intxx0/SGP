namespace Controle_balaca
{
    partial class frmPesqPeso
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskDtInic = new System.Windows.Forms.MaskedTextBox();
            this.mskDtFim = new System.Windows.Forms.MaskedTextBox();
            this.cboGerador = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(279, 120);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gerador";
            // 
            // mskDtInic
            // 
            this.mskDtInic.Location = new System.Drawing.Point(28, 79);
            this.mskDtInic.Mask = "00/00/0000";
            this.mskDtInic.Name = "mskDtInic";
            this.mskDtInic.Size = new System.Drawing.Size(83, 20);
            this.mskDtInic.TabIndex = 5;
            this.mskDtInic.ValidatingType = typeof(System.DateTime);
            // 
            // mskDtFim
            // 
            this.mskDtFim.Location = new System.Drawing.Point(117, 79);
            this.mskDtFim.Mask = "00/00/0000";
            this.mskDtFim.Name = "mskDtFim";
            this.mskDtFim.Size = new System.Drawing.Size(81, 20);
            this.mskDtFim.TabIndex = 6;
            this.mskDtFim.ValidatingType = typeof(System.DateTime);
            // 
            // cboGerador
            // 
            this.cboGerador.DisplayMember = "T";
            this.cboGerador.FormattingEnabled = true;
            this.cboGerador.Location = new System.Drawing.Point(30, 34);
            this.cboGerador.Name = "cboGerador";
            this.cboGerador.Size = new System.Drawing.Size(324, 21);
            this.cboGerador.TabIndex = 7;
            // 
            // frmPesqPeso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 158);
            this.Controls.Add(this.cboGerador);
            this.Controls.Add(this.mskDtFim);
            this.Controls.Add(this.mskDtInic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesqPeso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PESQUISA";
            this.Load += new System.EventHandler(this.frmPesqPeso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskDtInic;
        private System.Windows.Forms.MaskedTextBox mskDtFim;
        private System.Windows.Forms.ComboBox cboGerador;
    }
}