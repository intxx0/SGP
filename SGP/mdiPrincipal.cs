using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SGP
{
    public partial class mdiPrincipal : Form
    {
        //cControleBalanca.cControleBalanca cb = new cControleBalanca.cControleBalanca();
        int iBalanca = 1;
        bool isClosing = false;

        cConexao.cConexao cnn = new cConexao.cConexao();

        public mdiPrincipal()
        {

            InitializeComponent();

            this.toolStripStatusLabel2.Text = Session.Session.Nome;
            this.toolStripStatusLabel4.Text = Session.Session.Unidade;

            cnn.Oledb_Grava("EXEC PRC_EMISSORES_FLUSH");
            cnn.Oledb_Grava("EXEC PRC_GRUPOS_FLUSH");

        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose(); 
        }

        private void mnSaida_Click(object sender, EventArgs e)
        {
            frmSaida frm = new frmSaida();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mdiPrincipal_Load(object sender, EventArgs e)
        {

            /* ACL para menus */

            for(int i = 0; i < mnPrincipal.Items.Count; i++)
            {
                ToolStripMenuItem menu = mnPrincipal.Items[i] as ToolStripMenuItem;

                bool visible = false;

                if (menu.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem item in menu.DropDownItems)
                    {
                        if (Acl.Acl.Check(item.Tag.ToString(), Session.Session.gruCodigo.ToString()) == false)
                        {
                            item.Visible = false;
                        }
                        else
                        {
                            visible = true;
                        }
                    }
                }

                menu.Visible = visible;
            }


            /* ACL para botões */

            int marginLeft = 7;

            foreach (Control c in this.Controls)
            {
                foreach (Control component in c.Controls)
                {
                    if (component is Button)
                    {
                        if (Acl.Acl.Check(component.Tag.ToString(), Session.Session.gruCodigo.ToString()) == false)
                        {
                            component.Visible = false;
                        }
                        else
                        {
                            component.Location = new Point(marginLeft, 6);
                            marginLeft += 62;
                        }
                    }
                }
            }

        }

        private void mdiPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.isClosing)
            //{
                Application.Exit();
            //}
        }

        private void pesagemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.btnPesagens_Click(sender, e);
            
        }

        private void mnPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

            frmUsuarios frm = frmUsuarios.GetChild(this);
            frm.Show();

        }

        private void mdiPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!this.isClosing) {
                if (MessageBox.Show("Você realmente deseja sair?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.isClosing = true;
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {

            frmVeiculos frm = frmVeiculos.GetChild(this);
            frm.Show();

        }

        private void btnEmissores_Click(object sender, EventArgs e)
        {

            frmEmissores frm = frmEmissores.GetChild(this);
            frm.Show();

        }

        private void btnResiduos_Click(object sender, EventArgs e)
        {

            frmResiduos frm = frmResiduos.GetChild(this);
            frm.Show();

        }

        private void btnPesagem_Click(object sender, EventArgs e)
        {

            frmPesagem frm = frmPesagem.GetChild(this);
            frm.populateComboBoxes();
            frm.initClock();
            //frm.initScale();
            frm.Show();

        }

        private void btnPesagens_Click(object sender, EventArgs e)
        {

            frmPesagens frm = frmPesagens.GetChild(this);
            frm.Show();

        }

        private void pesagemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.btnPesagem_Click(sender, e);
        }

        private void pesagensRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnPesagens_Click(sender, e);
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {

            frmRelatorios frm = frmRelatorios.GetChild(this);
            frm.Show();

        }

        private void analiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnUsuarios_Click(sender, e);
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnVeiculos_Click(sender, e);
        }

        private void emissoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnEmissores_Click(sender, e);
        }

        private void resíduosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnResiduos_Click(sender, e);
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmGrupos frm = frmGrupos.GetChild(this);
            frm.Show();

        }

    }
}
