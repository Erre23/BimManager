using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public static class Configuracion
    {
        public static int Puerto { get { return 8080; } }
    }
}
