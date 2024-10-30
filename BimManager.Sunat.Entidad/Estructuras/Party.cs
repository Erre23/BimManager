﻿using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class Party
    {
        public PartyName PartyName { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }


        public Party()
        {
            PartyName = new PartyName();
            PostalAddress = new PostalAddress();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
}