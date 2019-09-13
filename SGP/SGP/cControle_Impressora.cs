using SGP;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace SGP.cControle_Impressora
{
    public class cControle_Impressora
    {
        protected Font printFont;

        protected string sNomeImp;

        private PrintDocument doc = new PrintDocument();

        protected PaperSize pz;

        private DataTable tbImp;

        private DataSet dsImp = new DataSet();

        public cControle_Impressora()
        {
        }

        public void AguardaImpressao()
        {
            cControle_Impressora.MEGENCOM32_AguardaImpressao("USB000", (long)4000);
        }

        public void AguardaImpressaoStr()
        {
            cControle_Impressora.MEGENCOM32_AguardaImpressao("USB000", (long)4000);
        }

        public void FechaImpressao()
        {
            this.dsImp.Clear();
        }

        public void FontImpressao(string NomeFont, float iTamanho)
        {
            this.printFont = new Font(NomeFont, iTamanho);
        }

        public void Impressoras()
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings.InstalledPrinters[i].ToString();
            }
            this.InicioImpressao();
        }

        public void Impressoras(string sNomeImpressora)
        {
            this.InicioImpressao();
            int i = 0;
            while (i < PrinterSettings.InstalledPrinters.Count)
            {
                string x = PrinterSettings.InstalledPrinters[i].ToString();
                if (!(x == sNomeImpressora))
                {
                    i++;
                }
                else
                {
                    this.sNomeImp = x;
                    break;
                }
            }
        }

        private void ImprimeTexto(object sender, PrintPageEventArgs e)
        {
            foreach (DataRow drr in this.dsImp.Tables[0].Rows)
            {
                int X = Convert.ToInt16(drr["X"].ToString());
                int Y = Convert.ToInt16(drr["Y"].ToString());
                e.Graphics.DrawString(drr[0].ToString(), this.printFont, Brushes.Black, (float)Y, (float)X, new StringFormat());
            }
        }

        public void Imprimir(string sTexto)
        {
            long lEscritos = (long)0;
            cControle_Impressora.MEGENCOM32_EscrevernoDispositivo("USB000", sTexto, (long)5, ref lEscritos);
        }

        public void Imprimir()
        {
            this.doc.DefaultPageSettings.PaperSize = this.pz;
            this.doc.PrinterSettings.PrinterName = this.sNomeImp;
            this.doc.PrintPage += new PrintPageEventHandler(this.ImprimeTexto);
            this.doc.Print();
            this.dsImp.Clear();
        }

        public void ImpTicket(OleDbDataReader dr, string Tipo)
        {
            string sSql;
            string str;
            string[] strArrays;
            int num;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            cConexao.cConexao cnn = new cConexao.cConexao();
            int i = 0;
            int iRes = 0;
            int iRes1 = 0;
            int iQtdImp = 0;
            int iCont = 0;
            decimal dX = new decimal(0);
            string sX = "";
            string sDtSaida = "";
            string sSetor = "";
            string sPesoSaida = "";
            string sNumTicket = "";
            string sObs = "";
            string sNumLab = "";
            string sGerador = "";
            string sCliente = "";
            double dPesoEnt = 0;
            double dPesoLiq = 0;
            string[] sResiduo = new string[10];
            if (dr.Read())
            {
                if (!(Tipo == "R"))
                {
                    sSql = string.Concat("EXEC SP_BALANCA_IMP_TICKET ", dr["CD_CONTROLE_LAB"].ToString(), " , ");
                    str = sSql;
                    strArrays = new string[] { str, "'", dr["CNPJ_CPF_GERADOR"].ToString(), "', 'R', ", dr["ID_ENT_BALANCA"].ToString() };
                    sSql = string.Concat(strArrays);
                }
                else
                {
                    sSql = string.Concat("EXEC SP_BALANCA_IMP_TICKET ", dr["CD_CONTROLE_LAB"].ToString(), " , ");
                    str = sSql;
                    strArrays = new string[] { str, "'", dr["CNPJ_CPF_GERADOR"].ToString(), "', 'H', ", dr["ID_ENT_BALANCA"].ToString() };
                    sSql = string.Concat(strArrays);
                }
                OleDbDataReader dr1 = cnn.Oledb_Pesquisa(sSql);
                while (dr1.Read())
                {
                    sObs = dr1["OBS_BAL_SAIDA"].ToString();
                    iQtdImp = Convert.ToInt16(dr1["QTDE_IMP_TICKET"].ToString());
                    sSetor = dr1["SETOR"].ToString();
                    sDtSaida = dr1["DT_SAIDA"].ToString();
                    sResiduo[iRes] = string.Concat(dr1["CD_RESIDUO"].ToString().Trim(), " - ", dr1["DESC_RESIDUO1"].ToString().Trim());
                    sNumTicket = dr1["NUM_TICKET"].ToString();
                    sNumLab = dr1["CD_CONTROLE_LAB"].ToString();
                    sGerador = dr1["FAN_GERADOR_FIL"].ToString();
                    sCliente = dr1["CLIENTE"].ToString();
                    if (Convert.ToDouble(dr1["PESO_RATEIO"].ToString()) <= 0)
                    {
                        dPesoEnt = dPesoEnt + Convert.ToDouble(dr1["PESO_MANUAL"].ToString());
                        dPesoLiq = dPesoLiq + Convert.ToDouble(dr1["PESO_MANUAL"].ToString());
                    }
                    else
                    {
                        dPesoEnt = dPesoEnt + Convert.ToDouble(dr1["PESO_RATEIO"].ToString());
                        dPesoLiq = dPesoLiq + Convert.ToDouble(dr1["PESO_RATEIO"].ToString());
                    }
                    iRes++;
                }
                sPesoSaida = (Convert.ToDouble(dr["PESO_BRUTO_BALNACA_ENTRADA"].ToString()) <= 0 ? dr["PESO_TARA_MANU_ENTRADA"].ToString() : dr["PESO_TARA_BALANCA_ENTRADA"].ToString());
                dPesoEnt = dPesoEnt + Convert.ToDouble(sPesoSaida);
                string sPesoEnt = Convert.ToString(dPesoEnt);
                string sPesoLiq = Convert.ToString(dPesoLiq);
                sPesoSaida = Convert.ToString(Convert.ToDouble(sPesoSaida));
                for (i = 0; i < iQtdImp; i++)
                {
                    dX = new decimal(0);
                    this.IncluirTextoImpressao("PROACTIVA MEIO AMBIENTE BRASIL LTDA", Convert.ToString(dX), "0,2");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao("CGA - IPERO", sX.Replace(".", ","), "3");
                    dX = dX + Convert.ToDecimal("1");
                    sX = Convert.ToString(dX);
                    if (!(sSetor != "0"))
                    {
                        this.IncluirTextoImpressao(string.Concat("N Ticket: ", sNumTicket, " N Lab.: ", sNumLab), sX.Replace(".", ","), "0");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                    }
                    else
                    {
                        strArrays = new string[] { "N Ticket: ", sNumTicket, " N Lab.: ", sNumLab, "  Setor: ", sSetor };
                        this.IncluirTextoImpressao(string.Concat(strArrays), sX.Replace(".", ","), "0");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                    }
                    this.IncluirTextoImpressao(string.Concat("Cliente: ", sCliente), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Gerador: ", sGerador), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Transp: ", dr["FAN_TRANSPORTADOR"].ToString()), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Placa do Veículo: ", dr["PLACA_TRANSPORTADOR"].ToString()), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Motorista: ", dr["NOM_MOTORISTA"].ToString()), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao("Resíduo: ", sX.Replace(".", ","), "0");
                    for (iRes1 = 0; iRes1 < iRes; iRes1++)
                    {
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        string str1 = sResiduo[iRes1] ?? "";
                        this.IncluirTextoImpressao(str1, sX.Replace(".", ","), "1");
                    }
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Data Entrada: ", dr["DT_ENTRADA"].ToString()), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Peso Entrada(kg): ", sPesoEnt), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Data Saída: ", sDtSaida), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Peso Saída(kg): ", sPesoSaida), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao(string.Concat("Peso Líquido(kg): ", sPesoLiq), sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("0,5");
                    sX = Convert.ToString(dX);
                    if (sObs.Length > 1)
                    {
                        num6 = (sObs.Length > 26 ? 26 : sObs.Length);
                        iCont = num6;
                        this.IncluirTextoImpressao(string.Concat("Obs: ", sObs.Substring(0, iCont).ToString()), sX.Replace(".", ","), "0");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num5 = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num5;
                        this.IncluirTextoImpressao(sObs.Substring(0, iCont).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num4 = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num4;
                        this.IncluirTextoImpressao(sObs.Substring(0, iCont).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num3 = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num3;
                        this.IncluirTextoImpressao(sObs.Substring(0, iCont).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num2 = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num2;
                        this.IncluirTextoImpressao(sObs.Substring(0, 32).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num1 = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num1;
                        this.IncluirTextoImpressao(sObs.Substring(0, iCont).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    if (sObs.Length > 1)
                    {
                        num = (sObs.Length > 32 ? 32 : sObs.Length);
                        iCont = num;
                        this.IncluirTextoImpressao(sObs.Substring(0, iCont).ToString(), sX.Replace(".", ","), "0,5");
                        dX = dX + Convert.ToDecimal("0,5");
                        sX = Convert.ToString(dX);
                        sObs = (sObs.Length <= iCont + 1 ? "" : sObs.Substring(iCont + 1).ToString());
                    }
                    this.IncluirTextoImpressao("Ass. Balanceiro:_____________________", sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("1");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao("Conf. Balanceiro:____________________", sX.Replace(".", ","), "0");
                    dX = dX + Convert.ToDecimal("1");
                    sX = Convert.ToString(dX);
                    this.IncluirTextoImpressao("Ass. Motorista:______________________", sX.Replace(".", ","), "0");
                    this.Imprimir();
                }
            }
        }

        public void InciaImpressora()
        {
            cControle_Impressora.MEGENCOM32_AbrirDispositivo("USB000", "9600", 0, (long)8, (long)1, (long)0);
        }

        public void IncluirTextoImpressao(string sTexto, string X, string Y)
        {
            DataRow dr = this.tbImp.NewRow();
            dr["TEXT"] = sTexto;
            decimal iX = Convert.ToDecimal(X) * new decimal(36);
            dr["X"] = iX;
            decimal iY = Convert.ToDecimal(Y) * new decimal(36);
            dr["Y"] = iY;
            this.tbImp.Rows.Add(dr);
        }

        private void InicioImpressao()
        {
            this.dsImp.Clear();
            this.dsImp.Dispose();
            if (this.dsImp.Tables.Count <= 0)
            {
                this.tbImp = new DataTable("Imp");
                this.tbImp.Columns.Add("TEXT", Type.GetType("System.String"));
                this.tbImp.Columns.Add("X", Type.GetType("System.Int16"));
                this.tbImp.Columns.Add("Y", Type.GetType("System.Int16"));
                this.dsImp.Tables.Add(this.tbImp);
            }
        }

        public void LerDispositivo()
        {
            long lBytesLidos = (long)0;
            string sBuffer = "";
            cControle_Impressora.MEGENCOM32_LeroDispositivo("USB000", sBuffer, (long)1, ref lBytesLidos);
        }

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_AbrirDispositivo(string Porta, string Velocidade, byte Paridade, long NumBits, long NumStopbits, long CtrlFluxo);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_AguardaImpressao(string Porta, long Timeout);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_ConfigurarTimeoutsRXTX(string Porta, long TimeOutRX, long TimeOutTX);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_EscrevernoDispositivo(string Porta, string Buffer, long NumBytes, ref long BytesEscritos);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_FecharDispositivo(string Porta);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_LeroDispositivo(string Porta, string Buffer, long NumBytes, ref long BytesLidos);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_PreparaImpressao(string Porta);

        [DllImport("MEGENCOM32.dll", CharSet=CharSet.None, ExactSpelling=false)]
        private static extern long MEGENCOM32_StatusDoDispositivo(string Porta, ref byte Status);

        public void PapelImpressao(string sImpresoara)
        {
            PrinterSettings pImpressora = new PrinterSettings();
            pImpressora.PrinterName = sImpresoara;
            foreach (PaperSize ps in pImpressora.PaperSizes)
            {
                string x = ps.PaperName;
            }
        }

        public void PapelImpressoaCuston(string sAltura, string sLargura)
        {
            int X = (int)Convert.ToDecimal(sAltura) * 40;
            int Y = (int)Convert.ToDecimal(sLargura) * 40;
            this.pz = new PaperSize("Custon", Y, X);
        }

        public void ParaImpressora()
        {
            cControle_Impressora.MEGENCOM32_FecharDispositivo("USB000");
        }

        public void PreparaImpressao()
        {
            cControle_Impressora.MEGENCOM32_PreparaImpressao("USB000");
        }

        public void StatusDispositivo()
        {
            byte bStatus = 0;
            cControle_Impressora.MEGENCOM32_StatusDoDispositivo("USB000", ref bStatus);
        }

        public void TimerDeImperessao()
        {
            cControle_Impressora.MEGENCOM32_ConfigurarTimeoutsRXTX("USB000", (long)2000, (long)5000);
        }
    }
}
