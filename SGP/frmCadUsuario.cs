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
    public partial class frmCadUsuario : Form
    {

        public string usuCodigo = null;
        cConexao.cConexao cnn = new cConexao.cConexao();

        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {

            //populateComboBox();

            this.WindowState = FormWindowState.Normal;

        }

        public void populateComboBox(string itemUnidade = null, string itemGrupo = null)
        {

            DataSet ds = null;
            DataTableReader dr = null;
            string sql = "";

            sql = "EXEC PRC_GET_UNIDADES";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbUnidade.Items.Clear();

            while (dr.Read())
            {
                cmbUnidade.Items.Add(dr["UNI_NOME"].ToString());
            }

            if (itemUnidade != null)
            {
                cmbUnidade.SelectedIndex = cmbUnidade.Items.IndexOf(itemUnidade);
            }
            else
            {
                cmbUnidade.SelectedIndex = 0;
            }

            sql = "EXEC PRC_GET_GRUPOS";

            ds = cnn.DataSet_Pesquisa(sql);
            dr = ds.CreateDataReader();

            cmbGrupo.Items.Clear();

            while (dr.Read())
            {
                cmbGrupo.Items.Add(dr["GRU_NOME"].ToString());
            }

            if (itemGrupo != null)
            {
                cmbGrupo.SelectedIndex = cmbGrupo.Items.IndexOf(itemGrupo);
            }
            else
            {
                cmbGrupo.SelectedIndex = 0;
            }

            radAtivo.Checked = true;

        }

        public void populateData(string codigo = null)
        {

            DataSet         ds = null;
            DataTableReader dr = null;
            string sql = "";

            if (codigo != null)
            {

                usuCodigo = codigo;

                sql = "EXEC PRC_USUARIOS_SEARCH NULL, '" + usuCodigo + "'";

                ds = cnn.DataSet_Pesquisa(sql);
                dr = ds.CreateDataReader();

                if(dr.Read())
                {

                    txtNome.Text = dr["USU_NOME"].ToString();

                    populateComboBox(dr["UNIDADE"].ToString(), dr["GRUPO"].ToString());

                    txtEmail.Text = dr["USU_EMAIL"].ToString();
                    txtObservacoes.Text = dr["USU_OBSERVACOES"].ToString();
                    txtLogin.Text = dr["USU_LOGIN"].ToString();

                    radAtivo.Checked = false;
                    radInativo.Checked = false;

                    if (Convert.ToBoolean(dr["USU_STATUS"]) == true)
                        radAtivo.Checked = true;
                    else
                        radInativo.Checked = true;
                    
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string usuUnidade = null, usuGrupo = null, usuStatus = null, sSql = "", errors = "";

            OleDbDataReader dr;

            // Validate

            if (txtNome.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Nome\"\n";
            }

            if (txtLogin.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Login\"\n";
            }

            if (txtSenha.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Senha\"\n";
            }

            if (txtConfirmarSenha.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Confirmar Senha\"\n";
            }

            if (txtSenha.Text.ToString() != txtConfirmarSenha.Text.ToString())
            {
                errors += " - Os campos \"Senha\" e \"Confirmar Senha\" não conferem\n";
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

            sSql = "EXEC PRC_GET_USUARIO_BY_LOGIN '" + txtLogin.Text.ToString() + "'";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                if(usuCodigo==null||usuCodigo!=dr["USU_CODIGO"].ToString())
                    errors += " - Login já existente\n";
            }

            if (errors.ToString()!="")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                // Do save

                sSql = "EXEC PRC_GET_UNIDADE_BY_NOME '" + cmbUnidade.SelectedItem.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    usuUnidade = dr["UNI_CODIGO"].ToString();
                }
                else
                {
                    usuUnidade = "0";
                }

                sSql = "EXEC PRC_GET_GRUPO_BY_NOME '" + cmbGrupo.SelectedItem.ToString() + "'";
                dr = cnn.Oledb_Pesquisa(sSql);

                if (dr.Read())
                {
                    usuGrupo = dr["GRU_CODIGO"].ToString();
                }
                else
                {
                    usuGrupo = "0";
                }

                sSql = "EXEC PRC_USUARIO_SAVE ";

                if (usuCodigo != null)
                {
                    sSql += "'" + usuCodigo + "'";
                }
                else
                {
                    sSql += "NULL";
                }

                usuStatus = radAtivo.Checked == true ? "1" : "0";

                sSql += ", '" + usuUnidade + "', '" + usuGrupo + "', '" + txtNome.Text.ToString() + "', '" + txtEmail.Text.ToString() + "', '" + txtLogin.Text.ToUpper() + "', '" + txtSenha.Text.ToUpper() + "', '" + txtObservacoes.Text.ToString() + "', '" + usuStatus + "'";

                cnn.Oledb_Grava(sSql);

                Close();

                frmGrupos.GetChild().Focus();

            }

        }

        private void radInativo_Click(object sender, EventArgs e)
        {
            radInativo.Checked = true;
            radAtivo.Checked = false;
        }

        private void radAtivo_Click(object sender, EventArgs e)
        {
            radAtivo.Checked = true;
            radInativo.Checked = false;
        }
    }
}
