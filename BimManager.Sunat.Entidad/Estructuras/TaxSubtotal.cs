﻿using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class TaxSubtotal
    {
        public PayableAmount TaxAmount { get; set; }
        public TaxCategory TaxCategory { get; set; }
        public decimal Percent { get; set; }

        public TaxSubtotal()
        {
            TaxAmount = new PayableAmount();
            TaxCategory = new TaxCategory();
        }
    }
}