using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogProyecto
    {
        #region sigleton
        private static readonly LogProyecto _instancia = new LogProyecto();
        public static LogProyecto Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        
        public async Task<int> ProyectoInsertar(Proyecto Proyecto)
        {
            return await DaoProyecto.Instancia.Insertar(Proyecto);
        }

        public async Task ProyectoActualizar(Proyecto Proyecto)
        {
            await DaoProyecto.Instancia.Actualizar(Proyecto);
        }

        public async Task ProyectoDeshabilitar(int idProyecto)
        {
            await DaoProyecto.Instancia.Deshabilitar(idProyecto);
        }

        public async Task<Proyecto> ProyectoBuscarPorProyectoID(int proyectoID)
        {
            return await DaoProyecto.Instancia.BuscarPorProyectoID(proyectoID);
        }

        public async Task<Proyecto> ProyectoBuscarPorClienteID(int clienteID)
        {
            return await DaoProyecto.Instancia.BuscarPorClienteID(clienteID);
        }

        public async Task<List<Proyecto>> ProyectoBusquedaGeneral(int? clienteID, string nombre, short? distritoID, short? provinciaID, short? departamentoID)
        {
            var listaProyectos = await DaoProyecto.Instancia.BusquedaGeneral(clienteID, nombre, distritoID, provinciaID, departamentoID);
            if (listaProyectos.Count > 0)
            {
                var tiposDocumentoIdentidad = await DaoTipoDocumentoIdentidad.Instancia.ListarTodos();
                foreach (var Proyecto in listaProyectos)
                {
                    Proyecto.Cliente = await DaoCliente.Instancia.BuscarPorClienteID(Proyecto.ClienteID);
                    Proyecto.Cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == Proyecto.Cliente.TipoDocumentoIdentidadID);
                }
            }

            await LLenarDistrito(listaProyectos);

            return listaProyectos;
        }

		private async Task LLenarDistrito(List<Proyecto> listaProyectos)
		{
			if (listaProyectos.Count > 0)
			{
				var distritos = await LogDepartamento.Instancia.DistritoBuscarTodos();
				foreach (var proyecto in listaProyectos)
				{
					proyecto.DireccionDistrito = distritos.Find(x => x.DistritoID == proyecto.DireccionDistritoID);
					proyecto.DireccionProvincia = proyecto.DireccionDistrito.Provincia;
					proyecto.DireccionDepartamento = proyecto.DireccionProvincia.Departamento;
				}
			}
		}

		#endregion metodos
	}
}
