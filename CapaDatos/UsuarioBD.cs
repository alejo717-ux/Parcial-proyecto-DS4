using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class UsuarioBD : ConexionBD, IRepositorio<Usuario>
    {
        // Devuelve el hash SHA-256 en hexadecimal minúscula (64 caracteres).
        // Es el mismo formato que produce SHA2('texto', 256) en MariaDB.
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password ?? string.Empty));
                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // Valida credenciales. Devuelve el usuario si es correcto y está Activo; si no, null.
        public Usuario Login(string username, string password)
        {
            Usuario u = null;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT IdUsuario, Username, Rol, Estado FROM Usuarios " +
                                  "WHERE Username = @user AND Password = @pass AND Estado = 'Activo'";
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", HashPassword(password));

                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        u = new Usuario
                        {
                            IdUsuario = rd.GetInt32("IdUsuario"),
                            Username = rd.GetString("Username"),
                            Rol = rd.GetString("Rol"),
                            Estado = rd.GetString("Estado")
                        };
                    }
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return u;
        }

        public bool ExisteUsername(string username, int idExcluir = 0)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Username = @user AND IdUsuario <> @id";
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@id", idExcluir);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public bool Insertar(Usuario u)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Usuarios (Username, Password, Rol, Estado) VALUES (@user, @pass, @rol, @est)";
                cmd.Parameters.AddWithValue("@user", u.Username);
                cmd.Parameters.AddWithValue("@pass", HashPassword(u.Password));
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@est", string.IsNullOrEmpty(u.Estado) ? "Activo" : u.Estado);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        // Nunca se devuelve la columna Password al DataGridView.
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT IdUsuario, Username, Rol, Estado FROM Usuarios ORDER BY IdUsuario";

                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return dt;
        }

        // Si u.Password viene vacío, se conserva la contraseña actual.
        public bool Actualizar(Usuario u)
        {
            try
            {
                cmd.Parameters.Clear();
                bool cambiaPass = !string.IsNullOrEmpty(u.Password);
                cmd.CommandText = cambiaPass
                    ? "UPDATE Usuarios SET Username = @user, Password = @pass, Rol = @rol, Estado = @est WHERE IdUsuario = @id"
                    : "UPDATE Usuarios SET Username = @user, Rol = @rol, Estado = @est WHERE IdUsuario = @id";
                cmd.Parameters.AddWithValue("@user", u.Username);
                if (cambiaPass) cmd.Parameters.AddWithValue("@pass", HashPassword(u.Password));
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@est", u.Estado);
                cmd.Parameters.AddWithValue("@id", u.IdUsuario);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        // "Eliminar" es una baja lógica: el usuario queda Inactivo para no romper
        // la llave foránea de la Bitacora ni perder el historial de auditoría.
        public bool Eliminar(int id)
        {
            return CambiarEstado(id, "Inactivo");
        }

        public bool CambiarEstado(int id, string estado)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Usuarios SET Estado = @est WHERE IdUsuario = @id";
                cmd.Parameters.AddWithValue("@est", estado);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
    }
}
