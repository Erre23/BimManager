﻿using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class BillingReference : IEquatable<BillingReference>
    {
        public InvoiceDocumentReference InvoiceDocumentReference { get; set; }

        public BillingReference()
        {
            InvoiceDocumentReference = new InvoiceDocumentReference();
        }

        public bool Equals(BillingReference other)
        {
            return InvoiceDocumentReference.Equals(other.InvoiceDocumentReference);
        }

        public override int GetHashCode()
        {
            return InvoiceDocumentReference.GetHashCode();
        }
    }
}