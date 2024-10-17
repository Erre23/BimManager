using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
			//cn.ConnectionString = "Data Source=UTSILAB736;Initial Catalog=BDBimManager;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
			cn.ConnectionString = "Data Source=localhost;Initial Catalog=BDBimManager;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";

			return cn;
        }
    }
}
