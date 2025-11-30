using System;

namespace WebStudioPro.Presentacion.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }  // usuario de login
        public string Nombre { get; set; }         // nombre para mostrar
        public string Clave { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
