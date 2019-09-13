using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SGP.cControleBalanca
{
    public class cControleBalanca
    {
        public cControleBalanca()
        {
        }

        public void ConfigBalanca(int balanca, long lHandle)
        {
            if (cControleBalanca.ConfiguraBalanca(balanca, lHandle))
            {
                MessageBox.Show("Configurado com sucesso !!!");
            }
            else
            {
                cControleBalanca.ExibeMsgErro(lHandle);
            }
        }

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool ConfiguraBalanca(int balanca, long Handle);

        public void ConfiguracoesBalanca(int balanca, ref int iPorta, ref int iModelo, ref string sNomeModelo)
        {
            int Porta = 0;
            long BaudRate = (long)0;
            string NomeModelo = "";
            int modelo = 0;
            NomeModelo = NomeModelo.PadLeft(52, ' ');
            if (!cControleBalanca.ObtemParametrosBalanca(balanca, ref modelo, ref Porta, ref BaudRate))
            {
                iModelo = 0;
                iPorta = 0;
                sNomeModelo = "";
            }
            else
            {
                cControleBalanca.ObtemNomeBalanca(modelo, NomeModelo);
                iModelo = modelo;
                iPorta = Porta;
                sNomeModelo = NomeModelo;
            }
        }

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool EnviaPrecoCS(int balanca, double preco);

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern void ExibeMsgErro(long Handle);

        public void FinalizaBalanca(int balanca)
        {
            if (!cControleBalanca.FinalizaLeitura(balanca))
            {
                cControleBalanca.ExibeMsgErro((long)0);
            }
            else
            {
                MessageBox.Show("Leitura Finalizada");
            }
        }

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool FinalizaLeitura(int balanca);

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool InicializaLeitura(int balanca);

        public bool IniciarBalanca(int balanca)
        {
            bool bRet = cControleBalanca.InicializaLeitura(balanca);
            if (!bRet)
            {
                cControleBalanca.ExibeMsgErro((long)0);
            }
            bool flag = bRet;
            return flag;
        }

        public void LeituraBalanca(int balanca, ref string PesoBruto, ref string PesoLiquido, ref string PesoTara, ref string Contagem, ref string VlUnitario, ref string VlTotal, ref string Codigo, ref string Menssagem)
        {
            bool flag;
            double dRet = 0;
            string sMsn = "";
            int iRet = Convert.ToInt32(cControleBalanca.ObtemInformacao(balanca, 0));
            switch (iRet)
            {
                case -1:
                    {
                        sMsn = "O número da balança deve esta entra 0 e 7";
                        break;
                    }
                case 0:
                    {
                        sMsn = "Erro na Leitura da Balança !!!";
                        break;
                    }
                case 1:
                    {
                        sMsn = "Peso oscilando";
                        break;
                    }
                case 2:
                    {
                        sMsn = "Peso estável";
                        break;
                    }
                case 3:
                    {
                        sMsn = "Balança fora de range (sobrecarga/alívio de plataforma)";
                        break;
                    }
                case 4:
                    {
                        sMsn = "Licença de software não encontrada.";
                        break;
                    }
                default:
                    {
                        sMsn = string.Concat("Valor inteiro: ", iRet.ToString(), " - Valor Double: ", dRet.ToString());
                        break;
                    }
            }
            flag = (iRet == 1 ? false : iRet != 2);
            if (flag)
            {
                PesoBruto = "0";
                PesoTara = "0";
                PesoLiquido = "0";
                Contagem = "0";
                Codigo = "0";
                VlUnitario = "0";
                VlTotal = "0";
                Menssagem = sMsn;
            }
            else
            {
                PesoBruto = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 1));
                PesoTara = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 2));
                PesoLiquido = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 3));
                Contagem = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 5));
                Codigo = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 4));
                VlUnitario = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 6));
                VlTotal = string.Format("{0:0.000}", cControleBalanca.ObtemInformacao(balanca, 7));
                Menssagem = sMsn;
            }
        }

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double ObtemInformacao(int balanca, int campo);

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern void ObtemNomeBalanca(int Modelo, string Nome);

        [DllImport("PcScale.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern bool ObtemParametrosBalanca(int balanca, ref int Modelo, ref int Porta, ref long BaudRate);
    }
}