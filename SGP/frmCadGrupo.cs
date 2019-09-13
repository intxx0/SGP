using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace SGP
{
    public partial class frmCadGrupo : Form
    {

        public string gruCodigo = null;
        public bool change = false;
        private bool saved = false;

        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadGrupo()
        {
            InitializeComponent();
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            radAtivo.Checked = true;

        }

        public void populateData(string codigo = null)
        {

            DataSet         ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                gruCodigo = codigo;

                sql = "EXEC PRC_GRUPOS_SEARCH NULL, '" + gruCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if (dr.Read())
                {

                    txtNome.Text = dr["GRU_NOME"].ToString();

                    radAtivo.Checked = false;
                    radInativo.Checked = false;

                    if (Convert.ToBoolean(dr["GRU_STATUS"]) == true)
                        radAtivo.Checked = true;
                    else
                        radInativo.Checked = true;

                    populatePermissoes();

                }

            }
            else
            {

                radAtivo.Checked = true;

                sql = "EXEC PRC_GRUPO_SAVE NULL, '', '-1'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                dr.Read();

                gruCodigo = dr["GRU_CODIGO"].ToString();

            }

        }

        public void populatePermissoes()
        {

            int i = 0;

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_PERMISSOES_BY_ID_GRUPO '" + gruCodigo + "'");
            dr = ds.CreateDataReader();

            dgvPermissoes.Rows.Clear();

            while (dr.Read())
            {

                dgvPermissoes.Rows.Add();
                dgvPermissoes.Rows[i].Cells["id"].Value = dr["PER_CODIGO"].ToString();
                dgvPermissoes.Rows[i].Cells["modulo"].Value = dr["MODULO"].ToString();
                dgvPermissoes.Rows[i].Cells["recurso"].Value = dr["RECURSO"].ToString();

                i++;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string gruStatus = null, sSql = "", errors = "";

            OleDbDataReader dr;

            // Validate

            if (txtNome.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Nome\"\n";
            }

            if (errors.ToString()!="")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                sSql = "EXEC PRC_GRUPO_SAVE ";

                if (gruCodigo != null)
                {
                    sSql += "'" + gruCodigo + "'";
                }
                else
                {
                    sSql += "NULL";
                }

                gruStatus = radAtivo.Checked == true ? "1" : "0";

                sSql += ", '" + txtNome.Text.ToString() + "', '" + gruStatus + "'";

                cnn.Oledb_Grava(sSql);

                saved = true;

                Close();

                frmGrupos.GetChild().Focus();

            }

        }

        private void radInativo_Click(object sender, EventArgs e)
        {
            radInativo.Checked = true;
            radAtivo.Checked = false;
        }

        private void radAtivo_Click(object sender, EventArgs e)
        {
            radAtivo.Checked = true;
            radInativo.Checked = false;
        }

        private void btnAdicionarPermissao_Click(object sender, EventArgs e)
        {

            frmAdicionarPermissao frm = new frmAdicionarPermissao();
            frm.populateComboBox();
            frm.gruCodigo = gruCodigo;
            frm.caller = this;
            frm.Show();

        }

        private void btnExcluirPermissao_Click(object sender, EventArgs e)
        {


            if (dgvPermissoes.SelectedRows.Count < 1)
            {
                MessageBox.Show("Selecione um recurso para excluir.", "Erro");
                return;
            }

            if (MessageBox.Show("Você realmente deseja remover esta permissão?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cnn.Oledb_Grava("EXEC PRC_DELETE_PERMISSAO '" + dgvPermissoes.Rows[dgvPermissoes.SelectedRows[0].Index].Cells["id"].Value.ToString() + "'");
                populatePermissoes();
            }

        }
    }
}
