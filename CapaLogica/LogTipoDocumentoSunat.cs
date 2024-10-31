using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Logica
{
    [Serializable]
    public class LogTipoDocumentoSunat : Conexion, ILogTipoDocumentoSunat
    {
        #region sigleton
        private static readonly LogTipoDocumentoSunat _instancia = new LogTipoDocumentoSunat();
        public static LogTipoDocumentoSunat Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        public async Task<byte> TipoDocumentoSunatInsertar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var tipoDocumentoSunatID = await new DaoTipoDocumentoSunat(tran).Insertar(tipoDocumentoSunat);
                        tran.Commit();
                        Close(cnn);
                        return tipoDocumentoSunatID;
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

        public async Task TipoDocumentoSunatActualizar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoTipoDocumentoSunat(tran).Actualizar(tipoDocumentoSunat);
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

        public async Task TipoDocumentoSunatDeshabilitar(byte idTipoDocumentoSunat)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoTipoDocumentoSunat(tran).Deshabilitar(idTipoDocumentoSunat);
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
        public async Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarActivos(bool incluirSeries = false)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var lista = await new DaoTipoDocumentoSunat(cnn).ListarActivos();
                if (lista.Count > 0)
                {
                    var daoSerie = new DaoSerie(cnn);
                    foreach (var item in lista)
                    {
                        item.Series = await daoSerie.ListarActivosPorTipoDocumentoSunatID(item.TipoDocumentoSunatID);
                    }
                }
                Close(cnn);
                return lista;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarTodos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var lista = await new DaoTipoDocumentoSunat(cnn).ListarTodos();
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
