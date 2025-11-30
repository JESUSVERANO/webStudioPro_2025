using System;

namespace WebStudioPro.Presentacion.Entities
{
    // Representa la tabla Cotizaciones
    public class Cotizacion
    {
        public int IdCotizacion { get; set; }

        /// <summary>
        /// Lead asociado a la cotización (opcional).
        /// </summary>
        public int? IdLead { get; set; }

        /// <summary>
        /// Cliente al que se le cotiza (obligatorio).
        /// </summary>
        public int IdCliente { get; set; }

        public string TipoWeb { get; set; }
        public int Paginas { get; set; }
        public int Productos { get; set; }
        public string Extras { get; set; }
        public string Moneda { get; set; }
        public decimal Total { get; set; }
        public string TiempoEstimado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
