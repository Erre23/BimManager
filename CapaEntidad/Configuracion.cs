using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public static class Configuracion
    {
        public static int Puerto { get { return 8080; } }
    }
}
