using BimManager.Entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BimManager.Datos
{
	public class DaoUsuario
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoUsuario(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoUsuario(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos
        private const int SaltSize = 16; // Tamaño de la sal en bytes
        private const int Iterations = 100000; // Número de iteraciones para PBKDF2
        private string Encriptar(string contrasena)
        {
            // Genera una sal aleatoria
            byte[] salt = new byte[SaltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // Crea el hash de la contraseña
            var pbkdf2 = new Rfc2898DeriveBytes(contrasena, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20); // 20 bytes para el hash

            // Combina la sal y el hash para almacenar
            byte[] hashBytes = new byte[SaltSize + 20];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, 20);

            // Convierte a Base64 para almacenar en la base de datos
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public bool VerificarPassword(string hashPasswordGuardada, string passwordIngresada)
        {
            // Extrae la sal y el hash almacenados
            byte[] hashBytesContrasenaGuardada = Convert.FromBase64String(hashPasswordGuardada);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytesContrasenaGuardada, 0, salt, 0, SaltSize);

            // Calcula el hash para la contraseña ingresada
            var pbkdf2 = new Rfc2898DeriveBytes(passwordIngresada, salt, Iterations);
            byte[] hashBytesContrasenaIngresada = pbkdf2.GetBytes(20);

            // Compara los hashes
            for (int i = 0; i < 20; i++)
            {
                if (hashBytesContrasenaGuardada[i + SaltSize] != hashBytesContrasenaIngresada[i])
                    return false;
            }

            return true;
        }

        public async Task<int> Insertar(Usuario usuario)
        {

            usuario.HashPassword = Encriptar(usuario.HashPassword);
            var cmd = (SqlCommand)null;

            try
            {
                cmd = new SqlCommand("spUsuarioInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.NVarchar("NumeroDocumentoIdentidad", usuario.Username, 50));
                cmd.Parameters.Add(CreateParams.NVarchar("Nombres", usuario.Nombres, 100));
                cmd.Parameters.Add(CreateParams.NVarchar("Apellido1", usuario.Apellido1, 50));
                cmd.Parameters.Add(CreateParams.NVarchar("Apellido2", usuario.Apellido2, 50));
                cmd.Parameters.Add(CreateParams.NVarchar("HashPassword", usuario.HashPassword, -1));
                cmd.Parameters.Add(CreateParams.Bit("Activo", usuario.Activo));                    

                usuario.UsuarioID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return usuario.UsuarioID;
        }

        public async Task<Usuario> Login(string username, string password)
        {
            var cmd = (SqlCommand)null;
            var usuario = (Usuario)null;
            try
            {
                cmd = new SqlCommand("spUsuarioBuscarPorUsername", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.NVarchar("Username", username, 50));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    usuario = ReadEntidad(dr, true);
                }

                dr.Close();
                cmd.Dispose();

                /* Si las contraseñas no coinciden retornamos el usuario null */
                if (!VerificarPassword(usuario.HashPassword, password)) usuario = null;
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return usuario;
        }

        public async Task<Usuario> BuscarPorUsername(string username)
        {
            var cmd = (SqlCommand)null;
            var usuario = (Usuario)null;
            try
            {
                cmd = new SqlCommand("spUsuarioBuscarUsername", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.NVarchar("username", username, 50));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    usuario = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return usuario;
        }
        public async Task<Usuario> BuscarPorUsuarioID(int usuerioID)
        {
            var cmd = (SqlCommand)null;
            var usuario = (Usuario)null;
            try
            {
                cmd = new SqlCommand("spUsuarioBuscarPorUsuarioID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("UsuarioID", usuerioID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    usuario = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return usuario;
        }

        private Usuario ReadEntidad(SqlDataReader dr, bool traerPassword = false)
        {
            try
            {
                var obj = new Usuario();
                obj.UsuarioID = Convert.ToInt32(dr["UsuarioID"]);
                obj.Username = dr["username"].ToString();
                obj.Nombres = dr["Nombres"].ToString();
                obj.Apellido1 = dr["Apellido1"].ToString();
                obj.Apellido2 = dr["Apellido2"].ToString();
                obj.Activo = Convert.ToBoolean(dr["Activo"]);
                if (traerPassword) obj.HashPassword = dr["HashPassword"].ToString();

                return obj;
            }
            catch(Exception ex)
            {
                dr.Close();
                throw ex;
            }
        }
        #endregion métodos
    }
}
