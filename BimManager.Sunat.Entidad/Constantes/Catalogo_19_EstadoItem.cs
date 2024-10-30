using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 18 de SUNAT para Resumen Diario de boletas de venta y notas electrónicas
    /// </summary>
    [Serializable]
    public static class Catalogo_19_EstadoItem
    {
        /// <summary>
        /// Retorna 1
        /// </summary>
        public static string Adicionar { get { return "1"; } }

        /// <summary>
        /// Retorna 2
        /// </summary>
        public static string Modificar { get { return "2"; } }

        /// <summary>
        /// Retorna 3
        /// </summary>
        public static string Anulado { get { return "3"; } }

        /// <summary>
        /// Retonar 4 (para cuando se ha anulado antes de informar comprobante - transporte público
        /// </summary>
        public static string AnuladoEnElDia { get { return "4"; } }
    }
}
