using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catálogo Nº 10 de sunat para Tipo de Nota de Débito Electrónica
    /// </summary>
    [Serializable]
    public static class Catalogo_10_TIpoNotaDebito
    {
        /// <summary>
        /// Retorna 01 - Para intereses o mora
        /// </summary>
        public static string Interes_Mora { get { return "01"; } }

        /// <summary>
        /// Retorna 02 - Para aumento en el valor
        /// </summary>
        public static string Aumento_Valor { get { return "02"; } }

        /// <summary>
        /// Retorna 03 - Para penalidades y/u otros conceptos
        /// </summary>
        public static string Penalidad_Otros { get { return "03"; } }
    }
}
