using CapaEntidad;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CapaILogica
{
    [ServiceContract]
    public interface ILogUsuario
    {
        [OperationContract]
        Task<Usuario> UsuarioBuscarPorUsername(string username);

        [OperationContract]
        Task<int> UsuarioInsertar(Usuario usuario);

        [OperationContract]
        Task<Usuario> UsuarioLogin(string username, string password);
    }
}