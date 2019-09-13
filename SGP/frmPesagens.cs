using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Globalization;

namespace SGP
{
    public partial class frmPesagens : Form
    {

        private static frmPesagens _childInstance = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmPesagens()
        {
            InitializeComponent();
        }

        public static frmPesagens GetChild(mdiPrincipal parent = null)
        {

            if (_childInstance == null)
            {
                _childInstance = new frmPesagens();
                _childInstance.MdiParent = parent;
            }

            return _childInstance;

        }

        public void loadPesagens(string search = null)
        {

            int i = 0, n;
            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_PESAGENS_SEARCH " + (search != null ? "'%" + search + "%'" : "NULL") + "";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

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

        private void frmPesagens_Enter(object sender, EventArgs e)
        {

            this.loadPesagens();

        }

        private void frmPesagens_ResizeEnd(object sender, EventArgs e)
        {

            txtSearch.Location = new Point(this.Width - 230, 14);
            btnSearch.Location = new Point(this.Width - 55, 12);

            dgvPesagens.Width = this.Width - 40;
            dgvPesagens.Height = this.Height - 120;
            lblTotal.Location = new Point(9, this.Height - 60);

        }

        private void frmPesagens_SizeChanged(object sender, EventArgs e)
        {

            txtSearch.Location = new Point(this.Width - 230, 14);
            btnSearch.Location = new Point(this.Width - 55, 12);

            dgvPesagens.Width = this.Width - 40;
            dgvPesagens.Height = this.Height - 120;
            lblTotal.Location = new Point(9, this.Height - 60);

        }

        private void frmPesagens_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = false;
            e.Cancel = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.TextLength < 1)
                this.loadPesagens();
            else
                this.loadPesagens(txtSearch.Text.ToString());
    
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

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataSet ds;
            DataTableReader dr = null;

            int printerMode = Convert.ToInt16(ConfigurationManager.AppSettings["Printer_Mode"].ToString());
            string printerPort = ConfigurationManager.AppSettings["Printer_Port"].ToString();

            string pesCodigo = dgvPesagens.Rows[dgvPesagens.SelectedRows[0].Index].Cells["Id"].Value.ToString();

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
                printer.Add("Balanceiro - " + this.removeAccents(dr["USUARIO"].ToString()) + "\n\n");
                printer.Add("____________________________________________\n");
                printer.Add("Assinatura Motorista\n\n");
                printer.Add(dr["PES_CHECKSUM"].ToString() + " PMA-BR" + "\n\n\n\n\n\n\n\n\n\n\n");

                printer.Print();

            }

        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {

            frmCadPesagem frm = new frmCadPesagem();
            frm.Show();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCadPesagem frm = new frmCadPesagem();

            //frm.MdiParent = this.MdiParent;
            frm.Text = "Editar Pesagem";
            frm.populateData(dgvPesagens.Rows[dgvPesagens.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            //frm.change = true;
            frm.Show();

        }

        private void dgvPesagens_DoubleClick(object sender, EventArgs e)
        {

            frmCadPesagem frm = new frmCadPesagem();
            frm.MdiParent = this.MdiParent;
            frm.populateData(dgvPesagens.Rows[dgvPesagens.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            frm.Show();

        }

        private void frmPesagens_Load(object sender, EventArgs e)
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

        }

    }
}
