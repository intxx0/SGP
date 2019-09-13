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
    public partial class frmEmissores : Form
    {

        private static frmEmissores _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmEmissores()
        {
            InitializeComponent();
        }

        public static frmEmissores GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmEmissores();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadEmissores(string search = null)
        {

            int i = 0;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_EMISSORES_SEARCH " + (search != null ? "'" + search + "'" : "NULL") + ", NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dgvEmissores.Rows.Clear();

            while (dr.Read())
            {

                dgvEmissores.Rows.Add();
                dgvEmissores.Rows[i].Cells["id"].Value = dr["EMI_CODIGO"].ToString();
                dgvEmissores.Rows[i].Cells["nome"].Value = dr["EMI_NOME_FANTASIA"].ToString();
                dgvEmissores.Rows[i].Cells["cidade"].Value = dr["CIDADE"].ToString();
                dgvEmissores.Rows[i].Cells["uf"].Value = dr["UF"].ToString();

                if (Convert.ToBoolean(dr["EMI_STATUS"]))
                {
                    dgvEmissores.Rows[i].Cells["status"].Value = "Ativo";
                }
                else
                {
                    dgvEmissores.Rows[i].Cells["status"].Value = "Inativo";
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

        private void btnNovoEmissor_Click(object sender, EventArgs e)
        {

            frmCadEmissor frm = new frmCadEmissor();
            frm.MdiParent = this.MdiParent;
            frm.populateComboBox();
            frm.populateData();
            frm.Show();

        }

        private void frmEmissores_Enter(object sender, EventArgs e)
        {

            loadEmissores();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadEmissor frm = new frmCadEmissor();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Emissor";
            frm.populateData(dgvEmissores.Rows[dgvEmissores.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.change = true;
            frm.Show();

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja excluir este emissor?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_EMISSOR '" + dgvEmissores.Rows[dgvEmissores.SelectedRows[0].Index].Cells["Id"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                loadEmissores(null);

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.TextLength < 1)
                loadEmissores();
            else
                loadEmissores(txtSearch.Text.ToString());

        }

        private void dgvEmissores_DoubleClick(object sender, EventArgs e)
        {

            editarToolStripMenuItem_Click(sender, e);

        }

        private void frmEmissores_FormClosing(object sender, FormClosingEventArgs e)
        {

            Visible = false;
            e.Cancel = true;

        }

        private void frmEmissores_Load(object sender, EventArgs e)
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
