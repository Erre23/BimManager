using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogica
{
    public class LogPresupuestoCategoria
	{
        #region sigleton
        private static readonly LogPresupuestoCategoria _instancia = new LogPresupuestoCategoria();
        public static LogPresupuestoCategoria Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<PresupuestoCategoria> PresupuestoCategoriaBuscarPorPresupuestoCategoriaID(short PresupuestoCategoriaID)
        {
            return await DaoPresupuestoCategoria.Instancia.BuscarPorPresupuestoCategoriaID(PresupuestoCategoriaID);
        }

        public async Task<List<PresupuestoCategoria>> PresupuestoCategoriaBuscarTodos()
        {
            var presupuestoCategorias = await DaoPresupuestoCategoria.Instancia.BuscarTodos();

            presupuestoCategorias = PresupuestoCategoriaJerarquizar(presupuestoCategorias);

			return presupuestoCategorias;
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
						iteracion.PadrePresupuestoCategoria = padrePresupuestoCategoria;
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
