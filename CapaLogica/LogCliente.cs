using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogCliente
    {
        #region sigleton
        private static readonly LogCliente _instancia = new LogCliente();
        public static LogCliente Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        
        public async Task<int> ClienteInsertar(Cliente cliente)
        {
            return await DaoCliente.Instancia.Insertar(cliente);
        }

        public async Task ClienteActualizar(Cliente cliente)
        {
            await DaoCliente.Instancia.Actualizar(cliente);
        }

        public async Task ClienteDeshabilitar(int idCliente)
        {
            await DaoCliente.Instancia.Deshabilitar(idCliente);
        }

        public async Task<Cliente> ClienteBuscarPorIdCliente(int idCliente)
        {
            return await DaoCliente.Instancia.BuscarPorClienteID(idCliente);
        }

        public async Task<Cliente> ClienteBuscarPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
        {
            return await DaoCliente.Instancia.BuscarPorDocumentoIdentidad(idTipoDocumentoIdentidad, numeroDocumentoIdentidad);
		}

		public async Task<Cliente> ClienteConsultaApiPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
		{
            if (idTipoDocumentoIdentidad == 1) return await Apis.ApisPeru.Instancia.GetCliente_PersonaNaturalAsync(numeroDocumentoIdentidad);
			else return await Apis.ApisPeru.Instancia.GetCliente_PersonaJuridicaAsync(numeroDocumentoIdentidad);
		}

		public async Task<List<Cliente>> ClienteBusquedaGeneral(short? idTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string razonSocial, string nombres, string apellido1, string apellido2)
        {
            var listaClientes = await DaoCliente.Instancia.BusquedaGeneral(idTipoDocumentoIdentidad, numeroDocumentoIdentidad, razonSocial, nombres, apellido1, apellido2);
            if (listaClientes.Count > 0)
            {
                var tiposDocumentoIdentidad = await DaoTipoDocumentoIdentidad.Instancia.ListarTodos();
                foreach (var cliente in listaClientes)
                {
                    cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == cliente.TipoDocumentoIdentidadID);
                }
            }

            return listaClientes;
        }

        #endregion metodos
    }
}
