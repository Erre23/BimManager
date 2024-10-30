using System;
using System.Collections.Generic;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class DatosAdicionales
    {
        public List<DatoAdicional> DatoAdicional { get; set; }

        public DatosAdicionales()
        {
            DatoAdicional = new List<DatoAdicional>();
        }
    }
}
