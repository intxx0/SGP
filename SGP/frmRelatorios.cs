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
    public partial class frmRelatorios : Form
    {

        private static frmRelatorios _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmRelatorios()
        {
            InitializeComponent();
        }

        public static frmRelatorios GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmRelatorios();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void populateComboBoxes()
        {

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_UNIDADES");
            dr = ds.CreateDataReader();

            cmbUnidade.Items.Clear();
            cmbUnidade.Items.Add(" - Todos - ");

            while (dr.Read())
            {
                cmbUnidade.Items.Add(dr["UNI_NOME"].ToString());
            }

            ds = cnn.DataSet_Pesquisa("EXEC PRC_USUARIOS_SEARCH NULL, NULL");
            dr = ds.CreateDataReader();

            cmbUsuario.Items.Clear();
            cmbUsuario.Items.Add(" - Todos - ");

            while (dr.Read())
            {
                cmbUsuario.Items.Add(dr["USU_NOME"].ToString());
            }

            ds = cnn.DataSet_Pesquisa("EXEC PRC_EMISSORES_SEARCH NULL, NULL");
            dr = ds.CreateDataReader();

            cmbEmissor.Items.Clear();
            cmbEmissor.Items.Add(" - Todos - ");

            while (dr.Read())
            {
                cmbEmissor.Items.Add(dr["EMI_NOME_FANTASIA"].ToString());
            }

            ds = cnn.DataSet_Pesquisa("EXEC PRC_VEICULOS_SEARCH NULL, NULL");
            dr = ds.CreateDataReader();

            cmbPlaca.Items.Clear();
            cmbPlaca.Items.Add(" - Todos - ");

            while (dr.Read())
            {
                cmbPlaca.Items.Add(dr["VEI_PLACA"].ToString());
            }

            ds = cnn.DataSet_Pesquisa("EXEC PRC_RESIDUOS_SEARCH NULL, NULL");
            dr = ds.CreateDataReader();

            cmbResiduo.Items.Clear();
            cmbResiduo.Items.Add(" - Todos - ");

            while (dr.Read())
            {
                cmbResiduo.Items.Add(dr["RES_NOME"].ToString());
            }

            cmbUnidade.SelectedIndex = 0;
            cmbUsuario.SelectedIndex = 0;
            cmbEmissor.SelectedIndex = 0;
            cmbPlaca.SelectedIndex = 0;
            cmbResiduo.SelectedIndex = 0;

        }


        private void frmRelatorios_Load(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (Acl.Acl.Check(c.Tag.ToString(), Session.Session.gruCodigo.ToString()) == false)
                    {
                        c.Visible = false;
                    }
                }
            }

            this.populateComboBoxes();

        }

        private void frmRelatorios_SizeChanged(object sender, EventArgs e)
        {

            /*txtSearch.Location = new Point(this.Width - 230, 14);
            btnSearch.Location = new Point(this.Width - 55, 12);*/

            dgvPesagens.Width = this.Width - 40;
            dgvPesagens.Height = this.Height - 170;
            lblTotal.Location = new Point(9, this.Height - 60);
            btnImprimir.Location = new Point(this.Width - 230, this.Height - 65);
            btnExportar.Location = new Point(this.Width - 126, this.Height - 65);

        }

        private void frmRelatorios_ResizeEnd(object sender, EventArgs e)
        {

        }

        private DataTableReader getPesagens()
        {

            int i = 0, n;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            string dataInicio = null, dataTermino = null;
            string dtPattern = @"yyyy-MM-ddTHH:mm:ss";

            sql = "SELECT T1.*, T2.EMI_CODIGO, T2.EMI_NOME_FANTASIA AS EMISSOR, T3.VEI_PLACA AS PLACA, T4.RES_NOME AS RESIDUO, T5.UNI_NOME AS UNIDADE, T6.USU_NOME AS USUARIO, " +
                  "T1.PES_DATA_ENTRADA AS DATA_ENTRADA, T1.PES_DATA_SAIDA AS DATA_SAIDA " +
                  "FROM TBL_PESAGENS T1 " +
                  "INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO " +
                  "INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO " +
                  "INNER JOIN TBL_RESIDUOS T4 ON T1.PES_RESIDUO = T4.RES_CODIGO " +
                  "INNER JOIN TBL_UNIDADES T5 ON T1.PES_UNIDADE = T5.UNI_CODIGO " +
                  "INNER JOIN TBL_USUARIOS T6 ON T1.PES_USUARIO = T6.USU_CODIGO ";

            sql += "WHERE T1.PES_CODIGO > 0 ";

            if (cmbUnidade.Text != " - Todos - ")
                sql += "AND T5.UNI_NOME = '" + cmbUnidade.Text + "' ";

            if (cmbUsuario.Text != " - Todos - ")
                sql += "AND T6.USU_NOME = '" + cmbUsuario.Text + "' ";

            if (cmbEmissor.Text != " - Todos - ")
                sql += "AND T2.EMI_NOME_FANTASIA = '" + cmbEmissor.Text + "' ";

            if (cmbPlaca.Text != " - Todos - ")
                sql += "AND T3.VEI_PLACA = '" + cmbPlaca.Text + "' ";

            if (cmbResiduo.Text != " - Todos - ")
                sql += "AND T4.RES_NOME = '" + cmbResiduo.Text + "' ";

            if (cmbResiduo.Text != " - Todos - ")
                sql += "AND T4.RES_NOME = '" + cmbResiduo.Text + "' ";

            if (dtpInicio.Value.ToString(dtPattern) != dtpTermino.Value.ToString(dtPattern))
            {
                if (dtpInicio.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds > dtpTermino.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
                {
                    MessageBox.Show("A data de início tem que ser inferior à data de término.");
                    return null;
                }

                dataInicio = dtpInicio.Value.ToString(dtPattern) + ".000";
                dataTermino = dtpTermino.Value.ToString(dtPattern) + ".000";

                sql += "AND T1.PES_DATA_SAIDA BETWEEN '" + dataInicio + "' AND '" + dataTermino + "'";

            }

            sql += "ORDER BY PES_DATA_SAIDA DESC;";

            ds = cnn.DataSet_Pesquisa(sql);

            return ds.CreateDataReader();

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {

            int i = 0;

            DataTableReader dr = null;

            dr = getPesagens();

            if (dr != null)
            {

                dgvPesagens.Rows.Clear();

                while (dr.Read())
                {

                    dgvPesagens.Rows.Add();
                    dgvPesagens.Rows[i].Cells["id"].Value = dr["PES_CODIGO"].ToString();
                    dgvPesagens.Rows[i].Cells["unidade"].Value = dr["UNIDADE"].ToString();
                    dgvPesagens.Rows[i].Cells["usuario"].Value = dr["USUARIO"].ToString();
                    dgvPesagens.Rows[i].Cells["emissor"].Value = dr["EMISSOR"].ToString();
                    dgvPesagens.Rows[i].Cells["placa"].Value = dr["PLACA"].ToString();
                    dgvPesagens.Rows[i].Cells["residuo"].Value = dr["RESIDUO"].ToString();
                    dgvPesagens.Rows[i].Cells["peso_bruto"].Value = dr["PES_PESO_BRUTO"].ToString();
                    dgvPesagens.Rows[i].Cells["peso_tara"].Value = dr["PES_PESO_TARA"].ToString();
                    dgvPesagens.Rows[i].Cells["peso_liquido"].Value = dr["PES_PESO_LIQUIDO"].ToString();
                    dgvPesagens.Rows[i].Cells["data_entrada"].Value = dr["PES_DATA_ENTRADA"].ToString();
                    dgvPesagens.Rows[i].Cells["data_saida"].Value = dr["PES_DATA_SAIDA"].ToString();

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

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            int i = 0;
            DataTableReader dr;

            SaveFileDialog salvar = new SaveFileDialog();

            Microsoft.Office.Interop.Excel.Application App;
            Microsoft.Office.Interop.Excel.Workbook WorkBook;
            Microsoft.Office.Interop.Excel.Worksheet WorkSheet;
            object misValue = System.Reflection.Missing.Value;
            App = new Microsoft.Office.Interop.Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);

            WorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Relatório de Pesagem";

            WorkSheet.Cells[2, 1] = "Emissão:";
            WorkSheet.Cells[2, 2] = Clock.dateTime.ToString(Clock.getDate()) + " " + Clock.dateTime.ToString(Clock.getTime());
            WorkSheet.Cells[4, 1] = "Unidade:";
            WorkSheet.Cells[4, 2] = "Usuário:";
            WorkSheet.Cells[4, 3] = "Emissor:";
            WorkSheet.Cells[4, 4] = "Placa:";
            WorkSheet.Cells[4, 5] = "Resíduo:";
            WorkSheet.Cells[4, 6] = "Peso Bruto (Kg):";
            WorkSheet.Cells[4, 7] = "Peso Tara (Kg):";
            WorkSheet.Cells[4, 8] = "Peso Líquido (Kg):";
            WorkSheet.Cells[4, 9] = "Entrada:";
            WorkSheet.Cells[4, 10] = "Saída:";

            dr = getPesagens();

            i = 6;

            while (dr.Read())
            {

                WorkSheet.Cells[i, 1] = dr["UNIDADE"].ToString();
                WorkSheet.Cells[i, 2] = dr["USUARIO"].ToString();
                WorkSheet.Cells[i, 3] = dr["EMISSOR"].ToString();
                WorkSheet.Cells[i, 4] = dr["PLACA"].ToString();
                WorkSheet.Cells[i, 5] = dr["RESIDUO"].ToString();
                WorkSheet.Cells[i, 6] = dr["PES_PESO_BRUTO"].ToString();
                WorkSheet.Cells[i, 7] = dr["PES_PESO_TARA"].ToString();
                WorkSheet.Cells[i, 8] = dr["PES_PESO_LIQUIDO"].ToString();
                WorkSheet.Cells[i, 9] = dr["DATA_ENTRADA"].ToString();
                WorkSheet.Cells[i, 10] = dr["DATA_SAIDA"].ToString();

                i++;

            }

            WorkSheet.Cells.EntireColumn.AutoFit();

            salvar.Title = "Exportar para Excel";
            salvar.Filter = "Arquivo do Excel *.xls | *.xls";
            salvar.ShowDialog();

            if (salvar.FileName=="")
            {
                MessageBox.Show("Especifique o nome do arquivo para exportar.", "Exportar");
                return;
            }

            WorkBook.SaveAs(salvar.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            WorkBook.Close(true, misValue, misValue);
            App.Quit();
            MessageBox.Show("Relatório exportado com sucesso.", "Exportar");

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DataTableReader dr = null;

            Printer printer = new Printer();

            printer.Add("Relatório de Pesagem\r\n");
            printer.Add("Emissão:\t" + Clock.dateTime.ToString(Clock.getDate()) + " " + Clock.dateTime.ToString(Clock.getTime()) + "\r\n\r\n");
            printer.Add("Unidade:\tUsuário:\tEmissor:\tPlaca:\tResíduo:\tPeso Bruto (Kg):\tPeso Tara (Kg):\tPeso Líquido (Kg):\tEntrada:\tSaída:\r\n\r\n");

            dr = getPesagens();

            while (dr.Read())
            {
                printer.Add(dr["UNIDADE"].ToString() + "\t" + dr["USUARIO"].ToString() + "\t" + dr["EMISSOR"].ToString() + "\t" + dr["PLACA"].ToString() + "\t" + 
                            dr["RESIDUO"].ToString() + "\t" + dr["PES_PESO_BRUTO"].ToString() + "\t" + dr["PES_PESO_TARA"].ToString() + "\t" + dr["PES_PESO_LIQUIDO"].ToString() + "\t" + 
                            dr["DATA_ENTRADA"].ToString() + "\t" + dr["DATA_SAIDA"].ToString() + "\r\n");
            }

            printer.Print();

        }

        private void frmRelatorios_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = false;
            e.Cancel = true;

        }
    }
}
