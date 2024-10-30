namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class DocumentoRelacionado
    {
        /// <summary>
        /// Tipo Documento (Boleta o factura), usar clase Ee.FacturaElectronica.Constantes.Catalogo_01_TipoDocumento
        /// </summary>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Serie y correlativo de la boleta o factura, ejemplo F001-12345678
        /// </summary>
        public string NroDocumento { get; set; }
    }
}
