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
    public partial class frmAdicionarPermissao : Form
    {

        public string gruCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadGrupo caller;

        public frmAdicionarPermissao()
        {
            InitializeComponent();
        }

        public void populateComboBox(string item = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_MODULOS";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbModulo.Items.Clear();

            while (dr.Read())
            {
                cmbModulo.Items.Add(dr["MOD_NOME"].ToString());
            }

            if (item != null)
            {
                cmbModulo.SelectedIndex = cmbModulo.Items.IndexOf(item);
            }
            else
            {
                if (cmbModulo.Items.Count > 0)
                    cmbModulo.SelectedIndex = 0;
            }

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "EXEC PRC_GET_RECURSOS_BY_MODULO '" + cmbModulo.Text + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbRecurso.Items.Clear();

            while (dr.Read())
            {
                cmbRecurso.Items.Add(dr["REC_NOME"].ToString());
            }

            cmbRecurso.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string sSql = "", errors = "", recCodigo;

            OleDbDataReader dr;

            // Validate

            if (cmbModulo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Módulo\"\n";
            }

            if (cmbRecurso.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Recurso\"\n";
            }

            sSql = "EXEC PRC_GET_PERMISSAO_BY_NOME_RECURSO '" + gruCodigo + "','" + cmbRecurso.Text.ToString() + "'";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                errors += " - Permissão já adicionada\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                dr = cnn.Oledb_Pesquisa("EXEC PRC_GET_RECURSO_BY_NOME '" + cmbRecurso.Text.ToString() + "'");

                dr.Read();
                recCodigo = dr["REC_CODIGO"].ToString();

                cnn.Oledb_Grava("EXEC PRC_PERMISSAO_SAVE '" + gruCodigo + "', '" + recCodigo + "'");

                this.caller.populatePermissoes();

                Close();

            }

        }


    }
}
