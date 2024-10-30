using System;
using System.Collections.Generic;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class ExtensionContent
    {
        public AdditionalInformation AdditionalInformation { get; set; }

        public DatosAdicionales DatosAdicionales_Internos { get; set; }
        
        public ExtensionContent()
        {
            AdditionalInformation = new AdditionalInformation();

            DatosAdicionales_Internos = new DatosAdicionales();
        }
    }
}