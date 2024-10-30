using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catálogo Nº 09 de SUNAT para Tipo de Nota de Crédito Electrónica
    /// </summary>
    [Serializable]
    public static class Catalogo_09_TipoNotaCredito
    {
        /// <summary>
        /// Retorna 01
        /// </summary>
        public static string Anulacion_Operacion { get { return "01"; } }


        /// <summary>
        /// Retorna 02
        /// </summary>
        public static string Anulacion_Error_RUC { get { return "02"; } }

        /// <summary>
        /// Retorna 03
        /// </summary>
        public static string Correccion_Error_Descripcion { get { return "03"; } }

        /// <summary>
        /// Retorna 04
        /// </summary>
        public static string Descuento_Global { get { return "04"; } }

        /// <summary>
        /// Retorna 05
        /// </summary>
        public static string Descuento_Por_Item { get { return "05"; } }

        /// <summary>
        /// Retorna 06
        /// </summary>
        public static string Devolucion_total { get { return "06"; } }

        /// <summary>
        /// Retorna 07
        /// </summary>
        public static string Devolucion_Por_Item { get { return "07"; } }

        /// <summary>
        /// Retorna 08
        /// </summary>
        public static string Bonificacion { get { return "08"; } }

        /// <summary>
        /// Retorna 09 - Para disminución en el valor
        /// </summary>
        public static string Disminucion_Valor { get { return "09"; } }

        /// <summary>
        /// Retorna 10
        /// </summary>
        public static string Otros { get { return "10"; } }
}
}
