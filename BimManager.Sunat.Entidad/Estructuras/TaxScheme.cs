using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class TaxScheme
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string TaxTypeCode { get; set; }
    }
}