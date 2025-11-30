using System;

namespace WebStudioPro.Presentacion.Entities
{
    public class LeadSeguimiento
    {
        public int IdSeguimiento { get; set; }
        public int IdLead { get; set; }
        public DateTime FechaContacto { get; set; }
        public string TipoContacto { get; set; }
        public string Detalle { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
