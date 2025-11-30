using System;
using System.Data.SqlClient;
using WebStudioPro.Presentacion.Entities;   // 👈 AQUI TRAEMOS Usuario

namespace WebStudioPro.Presentacion.DAL
{
    /// <summary>
    /// Acceso a datos para autenticación de usuarios.
    /// </summary>
    public class LoginDAL
    {
        /// <summary>
        /// Intenta autenticar al usuario. Devuelve un Usuario válido o null.
        /// </summary>
        public Usuario Login(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                return null;

            using (SqlConnection cn = new SqlConnection(Config.Conexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 IdUsuario, Usuario, Nombre, Clave, Rol
                    FROM Usuarios
                    WHERE Usuario = @Usuario AND Clave = @Clave;", cn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                            return null;

                        var u = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreUsuario = dr["Usuario"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            Activo = true
                        };

                        return u;
                    }
                }
            }
        }
    }
}
