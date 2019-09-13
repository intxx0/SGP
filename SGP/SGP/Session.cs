using System;
using System.Data.OleDb;

namespace SGP.Session
{
    public class Session
    {
        public const int AUTH_LOGGED = 1;
        public const int AUTH_USER_NOT_FOUND = 0;
        public const int AUTH_LOGIN_INVALID = -1;

        public static string Nome;
        public static string Unidade;
        public static string Login;

        public static string usuCodigo;
        public static string uniCodigo;
        public static string gruCodigo;

        public static int Status;

        private static cConexao.cConexao cnn = new cConexao.cConexao();

        public Session()
        {
        }

        public static bool Auth(string login, string password)
        {

            OleDbDataReader dr;

            string sSql = "EXEC PRC_USUARIO_AUTH '" + login + "','" + password + "' ";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {

                sSql = "EXEC PRC_USUARIO_ACESSO '" + dr["USU_CODIGO"] + "'";
                cnn.Oledb_Grava(sSql);
                
                Nome = dr["USU_NOME"].ToString();
                Unidade = dr["UNIDADE"].ToString();
                Login = dr["USU_LOGIN"].ToString();

                usuCodigo = dr["USU_CODIGO"].ToString();
                uniCodigo = dr["USU_UNIDADE"].ToString();
                gruCodigo = dr["USU_GRUPO"].ToString();

                Status = Session.AUTH_LOGGED;

                return true;

            }
            else
            {
                Status = Session.AUTH_LOGIN_INVALID;
                return false;
            }

        }

    }
}