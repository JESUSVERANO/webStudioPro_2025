using System;
using System.Data;
using System.Data.SqlClient;
using WebStudioPro.Presentacion.Entities;

namespace WebStudioPro.Presentacion.DAL
{
    public class LeadDAL
    {
        private readonly string _cnx;

        public LeadDAL()
        {
            _cnx = Config.Conexion;
        }

        // LISTAR LEADS
        public DataTable Listar(string filtro = "", string estado = "")
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = @"
                    SELECT IdLead, Nombre, Email, Telefono, TipoCliente,
                           Fuente, Interes, MonedaPreferida, Pais,
                           EstadoLead, FechaRegistro, Notas
                    FROM Leads
                    WHERE (@Filtro = '' 
                           OR Nombre LIKE '%' + @Filtro + '%' 
                           OR Email LIKE '%' + @Filtro + '%'
                           OR Telefono LIKE '%' + @Filtro + '%')
                      AND (@Estado = '' OR EstadoLead = @Estado)
                    ORDER BY FechaRegistro DESC;";

                cmd.Parameters.AddWithValue("@Filtro", filtro ?? string.Empty);
                cmd.Parameters.AddWithValue("@Estado", estado ?? string.Empty);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
        }

        // INSERTAR LEAD
        public int Insertar(Lead lead)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = @"
                    INSERT INTO Leads
                        (Nombre, Email, Telefono, TipoCliente, Fuente,
                         Interes, MonedaPreferida, Pais, EstadoLead, Notas)
                    VALUES
                        (@Nombre, @Email, @Telefono, @TipoCliente, @Fuente,
                         @Interes, @MonedaPreferida, @Pais, @EstadoLead, @Notas);
                    SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@Nombre",          lead.Nombre);
                cmd.Parameters.AddWithValue("@Email",           (object)lead.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono",        (object)lead.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoCliente",     (object)lead.TipoCliente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fuente",          (object)lead.Fuente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Interes",         (object)lead.Interes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MonedaPreferida", (object)lead.MonedaPreferida ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Pais",            (object)lead.Pais ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EstadoLead",      lead.EstadoLead ?? "Nuevo");
                cmd.Parameters.AddWithValue("@Notas",           (object)lead.Notas ?? DBNull.Value);

                cn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // ACTUALIZAR LEAD
        public void Actualizar(Lead lead)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = @"
                    UPDATE Leads
                    SET Nombre          = @Nombre,
                        Email           = @Email,
                        Telefono        = @Telefono,
                        TipoCliente     = @TipoCliente,
                        Fuente          = @Fuente,
                        Interes         = @Interes,
                        MonedaPreferida = @MonedaPreferida,
                        Pais            = @Pais,
                        EstadoLead      = @EstadoLead,
                        Notas           = @Notas
                    WHERE IdLead = @IdLead;";

                cmd.Parameters.AddWithValue("@IdLead",          lead.IdLead);
                cmd.Parameters.AddWithValue("@Nombre",          lead.Nombre);
                cmd.Parameters.AddWithValue("@Email",           (object)lead.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono",        (object)lead.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoCliente",     (object)lead.TipoCliente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fuente",          (object)lead.Fuente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Interes",         (object)lead.Interes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MonedaPreferida", (object)lead.MonedaPreferida ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Pais",            (object)lead.Pais ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EstadoLead",      lead.EstadoLead ?? "Nuevo");
                cmd.Parameters.AddWithValue("@Notas",           (object)lead.Notas ?? DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // CAMBIAR ESTADO
        public void CambiarEstado(int idLead, string nuevoEstado)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Leads SET EstadoLead = @Estado WHERE IdLead = @IdLead;", cn))
            {
                cmd.Parameters.AddWithValue("@IdLead", idLead);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR LEAD (y sus seguimientos)
        public void Eliminar(int idLead)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            {
                cn.Open();

                using (SqlCommand cmdSeg = new SqlCommand(
                    "DELETE FROM LeadSeguimientos WHERE IdLead = @IdLead;", cn))
                {
                    cmdSeg.Parameters.AddWithValue("@IdLead", idLead);
                    cmdSeg.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Leads WHERE IdLead = @IdLead;", cn))
                {
                    cmd.Parameters.AddWithValue("@IdLead", idLead);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // INSERTAR SEGUIMIENTO
        public void InsertarSeguimiento(LeadSeguimiento seg)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO LeadSeguimientos
                    (IdLead, FechaContacto, TipoContacto, Detalle, UsuarioRegistro)
                VALUES
                    (@IdLead, @FechaContacto, @TipoContacto, @Detalle, @UsuarioRegistro);", cn))
            {
                cmd.Parameters.AddWithValue("@IdLead",         seg.IdLead);
                cmd.Parameters.AddWithValue("@FechaContacto", seg.FechaContacto);
                cmd.Parameters.AddWithValue("@TipoContacto",  seg.TipoContacto);
                cmd.Parameters.AddWithValue("@Detalle",       (object)seg.Detalle ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UsuarioRegistro",
                                            (object)seg.UsuarioRegistro ?? DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // LISTAR SEGUIMIENTOS
        public DataTable ListarSeguimientos(int idLead)
        {
            using (SqlConnection cn = new SqlConnection(_cnx))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT IdSeguimiento, IdLead, FechaContacto, TipoContacto, Detalle, UsuarioRegistro
                FROM LeadSeguimientos
                WHERE IdLead = @IdLead
                ORDER BY FechaContacto DESC;", cn))
            {
                cmd.Parameters.AddWithValue("@IdLead", idLead);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
        }
    }
}
