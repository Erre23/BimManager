using System;

namespace BimManager.Sunat.Entidad.Estructuras
{
    [Serializable]
    public class UBLExtension
    {
        public ExtensionContent ExtensionContent { get; set; }

        public UBLExtension()
        {
            ExtensionContent = new ExtensionContent();
        }
    }
}