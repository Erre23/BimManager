using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
	public class LogTipoDocumentoSunat
    {
        #region sigleton
        private static readonly LogTipoDocumentoSunat _instancia = new LogTipoDocumentoSunat();
        public static LogTipoDocumentoSunat Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        public async Task<short> TipoDocumentoSunatInsertar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            return await DaoTipoDocumentoSunat.Instancia.Insertar(tipoDocumentoSunat);
        }

        public async Task TipoDocumentoSunatActualizar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            await DaoTipoDocumentoSunat.Instancia.Actualizar(tipoDocumentoSunat);
        }

        public async Task TipoDocumentoSunatDeshabilitar(short idTipoDocumentoSunat)
        {
            await DaoTipoDocumentoSunat.Instancia.Deshabilitar(idTipoDocumentoSunat);
        }

        ///listado
        public async Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarActivos()
        {
            return await DaoTipoDocumentoSunat.Instancia.ListarActivos();
        }

        public async Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarTodos()
        {
            return await DaoTipoDocumentoSunat.Instancia.ListarTodos();
        }

        #endregion metodos
    }
}
