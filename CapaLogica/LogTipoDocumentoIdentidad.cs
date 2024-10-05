using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogTipoDocumentoIdentidad
    {
        #region sigleton
        private static readonly LogTipoDocumentoIdentidad _instancia = new LogTipoDocumentoIdentidad();
        public static LogTipoDocumentoIdentidad Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        public async Task<short> TipoDocumentoIdentidadInsertar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            return await DaoTipoDocumentoIdentidad.Instancia.Insertar(tipoDocumentoIdentidad);
        }

        public async Task TipoDocumentoIdentidadActualizar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            await DaoTipoDocumentoIdentidad.Instancia.Actualizar(tipoDocumentoIdentidad);
        }

        public async Task TipoDocumentoIdentidadDeshabilitar(short idTipoDocumentoIdentidad)
        {
            await DaoTipoDocumentoIdentidad.Instancia.Deshabilitar(idTipoDocumentoIdentidad);
        }

        ///listado
        public async Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarActivos()
        {
            return await DaoTipoDocumentoIdentidad.Instancia.ListarActivos();
        }

        public async Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarTodos()
        {
            return await DaoTipoDocumentoIdentidad.Instancia.ListarTodos();
        }

        #endregion metodos
    }
}
