using System;
using System.Data;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class BitacoraBD : ConexionBD
    {
        // Registra quién hizo qué. La fecha y hora la pone la base de datos (CURRENT_TIMESTAMP).
        // Un fallo al escribir la bitácora nunca debe tumbar la operación principal.
        public bool Registrar(int idUsuario, string accion)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Bitacora (IdUsuario, Accion) VALUES (@usr, @acc)";
                cmd.Parameters.AddWithValue("@usr", idUsuario);
                cmd.Parameters.AddWithValue("@acc", accion != null && accion.Length > 255 ? accion.Substring(0, 255) : accion);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public bool Registrar(BitacoraEntry e)
        {
            return Registrar(e.IdUsuario, e.Accion);
        }

        // Historial completo con el nombre del usuario (JOIN con Usuarios).
        public DataTable Listar()
        {
            return Listar(null, null, null);
        }

        // Filtros opcionales: rango de fechas (inclusive) y texto en usuario o acción.
        public DataTable Listar(DateTime? desde, DateTime? hasta, string texto)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Parameters.Clear();
                string sql = "SELECT b.IdLog, u.Username AS Usuario, b.Accion, b.FechaHora " +
                             "FROM Bitacora b INNER JOIN Usuarios u ON b.IdUsuario = u.IdUsuario WHERE 1 = 1";

                if (desde.HasValue)
                {
                    sql += " AND b.FechaHora >= @desde";
                    cmd.Parameters.AddWithValue("@desde", desde.Value.Date);
                }
                if (hasta.HasValue)
                {
                    sql += " AND b.FechaHora < @hasta";
                    cmd.Parameters.AddWithValue("@hasta", hasta.Value.Date.AddDays(1));
                }
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    sql += " AND (u.Username LIKE @txt OR b.Accion LIKE @txt)";
                    cmd.Parameters.AddWithValue("@txt", "%" + texto.Trim() + "%");
                }
                sql += " ORDER BY b.FechaHora DESC, b.IdLog DESC";
                cmd.CommandText = sql;

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
    }
}
