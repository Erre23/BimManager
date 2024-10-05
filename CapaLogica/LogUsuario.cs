using CapaDatos;
using CapaEntidad;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogUsuario
    {
        #region sigleton
        private static readonly LogUsuario _instancia = new LogUsuario();
        public static LogUsuario Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        
        public async Task<int> UsuarioInsertar(Usuario usuario)
        {
            return await DaoUsuario.Instancia.Insertar(usuario);
        }

        public async Task<Usuario> UsuarioLogin(string username, string password)
        {
            return await DaoUsuario.Instancia.Login(username, password);
        }

        public async Task<Usuario> UsuarioBuscarPorUsername(string username)
        {
            return await DaoUsuario.Instancia.BuscarPorUsername(username);
        }

        #endregion metodos
    }
}
