using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 5 para tipos de tributo en el detalle del documento de pago
    /// </summary>
    [Serializable]
    public static class Catalogo_05_TipoTributo
    {
        /// <summary>
        /// Retorna 1000 como codigo de SUNAT
        /// </summary>
        public static string IGV_Codigo_SUNAT { get { return "1000"; } }

        /// <summary>
        /// Retorna VAT como codigo internacional
        /// </summary>
        public static string IGV_Codigo_Internacional { get { return "VAT"; } }

        /// <summary>
        /// Retorna 2000 como codigo de SUNAT
        /// </summary>
        public static string ISC_Codigo_SUNAT { get { return "2000"; } }

        /// <summary>
        /// Retorna EXC como codigo internacional
        /// </summary>
        public static string ISC_Codigo_Internacional { get { return "EXC"; } }

        /// <summary>
        /// Retorna 9999 como codigo de SUNAT
        /// </summary>
        public static string Otros_Codigo_SUNAT { get { return "9999"; } }

        /// <summary>
        /// Retorna OTH como codigo internacional
        /// </summary>
        public static string Otros_Codigo_Internacional { get { return "OTH"; } }
    }
}
