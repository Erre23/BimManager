﻿using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class BillingPayment
    {
        public PartyIdentificationID Id { get; set; }
        public PayableAmount PaidAmount { get; set; }
        public string InstructionId { get; set; }

        public BillingPayment()
        {
            PaidAmount = new PayableAmount();
            Id = new PartyIdentificationID();
        }
    }
}