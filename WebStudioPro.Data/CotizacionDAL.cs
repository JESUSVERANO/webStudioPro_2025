using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebStudioPro.Presentacion.Entities;
using WebStudioPro.Presentacion;   // para usar Config.Conexion

namespace WebStudioPro.Presentacion.DAL
{
    // DTO de Cotización
    public class Cotizacion
    {
        public int IdCotizacion { get; set; }
        public string TipoWeb { get; set; }
        public int Paginas { get; set; }
        public int Productos { get; set; }
        public string Extras { get; set; }
        public string Moneda { get; set; }
        public decimal Total { get; set; }
        public string TiempoEstimado { get; set; }
        public DateTime Fecha { get; set; }
        public object IdLead { get; set; }
        public object IdCliente { get; set; }
    }

    public class CotizacionDAL
    {
        private readonly string _cnx;

        public CotizacionDAL()
        {
            _cnx = Config.Conexion;
        }

        // =============== LISTAR ===============
        public List<Cotizacion> Listar()
        {
            var lista = new List<Cotizacion>();

            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
SELECT  IdCotizacion,
        TipoWeb,
        Paginas,
        Productos,
        Extras,
        Moneda,
        Total,
        TiempoEstimado,
        Fecha
FROM Cotizaciones
ORDER BY IdCotizacion DESC;", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var c = new Cotizacion
                        {
                            IdCotizacion = dr.GetInt32(0),
                            TipoWeb = dr.GetString(1),
                            Paginas = dr.GetInt32(2),
                            Productos = dr.GetInt32(3),
                            Extras = dr.IsDBNull(4) ? "" : dr.GetString(4),
                            Moneda = dr.GetString(5),
                            Total = dr.GetDecimal(6),
                            TiempoEstimado = dr.GetString(7),
                            Fecha = dr.GetDateTime(8)
                        };

                        lista.Add(c);
                    }
                }
            }

            return lista;
        }

        // =============== INSERTAR ===============
        public int Insertar(Cotizacion c)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
INSERT INTO Cotizaciones
    (TipoWeb, Paginas, Productos, Extras, Moneda, Total, TiempoEstimado, Fecha)
VALUES
    (@TipoWeb, @Paginas, @Productos, @Extras, @Moneda, @Total, @TiempoEstimado, @Fecha);
SELECT SCOPE_IDENTITY();", cn))
            {
                cmd.Parameters.AddWithValue("@TipoWeb", c.TipoWeb);
                cmd.Parameters.AddWithValue("@Paginas", c.Paginas);
                cmd.Parameters.AddWithValue("@Productos", c.Productos);

                cmd.Parameters.AddWithValue("@Extras",
                    string.IsNullOrEmpty(c.Extras) ? (object)DBNull.Value : c.Extras);

                cmd.Parameters.AddWithValue("@Moneda", c.Moneda);
                cmd.Parameters.AddWithValue("@Total", c.Total);
                cmd.Parameters.AddWithValue("@TiempoEstimado", c.TiempoEstimado);
                cmd.Parameters.AddWithValue("@Fecha", c.Fecha);

                cn.Open();
                var result = cmd.ExecuteScalar();
                int id = Convert.ToInt32(result);
                return id;
            }
        }

        // (opcional) ELIMINAR UNA COTIZACIÓN
        public void Eliminar(int idCotizacion)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(
                "DELETE FROM Cotizaciones WHERE IdCotizacion = @IdCotizacion;", cn))
            {
                cmd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
