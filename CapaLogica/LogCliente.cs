using CapaDatos;
using CapaEntidad;
using CapaILogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace CapaLogica
{
    [Serializable]
    public class LogCliente : Conexion, ILogCliente
    {
        #region sigleton
        private static readonly LogCliente _instancia = new LogCliente();
        public static LogCliente Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<int> ClienteInsertar(Cliente cliente)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var clienteID = await new DaoCliente(tran).Insertar(cliente);
                        tran.Commit();
                        Close(cnn);
                        return clienteID;
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }  
            catch(Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task ClienteActualizar(Cliente cliente)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoCliente(tran).Actualizar(cliente);
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

        public async Task ClienteDeshabilitar(int idCliente)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoCliente(tran).Deshabilitar(idCliente);
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

        public async Task<Cliente> ClienteBuscarPorIdCliente(int idCliente)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var cliente = await new DaoCliente(cnn).BuscarPorClienteID(idCliente);
                Close(cnn);
                return cliente;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Cliente> ClienteBuscarPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad, bool buscarProyectos = false, bool buscarEnAPI = false)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var daoCliente = new DaoCliente(cnn);
                var cliente = await daoCliente.BuscarPorDocumentoIdentidad(idTipoDocumentoIdentidad, numeroDocumentoIdentidad);
                if (cliente != null && buscarProyectos)
                {
                    cliente.Proyectos = await new DaoProyecto(cnn).BuscarPorClienteID(cliente.ClienteID);
                    foreach (var proyecto in cliente.Proyectos)
                    {
                        proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(proyecto.DireccionDepartamentoID);
                        proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(proyecto.DireccionProvinciaID);
                        proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(proyecto.DireccionDistritoID);
                    }
                }
                else if (cliente == null && buscarEnAPI)
                {
                    cliente = await ClienteConsultaApiPorDocumentoIdentidad(idTipoDocumentoIdentidad, numeroDocumentoIdentidad);
                    if (cliente != null)
                    {
                        using (var tran = cnn.BeginTransaction())
                        {
                            try
                            {
                                cliente.ClienteID = await new DaoCliente(tran).Insertar(cliente);
                                tran.Commit();
                            }
                            catch(Exception ex)
                            {
                                tran.Rollback();
                                throw ex;
                            }
                        }
                    }
                }

                if (cliente != null && cliente.TipoDocumentoIdentidad == null) cliente.TipoDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).BuscarPorTipoDocumentoIdentidadID(cliente.TipoDocumentoIdentidadID);
                Close(cnn);
                return cliente;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }            
        }

        public async Task<Cliente> ClienteConsultaApiPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
        {
            var cliente = (Cliente)null;
            if (idTipoDocumentoIdentidad == 1)
            {
                cliente = await Apis.ConsultaDatosReniec.Instancia.GetCliente_PersonaNaturalAsync(numeroDocumentoIdentidad);
                if (cliente == null) cliente = await Apis.ApisPeru.Instancia.GetCliente_PersonaNaturalAsync(numeroDocumentoIdentidad);
            }
            else
            {
                cliente = await Apis.ConsultaDatosReniec.Instancia.GetCliente_PersonaJuridicaAsync(numeroDocumentoIdentidad);
                if (cliente == null) await Apis.ApisPeru.Instancia.GetCliente_PersonaJuridicaAsync(numeroDocumentoIdentidad);
            }
            return cliente;
        }

        public async Task<List<Cliente>> ClienteBusquedaGeneral(short? idTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string razonSocial, string nombres, string apellido1, string apellido2)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var listaClientes = await new DaoCliente(cnn).BusquedaGeneral(idTipoDocumentoIdentidad, numeroDocumentoIdentidad, razonSocial, nombres, apellido1, apellido2);
                if (listaClientes.Count > 0)
                {
                    var tiposDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
                    foreach (var cliente in listaClientes)
                    {
                        cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == cliente.TipoDocumentoIdentidadID);
                    }
                }
                Close(cnn);
                return listaClientes;
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
