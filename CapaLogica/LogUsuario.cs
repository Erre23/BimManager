using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Logica
{
    [Serializable]
    public class LogUsuario : Conexion, ILogUsuario
    {
        #region sigleton
        private static readonly LogUsuario _instancia = new LogUsuario();
        public static LogUsuario Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<int> UsuarioInsertar(Usuario usuario)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var usuarioID = await new DaoUsuario(tran).Insertar(usuario);
                        tran.Commit();
                        Close(cnn);
                        return usuarioID;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Usuario> UsuarioLogin(string username, string password)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var usuario = await new DaoUsuario(cnn).Login(username, password);
                Close(cnn);
                return usuario;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Usuario> UsuarioBuscarPorUsername(string username)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var usuario = await new DaoUsuario(cnn).BuscarPorUsername(username);
                Close(cnn);
                return usuario;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion metodos
    }
}
