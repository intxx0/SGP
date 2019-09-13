using System;
using System.Collections;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace SGP.cFuncoes
{
    public class cFuncoes
    {
        public static string sAcesso;

        public cFuncoes()
        {
        }

        public void FormataCampos(cFuncoes.OpcaoFormata Opcao, TextBox NomeText)
        {
            bool flag;
            bool flag1;
            switch (Opcao)
            {
                case cFuncoes.OpcaoFormata.ForCep:
                    {
                        if (NomeText.Text.Length == 5)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "-");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        break;
                    }
                case cFuncoes.OpcaoFormata.ForData:
                    {
                        flag = (NomeText.Text.Length == 2 ? false : NomeText.Text.Length != 5);
                        if (!flag)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "/");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 10)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, " ");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 13)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, ":");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        break;
                    }
                case cFuncoes.OpcaoFormata.ForCNPJ:
                    {
                        flag1 = (NomeText.Text.Length == 2 ? false : NomeText.Text.Length != 6);
                        if (!flag1)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, ".");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        if (NomeText.Text.Length == 10)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "/");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        if (NomeText.Text.Length == 15)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "-");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        break;
                    }
                case cFuncoes.OpcaoFormata.ForCPF:
                    {
                        if (NomeText.Text.Length == 3)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, ".");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 7)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, ".");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 11)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "-");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length > 14)
                        {
                            if (NomeText.Text.Length == 15)
                            {
                                NomeText.Text = NomeText.Text.Replace(".", "");
                                NomeText.Text = NomeText.Text.Replace("-", "");
                                string sAux = NomeText.Text;
                                string[] strArrays = new string[] { sAux.Substring(0, 2), ".", sAux.Substring(2, 3), ".", sAux.Substring(5, 3), "/", sAux.Substring(8, 4), "-" };
                                NomeText.Text = string.Concat(strArrays);
                                NomeText.SelectionStart = NomeText.Text.Length + 1;
                            }
                        }
                        break;
                    }
                case cFuncoes.OpcaoFormata.ForTel:
                    {
                        if (NomeText.Text.Length == 0)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "(");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 3)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, ")");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        else if (NomeText.Text.Length == 8)
                        {
                            NomeText.Text = string.Concat(NomeText.Text, "-");
                            NomeText.SelectionStart = NomeText.Text.Length + 1;
                        }
                        break;
                    }
            }
        }

        public bool IsDate(string sDate)
        {
            bool flag;
            bool flag1;
            string strData = sDate;
            try
            {
                DateTime dt = DateTime.Parse(strData);
                flag1 = (dt == DateTime.MinValue ? true : !(dt != DateTime.MaxValue));
                flag = (flag1 ? false : true);
            }
            catch (Exception exception)
            {
                flag = false;
            }
            return flag;
        }

        public void LetrasMaiusculas(Control NomeForm)
        {
            foreach (Control c in NomeForm.Controls)
            {
                foreach (Control cc in c.Controls)
                {
                    if (cc is TextBox)
                    {
                        cc.Text = cc.Text.ToUpper();
                        TextBox TX = (TextBox)cc;
                        TX.SelectionStart = TX.Text.Length + 1;
                    }
                }
            }
        }

        public void Localiza(ref DataGrid grd, ref CurrencyManager CurrencyManage, string pTexto, int pCol)
        {
            int Ix;
            string TxCampo = pTexto.ToUpper();
            int Size = TxCampo.Length;
            for (Ix = 0; Ix <= CurrencyManage.Count - 1; Ix++)
            {
                grd.UnSelect(Ix);
            }
            CurrencyManage.Position = 0;
            if (Size != 0)
            {
                Ix = 0;
                while (Ix <= CurrencyManage.Count - 1)
                {
                    string TxGrid = Convert.ToString(grd[Ix, pCol]);
                    if (!(TxCampo.Substring(0, Size) == TxGrid.Substring(0, Size).ToUpper()))
                    {
                        Ix++;
                    }
                    else
                    {
                        grd.Select(Ix);
                        CurrencyManage.Position = Ix;
                        break;
                    }
                }
            }
        }

        public enum OpcaoFormata
        {
            ForCep = 1,
            ForData = 2,
            ForCNPJ = 3,
            ForCPF = 4,
            ForTel = 5
        }

        public static bool ValidaCnpj(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

        }

        public static string CreateMD5Hash(string input)
        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();

        }
    }

}