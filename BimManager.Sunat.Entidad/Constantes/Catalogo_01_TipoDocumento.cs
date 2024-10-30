using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 1 de SUNAT para tipo de documento de pago
    /// </summary>
    [Serializable]
    public static class Catalogo_01_TipoDocumento
    {
        /// <summary>
        /// Retorna 01
        /// </summary>
        public static string Factura { get { return "01"; } }

        /// <summary>
        /// Retorna 03
        /// </summary>
        public static string Boleta { get { return "03"; } }

        /// <summary>
        /// Retorna 07
        /// </summary>
        public static string NotaCredito { get { return "07"; } }

        /// <summary>
        /// Retorna 08
        /// </summary>
        public static string NotaDebito { get { return "08"; } }
    }
}
