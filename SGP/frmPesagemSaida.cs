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
    public partial class frmPesagemSaida : Form
    {

        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmPesagemSaida()
        {
            InitializeComponent();
        }

        private void frmPesagemSaida_Load(object sender, EventArgs e)
        {

        }

        public void populateVeiculos()
        {

            int i = 0;

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_VEICULOS_INTERNOS");
            dr = ds.CreateDataReader();

            dgvEmissoresVeiculos.Rows.Clear();

            while (dr.Read())
            {

                dgvEmissoresVeiculos.Rows.Add();
                dgvEmissoresVeiculos.Rows[i].Cells["Id"].Value = dr["PES_CODIGO"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Emissor"].Value = dr["EMISSOR"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Placa"].Value = dr["PLACA"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Residuo"].Value = dr["RESIDUO"].ToString();

                i++;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            frmPesagem.GetChild().populateData(dgvEmissoresVeiculos.Rows[dgvEmissoresVeiculos.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            this.Close();

        }
    }
}
