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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Cancela(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string errors = "";

            if (txtUsuario.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Usuário\"\n";
            }

            if (txtSenha.Text.ToString() == "")
            {
                errors += " - Preencha o campo \"Senha\"\n";
            }

            if (errors.ToString() != "")
            {
                MessageBox.Show("Ocorreram os seguintes erros:\n\n" + errors.ToString(), "Erro");
            }
            else
            {

                if (Session.Session.Auth(txtUsuario.Text.ToString(), txtSenha.Text.ToString()))
                {
                    mdiPrincipal Frm = new mdiPrincipal();
                    Frm.Show();
                    this.Visible = false;
                }
                else
                {
                    MSGLOGINERRO();
                }

            }
            
        }

        private void MSGLOGINERRO()
        {
            MessageBox.Show("Usuário ou senha inválida.");  
        }

        private void Cancela()
        {
            this.Close();
            this.Dispose();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                this.btnOk_Click(this, e);

        }
        
    }
}
