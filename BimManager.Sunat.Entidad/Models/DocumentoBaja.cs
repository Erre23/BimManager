namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        public string Correlativo { get; set; }
        public string MotivoBaja { get; set; }
    }
}
