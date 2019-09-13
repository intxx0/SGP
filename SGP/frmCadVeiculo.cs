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
    public partial class frmCadVeiculo : Form
    {

        public string veiCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadVeiculo()
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

            radAtivo.Checked = true;

        }

        public void populateData(string codigo = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                veiCodigo = codigo;

                sql = "EXEC PRC_VEICULOS_SEARCH NULL, '" + veiCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if (dr.Read())
                {

                    txtNome.Text = dr["VEI_NOME"].ToString();

                    populateComboBox(dr["TIPO"].ToString());

                    txtPlaca.Text = dr["VEI_PLACA"].ToString();
                    txtTara.Text = dr["VEI_TARA"].ToString();

                    radAtivo.Checked = false;
                    radInativo.Checked = false;

                    if (Convert.ToBoolean(dr["VEI_STATUS"]) == true)
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

            string veiTipo = null, veiStatus = null, sSql = "", errors = "";

            OleDbDataReader dr;

            // Validate

            if (txtNome.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Nome\"\n";
            }

            if (txtPlaca.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Placa\"\n";
            }

            if (txtPlaca.TextLength > 0)
            {
                Regex regex = new Regex(@"^(((\w){3})+)(((\d){4})+)$");
                Match match = regex.Match(txtPlaca.Text);
                if (match.Success == false)
                {
                    errors += " - Placa com formato incorreto\n";
                }
            }

            sSql = "EXEC PRC_GET_VEICULO_BY_PLACA '" + txtPlaca.Text.ToString() + "'";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                if (veiCodigo == null || veiCodigo != dr["VEI_CODIGO"].ToString())
                    errors += " - Veículo já existente\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                sSql = "EXEC PRC_GET_VEICULO_TIPO_BY_NOME '" + cmbTipo.SelectedItem.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    veiTipo = dr["VET_CODIGO"].ToString();
                }
                else
                {
                    veiTipo = "0";
                }

                sSql = "EXEC PRC_VEICULO_SAVE ";

                if (veiCodigo != null)
                {
                    sSql += "'" + veiCodigo + "'";
                }
                else
                {
                    sSql += "NULL";
                }

                veiStatus = radAtivo.Checked == true ? "1" : "0";

                sSql += ", '" + veiTipo + "', '" + txtNome.Text.ToString() + "', '" + txtPlaca.Text.ToString() + "', '" + txtTara.Text.ToUpper() + "', '" + veiStatus + "'";

                cnn.Oledb_Grava(sSql);

                Close();

                frmVeiculos.GetChild().Focus();

            }

        }

        private void frmCadVeiculo_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;

        }


    }

}
