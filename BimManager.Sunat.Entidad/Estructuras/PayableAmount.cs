using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class PayableAmount
    {
        public string currencyID { get; set; }
        public decimal value { get; set; }
    }
}