using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 16 de SUNAT para Tipo de Precio de Venta Unitario
    /// </summary>
    [Serializable]
    public static class Catalogo_16_TipoPrecioVentaUnitario
    {
        /// <summary>
        /// Retorna 01
        /// </summary>
        public static string PrecioUnitario_IncluyeIGV { get { return "01"; } }

        /// <summary>
        /// Retorna 02
        /// </summary>
        public static string ValorReferencialUnitario_OperacionesNoOnerosas { get { return "02"; } }
    }
}
