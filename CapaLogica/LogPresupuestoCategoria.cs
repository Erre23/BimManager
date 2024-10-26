using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BimManager.Logica
{
    [Serializable]
    public class LogPresupuestoCategoria : Conexion, ILogPresupuestoCategoria
    {
        #region sigleton
        private static readonly LogPresupuestoCategoria _instancia = new LogPresupuestoCategoria();
        public static LogPresupuestoCategoria Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<short> PresupuestoCategoriaInsertar(PresupuestoCategoria presupuestoCategoria)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var presupuestoCategoriaId = await new DaoPresupuestoCategoria(tran).Insertar(presupuestoCategoria);
                        tran.Commit();
                        Close(cnn);
                        return presupuestoCategoriaId;
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

        public async Task PresupuestoCategoriaActualizar(PresupuestoCategoria presupuestoCategoria)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        await new DaoPresupuestoCategoria(tran).Actualizar(presupuestoCategoria);
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

        public async Task<PresupuestoCategoria> PresupuestoCategoriaBuscarPorPresupuestoCategoriaID(short PresupuestoCategoriaID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuestoCategoria = await new DaoPresupuestoCategoria(cnn).BuscarPorPresupuestoCategoriaID(PresupuestoCategoriaID);
                Close(cnn);
                return presupuestoCategoria;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<PresupuestoCategoria>> PresupuestoCategoriaBuscarTodos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuestoCategorias = await new DaoPresupuestoCategoria(cnn).BuscarTodos();
                presupuestoCategorias = PresupuestoCategoriaJerarquizar(presupuestoCategorias);

                Close(cnn);
                return presupuestoCategorias;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        private List<PresupuestoCategoria> PresupuestoCategoriaJerarquizar(List<PresupuestoCategoria> presupuestoCategorias)
        {
            var diccionario = new Dictionary<short, PresupuestoCategoria>();

            foreach (var iteracion in presupuestoCategorias)
            {
                if (iteracion.PadrePresupuestoCategoriaID != null)
                {
                    PresupuestoCategoria padrePresupuestoCategoria = null;
                    diccionario.TryGetValue(iteracion.PadrePresupuestoCategoriaID.Value, out padrePresupuestoCategoria);
                    if (padrePresupuestoCategoria == null)
                    {
                        padrePresupuestoCategoria = new PresupuestoCategoria
                        {
                            PresupuestoCategoriaID = iteracion.PadrePresupuestoCategoriaID.Value
                        };
                        diccionario.Add(padrePresupuestoCategoria.PresupuestoCategoriaID, padrePresupuestoCategoria);
                        //iteracion.PadrePresupuestoCategoria = padrePresupuestoCategoria;
                    }
                    padrePresupuestoCategoria.SubPresupuestoCategorias.Add(iteracion);
                }
                else
                {
                    PresupuestoCategoria presupuestoCategoria = null;
                    diccionario.TryGetValue(iteracion.PresupuestoCategoriaID, out presupuestoCategoria);
                    if (presupuestoCategoria != null)
                    {
                        presupuestoCategoria.Nombre = iteracion.Nombre;
                        presupuestoCategoria.Observaciones = iteracion.Observaciones;
                        presupuestoCategoria.Porcentaje = iteracion.Porcentaje;
                    }
                    else
                    {
                        diccionario.Add(iteracion.PresupuestoCategoriaID, iteracion);
                    }
                }
            }

            return diccionario.Values.ToList();
        }

        #endregion metodos
    }
}
