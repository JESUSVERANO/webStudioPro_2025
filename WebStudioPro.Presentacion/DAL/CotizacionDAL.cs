using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebStudioPro.Presentacion;                    // Config
using Ent = WebStudioPro.Presentacion.Entities;    // alias para las entidades

namespace WebStudioPro.Presentacion.DAL
{
    public class CotizacionDAL
    {
        private readonly string _cnx;

        public CotizacionDAL()
        {
            _cnx = Config.Conexion;
        }

        // =============== LISTAR ===============
        public List<Ent.Cotizacion> Listar()
        {
            var lista = new List<Ent.Cotizacion>();

            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
SELECT  IdCotizacion,
        IdLead,
        IdCliente,
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
                        var c = new Ent.Cotizacion
                        {
                            IdCotizacion = dr.GetInt32(0),
                            IdLead = dr.IsDBNull(1) ? (int?)null : dr.GetInt32(1),
                            IdCliente = dr.GetInt32(2),
                            TipoWeb = dr.GetString(3),
                            Paginas = dr.GetInt32(4),
                            Productos = dr.GetInt32(5),
                            Extras = dr.IsDBNull(6) ? string.Empty : dr.GetString(6),
                            Moneda = dr.GetString(7),
                            Total = dr.GetDecimal(8),
                            TiempoEstimado = dr.IsDBNull(9) ? string.Empty : dr.GetString(9),
                            Fecha = dr.GetDateTime(10)
                        };

                        lista.Add(c);
                    }
                }
            }

            return lista;
        }

        // =============== INSERTAR ===============
        public int Insertar(Ent.Cotizacion c)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
INSERT INTO Cotizaciones
    (IdLead, IdCliente, TipoWeb, Paginas, Productos, Extras, Moneda, Total, TiempoEstimado, Fecha)
VALUES
    (@IdLead, @IdCliente, @TipoWeb, @Paginas, @Productos, @Extras, @Moneda, @Total, @TiempoEstimado, @Fecha);
SELECT SCOPE_IDENTITY();", cn))
            {
                // IdLead puede ser null
                if (c.IdLead != null)
                    cmd.Parameters.AddWithValue("@IdLead", c.IdLead);
                else
                    cmd.Parameters.AddWithValue("@IdLead", DBNull.Value);

                cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                cmd.Parameters.AddWithValue("@TipoWeb", c.TipoWeb);
                cmd.Parameters.AddWithValue("@Paginas", c.Paginas);
                cmd.Parameters.AddWithValue("@Productos", c.Productos);

                cmd.Parameters.AddWithValue("@Extras",
                    string.IsNullOrWhiteSpace(c.Extras) ? (object)DBNull.Value : c.Extras);

                cmd.Parameters.AddWithValue("@Moneda", c.Moneda);
                cmd.Parameters.AddWithValue("@Total", c.Total);

                cmd.Parameters.AddWithValue("@TiempoEstimado",
                    string.IsNullOrWhiteSpace(c.TiempoEstimado) ? (object)DBNull.Value : c.TiempoEstimado);

                cmd.Parameters.AddWithValue("@Fecha", c.Fecha);

                cn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
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
