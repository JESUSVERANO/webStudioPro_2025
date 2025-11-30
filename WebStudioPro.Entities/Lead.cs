using System;

namespace WebStudioPro.Presentacion.Entities
{
    public class Lead
    {
        public int IdLead { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string TipoCliente { get; set; }
        public string Fuente { get; set; }
        public string Interes { get; set; }
        public string MonedaPreferida { get; set; }
        public string Pais { get; set; }
        public string EstadoLead { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Notas { get; set; }
    }
}
