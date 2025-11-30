using System;
using System.Data;
using System.Data.SqlClient;
using WebStudioPro.Presentacion.Entities;

namespace WebStudioPro.Presentacion.DAL
{
    public class ProyectoDAL
    {
        private readonly string _cnx;

        public ProyectoDAL()
        {
            _cnx = Config.Conexion;
        }

        // =============== LISTAR ===============
        public DataTable Listar()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
SELECT  p.IdProyecto,
        p.IdCliente,
        c.Nombre AS ClienteNombre,
        p.Nombre,
        p.TipoWeb,
        p.Estado,
        p.FechaInicio,
        p.FechaEntrega,
        p.Monto,
        p.Moneda,
        p.Extras,
        p.Notas
FROM Proyectos p
INNER JOIN Clientes c ON c.IdCliente = p.IdCliente
ORDER BY p.IdProyecto DESC;", cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cn.Open();
                da.Fill(dt);
            }

            return dt;
        }

        // =============== INSERTAR ===============
        public int Insertar(Proyecto dto)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
INSERT INTO Proyectos
    (IdCliente, Nombre, TipoWeb, Estado, FechaInicio, FechaEntrega, Monto, Moneda, Extras, Notas)
VALUES
    (@IdCliente, @Nombre, @TipoWeb, @Estado, @FechaInicio, @FechaEntrega, @Monto, @Moneda, @Extras, @Notas);
SELECT SCOPE_IDENTITY();", cn))
            {
                cmd.Parameters.AddWithValue("@IdCliente", dto.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@TipoWeb", dto.TipoWeb);
                cmd.Parameters.AddWithValue("@Estado", dto.Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", dto.FechaInicio);

                // FechaEntrega puede ser null
                if (dto.FechaEntrega.HasValue)
                    cmd.Parameters.AddWithValue("@FechaEntrega", dto.FechaEntrega.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaEntrega", DBNull.Value);

                cmd.Parameters.AddWithValue("@Monto", dto.Monto);
                cmd.Parameters.AddWithValue("@Moneda", dto.Moneda);

                cmd.Parameters.AddWithValue("@Extras",
                    string.IsNullOrWhiteSpace(dto.Extras) ? (object)DBNull.Value : dto.Extras);

                cmd.Parameters.AddWithValue("@Notas",
                    string.IsNullOrWhiteSpace(dto.Notas) ? (object)DBNull.Value : dto.Notas);

                cn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // =============== ACTUALIZAR ===============
        public void Actualizar(Proyecto dto)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
UPDATE Proyectos
SET IdCliente    = @IdCliente,
    Nombre       = @Nombre,
    TipoWeb      = @TipoWeb,
    Estado       = @Estado,
    FechaInicio  = @FechaInicio,
    FechaEntrega = @FechaEntrega,
    Monto        = @Monto,
    Moneda       = @Moneda,
    Extras       = @Extras,
    Notas        = @Notas
WHERE IdProyecto = @IdProyecto;", cn))
            {
                cmd.Parameters.AddWithValue("@IdProyecto", dto.IdProyecto);
                cmd.Parameters.AddWithValue("@IdCliente", dto.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@TipoWeb", dto.TipoWeb);
                cmd.Parameters.AddWithValue("@Estado", dto.Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", dto.FechaInicio);

                if (dto.FechaEntrega.HasValue)
                    cmd.Parameters.AddWithValue("@FechaEntrega", dto.FechaEntrega.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaEntrega", DBNull.Value);

                cmd.Parameters.AddWithValue("@Monto", dto.Monto);
                cmd.Parameters.AddWithValue("@Moneda", dto.Moneda);

                cmd.Parameters.AddWithValue("@Extras",
                    string.IsNullOrWhiteSpace(dto.Extras) ? (object)DBNull.Value : dto.Extras);

                cmd.Parameters.AddWithValue("@Notas",
                    string.IsNullOrWhiteSpace(dto.Notas) ? (object)DBNull.Value : dto.Notas);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =============== ELIMINAR ===============
        public void Eliminar(int idProyecto)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(
                "DELETE FROM Proyectos WHERE IdProyecto = @IdProyecto;", cn))
            {
                cmd.Parameters.AddWithValue("@IdProyecto", idProyecto);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
