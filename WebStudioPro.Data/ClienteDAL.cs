using System;
using System.Data;
using System.Data.SqlClient;
using WebStudioPro.Presentacion.Entities;


namespace WebStudioPro.Presentacion.DAL
{
    public class ClienteDAL
    {
        // LISTAR (con filtro opcional por nombre/documento)
        public DataTable Listar(string filtro = "")
        {
            using (SqlConnection cn = new SqlConnection(Config.Conexion))
            {
                string sql = @"
                    SELECT IdCliente,
                           Nombre,
                           TipoDocumento,
                           Documento,
                           Telefono,
                           Correo,
                           Moneda,
                           Pais,
                           FechaRegistro
                    FROM Clientes";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql += " WHERE Nombre LIKE @filtro OR Documento LIKE @filtro OR Correo LIKE @filtro";
                }

                sql += " ORDER BY IdCliente DESC";

                SqlCommand cmd = new SqlCommand(sql, cn);

                if (!string.IsNullOrWhiteSpace(filtro))
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // INSERTAR
        public void Insertar(
            string nombre,
            string tipoDoc,
            string documento,
            string telefono,
            string correo,
            string moneda,
            string pais,
            DateTime fechaRegistro)
        {
            using (SqlConnection cn = new SqlConnection(Config.Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Clientes
                    (Nombre, TipoDocumento, Documento,
                     Telefono, Correo, Moneda, Pais, FechaRegistro)
                    VALUES
                    (@Nombre, @TipoDocumento, @Documento,
                     @Telefono, @Correo, @Moneda, @Pais, @FechaRegistro);
                ", cn);

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@TipoDocumento", tipoDoc);
                cmd.Parameters.AddWithValue("@Documento", documento);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Moneda", moneda);
                cmd.Parameters.AddWithValue("@Pais", pais);
                cmd.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);

                cmd.ExecuteNonQuery();
            }
        }

        // ACTUALIZAR
        public void Actualizar(
            int idCliente,
            string nombre,
            string tipoDoc,
            string documento,
            string telefono,
            string correo,
            string moneda,
            string pais)
        {
            using (SqlConnection cn = new SqlConnection(Config.Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Clientes SET
                        Nombre        = @Nombre,
                        TipoDocumento = @TipoDocumento,
                        Documento     = @Documento,
                        Telefono      = @Telefono,
                        Correo        = @Correo,
                        Moneda        = @Moneda,
                        Pais          = @Pais
                    WHERE IdCliente = @IdCliente;
                ", cn);

                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@TipoDocumento", tipoDoc);
                cmd.Parameters.AddWithValue("@Documento", documento);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Moneda", moneda);
                cmd.Parameters.AddWithValue("@Pais", pais);

                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void Eliminar(int idCliente)
        {
            using (SqlConnection cn = new SqlConnection(Config.Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Clientes WHERE IdCliente = @IdCliente;", cn);

                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
