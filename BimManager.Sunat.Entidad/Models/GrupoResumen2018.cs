namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class GrupoResumen2018 : DocumentoResumenDetalle
    {
        public string DocumentoIdentidadTipo { get; set; }
        public string DocumentoIdentidadNumero { get; set; }
        public int Correlativo { get; set; }
        public string Moneda { get; set; }
        public decimal Gravada { get; set; }
        public decimal Exonerada { get; set; }
        public decimal Inafecta { get; set; }
        public decimal Gratuita { get; set; }
        public decimal Exportacion { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal TotalIsc { get; set; }
        public decimal TotalOtrosImpuestos { get; set; }
        public decimal TotalVenta { get; set; }

        public string EstadoItem { get; set; }
        public string Afecta_TipoDocumento { get; set; }
        public string Afecta_Serie { get; set; }
        public int Afecta_Correlativo { get; set; }
    }
}
