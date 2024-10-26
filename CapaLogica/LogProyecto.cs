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
    public class LogProyecto : Conexion, ILogProyecto
    {
        #region sigleton
        private static readonly LogProyecto _instancia = new LogProyecto();
        public static LogProyecto Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<int> ProyectoInsertar(Proyecto Proyecto)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var proyectoID = await new DaoProyecto(tran).Insertar(Proyecto);
                        tran.Commit();
                        Close(cnn);
                        return proyectoID;
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

        public async Task ProyectoActualizar(Proyecto Proyecto)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoProyecto(tran).Actualizar(Proyecto);
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

        public async Task ProyectoDeshabilitar(int idProyecto)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoProyecto(tran).Deshabilitar(idProyecto);
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

        public async Task<Proyecto> ProyectoBuscarPorProyectoID(int proyectoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(proyectoID);
                Close(cnn);
                return proyecto;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Proyecto>> ProyectoBuscarPorClienteID(int clienteID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var proyectos = await new DaoProyecto(cnn).BuscarPorClienteID(clienteID); 
                Close(cnn);
                return proyectos;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Proyecto>> ProyectoBusquedaGeneral(int? clienteID, string nombre, short? distritoID, short? provinciaID, short? departamentoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var listaProyectos = await new DaoProyecto(cnn).BusquedaGeneral(clienteID, nombre, distritoID, provinciaID, departamentoID);
                if (listaProyectos.Count > 0)
                {
                    var tiposDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
                    var daoCliente = new DaoCliente(cnn);
                    foreach (var Proyecto in listaProyectos)
                    {
                        Proyecto.Cliente = await daoCliente.BuscarPorClienteID(Proyecto.ClienteID);
                        Proyecto.Cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == Proyecto.Cliente.TipoDocumentoIdentidadID);
                    }
                }
                await LLenarUbigeo(listaProyectos);

                Close(cnn);
                return listaProyectos;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        private async Task LLenarUbigeo(List<Proyecto> listaProyectos)
        {
            if (listaProyectos.Count > 0)
            {
                var departamentos = await LogDepartamento.Instancia.DepartamentoBuscarTodos();
                foreach (var proyecto in listaProyectos)
                {
                    proyecto.DireccionDepartamento = departamentos.Find(x => x.DepartamentoID == proyecto.DireccionDepartamentoID);
                    proyecto.DireccionProvincia = proyecto.DireccionDepartamento.Provincias.Find(x => x.ProvinciaID == proyecto.DireccionProvinciaID);
                    proyecto.DireccionDistrito = proyecto.DireccionProvincia.Distritos.Find(x => x.DistritoID == proyecto.DireccionDistritoID);
                }
            }
        }

        #endregion metodos
    }
}
