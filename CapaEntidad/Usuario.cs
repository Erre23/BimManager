using System;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string HashPassword { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Apellido1 { get; set; }

        [DataMember]
        public string Apellido2 { get; set; }

        [DataMember]
        public bool CambioContrasena { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        
        public string ApellidosNombres { get { return $"{Apellido1} {Apellido2} {Nombres}".Trim(); } }
    }
}
