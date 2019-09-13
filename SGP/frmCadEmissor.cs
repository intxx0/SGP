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
using SGP.cFuncoes;

namespace SGP
{
    public partial class frmCadEmissor : Form
    {

        public string emiCodigo = null;
        public bool change = false;
        private bool saved = false;

        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadEmissor()
        {
            InitializeComponent();
        }

        public void populateComboBox(string item = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_CIDADES_UF";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbUf.Items.Clear();

            while (dr.Read())
            {
                cmbUf.Items.Add(dr["CID_UF"].ToString());
            }

            if (item != null)
            {
                cmbUf.SelectedIndex = cmbUf.Items.IndexOf(item);
            }
            else
            {
                cmbUf.SelectedIndex = 0;
            }

            radAtivo.Checked = true;

        }

        private void cmbUf_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_CIDADES_BY_UF '" + cmbUf.Text + "'";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbCidade.Items.Clear();

            while (dr.Read())
            {
                cmbCidade.Items.Add(dr["CID_NOME"].ToString());
            }

            cmbCidade.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string emiCidade = null, emiStatus = null, emiTipoPessoa = null, emiTipoCliente = null, sSql = "", errors = "";

            OleDbDataReader dr;

            // Validate

            if (txtNomeFantasia.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Nome\"\n";
            }

            if (txtRazaoSocial.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Razão Social\"\n";
            }

            if (cmbTipo.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Tipo\"\n";
            }

            emiTipoPessoa = cmbTipo.Text.ToString() == "Pessoa Física" ? "1" : "2";

            if (Convert.ToInt16(emiTipoPessoa) > 1)
            {
                if (txtCnpj.Text.ToString() == "  ,   ,   /    -")
                {
                    errors += " - Preencha o campo \"CNPJ\"\n";
                }
                else
                {
                    if (cFuncoes.cFuncoes.ValidaCnpj(txtCnpj.Text.ToString().Replace(',', '.')) == false)
                    {
                        errors += " - Número de \"CNPJ\" inválido\n";
                    }
                }
            }
            else
            {
                if (txtCpf.Text.ToString() == "")
                {
                    errors += " - Preencha o campo \"CPF\"\n";
                }
            }

            if (cmbTipoCliente.Text.ToString() == "")
            {
                errors += " - Selecione o campo \"Cliente\"\n";
            }

            if (txtEndereco.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Endereço\"\n";
            }

            if (txtNumero.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Número\"\n";
            }

            if (txtBairro.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Bairro\"\n";
            }

            if (txtEmail.TextLength > 0)
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(txtEmail.Text);
                if (match.Success == false)
                {
                    errors += " - Endereço de e-mail com formato incorreto\n";
                }
            }

            //MessageBox.Show(txtNome.ToString());
            //MessageBox.Show(Convert.ToString(txtNome.ToString().Length));

            if (txtRazaoSocial.Text.ToString().Length > 0 && change == false)
            {

                sSql = "EXEC PRC_GET_EMISSOR_BY_NOME '" + txtRazaoSocial.Text.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    if (emiCodigo != dr["EMI_CODIGO"].ToString())
                        errors += " - Emissor já existente\n";
                }

            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                emiTipoCliente = cmbTipoCliente.SelectedItem == "Público" ? "1" : "2";

