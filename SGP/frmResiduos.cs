using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGP
{
    public partial class frmResiduos : Form
    {

        private static frmResiduos _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmResiduos()
        {
            InitializeComponent();
        }

        public static frmResiduos GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmResiduos();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadResiduos(string search = null)
        {

            int i = 0;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_RESIDUOS_SEARCH " + (search != null ? "'" + search + "'" : "NULL") + ", NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dgvResiduos.Rows.Clear();

            while (dr.Read())
            {

                dgvResiduos.Rows.Add();
                dgvResiduos.Rows[i].Cells["id"].Value = dr["RES_CODIGO"].ToString();
                dgvResiduos.Rows[i].Cells["nome"].Value = dr["RES_NOME"].ToString();
                dgvResiduos.Rows[i].Cells["tipo"].Value = dr["TIPO"].ToString();

                if (Convert.ToBoolean(dr["RES_STATUS"]))
                {
                    dgvResiduos.Rows[i].Cells["status"].Value = "Ativo";
                }
                else
                {
                    dgvResiduos.Rows[i].Cells["status"].Value = "Inativo";
                }

                i++;

            }

            if (i < 1)
            {
                lblTotal.Text = "Nenhum registro encontrado.";
            }
            else
            {
                lblTotal.Text = Convert.ToString(i) + " registro" + (i > 0 ? "s" : "") + " encontrado" + (i > 0 ? "s" : "");
            }

        }

        private void btnNovoResiduo_Click(object sender, EventArgs e)
        {

            frmCadResiduo frm = new frmCadResiduo();
            frm.MdiParent = this.MdiParent;
            frm.populateComboBox();
            frm.Show();

        }

        private void frmResiduos_Enter(object sender, EventArgs e)
        {

            loadResiduos();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadResiduo frm = new frmCadResiduo();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Resíduo";
            frm.populateData(dgvResiduos.Rows[dgvResiduos.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja excluir este resíduo?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_RESIDUO '" + dgvResiduos.Rows[dgvResiduos.SelectedRows[0].Index].Cells["Id"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                loadResiduos(null);

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.TextLength < 1)
                loadResiduos();
            else
                loadResiduos(txtSearch.Text.ToString());

        }

        private void dgvResiduos_DoubleClick(object sender, EventArgs e)
        {

            editarToolStripMenuItem_Click(sender, e);

        }

        private void frmResiduos_FormClosing(object sender, FormClosingEventArgs e)
        {

            Visible = false;
            e.Cancel = true;

        }

        private void frmResiduos_Load(object sender, EventArgs e)
        {

            string gruCodigo = Session.Session.gruCodigo.ToString();

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (Acl.Acl.Check(c.Tag.ToString(), gruCodigo) == false)
                    {
                        c.Visible = false;
                    }
                }
                if (c is DataGridView)
                {
                    foreach (ToolStripItem item in c.ContextMenuStrip.Items)
                    {
                        if (Acl.Acl.Check(item.Tag.ToString(), gruCodigo) == false)
                        {
                            item.Visible = false;
                        }
                    }
                }

            }

            this.WindowState = FormWindowState.Normal;

        }

    }
}
