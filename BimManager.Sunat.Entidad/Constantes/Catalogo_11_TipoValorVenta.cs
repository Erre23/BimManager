using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public static class Catalogo_11_TipoValorVenta
    {
        /// <summary>
        /// Retorna 01
        /// </summary>
        public static string Gravado { get { return "01"; } }

        /// <summary>
        /// Retorna 02
        /// </summary>
        public static string Exonerado { get { return "02"; } }

        /// <summary>
        /// Retorna 03
        /// </summary>
        public static string Inafecto { get { return "03"; } }

        /// <summary>
        /// Retorna 04
        /// </summary>
        public static string Exportacion { get { return "04"; } }

        /// <summary>
        /// Retorna 05
        /// </summary>
        public static string Gratuitas { get { return "05"; } }
    }
}
