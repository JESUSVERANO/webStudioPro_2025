using System;

namespace WebStudioPro.Presentacion.Entities
{
    // Representa la tabla Clientes
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Moneda { get; set; }
        public string Pais { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
