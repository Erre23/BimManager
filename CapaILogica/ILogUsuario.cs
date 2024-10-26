using BimManager.Entidad;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
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