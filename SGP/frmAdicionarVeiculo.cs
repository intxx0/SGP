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
    public partial class frmAdicionarVeiculo : Form
    {

        public string emiCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadEmissor caller;

        public frmAdicionarVeiculo()
        {
            InitializeComponent();
        }

        public void populateComboBox(string item = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_VEICULOS_TIPOS";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbTipo.Items.Clear();

            while (dr.Read())
            {
                cmbTipo.Items.Add(dr["VET_NOME"].ToString());
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
            string sql = "EXEC PRC_GET_VEICULOS_BY_TIPO '" + cmbTipo.Text + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbVeiculo.Items.Clear();

            while (dr.Read())
            {
                cmbVeiculo.Items.Add(dr["VEI_PLACA"].ToString() + " - " + dr["VEI_NOME"].ToString());
            }

            cmbVeiculo.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string sSql = "", errors = "", veiCodigo;
            string[] parts;

            OleDbDataReader dr;

            // Validate

            if (cmbTipo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Tipo\"\n";
            }

            if (cmbVeiculo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Veículo\"\n";
            }

            parts = cmbVeiculo.Text.Split('-');

            sSql = "EXEC PRC_GET_EMISSOR_VEICULO_BY_PLACA '" + emiCodigo + "','" + parts[0].Trim().ToString() + "'";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                errors += " - Veículo já adicionado\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                dr = cnn.Oledb_Pesquisa("EXEC PRC_GET_VEICULO_BY_PLACA '" + parts[0].Trim().ToString() + "'");

                dr.Read();
                veiCodigo = dr["VEI_CODIGO"].ToString();

                cnn.Oledb_Grava("EXEC PRC_EMISSOR_VEICULO_SAVE '" + emiCodigo + "', '" + veiCodigo + "'");

                this.caller.populateVeiculos();

                Close();

            }

        }


    }
}
