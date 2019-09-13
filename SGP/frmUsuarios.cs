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
    public partial class frmUsuarios : Form
    {

        private static frmUsuarios _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmUsuarios()
        {
            InitializeComponent();

            //loadUsuarios();

        }

        public static frmUsuarios GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmUsuarios();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadUsuarios(string search = null)
        {

            int i = 0, n;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_USUARIOS_SEARCH " + (search!=null?"'%" + search + "%'":"NULL") + ", NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dgvUsuarios.Rows.Clear();

            while (dr.Read())
            {

                dgvUsuarios.Rows.Add();
                dgvUsuarios.Rows[i].Cells["id"].Value = dr["USU_CODIGO"].ToString();
                dgvUsuarios.Rows[i].Cells["nome"].Value = dr["USU_NOME"].ToString();
                dgvUsuarios.Rows[i].Cells["unidade"].Value = dr["UNIDADE"].ToString();
                dgvUsuarios.Rows[i].Cells["email"].Value = dr["USU_EMAIL"].ToString();
                dgvUsuarios.Rows[i].Cells["login"].Value = dr["USU_LOGIN"].ToString();

                if (Convert.ToBoolean(dr["USU_STATUS"]))
                {
                    dgvUsuarios.Rows[i].Cells["status"].Value = "Ativo";
                }
                else
                {
                    dgvUsuarios.Rows[i].Cells["status"].Value = "Inativo";
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

            frmCadUsuario frm = new frmCadUsuario();
            frm.MdiParent = this.MdiParent;
            frm.populateComboBox();
            frm.Show();

        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {

            frmGrupos frm = frmGrupos.GetChild((SGP.mdiPrincipal)this.MdiParent);
            frm.Show();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadUsuario frm = new frmCadUsuario();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Usuário";
            frm.populateData(dgvUsuarios.Rows[dgvUsuarios.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void frmUsuarios_Enter(object sender, EventArgs e)
        {

            loadUsuarios();

        }

        private void frmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {

            Visible = false;
            e.Cancel = true;

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
                loadUsuarios();
            else
                loadUsuarios(txtSearch.Text.ToString());

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja excluir este usuário?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_USUARIO '" + dgvUsuarios.Rows[dgvUsuarios.SelectedRows[0].Index].Cells["Id"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                loadUsuarios(null);

            }

        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {

            frmCadUsuario frm = new frmCadUsuario();
            frm.MdiParent = this.MdiParent;
            frm.populateData(dgvUsuarios.Rows[dgvUsuarios.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
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
