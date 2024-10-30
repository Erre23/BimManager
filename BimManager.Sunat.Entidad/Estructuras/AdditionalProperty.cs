using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class AdditionalProperty
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}