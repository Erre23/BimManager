using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 2 de SUNAT para tipos de moneda
    /// </summary>
    [Serializable]
    public static class Catalogo_02_TipoMoneda
    {
        /// <summary>
        /// Retorna PEN
        /// </summary>
        public static string Soles { get { return "PEN"; } }

        /// <summary>
        /// Retorna USD
        /// </summary>
        public static string DolaresAmericanos { get { return "USD"; } }

        /// <summary>
        /// Retornar EUR
        /// </summary>
        public static string Euros { get { return "EUR"; } }
    }
}
