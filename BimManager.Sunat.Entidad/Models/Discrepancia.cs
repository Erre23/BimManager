namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class Discrepancia
    {
        /// <summary>
        /// Indica el tipo de nota de credito usar la clase Ee.FacturaElectronica.Constantes.Catalogo_09_TipoNotaCredito o debito usar catalogo Ee.FacturaElectronica.Constantes.Catalogo_10_TIpoNotaDebito
        /// </summary>
        public string Tipo { get; set; }
        

        /// <summary>
        /// Serie y correlativo de la boleta o factura afectado, ejemplo F001-12345678
        /// </summary>
        public string NroReferencia { get; set; }


        /// <summary>
        /// Descripcion de la discrepancia 
        /// </summary>
        public string Descripcion { get; set; }
    }
}
