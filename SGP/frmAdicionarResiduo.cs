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
    public partial class frmAdicionarResiduo : Form
    {

        public string emiCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadEmissor caller;

        public frmAdicionarResiduo()
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
                if (cmbTipo.Items.Count > 0)
                    cmbTipo.SelectedIndex = 0;
            }

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "EXEC PRC_GET_RESIDUOS_BY_NOME_TIPO '" + cmbTipo.Text + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbResiduo.Items.Clear();

            while (dr.Read())
            {
                cmbResiduo.Items.Add(dr["RES_NOME"].ToString());
            }

            cmbResiduo.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string sSql = "", errors = "", resCodigo;

            OleDbDataReader dr;

            // Validate

            if (cmbTipo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Tipo\"\n";
            }

            if (cmbResiduo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Resíduo\"\n";
            }

            sSql = "EXEC PRC_GET_EMISSOR_RESIDUO_BY_NOME '" + emiCodigo + "','" + cmbResiduo.Text.ToString() + "'";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                errors += " - Resíduo já adicionado\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                dr = cnn.Oledb_Pesquisa("EXEC PRC_GET_RESIDUO_BY_NOME '" + cmbResiduo.Text.ToString() + "'");

                dr.Read();
                resCodigo = dr["RES_CODIGO"].ToString();

                cnn.Oledb_Grava("EXEC PRC_EMISSOR_RESIDUO_SAVE '" + emiCodigo + "', '" + resCodigo + "'");

                this.caller.populateResiduos();

                Close();

            }

        }


    }
}
