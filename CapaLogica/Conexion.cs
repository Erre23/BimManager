using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    [Serializable]
    public abstract class Conexion : MarshalByRefObject
    {
        public SqlConnection Conectar()
        {
            SqlConnection cnn = new SqlConnection();
			//cnn.ConnectionString = "Data Source=UTSILAB736;Initial Catalog=BDBimManager;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
			cnn.ConnectionString = "Data Source=localhost;Initial Catalog=BDBimManager;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
			return cnn;
        }

        public void Close(SqlConnection cnn)
        {
            if (cnn != null)
            {
                if (cnn.State != ConnectionState.Closed) cnn.Close();
                cnn.Dispose();
            }
        }
    }
}
