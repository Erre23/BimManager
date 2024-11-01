using System;

namespace BimManager.Sunat.Entidad.RepresentacionImpresa
{
    [Serializable]
    public class ComprobanteElectronico_DocumentoModifica
    {
        public string TipoDocumentoCodigo { get; set; }

        public string SerieCorrelativo { get; set; }

        public string TipoDocumento_Serie_Correlativo
        {
            get
            {
                string TipoDocumento_Serie_Correlativo_ = "";
                TipoDocumento_Serie_Correlativo_ += (TipoDocumentoCodigo == "01" ? "FACTURA" : (TipoDocumentoCodigo == "03" ? "BOLETA" : ""));
                TipoDocumento_Serie_Correlativo_ += " " + SerieCorrelativo;
                return TipoDocumento_Serie_Correlativo_.Trim();
            }
        }
    }
}
