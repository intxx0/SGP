using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using SGP;

namespace SGP
{
    public partial class frmPesagem : Form
    {

        private static frmPesagem   _childInstance = null;
        private Thread              clkThread, sclThread;

        private bool                _lockChangeEvent = false;

        private string              emiCodigo = null;
        public string               pesCodigo = null;

        public string               weight = null;
        public static int           typeWeight = 1;

        cConexao.cConexao cnn = new cConexao.cConexao();

        public static frmPesagem GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmPesagem();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public frmPesagem()
        {
            InitializeComponent();
        }

        public void initClock()
        {
            Clock clk = new Clock();
            this.clkThread = new Thread(clk.init);

            this.clkThread.Start();
        }

        public void initScale()
        {
            Scale scl = new Scale();
            this.sclThread = new Thread(scl.init);

            this.sclThread.Start();
        }

        private void frmPesagem_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.clkThread.Suspend();

            if (this.sclThread!=null)
            {
                this.sclThread.Suspend();
            }

            this.resetForm();
            this.resetDisplay();

            btnSalvar.Visible = false;
            btnImprimir.Visible = false;
            btnIniciar.Visible = true;

            this.Visible = false;
            e.Cancel = true;

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

        private void cmbVeiculo_TextChanged(object sender, EventArgs e)
        {
            if (_lockChangeEvent == false && emiCodigo != null)
            {

                _lockChangeEvent = true;
                cmbVeiculo.TextChanged -= this.cmbVeiculo_TextChanged;

                int i = 0;
                string search = cmbVeiculo.Text.ToString(), lastText = "";
                string sSql = "EXEC PRC_EMISSORES_VEICULOS_SEARCH '" + emiCodigo + "', '%" + search + "%'";

                OleDbDataReader dr = cnn.Oledb_Pesquisa(sSql);

                cmbVeiculo.Items.Clear();

                while (dr.Read())
                {
                    lastText = dr["PLACA"].ToString();
                    cmbVeiculo.Items.Add(lastText);
                    i++;
                }

                if (i > 1)
                {
                    cmbVeiculo.DroppedDown = true;
                    cmbVeiculo.Text = search;
                }
                else
                {
                    cmbVeiculo.DroppedDown = false;
                    if(lastText!="")
                        cmbVeiculo.Text = lastText;
                }

                cmbVeiculo.SelectionStart = cmbVeiculo.Text.Length;
                cmbVeiculo.TextChanged += this.cmbVeiculo_TextChanged;

                _lockChangeEvent = false;

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

        public void populateData(string codigo)
        {

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_PESAGEM_BY_ID '" + codigo + "'");
            dr = ds.CreateDataReader();

            if (dr.Read())
            {
                pesCodigo = codigo;
                emiCodigo = dr["EMI_CODIGO"].ToString();

                frmPesagem.typeWeight = 2;

                txtPesoBruto.Text = dr["PES_PESO_BRUTO"].ToString();
                cmbEmissor.Text = dr["EMISSOR"].ToString();
                cmbVeiculo.Text = dr["PLACA"].ToString();
                cmbEmissor.Text = dr["EMISSOR"].ToString();
                cmbResiduo.Text = dr["RESIDUO"].ToString();
            }

        }

        private void frmPesagem_Load(object sender, EventArgs e)
        {

            this.resetForm();
            this.resetDisplay();

            this.populateComboBoxes();

            frmPesagem.typeWeight = 1;

            this.WindowState = FormWindowState.Normal;

        }

        private void cmbResiduo_TextChanged(object sender, EventArgs e)
        {

            if (_lockChangeEvent == false && emiCodigo != null)
            {

                _lockChangeEvent = true;
                cmbResiduo.TextChanged -= this.cmbResiduo_TextChanged;

                int i = 0;
                string search = cmbResiduo.Text.ToString(), lastText = "";
                string sSql = "EXEC PRC_EMISSORES_RESIDUOS_SEARCH '" + emiCodigo + "', '%" + search + "%'";

                OleDbDataReader dr = cnn.Oledb_Pesquisa(sSql);

                cmbResiduo.Items.Clear();

                while (dr.Read())
                {
                    lastText = dr["RESIDUO"].ToString();
                    cmbResiduo.Items.Add(lastText);
                    i++;
                }

                if (i > 1)
                {
                    cmbResiduo.DroppedDown = true;
                    cmbResiduo.Text = search;
                }
                else
                {
                    cmbResiduo.DroppedDown = false;
                    if (lastText != "")
                        cmbResiduo.Text = lastText;
                }

                cmbResiduo.SelectionStart = cmbResiduo.Text.Length;
                cmbResiduo.TextChanged += this.cmbResiduo_TextChanged;

                _lockChangeEvent = false;

            }

        }

        private void resetForm()
        {

            radTipoEntrada.Checked = true;
            radTipoSaida.Checked = false;

            cmbEmissor.Items.Clear();
            cmbEmissor.Text = "";

            cmbVeiculo.Items.Clear();
            cmbVeiculo.Text = "";

            cmbResiduo.Items.Clear();
            cmbResiduo.Text = "";

            btnImprimir.Visible = false;
            btnSalvar.Visible = false;
            btnIniciar.Visible = true;

            cmbEmissor.Focus();
            cmbResiduo.DroppedDown = false;

            cmbEmissor.ResetText();

        }

        private void resetDisplay()
        {

            txtPesoBruto.Text   = "000000";
            txtPesoLiquido.Text = "000000";
            txtPesoTara.Text    = "000000";

        }

        private string removeAccents(string str)
        {
            string s = str.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DestroyHandle();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            DataSet ds = null;
            DataTableReader dr = null;

            Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            //string pesCodigo = cFuncoes.cFuncoes.CreateMD5Hash(Convert.ToString(unixTimestamp) + Session.Session.usuCodigo);
            string uniCodigo = Session.Session.uniCodigo;
            string usuCodigo = Session.Session.usuCodigo;
            string veiCodigo = null, resCodigo = null;
            string status = null, checkSum;

            string dataEntrada = null, dataSaida = null;
            string dtPattern = @"yyyy-MM-ddTHH:mm:ss";

            DateTime dateTime = DateTime.Now;

            double pesoBruto = 0, pesoLiquido = 0, pesoTara = 0;

            if (radTipoEntrada.Checked == true)
            {

                dataEntrada = dateTime.ToString(dtPattern) + ".000";

                ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_PESAGEM_ENTRADA '" + emiCodigo + "', '" + cmbVeiculo.Text.ToString() + "'");
                dr = ds.CreateDataReader();

                if (dr.Read())
                {
                    MessageBox.Show("Entrada de veículo já registrada.\nFavor verificar o \"Tipo de Pesagem\".");
                    return;
                }

            }
            else
            {

                dataSaida = dateTime.ToString(dtPattern) + ".000";

                ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_PESAGEM_ENTRADA '" + emiCodigo + "', '" + cmbVeiculo.Text.ToString() + "'");
                dr = ds.CreateDataReader();

                if (dr.Read())
                {
                    pesCodigo = dr["PES_CODIGO"].ToString();
                }
                else
                {
                    MessageBox.Show("Entrada de veículo não registrada.\nFavor verificar o \"Tipo de Pesagem\".");
                    return;
                }

            }

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

            if (radTipoEntrada.Checked)
            {
                status = "0";
            }
            else
            {
                status = "1";
            }

            this.sclThread.Suspend();

            pesoBruto   = (double)Convert.ToDouble(txtPesoBruto.Text.ToString());
            pesoLiquido = (double)Convert.ToDouble(txtPesoLiquido.Text.ToString());
            pesoTara    = (double)Convert.ToDouble(txtPesoTara.Text.ToString());

            checkSum = cFuncoes.cFuncoes.CreateMD5Hash((pesCodigo + Convert.ToString((uniCodigo+usuCodigo+veiCodigo+resCodigo+emiCodigo)) + 
                                                       Convert.ToString(pesoBruto+pesoLiquido+pesoTara) + status));

            //MessageBox.Show("Código:\t\t" + pesCodigo + "\nCheckSum:\t" + checkSum);

            string sql = "EXEC PRC_PESAGEM_SAVE " + (pesCodigo==null?"NULL":"'" + pesCodigo + "'") + ", " + uniCodigo + ", " + usuCodigo + ", " + veiCodigo + ", " + 
                         resCodigo + ", " + emiCodigo + ", " + Convert.ToString(pesoBruto) + ", " + Convert.ToString(pesoLiquido) + ", " +
                         Convert.ToString(pesoTara) + ", " + (dataEntrada != null ? "'" + dataEntrada + "'" : "NULL") + ", " + 
                         (dataSaida != null ? "'" + dataSaida + "'" : "NULL") + ", '', " + status + ", '" + checkSum + "'";
            cnn.Oledb_Grava(sql);

            if (radTipoSaida.Checked)
            {
                btnSalvar.Visible = false;
                btnImprimir.Visible = true;
            }
            else
            {
                resetForm();
                resetDisplay();
            }

        }

        private void radTipoEntrada_Click(object sender, EventArgs e)
        {

            radTipoEntrada.Checked = true;
            radTipoSaida.Checked = false;

        }

        private void radTipoSaida_Click(object sender, EventArgs e)
        {

            frmPesagemSaida frm = new frmPesagemSaida();
            frm.populateVeiculos();
            frm.Show();

            frmPesagem.typeWeight = 2;

            radTipoEntrada.Checked = false;
            radTipoSaida.Checked = true;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DataSet ds;
            DataTableReader dr = null;

            int printerMode = Convert.ToInt16(ConfigurationManager.AppSettings["Printer_Mode"].ToString());
            string printerPort = ConfigurationManager.AppSettings["Printer_Port"].ToString();

            Printer printer = new Printer(printerMode, null, printerPort);

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_PESAGEM_BY_ID '" + pesCodigo + "'");
            dr = ds.CreateDataReader();

            if (dr.Read())
            {

                string dtPattern = @"dd/MM/yyyy HH:mm:ss";
                DateTime dateTime = DateTime.Parse(dr["PES_DATA_SAIDA"].ToString());

                printer.Add("PROACTIVA MEIO AMBIENTE BRASIL LTDA\n\n");
                printer.Add("Codigo:\t" + pesCodigo.PadLeft(5, '0') + "\n\n");
                printer.Add("Emissor:\t" + this.removeAccents(dr["EMISSOR"].ToString()) + "\n");
                printer.Add("Placa:\t\t" + dr["PLACA"].ToString() + "\n");
                printer.Add("Residuo:\t" + this.removeAccents(dr["RESIDUO"].ToString()) + "\n");
                printer.Add("Data/Hora:\t" + dateTime.ToString(dtPattern) + "\n\n");
                printer.Add("Peso bruto:\t" + dr["PES_PESO_BRUTO"].ToString() + "\n");
                printer.Add("Peso tara:\t" + dr["PES_PESO_TARA"].ToString() + "\n");
                printer.Add("Peso liquido:\t" + dr["PES_PESO_LIQUIDO"].ToString() + "\n\n");
                printer.Add("____________________________________________\n");
                printer.Add("Balanceiro - " + this.removeAccents(Session.Session.Nome) + "\n\n");
                printer.Add("____________________________________________\n");
                printer.Add("Assinatura Motorista\n\n");
                printer.Add(dr["PES_CHECKSUM"].ToString() + " PMA-BR" + "\n\n\n\n\n\n\n\n\n\n\n");

                printer.Print();

            }

            frmPesagem.typeWeight = 1;

            this.resetForm();
            this.resetDisplay();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            btnIniciar.Visible = false;
            btnSalvar.Visible = true;

            this.initScale();

        }

    }
}
