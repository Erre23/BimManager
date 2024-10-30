namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class EnviarDocumentoResponse : RespuestaComun
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string TramaZipCdr { get; set; }
    }
}
