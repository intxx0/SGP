using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

  
namespace Controle_balaca
{
    public partial class frmPesqPeso : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; 
                Value = value;
            }
        }

        public frmPesqPeso()
        {
            InitializeComponent();
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cImprimeRelatorios.cImprimir rp = new cImprimeRelatorios.cImprimir();
            frmRelatorios frmRel = new frmRelatorios();
            mdiPrincipal frmPrinc = new mdiPrincipal();


            string[] sValor = new string[4];
            sValor[0] = "P";
            sValor[1] = mskDtInic.Text ;
            sValor[2] = mskDtFim.Text  ;
            sValor[3] = cboGerador.Text ; 

            
            frmRel.Show();
            frmRel.Print(rp.Imprimir("rptPesagem.rpt", sValor)); 
        }
        
        private void PreencheGrid()
        {
            OleDbDataReader dr;
            cConexao.cConexao cnn = new cConexao.cConexao();
            string sSql = "SP_GERADOR_SEARCH @ACTION='D'"; 
            
            dr = cnn.Oledb_Pesquisa  (sSql);
                       
            cboGerador.Items.Add("TODOS");

            while (dr.Read())
            {
                cboGerador.Items.Add(dr["FAN_GERADOR_FIL"].ToString());
            }

            cboGerador.SelectedIndex = 0;

        }

        private void frmPesqPeso_Load(object sender, EventArgs e)
        {
            PreencheGrid();
        }
    }
}
