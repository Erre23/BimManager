namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        public string TramaXmlFirmado { get; set; }
    }
}
