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
    public partial class frmGrupos : Form
    {

        private static frmGrupos _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmGrupos()
        {
            InitializeComponent();

            //loadGrupos();

        }

        public static frmGrupos GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmGrupos();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadGrupos(string search = null)
        {

            int i = 0, n;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GRUPOS_SEARCH " + (search!=null?"'%" + search + "%'":"NULL") + ", NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dgvGrupos.Rows.Clear();

            while (dr.Read())
            {

                dgvGrupos.Rows.Add();
                dgvGrupos.Rows[i].Cells["id"].Value = dr["GRU_CODIGO"].ToString();
                dgvGrupos.Rows[i].Cells["nome"].Value = dr["GRU_NOME"].ToString();

                if (Convert.ToBoolean(dr["GRU_STATUS"]))
                {
                    dgvGrupos.Rows[i].Cells["status"].Value = "Ativo";
                }
                else
                {
                    dgvGrupos.Rows[i].Cells["status"].Value = "Inativo";
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

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {

            frmCadGrupo frm = new frmCadGrupo();
            frm.MdiParent = this.MdiParent;
            frm.populateData();
            frm.Show();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadGrupo frm = new frmCadGrupo();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Grupo de Usuários";
            frm.populateData(dgvGrupos.Rows[dgvGrupos.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            /*if (txtSearch.TextLength < 1)
            {
                MessageBox.Show("Especifique um termo para pesquisa.", "Erro");
                txtSearch.Focus();
                return;
            }*/

            if (txtSearch.TextLength < 1)
                loadGrupos();
            else
                loadGrupos(txtSearch.Text.ToString());

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja excluir este grupo?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_GRUPO '" + dgvGrupos.Rows[dgvGrupos.SelectedRows[0].Index].Cells["Id"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                loadGrupos(null);

            }

        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {

            frmCadGrupo frm = new frmCadGrupo();
            frm.MdiParent = this.MdiParent;
            frm.populateData(dgvGrupos.Rows[dgvGrupos.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void frmGrupos_Enter(object sender, EventArgs e)
        {

            loadGrupos();

        }

        private void frmGrupos_FormClosing(object sender, FormClosingEventArgs e)
        {

            Visible = false;
            e.Cancel = true;

        }

        private void frmGrupos_Load(object sender, EventArgs e)
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

        }
    }
}
