using System;
using System.Data.OleDb;

namespace SGP.Acl
{
    public class Acl
    {
        public const int ACL_PERMISSION_GRANTED = 1;
        public const int ACL_PERMISSION_DENIED = 0;

        public static int Status;

        private static cConexao.cConexao cnn = new cConexao.cConexao();

        public Acl()
        {
        }

        public static bool Check(string action, string gruCodigo)
        {

            OleDbDataReader dr;

            string sSql = "EXEC PRC_ACL_CHECK '" + action + "','" + gruCodigo + "' ";
            dr = cnn.Oledb_Pesquisa(sSql);

            if (dr.Read())
            {
                Status = Acl.ACL_PERMISSION_GRANTED;
                return true;
            }
            else
            {
                Status = Acl.ACL_PERMISSION_DENIED;
                return false;
            }

        }

    }
}