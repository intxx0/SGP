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
    public partial class frmVeiculos : Form
    {

        private static frmVeiculos _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmVeiculos()
        {
            InitializeComponent();
        }

        public static frmVeiculos GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmVeiculos();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadVeiculos(string search = null)
        {

            int i = 0;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_VEICULOS_SEARCH " + (search != null ? "'" + search + "'" : "NULL") + ", NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dgvVeiculos.Rows.Clear();

            while (dr.Read())
            {

                dgvVeiculos.Rows.Add();
                dgvVeiculos.Rows[i].Cells["id"].Value = dr["VEI_CODIGO"].ToString();
                dgvVeiculos.Rows[i].Cells["nome"].Value = dr["VEI_NOME"].ToString();
                dgvVeiculos.Rows[i].Cells["tipo"].Value = dr["TIPO"].ToString();
                dgvVeiculos.Rows[i].Cells["placa"].Value = dr["VEI_PLACA"].ToString();
                dgvVeiculos.Rows[i].Cells["tara"].Value = dr["VEI_TARA"].ToString();

                if (Convert.ToBoolean(dr["VEI_STATUS"]))
                {
                    dgvVeiculos.Rows[i].Cells["status"].Value = "Ativo";
                }
                else
                {
                    dgvVeiculos.Rows[i].Cells["status"].Value = "Inativo";
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

        private void btnNovoVeiculo_Click(object sender, EventArgs e)
        {

            frmCadVeiculo frm = new frmCadVeiculo();
            frm.MdiParent = this.MdiParent;
            frm.populateComboBox();
            frm.Show();

        }

        private void frmVeiculos_Enter(object sender, EventArgs e)
        {

            loadVeiculos();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadVeiculo frm = new frmCadVeiculo();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Veículo";
            frm.populateData(dgvVeiculos.Rows[dgvVeiculos.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja excluir este veículo?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_VEICULO '" + dgvVeiculos.Rows[dgvVeiculos.SelectedRows[0].Index].Cells["Id"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                loadVeiculos(null);

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.TextLength < 1)
                loadVeiculos();
            else
                loadVeiculos(txtSearch.Text.ToString());

        }

        private void dgvVeiculos_DoubleClick(object sender, EventArgs e)
        {

            editarToolStripMenuItem_Click(sender, e);

        }

        private void frmVeiculos_FormClosing(object sender, FormClosingEventArgs e)
        {

            Visible = false;
            e.Cancel = true;

        }

        private void frmVeiculos_Load(object sender, EventArgs e)
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
