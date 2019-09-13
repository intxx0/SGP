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
    public partial class frmCadPesagem : Form
    {

        public string pesCodigo = null, emiCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        private bool _lockChangeEvent = false;

        public frmCadPesagem()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string veiCodigo = null, resCodigo = null, errors = "";
            string uniCodigo = Session.Session.uniCodigo;
            string usuCodigo = Session.Session.usuCodigo;
            double pesoBruto = 0, pesoTara = 0, pesoLiquido = 0;
            string pesObservacoes = null, pesStatus = null, checkSum = null;

            string dtPattern = @"yyyy-MM-ddTHH:mm:ss";

            DataSet ds = null;
            DataTableReader dr = null;

            // Validate

            if (cmbEmissor.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Emissor\"\n";
            }

            if (cmbVeiculo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Veículo\"\n";
            }

            if (cmbResiduo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Resíduo\"\n";
            }

            if (numPesoBruto.Value < 1)
            {
                errors += " - Preencha o campo \"Peso Bruto\"\n";
            }

            if (numPesoTara.Value < 1)
            {
                errors += " - Preencha o campo \"Peso Tara\"\n";
            }

            if (numPesoLiquido.Value < 1)
            {
                errors += " - Preencha o campo \"Peso Líquido\"\n";
            }

            if (txtObservacoes.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Observações\"\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_VEICULO_BY_PLACA '" + cmbVeiculo.Text.ToString() + "'");
                dr = ds.CreateDataReader();

                if (dr.Read())
                {
                    veiCodigo = dr["VEI_CODIGO"].ToString();
                }
                else
                {
                    MessageBox.Show("Veículo não encontrado pela placa informada.");
                    return;
                }

                ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_RESIDUO_BY_NOME '" + cmbResiduo.Text.ToString() + "'");
                dr = ds.CreateDataReader();

                if (dr.Read())
                {
                    resCodigo = dr["RES_CODIGO"].ToString();
                }
                else
                {
                    MessageBox.Show("Resíduo não encontrado pelo nome informado.");
                    return;
                }

                DateTime dataEntrada    = dtEntrada.Value;
                DateTime dataSaida      = dtSaida.Value;

                pesoBruto   = (double)numPesoBruto.Value;
                pesoTara    = (double)numPesoTara.Value;
                pesoLiquido = (double)numPesoLiquido.Value;

                pesObservacoes = txtObservacoes.Text.ToString();

                pesStatus = "3";

                checkSum = cFuncoes.cFuncoes.CreateMD5Hash((pesCodigo + Convert.ToString((uniCodigo + usuCodigo + veiCodigo + resCodigo + emiCodigo)) +
                                                           Convert.ToString(pesoBruto + pesoLiquido + pesoTara) + pesStatus));

                string sql = "EXEC PRC_PESAGEM_SAVE " + (pesCodigo == null ? "NULL" : "'" + pesCodigo + "'") + ", " + uniCodigo + ", " + usuCodigo + ", " + veiCodigo + ", " +
                             resCodigo + ", " + emiCodigo + ", " + Convert.ToString(pesoBruto) + ", " + Convert.ToString(pesoLiquido) + ", " +
                             Convert.ToString(pesoTara) + ", " + (dataEntrada != null ? "'" + dataEntrada.ToString(dtPattern) + ".000'" : "NULL") + ", " +
                             (dataSaida != null ? "'" + dataSaida.ToString(dtPattern) + ".000'" : "NULL") + ", '" + pesObservacoes + "', " + pesStatus + ", '" + checkSum + "'";
                cnn.Oledb_Grava(sql);

                Close();

                frmPesagens.GetChild().Focus();
                frmPesagens.GetChild().loadPesagens();

            }

        }

        private void cmbEmissor_TextChanged(object sender, EventArgs e)
        {

            if (_lockChangeEvent == false)
            {

                _lockChangeEvent = true;
                cmbEmissor.TextChanged -= this.cmbEmissor_TextChanged;

                int i = 0;
                string search = cmbEmissor.Text.ToString(), lastText = "";
                string sSql = "EXEC PRC_EMISSORES_SEARCH '%" + search + "%', NULL";

                OleDbDataReader dr = cnn.Oledb_Pesquisa(sSql);

                cmbEmissor.Items.Clear();

                while (dr.Read())
                {
                    lastText = dr["EMI_NOME_FANTASIA"].ToString();
                    cmbEmissor.Items.Add(lastText);
                    i++;
                }

                if (i > 1)
                {
                    cmbEmissor.DroppedDown = true;
                    cmbEmissor.Text = search;
                }
                else
                {
                    cmbEmissor.DroppedDown = false;
                    if (lastText != "")
                        cmbEmissor.Text = lastText;
                }

                cmbEmissor.SelectionStart = cmbEmissor.Text.Length;
                cmbEmissor.TextChanged += this.cmbEmissor_TextChanged;

                _lockChangeEvent = false;

            }

        }

        private void cmbEmissor_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_EMISSOR_BY_NOME '" + cmbEmissor.Text.ToString() + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            dr.Read();

            emiCodigo = dr["EMI_CODIGO"].ToString();

            // Popula comboboxes com veículos relacionados com o emissor

            sql = "EXEC PRC_GET_EMISSORES_VEICULOS '" + emiCodigo + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbVeiculo.Items.Clear();

            while (dr.Read())
            {
                cmbVeiculo.Items.Add(dr["PLACA"].ToString());
            }

            // Popula comboboxes com resíduos relacionados com o emissor

            sql = "EXEC PRC_GET_EMISSORES_RESIDUOS '" + emiCodigo + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbResiduo.Items.Clear();

            while (dr.Read())
            {
                cmbResiduo.Items.Add(dr["RESIDUO"].ToString());
            }

        }

        public void populateComboBoxes()
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_EMISSORES_SEARCH NULL, NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbEmissor.Items.Clear();

            while (dr.Read())
            {
                cmbEmissor.Items.Add(dr["EMI_NOME_FANTASIA"].ToString());
            }

            /*sql = "EXEC PRC_VEICULOS_SEARCH NULL, NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbVeiculo.Items.Clear();

            while (dr.Read())
            {
                cmbVeiculo.Items.Add(dr["VEI_PLACA"].ToString());
            }

            sql = "EXEC PRC_RESIDUOS_SEARCH NULL, NULL";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbResiduo.Items.Clear();

            while (dr.Read())
            {
                cmbResiduo.Items.Add(dr["RES_NOME"].ToString());
            }*/

        }

        public void populateData(string codigo = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                pesCodigo = codigo;

                sql = "EXEC PRC_GET_PESAGEM_BY_ID '" + pesCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if (dr.Read())
                {

                    cmbEmissor.Text = dr["EMISSOR"].ToString();

                    this.populateComboBoxes();

                    cmbVeiculo.Text = dr["PLACA"].ToString();
                    cmbResiduo.Text = dr["RESIDUO"].ToString();

                    dtEntrada.Value = DateTime.Parse(dr["PES_DATA_ENTRADA"].ToString());
                    dtSaida.Value = DateTime.Parse(dr["PES_DATA_SAIDA"].ToString());

                    numPesoBruto.Text = dr["PES_PESO_BRUTO"].ToString();
                    numPesoTara.Text = dr["PES_PESO_TARA"].ToString();
                    numPesoLiquido.Text = dr["PES_PESO_LIQUIDO"].ToString();

                    txtObservacoes.Text = dr["PES_OBSERVACOES"].ToString();

                }

            }

        }

        private void frmCadPesagem_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;

        }

    }
}
