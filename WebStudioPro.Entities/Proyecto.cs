using System;

namespace WebStudioPro.Presentacion.Entities
{
    // Representa la tabla Proyectos
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }  // viene del JOIN con Clientes

        public string Nombre { get; set; }
        public string TipoWeb { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Extras { get; set; }
        public string Notas { get; set; }
    }
}
