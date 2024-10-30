﻿namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public abstract class DocumentoResumenDetalle
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
    }
}
