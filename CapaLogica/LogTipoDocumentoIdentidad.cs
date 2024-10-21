using CapaDatos;
using CapaEntidad;
using CapaILogica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaLogica
{
    [Serializable]
    public class LogTipoDocumentoIdentidad : Conexion, ILogTipoDocumentoIdentidad
    {
        #region sigleton
        private static readonly LogTipoDocumentoIdentidad _instancia = new LogTipoDocumentoIdentidad();
        public static LogTipoDocumentoIdentidad Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        public async Task<short> TipoDocumentoIdentidadInsertar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var tipoDocumentoIdentidadID = await new DaoTipoDocumentoIdentidad(tran).Insertar(tipoDocumentoIdentidad);
                        tran.Commit();
                        Close(cnn);
                        return tipoDocumentoIdentidadID;
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

        public async Task TipoDocumentoIdentidadActualizar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoTipoDocumentoIdentidad(tran).Actualizar(tipoDocumentoIdentidad);
                        tran.Commit();
                        Close(cnn);
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

        public async Task TipoDocumentoIdentidadDeshabilitar(short idTipoDocumentoIdentidad)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoTipoDocumentoIdentidad(tran).Deshabilitar(idTipoDocumentoIdentidad);
                        tran.Commit();
                        Close(cnn);
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

        ///listado
        public async Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarActivos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var lista = await new DaoTipoDocumentoIdentidad(cnn).ListarActivos();
                Close(cnn);
                return lista;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarTodos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var lista = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
                Close(cnn);
                return lista;
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
