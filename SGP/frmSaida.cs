using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGP
{
    public partial class frmSaida : Form
    {
        //CurrencyManager CM;
        cConexao.cConexao cnn = new cConexao.cConexao();
        cControleBalanca.cControleBalanca cb = new cControleBalanca.cControleBalanca();
        string sNumManifesto = "", sCNPJ = "", sSeg = "", sCodLab="";
        string sCod_Entrada;
        int iBalanca = 1;

        public frmSaida()
        {
            InitializeComponent();
        }

        private void frmSaida_Load(object sender, EventArgs e)
        {
            DateTime dtAtual = DateTime.Now;
            
            txtDtSaida.Text = dtAtual.ToString("dd/MM/yyyy HH:mm");
            //this.CM = ((CurrencyManager)(this.BindingContext[this.DataGrid1.DataSource, this.DataGrid1.DataMember]));

            //charmar a funcao de pesqisa
            //Localiza(this.DataGrid1, CM, TextBox.Text, 1);
            //InicializaBalaca();
            preecheGridInicio();
            //timer1.Enabled = true;
            

        }

        private void preecheGridInicio()
        {
            OleDbDataReader dr;
            DataSet ds;
            int iLinha = 0;
            string sSql = "SELECT ID_ENT_BALANCA, FAN_TRANSPORTADOR, VEICULO_TRANSPORTADOR, PLACA_TRANSPORTADOR, NOM_MOTORISTA ";
            sSql += "FROM TB_BALANCA_ENTRADA WHERE STATUS_ENTRADA IN ('E','T') GROUP BY ID_ENT_BALANCA, FAN_TRANSPORTADOR, VEICULO_TRANSPORTADOR, PLACA_TRANSPORTADOR, NOM_MOTORISTA";

            dr = cnn.Oledb_Pesquisa(sSql);
            ds = cnn.DataSet_Pesquisa(sSql);

            dgvTransDentroAterro.Rows.Clear();

            //for (iLinha = 2; iLinha <= dgvTransDentroAterro.Rows.Count; iLinha++)
            //    dgvTransDentroAterro.Rows.Remove(dgvTransDentroAterro.Rows[iLinha]);

            for (iLinha = 2; iLinha <= ds.Tables[0].Rows.Count; iLinha++)
                dgvTransDentroAterro.Rows.Add();


            iLinha = 0;
            while (dr.Read())
             {
                 dgvTransDentroAterro.Rows[iLinha].Cells["colCod"].Value = dr["ID_ENT_BALANCA"].ToString();
                dgvTransDentroAterro.Rows[iLinha].Cells["colPlaca"].Value = dr["PLACA_TRANSPORTADOR"].ToString();
                dgvTransDentroAterro.Rows[iLinha].Cells["colTrans"].Value = dr["FAN_TRANSPORTADOR"].ToString();
                dgvTransDentroAterro.Rows[iLinha].Cells["colVeicul"].Value = dr["VEICULO_TRANSPORTADOR"].ToString();
                dgvTransDentroAterro.Rows[iLinha].Cells["colMot"].Value = dr["NOM_MOTORISTA"].ToString();
                iLinha++;
                     
              }
            
        }

        private void PreencheCamposTelaSaida(string sPlaca)
        {
            OleDbDataReader dr;
            string sSql = "SELECT * FROM TB_BALANCA_ENTRADA WHERE STATUS_ENTRADA IN ('E','T') AND PLACA_TRANSPORTADOR = '"+ sPlaca +"'";
                        
            dr = cnn.Oledb_Pesquisa(sSql);
            
            if (dr.Read())
            {
                txtPlaca.Text = dr["PLACA_TRANSPORTADOR"].ToString();
                txtVeiculo.Text = dr["VEICULO_TRANSPORTADOR"].ToString();
                txtTransp.Text = dr["FAN_TRANSPORTADOR"].ToString();
                txtMot.Text = dr["NOM_MOTORISTA"].ToString();
                txtPesoTara.Text = dr["PESO_BRUTO_BALNACA_ENTRADA"].ToString();
                txtPesoTaraM.Text = dr["PESO_BRUTO_MANU_ENTRADA"].ToString();
                txtPesoBrutoM.Text = dr["PESO_TARA_MANU_ENTRADA"].ToString();
                txtPesoBruto.Text = dr["PESO_TARA_BALANCA_ENTRADA"].ToString();
                
                txtLiqM.Text = dr["PESO_LIQUIDO_MANU_ENTRADA"].ToString();
                txtPesoLiq.Text = dr["PESO_LIQUIDO_BALANCA_ENTRADA"].ToString();

                if ( Convert.ToChar(dr["STATUS_ENTRADA"].ToString()) == 'T')
                {
                    btnTicket.Enabled = true;
                }

            }
        }

        private void PreencheGridGeradorTelaSaida(string sPlaca)
        {
            DataSet ds;
            OleDbDataReader dr, drObs;
            int iLinha = 0;
            string sSql = "SELECT * FROM TB_BALANCA_ENTRADA WHERE STATUS_ENTRADA IN('E','T') AND PLACA_TRANSPORTADOR = '" + sPlaca + "'";

            ds = cnn.DataSet_Pesquisa(sSql);
            dr = cnn.Oledb_Pesquisa(sSql);

            dgvCliente.Rows.Clear();
            //for (iLinha = 2; iLinha <= dgvCliente.Rows.Count; iLinha++)
            //    dgvCliente.Rows.Remove(dgvCliente.Rows[iLinha]);

            for (iLinha = 2; iLinha <= ds.Tables[0].Rows.Count; iLinha++)
                dgvCliente.Rows.Add();

            iLinha = 0;
            while (dr.Read())
            {
                dgvCliente.Rows[iLinha].Cells["colNumManifesto"].Value = dr["MANIFESTO_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colCodLab"].Value = dr["CD_CONTROLE_LAB"].ToString();
                dgvCliente.Rows[iLinha].Cells["colCNPJ"].Value = dr["CNPJ_CPF_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colRazao"].Value = dr["RAZAO_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colFantasia"].Value = dr["FAN_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colTpEnd"].Value = dr["TP_END_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colEnd"].Value = dr["END_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colNum"].Value = dr["NUM_GERADOR"].ToString();
                dgvCliente.Rows[iLinha].Cells["colSeguencia"].Value = dr["ID_ENT_BALANCA"].ToString();

                sSql = "SELECT OBS_BAL_SAIDA FROM TB_BALANCA_SAIDA WHERE(ID_ENT_BALANCA = " + dr["ID_ENT_BALANCA"].ToString() + ")";

                drObs = cnn.Oledb_Pesquisa(sSql);
                
                if(drObs.Read()) txtObsTicket.Text = drObs["OBS_BAL_SAIDA"].ToString(); 

                iLinha++;
            }
        
        }

        private void PreencheGridResiduosTelaSaida(string sCnpj)
        {
            DataSet ds;
            OleDbDataReader dr, drAviso;
            int iLinha = 0;
            string sSql = "";
            string sAviso = "";
            bool bAviso=false ;

            if (sCodLab == "0")
            {
                sSql = "EXEC SP_GERADOR_RESIDUO_SEARCH '" + sCnpj + "' ,'E'";
            }
            else
            {
                sSql = "EXEC SP_GERADOR_RESIDUO_SEARCH '" + sCnpj + "' ,'E','" + sCodLab  + "'";
            }

            dr = cnn.Oledb_Pesquisa(sSql);
            ds = cnn.DataSet_Pesquisa(sSql);

            sSql = "EXEC SP_VALIDA_ANALISE_LABORATORIO_SEARCH 0, " + sCodLab + ", 'A', '" + sCnpj + "' ";
            drAviso = cnn.Oledb_Pesquisa(sSql);
                                              
               while (drAviso.Read())
               {
                  sAviso += drAviso["RESIDUO"].ToString() + "\n";
                  bAviso = true;
               }

                if (bAviso == true)
                 {
                            MessageBox.Show("Este cliente não tem permissão para descaregar o(s) residuo(s): \n" + sAviso + "");
                 }
            
                if (!dr.HasRows && bAviso==false )
                {   
                    
                
                    sSql = "SELECT * FROM TB_RESIDUO";
                    dr = cnn.Oledb_Pesquisa(sSql);
                    ds = cnn.DataSet_Pesquisa(sSql);
                    
                    
                }

                dgvResiduos.Rows.Clear();
                //for (iLinha = 1; iLinha < dgvResiduos.Rows.Count; iLinha++)
                //    dgvResiduos.Rows.Remove(dgvResiduos.Rows[iLinha]);

                for (iLinha = 2; iLinha <= ds.Tables[0].Rows.Count; iLinha++)
                    dgvResiduos.Rows.Add();

                iLinha = 0;

                while (dr.Read())
                {
                    dgvResiduos.Rows[iLinha].Cells["colCodGerRes"].Value = dr["CD_GERADOR_RES"].ToString();
                    dgvResiduos.Rows[iLinha].Cells["colCodResiduo"].Value = dr["CD_RESIDUO"].ToString();
                    dgvResiduos.Rows[iLinha].Cells["colDescResiduo"].Value = dr["DESC_RESIDUO"].ToString();
                    iLinha++;
                }
            }
                    
        private void PreencheGridResiduosGerador(int iCod_Entrada)
        {
            OleDbDataReader dr;
            string sSql = ""; //ssCnpj ="";
            int i=0, iR=0, ix=1;

            for (i = 0; i < dgvCliente.Rows.Count; i++)
            {
                sSql = "SELECT * FROM TB_BALANCA_SAIDA TS INNER JOIN TB_BALANCA_ENTRADA TE ON TS.ID_ENT_BALANCA = TE.ID_ENT_BALANCA WHERE CNPJ_GERADOR= '" + dgvCliente.Rows[i].Cells["colCNPJ"].Value + "' AND NUM_TICKET = 0 AND TS.ID_ENT_BALANCA = " + iCod_Entrada + " ORDER BY ID_BAL_SAIDA";
                
                dr = cnn.Oledb_Pesquisa(sSql);

                while (dr.Read())
                {
                    if (dgvManiRes.Rows.Count < ix)
                    {
                        dgvManiRes.Rows.Add();
                    }

                    for (iR = 0; iR < dgvManiRes.Rows.Count; iR++)
                    {
                        

                        if (dgvManiRes.Rows[iR].Cells["colCNPJRes"].Value == null)
                        {
                            dgvManiRes.Rows[iR].Cells["colCNPJRes"].Value = dr["CNPJ_GERADOR"].ToString();
                            dgvManiRes.Rows[iR].Cells["colManifesto"].Value = dr["NUM_MANIFESTO"].ToString();
                            dgvManiRes.Rows[iR].Cells["colCodRes"].Value = dr["CD_RESIDUO"].ToString();
                            dgvManiRes.Rows[iR].Cells["colPeso"].Value = dr["PESO_RATEIO"].ToString();
                            dgvManiRes.Rows[iR].Cells["colPesoManual"].Value = dr["PESO_MANUAL"].ToString();
                            dgvManiRes.Rows[iR].Cells["colSeqGera"].Value = dr["ID_ENT_BALANCA"].ToString();
                            dgvManiRes.Rows[iR].Cells["colCodGerResSaida"].Value = dr["CD_GERADOR_RES"].ToString();
                            break;
                        }
                    
                    }

                    ix++;
                
                }

            }
        
        }

        private void dgvTransDentroAterro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string sPlaca;
            int iLinha = 20, i=0;

            if (dgvTransDentroAterro.Rows[e.RowIndex].Cells["colPlaca"].Value != null)
            {
                sPlaca = (string)dgvTransDentroAterro.Rows[e.RowIndex].Cells["colPlaca"].Value;
                sCod_Entrada = (string)dgvTransDentroAterro.Rows[e.RowIndex].Cells["colCod"].Value;

                dgvManiRes.Rows.Clear();

                for (i = 0; i <= iLinha; i++)
                    dgvManiRes.Rows.Add();

                PreencheCamposTelaSaida(sPlaca);
                PreencheGridGeradorTelaSaida(sPlaca);
                //PreencheGridResiduosTelaSaida();

                dgvCliente.Rows[0].Cells[0].Selected = true;

                SelecionaCliente(0);

                //PreencheGridResiduosGerador(int.Parse(sCod_Entrada));

                gbSaida.Visible = false;
                groupBox5.Visible = true;
            }
        }

        private void AddResiduosGerador()
        {
            int iLinha = 0, iLinhaResMan = 0;
            string sAux = "", sAux1 = "", sAux2 = "";

            if (sNumManifesto != "")
            {
                for (iLinha = 0; iLinha <= (dgvResiduos.Rows.Count - 1); iLinha++)
                {

                    if ((dgvResiduos.Rows[iLinha].Cells["colSeciona"].Value != null) && (dgvResiduos.Rows[iLinha].Cells["colSeciona"].Value.ToString() != "False"))
                    {
                        if (dgvManiRes.Rows.Count < iLinha)
                        {
                            dgvManiRes.Rows.Add();
                        }

                        for (iLinhaResMan = 0; iLinhaResMan <= (dgvManiRes.Rows.Count - 1) ; iLinhaResMan++)
                        {
                            if (dgvManiRes.Rows[iLinhaResMan].Cells["colManifesto"].Value == null)
                            {
                                dgvManiRes.Rows[iLinhaResMan].Cells["colCNPJRes"].Value = sCNPJ;
                                dgvManiRes.Rows[iLinhaResMan].Cells["colManifesto"].Value = sNumManifesto;

                                dgvManiRes.Rows[iLinhaResMan].Cells["colCodGerResSaida"].Value = dgvResiduos.Rows[iLinha].Cells["colCodGerRes"].Value;
                                dgvManiRes.Rows[iLinhaResMan].Cells["colDesRes"].Value = dgvResiduos.Rows[iLinha].Cells["colDescResiduo"].Value;
                                dgvManiRes.Rows[iLinhaResMan].Cells["colCodRes"].Value = dgvResiduos.Rows[iLinha].Cells["colCodResiduo"].Value;
                                dgvManiRes.Rows[iLinhaResMan].Cells["colSeqGera"].Value = sSeg;
                                dgvManiRes.Rows[iLinhaResMan].Cells["colPesoManual"].Value = "0";
                                CalculaPesoPorResiduo();
                                break;
                            }
                            else
                            {
                                sAux = (string)dgvManiRes.Rows[iLinhaResMan].Cells["colCNPJRes"].Value;
                                sAux1 = (string)dgvManiRes.Rows[iLinhaResMan].Cells["colCodGerResSaida"].Value;
                                sAux2 = (string)dgvResiduos.Rows[iLinha].Cells["colCodGerRes"].Value;
                                if (sAux == sCNPJ && sAux1 == sAux2 )
                                {
                                    break;
                                }
                            }
                        }

                    }

                }
            }
            else
                MessageBox.Show("Favor selecionar o Gerador !!!");
        
        }

        private void CalculaPesoPorResiduo()
        {
            int iLinha = 0, iPesoBalanca = 0;
            double dPeso = 0, dPesoManual = 0;
            string sPeso = "0", sPesoTara = "" ;
            double dPesoLiqEnt = 0;

            if (Convert.ToDouble(txtPesoTara.Text) > 0)
            {
                sPeso = txtPesoTara.Text;
                sPesoTara = txtPesoBruto.Text;
                

            }
            else
            {
                sPeso = txtPesoTaraM.Text;
                sPesoTara = txtPesoBrutoM.Text;
            }

            //dPesoLiqEnt = Convert.ToDouble(sPeso);

            if ((Convert.ToDouble(sPeso) - Convert.ToDouble(sPesoTara)) < 0)
                dPesoLiqEnt = ((Convert.ToDouble(sPeso) - Convert.ToDouble(sPesoTara)) * (-1))  ;
            else
                dPesoLiqEnt = (Convert.ToDouble(sPeso) - Convert.ToDouble(sPesoTara));

            if (Convert.ToDouble(txtPesoTara.Text) > 0)
                txtPesoLiq.Text = Convert.ToString(dPesoLiqEnt);
            else
                txtLiqM.Text = Convert.ToString(dPesoLiqEnt);

            for (iLinha = 0; iLinha <= dgvManiRes.Rows.Count-1; iLinha++)
            {
                if (dgvManiRes.Rows[iLinha].Cells["colManifesto"].Value != null)
                {
                    if (Convert.ToDouble(dgvManiRes.Rows[iLinha].Cells["colPesoManual"].Value.ToString()) > 0)
                    {
                        dPesoManual += Convert.ToDouble(dgvManiRes.Rows[iLinha].Cells["colPesoManual"].Value);
                    }
                    else
                        iPesoBalanca++;

                    if (iPesoBalanca > 0)
                        dPeso = (dPesoLiqEnt - dPesoManual) / iPesoBalanca;
                    else
                        dPeso = (dPesoLiqEnt - dPesoManual);

                }
                else
                    break;
            }

            if (dPesoManual <= dPesoLiqEnt)
            {

                for (iLinha = 0; iLinha <= dgvManiRes.Rows.Count-1; iLinha++)
                {
                    if (dgvManiRes.Rows[iLinha].Cells["colManifesto"].Value != null)
                    {
                        if (Convert.ToDouble(dgvManiRes.Rows[iLinha].Cells["colPesoManual"].Value.ToString()) == 0)
                        {
                            dgvManiRes.Rows[iLinha].Cells["colPeso"].Value = dPeso;
                        }
                        else
                            dgvManiRes.Rows[iLinha].Cells["colPeso"].Value = 0;

                    }
                    else
                        break;
                }
            }
            else
                MessageBox.Show("Peso manual: " + dPesoManual + " maior que o peso de entrada " + dPesoLiqEnt + "  ");

        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionaCliente(e.RowIndex);
        }

        private void SelecionaCliente(int Index)
        {
            sCodLab = (string)dgvCliente.Rows[Index].Cells["colCodLab"].Value;
            sNumManifesto = (string)dgvCliente.Rows[Index].Cells["colNumManifesto"].Value;
            sCNPJ = (string)dgvCliente.Rows[Index].Cells["colCNPJ"].Value;
            sSeg = (string)dgvCliente.Rows[Index].Cells["colSeguencia"].Value;
            PreencheGridResiduosTelaSaida(sCNPJ);
        
        }

        private void btnTransf_Click(object sender, EventArgs e)
        {
            AddResiduosGerador();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            
            btnGrava.Enabled = false;
            GravaSaida();
            //gbSaida.Visible = true;
            MessageBox.Show("Gravado com sucesso !!!");
            btnGrava.Enabled = true;
        }

        private void GravaSaida()
        {
            string sSql;
            int iLinha = 0;
            string sPesoRes, sPesoResM;
            AtualizaObs();
            for (iLinha = 0; iLinha <= dgvManiRes.Rows.Count; iLinha++)
            {
                sSql = "UPDATE TB_BALANCA_ENTRADA SET STATUS_ENTRADA = 'T', PESO_TARA_BALANCA_ENTRADA = '" + txtPesoBruto.Text.Replace(",", ".") + "', ";
                sSql += "PESO_TARA_MANU_ENTRADA = '" + txtPesoBrutoM.Text.Replace(",", ".") + "', ";
                sSql += "PESO_LIQUIDO_MANU_ENTRADA = '" + txtLiqM.Text.Replace(",", ".") + "', ";
                sSql += "PESO_LIQUIDO_BALANCA_ENTRADA = '" + txtPesoLiq.Text.Replace(",", ".") + "',  ";
                sSql += "VEICULO_TRANSPORTADOR = '"+txtVeiculo.Text+"', ";
                sSql += "NOM_MOTORISTA = '" + txtMot.Text + "', PLACA_TRANSPORTADOR = ";
                sSql += "'" + txtPlaca.Text + "', FAN_TRANSPORTADOR = '"+ txtTransp.Text +"' WHERE ID_ENT_BALANCA = " + sCod_Entrada + "";
 
                cnn.Oledb_Grava(sSql);

                if (dgvManiRes.Rows[iLinha].Cells["colManifesto"].Value != null)
                {
                    sPesoRes = Convert.ToString(dgvManiRes.Rows[iLinha].Cells["colPeso"].Value);
                    sPesoResM = Convert.ToString(dgvManiRes.Rows[iLinha].Cells["colPesoManual"].Value);
                    sSql = "EXEC SP_BALANCA_SAIDA ";
                    sSql += "'" + dgvManiRes.Rows[iLinha].Cells["colCNPJRes"].Value + "', ";
                    sSql += "'" + dgvManiRes.Rows[iLinha].Cells["colManifesto"].Value + "', ";
                    sSql += "'" + dgvManiRes.Rows[iLinha].Cells["colCodRes"].Value + "', ";
                    sSql += "'" + sPesoRes.Replace(",",".") + "', ";
                    sSql += "'" + sPesoResM.Replace(",", ".") + "', '" + txtDtSaida.Text + "', " + dgvManiRes.Rows[iLinha].Cells["colSeqGera"].Value + ", " + dgvManiRes.Rows[iLinha].Cells["colCodGerResSaida"].Value + " ";

                    cnn.Oledb_Grava(sSql); 

                   // sSql = "UPDATE TB_BALANCA_ENTRADA SET STATUS_ENTRADA = 'T', PESO_TARA_BALANCA_ENTRADA = '"+ txtPesoBruto.Text.Replace(",",".") +"', ";
                   // sSql += "PESO_TARA_MANU_ENTRADA = '" + txtPesoBrutoM.Text.Replace(",", ".") + "', ";
                   // sSql += "PESO_LIQUIDO_MANU_ENTRADA = '" + txtLiqM.Text.Replace(",",".") +"', ";
                   // sSql += "PESO_LIQUIDO_BALANCA_ENTRADA = '" + txtPesoLiq.Text.Replace(",", ".") + "', ";
                   // sSql += "NOM_MOTORISTA = '"+ txtMot.Text + "' WHERE CNPJ_CPF_GERADOR = ";
                   // sSql += "'" + dgvManiRes.Rows[iLinha].Cells["colCNPJRes"].Value + "' AND PLACA_TRANSPORTADOR = ";
                   // sSql += "'"+ txtPlaca.Text +"' AND ID_ENT_BALANCA = " + dgvManiRes.Rows[iLinha].Cells["colSeqGera"].Value + "";

                   //cnn.Oledb_Grava(sSql);

                   btnTicket.Enabled = true;

                }
                else
                    break;
            }
      
        }

        private void AtualizaObs()
        {
            string sSql;
            int iLinha = 0;
            

            for (iLinha = 0; iLinha <= dgvCliente.Rows.Count - 1; iLinha++){
                if (dgvManiRes.Rows[iLinha].Cells["colSeqGera"].Value != null )
                {
                    sSql = "UPDATE TB_BALANCA_SAIDA ";
                    sSql += "SET OBS_BAL_SAIDA = '" + txtObsTicket.Text  + "' ";
                    sSql += "WHERE ID_ENT_BALANCA = " + dgvManiRes.Rows[iLinha].Cells["colSeqGera"].Value;

                    cnn.Oledb_Grava(sSql);
                }
            }
        }

       /* private void InicializaBalaca()
        {
            Boolean bRet;
            int balanca = Convert.ToInt16(iBalanca);

            int x = this.Handle.ToInt32();

            bRet = cb.IniciarBalanca(balanca);

            if (bRet)
            {

                timer1.Enabled = true;

            }
            else
            {
                MessageBox.Show("Balança não Iniciada !!!");

            }

        }

        private void FinalizaBalanca()
        {
            cb.FinalizaBalanca(iBalanca);
        }*/

        private void Leitura()
        {

            string sMsn = "";
            string sPesoBruto = "0", sPesoLiquido = "0", sPesoTara = "0", sContagem = "0", sVlUnitario = "0", sVlTotal = "0", sCodigo = "0";
            int balanca = iBalanca;//Convert.ToInt16(txtBalanca.Text);

            cb.LeituraBalanca(balanca, ref sPesoBruto, ref sPesoLiquido, ref sPesoTara, ref sContagem, ref sVlUnitario, ref sVlTotal, ref sCodigo, ref sMsn);

            txtPesoBruto.Text = sPesoBruto;
            ///txtPesoLiq.Text = sPesoLiquido;
            //txtPesoTara.Text = sPesoTara;
            lblMsn.Text = sMsn;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sPesoEnt, sPesoSaida;

            DateTime dtAtual = DateTime.Now;

            if(Convert.ToDouble(txtPesoTara.Text) > 0)
                txtDtSaida.Text = dtAtual.ToString("dd/MM/yyyy HH:mm");

            Leitura();
            preecheGridInicio();
            CalculaPesoPorResiduo();

            if (Convert.ToDouble(txtPesoTara.Text) > 0)
            {
                sPesoEnt = txtPesoTara.Text;
                sPesoSaida = txtPesoBruto.Text;
            }
            else
            { 
                sPesoEnt = txtPesoTaraM.Text;
                sPesoSaida = txtPesoBrutoM.Text;
            }

            if (Convert.ToDouble(txtPesoTara.Text) > 0)
            {
                if (Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida) < 0)
                    txtPesoLiq.Text = Convert.ToString((Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida)) * (-1));
                else
                    txtPesoLiq.Text = Convert.ToString(Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida));
            }
            else
            {
                if (Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida) < 0)
                    txtLiqM.Text = Convert.ToString((Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida)) * (-1));
                else
                    txtLiqM.Text = Convert.ToString(Convert.ToDouble(sPesoEnt) - Convert.ToDouble(sPesoSaida));
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //FinalizaBalanca();
            gbSaida.Visible = true;
            btnTicket.Enabled = false;
            groupBox5.Visible = false;
            //this.Hide();

        }

        private void dgvManiRes_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaPesoPorResiduo();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            cControle_Impressora.cControle_Impressora ci = new cControle_Impressora.cControle_Impressora();
            int i;
            string sSql;
            
            OleDbDataReader dr, drSeq;

            GravaSaida();
            groupBox5.Visible = false;
            ci.Impressoras("Ticket");
            ci.FontImpressao("Courier New", 9);

            for (i = 0; i <= dgvCliente.Rows.Count-1; i++)
            {
                if (dgvCliente.Rows[i].Cells["colCNPJ"].Value != null)
                {
                    sSql = "SELECT NUM_CONTROLE FROM TB_CONTROLE_NUMERACAO WHERE ID_CONTROLE_NUM = 1";
                    drSeq = cnn.Oledb_Pesquisa(sSql);

                    drSeq.Read();

                    sSql = "UPDATE TB_BALANCA_SAIDA SET NUM_TICKET = " + drSeq["NUM_CONTROLE"].ToString() + " WHERE CNPJ_GERADOR = ";
                    sSql += "'" + dgvCliente.Rows[i].Cells["colCNPJ"].Value + "'  ";
                    sSql += "AND NUM_TICKET = 0 AND ID_ENT_BALANCA = " + dgvCliente.Rows[i].Cells["colSeguencia"].Value + "";

                    cnn.Oledb_Grava(sSql);

                    sSql = "EXEC SP_BALANCA_IMP_TICKET " + dgvCliente.Rows[i].Cells[1].Value + " , ";
                    sSql += "'" + dgvCliente.Rows[i].Cells["colCNPJ"].Value + "', 'G', " + dgvCliente.Rows[i].Cells["colSeguencia"].Value + "";
                    dr = cnn.Oledb_Pesquisa(sSql);
                    ci.ImpTicket(dr, "R");

                    sSql = "UPDATE TB_BALANCA_ENTRADA SET STATUS_ENTRADA = 'S'  ,PESO_LIQUIDO_BALANCA_ENTRADA = '" + txtPesoLiq.Text.Replace(",", ".") + "', PESO_TARA_BALANCA_ENTRADA = '" + txtPesoBruto.Text.Replace(",", ".") + "', PESO_LIQUIDO_MANU_ENTRADA='" + txtLiqM.Text.Replace(",", ".") + "', PESO_TARA_MANU_ENTRADA = '" + txtPesoBrutoM.Text.Replace(",", ".") + "' WHERE CNPJ_CPF_GERADOR = ";
                    sSql += "'" + dgvCliente.Rows[i].Cells["colCNPJ"].Value + "' AND PLACA_TRANSPORTADOR = ";
                    sSql += "'" + txtPlaca.Text + "' AND STATUS_ENTRADA = 'T' AND ID_ENT_BALANCA = " + dgvCliente.Rows[i].Cells["colSeguencia"].Value + "";

                    cnn.Oledb_Grava(sSql);

                    sSql = "UPDATE TB_CONTROLE_NUMERACAO SET NUM_CONTROLE = NUM_CONTROLE + 1 WHERE ID_CONTROLE_NUM = 1";
                    cnn.Oledb_Grava(sSql);
                }
            }
            dgvResiduos.Rows.Clear(); 
            dgvTransDentroAterro.Rows.Clear();
            btnTicket.Enabled = false; 
            gbSaida.Visible = true;

        }

        private void txtDtSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            cFuncoes.cFuncoes fn = new cFuncoes.cFuncoes();
            if (e.KeyChar != '\b')
            {
                if (Char.IsNumber(e.KeyChar))
                    fn.FormataCampos(cFuncoes.cFuncoes.OpcaoFormata.ForData, this.txtDtSaida);
                else
                    e.Handled = true;
            }
        }

        private void txtPesoBrutoM_Leave(object sender, EventArgs e)
        {
            CalculaPesoPorResiduo();
        }

        private void ApagaResMani(int iLinha)
        {
            string sSql = "", sCnpj = (string)dgvManiRes.Rows[iLinha].Cells["colCNPJRes"].Value, sCodRes = (string) dgvManiRes.Rows[iLinha].Cells["colCodRes"].Value;

            sSql = "DELETE FROM TB_BALANCA_SAIDA WHERE ID_ENT_BALANCA = " + dgvManiRes.Rows[iLinha].Cells["colSeqGera"].Value + " ";
            sSql += "AND CNPJ_GERADOR = '" + sCnpj.Trim() + "' AND ";
            sSql += "CD_RESIDUO = '" + sCodRes.Trim() + "'";

            cnn.Oledb_Grava(sSql);

            
            dgvManiRes.Rows.RemoveAt(iLinha);
        }

        private void dgvManiRes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          if (dgvManiRes.Columns[e.ColumnIndex].Name == "colApagar")
           {
                  ApagaResMani(e.RowIndex);
           }

        }

        private void txtDtSaida_Leave(object sender, EventArgs e)
        {
            cFuncoes.cFuncoes fn = new cFuncoes.cFuncoes();
            if (!fn.IsDate(txtDtSaida.Text))
            {
                MessageBox.Show("Data ou hora Invalida", "Aviso do Sistema");
                this.txtDtSaida.Focus();
            }
            else
            {
                if (Convert.ToDateTime(txtDtSaida.Text) > DateTime.Now)
                {
                    MessageBox.Show("Data e hora informada não pode ser maior que a data e hora atual - " + DateTime.Now.ToString(), "Aviso do Sistema");
                    this.txtDtSaida.Focus();
                }
            }
        }

       

                 

    }
}
