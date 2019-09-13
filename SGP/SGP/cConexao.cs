using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SGP.cConexao
{
    public class cConexao
    {
        private string strCnn = ConfigurationManager.ConnectionStrings["CNN"].ToString();

        private OleDbConnection oCnn;

        public cConexao()
        {
        }

        public void AbreConnection()
        {
            this.strConnection();
            if (this.oCnn.State == ConnectionState.Closed)
            {
                this.oCnn.Open();
            }
        }

        public DataSet DataSet_Pesquisa(string sSql)
        {
            DataSet dataSet;
            try
            {
                this.strConnection();
                string SQL = sSql;
                DataSet ds = new DataSet();
                OleDbDataAdapter oDa = new OleDbDataAdapter();
                OleDbCommand oCmd = new OleDbCommand(SQL, this.oCnn);
                oCmd.CommandType = CommandType.Text;
                oDa.SelectCommand = oCmd;
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                oDa.Fill(ds);
                dataSet = ds;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }

        public void FechaConnection()
        {
            if (this.oCnn.State == ConnectionState.Open)
            {
                this.oCnn.Dispose();
                this.oCnn.Close();
            }
        }

        private void Grava_Log(string sSql)
        {
            try
            {
                this.strConnection();
                OleDbCommand oCmd = new OleDbCommand(sSql, this.oCnn);
                oCmd.CommandType = CommandType.Text;
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                oCmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Log(OleDbDataReader dsAtual, DataSet dsNovo)
        {
            string[] strArrays;
            string sAlteracao = "";
            int iLinha = 0;
            while (dsAtual.Read())
            {
                int iColuna = 0;
                for (int iAux = 1; dsNovo.Tables[0].Columns.Count > iAux; iAux++)
                {
                    string sCampo = dsAtual.GetName(iColuna).ToString();
                    string sValorAtual = dsAtual[sCampo].ToString();
                    string sValorNovo = dsNovo.Tables[0].Rows[iLinha][sCampo].ToString();
                    if (sValorAtual != sValorNovo)
                    {
                        if (!(sAlteracao != ""))
                        {
                            strArrays = new string[] { sCampo, " - valor alterado de: ", sValorAtual, " para ", sValorNovo };
                            sAlteracao = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { sAlteracao, ", ", sCampo, " - valor alterado de: ", sValorAtual, " para ", sValorNovo };
                            sAlteracao = string.Concat(strArrays);
                        }
                    }
                    iColuna++;
                }
                iLinha++;
            }
        }

        public void Oledb_Grava(string sSql)
        {
            try
            {
                this.strConnection();
                OleDbCommand oCmd = new OleDbCommand(sSql, this.oCnn);
                oCmd.CommandType = CommandType.Text;
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                oCmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Oledb_Grava(string sSql, string sPesq_Log)
        {
            try
            {
                this.strConnection();
                OleDbCommand oCmd = new OleDbCommand(sSql, this.oCnn);
                Array[] sPesq = new Array[10];
                oCmd.CommandType = CommandType.Text;
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                OleDbDataReader drAtual = this.Oledb_Pesquisa(sPesq_Log);
                oCmd.ExecuteNonQuery();
                this.Log(drAtual, this.DataSet_Pesquisa(sPesq_Log));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public OleDbDataReader Oledb_Pesquisa(string sSql)
        {
            OleDbDataReader oleDbDataReader;
            try
            {
                this.strConnection();
                OleDbCommand oCmd = new OleDbCommand(sSql, this.oCnn);
                oCmd.CommandType = CommandType.Text;
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                oleDbDataReader = oCmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return oleDbDataReader;
        }

        public Int32 Oledb_LastId()
        {
            try
            {
                this.strConnection();
                OleDbCommand oCmd = new OleDbCommand("SELECT @@IDENTITY;", this.oCnn);
                //oCmd.CommandType = CommandType.Text;
                oCmd.CommandText = "SELECT @@IDENTITY;";
                if (this.oCnn.State == ConnectionState.Closed)
                {
                    this.oCnn.Open();
                }
                oCmd.ExecuteNonQuery();
                return (Int32) oCmd.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            //return -1;
        }


        private void strConnection()
        {
            try
            {
                this.oCnn = new OleDbConnection(this.strCnn);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}