                sSql = "EXEC PRC_GET_CIDADE_BY_NOME '" + cmbCidade.SelectedItem.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    emiCidade = dr["CID_CODIGO"].ToString();
                }
                else
                {
                    emiCidade = "0";
                }

                sSql = "EXEC PRC_EMISSOR_SAVE ";

                if (emiCodigo != null)
                {
                    sSql += "'" + emiCodigo + "'";
                }
                else
                {
                    sSql += "NULL";
                }

                emiStatus = radAtivo.Checked == true ? "1" : "0";

                sSql += ", '" + emiCidade + "', '" + txtNomeFantasia.Text.ToString() + "', '" + txtRazaoSocial.Text.ToString() + "', '" + 
                        emiTipoPessoa + "', '" + emiTipoCliente + "', '" + txtCnpj.Text.ToString() + "', '" + txtCpf.Text.ToString() + "', '" + 
                        txtIe.Text.ToString() + "', '" + txtIm.Text.ToString() + "', '" + txtEndereco.Text.ToString() + "', '" + 
                        txtNumero.Text.ToString() + "', '" + txtBairro.Text.ToString() + "', '" + txtEmail.Text.ToString() + "', '" + 
                        txtTelefone.Text.ToString() + "', '" + txtCelular.Text.ToString() + "', '" + txtObservacoes.Text.ToString() + "', '" + emiStatus + "'";

                cnn.Oledb_Grava(sSql);

                saved = true;

                Close();

                frmEmissores.GetChild().Focus();

            }
            
        }

        public void populateVeiculos()
        {

            int i = 0;

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_EMISSORES_VEICULOS '" + emiCodigo + "'");
            dr = ds.CreateDataReader();

            dgvEmissoresVeiculos.Rows.Clear();

            while (dr.Read())
            {

                dgvEmissoresVeiculos.Rows.Add();
                dgvEmissoresVeiculos.Rows[i].Cells["IdVeiculo"].Value = dr["EMV_CODIGO"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Veiculo"].Value = dr["VEICULO"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Tipo"].Value = dr["TIPO"].ToString();
                dgvEmissoresVeiculos.Rows[i].Cells["Placa"].Value = dr["PLACA"].ToString();

                i++;

            }

        }

        public void populateResiduos()
        {

            int i = 0;

            DataSet ds = null;
            DataTableReader dr = null;

            ds = cnn.DataSet_Pesquisa("EXEC PRC_GET_EMISSORES_RESIDUOS '" + emiCodigo + "'");
            dr = ds.CreateDataReader();

            dgvEmissoresResiduos.Rows.Clear();

            while (dr.Read())
            {

                dgvEmissoresResiduos.Rows.Add();
                dgvEmissoresResiduos.Rows[i].Cells["IdResiduo"].Value = dr["EMR_CODIGO"].ToString();
                dgvEmissoresResiduos.Rows[i].Cells["Residuo"].Value = dr["RESIDUO"].ToString();
                dgvEmissoresResiduos.Rows[i].Cells["TipoResiduo"].Value = dr["TIPO"].ToString();

                i++;

            }

        }

        public void populateData(string codigo = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                emiCodigo = codigo;

                sql = "EXEC PRC_EMISSORES_SEARCH NULL, '" + emiCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if (dr.Read())
                {

                    txtNomeFantasia.Text = dr["EMI_NOME_FANTASIA"].ToString();
                    txtRazaoSocial.Text = dr["EMI_RAZAO_SOCIAL"].ToString();

                    if (dr["EMI_TIPO_PESSOA"].ToString() == "1")
                        cmbTipo.SelectedItem = "Pessoa Física";
                    else
                        cmbTipo.SelectedItem = "Pessoa Jurídica";

                    if (dr["EMI_TIPO_CLIENTE"].ToString() == "1")
                        cmbTipoCliente.SelectedItem = "Público";
                    else
                        cmbTipoCliente.SelectedItem = "Privado";

                    txtCnpj.Text = dr["EMI_CNPJ"].ToString();
                    txtCpf.Text = dr["EMI_CPF"].ToString();
                    txtIe.Text = dr["EMI_IE"].ToString();
                    txtIm.Text = dr["EMI_IM"].ToString();

                    txtEndereco.Text = dr["EMI_ENDERECO"].ToString();
                    txtNumero.Text = dr["EMI_NUMERO"].ToString();
                    txtBairro.Text = dr["EMI_BAIRRO"].ToString();

                    populateComboBox(dr["UF"].ToString());

                    cmbUf_SelectedIndexChanged(null, null);

                    cmbCidade.SelectedIndex = cmbCidade.Items.IndexOf(dr["CIDADE"].ToString());

                    txtEmail.Text = dr["EMI_EMAIL"].ToString();
                    txtTelefone.Text = dr["EMI_TELEFONE"].ToString();
                    txtCelular.Text = dr["EMI_CELULAR"].ToString();

                    txtObservacoes.Text = dr["EMI_OBSERVACOES"].ToString();

                    radAtivo.Checked = false;
                    radInativo.Checked = false;

                    if (Convert.ToBoolean(dr["EMI_STATUS"]) == true)
                        radAtivo.Checked = true;
                    else
                        radInativo.Checked = true;

                    populateVeiculos();
                    populateResiduos();

                }

            }
            else
            {

                radAtivo.Checked = true;

                sql = "EXEC PRC_EMISSOR_SAVE NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '-1'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                dr.Read();

                emiCodigo = dr["EMI_CODIGO"].ToString();

            }

        }

        private void radAtivo_Click(object sender, EventArgs e)
        {
            radAtivo.Checked = true;
            radInativo.Checked = false;
        }

        private void radInativo_Click(object sender, EventArgs e)
        {
            radInativo.Checked = true;
            radAtivo.Checked = false;
        }

        private void btnAdicionarVeiculo_Click(object sender, EventArgs e)
        {

            frmAdicionarVeiculo frm = new frmAdicionarVeiculo();
            frm.populateComboBox();
            frm.emiCodigo = emiCodigo;
            frm.caller = this;
            frm.Show();

        }

        private void frmCadEmissor_FormClosed(object sender, FormClosedEventArgs e)
        {

            if(saved==false&&change==false)
                cnn.Oledb_Grava("EXEC PRC_DELETE_EMISSOR '" + emiCodigo + "'");

        }

        private void btnExcluirVeiculo_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja remover este veículo?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_EMISSOR_VEICULO '" + dgvEmissoresVeiculos.Rows[dgvEmissoresVeiculos.SelectedRows[0].Index].Cells["IdVeiculo"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                populateVeiculos();

            }

        }

        private void btnAdicionarResiduo_Click(object sender, EventArgs e)
        {

            frmAdicionarResiduo frm = new frmAdicionarResiduo();
            frm.populateComboBox();
            frm.emiCodigo = emiCodigo;
            frm.caller = this;
            frm.Show();

        }

        private void btnExcluirResiduo_Click(object sender, EventArgs e)
        {

            string sql;

            if (MessageBox.Show("Você realmente deseja remover este resíduo?", this.Text.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                sql = "EXEC PRC_DELETE_EMISSOR_RESIDUO '" + dgvEmissoresResiduos.Rows[dgvEmissoresResiduos.SelectedRows[0].Index].Cells["IdResiduo"].Value.ToString() + "'";
                cnn.Oledb_Grava(sql);

                populateResiduos();

            }

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTipo.Text.ToString() == "Pessoa Física")
            {
                txtCnpj.Enabled = false;
                txtIe.Enabled = false;
                txtIm.Enabled = false;
                txtCpf.Enabled = true;
            }
            else
            {
                txtCnpj.Enabled = true;
                txtIe.Enabled = true;
                txtIm.Enabled = true;
                txtCpf.Enabled = false;
            }

        }

        private void frmCadEmissor_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;

        }

    }
}
