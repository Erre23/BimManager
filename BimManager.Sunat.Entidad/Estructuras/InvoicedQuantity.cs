using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class InvoicedQuantity
    {
        public string unitCode { get; set; }
        public decimal Value { get; set; }
    }
}