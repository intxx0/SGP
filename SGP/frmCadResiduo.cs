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
    public partial class frmCadResiduo : Form
    {

        public string resCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadResiduo()
        {
            InitializeComponent();
        }

        public void populateComboBox(string item = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_RESIDUOS_TIPOS";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbTipo.Items.Clear();

            while (dr.Read())
            {
                cmbTipo.Items.Add(dr["RET_NOME"].ToString());
            }

            if (item != null)
            {
                cmbTipo.SelectedIndex = cmbTipo.Items.IndexOf(item);
            }
            else
            {
                if(cmbTipo.Items.Count>0)
                    cmbTipo.SelectedIndex = 0;
            }

            radAtivo.Checked = true;

        }

        public void populateData(string codigo = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                resCodigo = codigo;

                sql = "EXEC PRC_RESIDUOS_SEARCH NULL, '" + resCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if (dr.Read())
                {

                    txtNome.Text = dr["RES_NOME"].ToString();

                    populateComboBox(dr["TIPO"].ToString());

                    radAtivo.Checked = false;
                    radInativo.Checked = false;

                    if (Convert.ToBoolean(dr["RES_STATUS"]) == true)
                        radAtivo.Checked = true;
                    else
                        radInativo.Checked = true;

                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string resTipo = null, resStatus = null, sSql = "", errors = "";

            OleDbDataReader dr;

            // Validate

            if (txtNome.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Nome\"\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                sSql = "EXEC PRC_GET_RESIDUO_TIPO_BY_NOME '" + cmbTipo.SelectedItem.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    resTipo = dr["RET_CODIGO"].ToString();
                }
                else
                {
                    resTipo = "0";
                }

                sSql = "EXEC PRC_RESIDUO_SAVE ";

                if (resCodigo != null)
                {
                    sSql += "'" + resCodigo + "'";
                }
                else
                {
                    sSql += "NULL";
                }

                resStatus = radAtivo.Checked == true ? "1" : "0";

                sSql += ", '" + resTipo + "', '" + txtNome.Text.ToString() + "', '" + resStatus + "'";

                cnn.Oledb_Grava(sSql);

                Close();

                frmResiduos.GetChild().Focus();

            }

        }

        private void frmCadResiduo_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;

        }


    }
}
