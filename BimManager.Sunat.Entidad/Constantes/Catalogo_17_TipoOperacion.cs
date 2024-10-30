using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 17 de SUNAT para los tipos de operación
    /// </summary>
    [Serializable]
    public static class Catalogo_17_TipoOperacion
    {
        /// <summary>
        /// Retorna 01
        /// </summary>
        public static string VentaInterna { get { return "01"; } }

        /// <summary>
        /// Retorna 02
        /// </summary>
        public static string Exportacion { get { return "02"; } }

        /// <summary>
        /// Retorna 03
        /// </summary>
        public static string NoDomiciliados { get { return "03"; } }

        /// <summary>
        /// Retorna 04
        /// </summary>
        public static string VentaInterna_Anticipos { get { return "04"; } }

        /// <summary>
        /// Retorna 05
        /// </summary>
        public static string VentaItinerante { get { return "05"; } }

        /// <summary>
        /// Retorna 06
        /// </summary>
        public static string FacturaGuia { get { return "06"; } }

        /// <summary>
        /// Retorna 07
        /// </summary>
        public static string VentaArrozPilado { get { return "07"; } }

        /// <summary>
        /// Retorna 08
        /// </summary>
        public static string Factura_ComprobantePercerpcion { get { return "08"; } }
    }
}
