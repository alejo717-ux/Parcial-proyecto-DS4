using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    
    internal class OrdenReparacionBD : ConexionBD, IRepositorio<OrdenReparacion>
    {
        public static readonly string[] Estados = { "Pendiente", "En proceso", "Completada", "Cancelada" };

        // Consulta base multitabla: 4 INNER JOIN
        // Ordenes -> Clientes, Mecanicos, Servicios -> CategoriasServicio
        private const string SqlJoinBase =
            "SELECT o.IdOrden, c.Nombre AS Cliente, m.Nombre AS Mecanico, " +
            "s.NombreServicio AS Servicio, cat.NombreCategoria AS Categoria, " +
            "s.PrecioBase AS Precio, o.FechaIngreso, o.EstadoOrden AS Estado, " +
            "o.IdCliente, o.IdMecanico, o.IdServicio " +
            "FROM OrdenesReparacion o " +
            "INNER JOIN Clientes c ON o.IdCliente = c.IdCliente " +
            "INNER JOIN Mecanicos m ON o.IdMecanico = m.IdMecanico " +
            "INNER JOIN Servicios s ON o.IdServicio = s.IdServicio " +
            "INNER JOIN CategoriasServicio cat ON s.IdCategoria = cat.IdCategoria ";

        

        public bool Insertar(OrdenReparacion o)
        {
            return EjecutarNoQuery(
                "INSERT INTO OrdenesReparacion (FechaIngreso, IdCliente, IdMecanico, IdServicio, EstadoOrden) " +
                "VALUES (@fec, @cli, @mec, @srv, @est)",
                new MySqlParameter("@fec", o.FechaIngreso.Date),
                new MySqlParameter("@cli", o.IdCliente),
                new MySqlParameter("@mec", o.IdMecanico),
                new MySqlParameter("@srv", o.IdServicio),
                new MySqlParameter("@est", o.EstadoOrden));
        }

        // Listado completo con nombres (JOIN). Cumple IRepositorio<T>.Listar().
        public DataTable Listar()
        {
            return ListarConJoin(null, null, null, null);
        }

        public bool Actualizar(OrdenReparacion o)
        {
            return EjecutarNoQuery(
                "UPDATE OrdenesReparacion SET FechaIngreso=@fec, IdCliente=@cli, IdMecanico=@mec, " +
                "IdServicio=@srv, EstadoOrden=@est WHERE IdOrden=@id",
                new MySqlParameter("@fec", o.FechaIngreso.Date),
                new MySqlParameter("@cli", o.IdCliente),
                new MySqlParameter("@mec", o.IdMecanico),
                new MySqlParameter("@srv", o.IdServicio),
                new MySqlParameter("@est", o.EstadoOrden),
                new MySqlParameter("@id", o.IdOrden));
        }

        public bool Eliminar(int id)
        {
            return EjecutarNoQuery("DELETE FROM OrdenesReparacion WHERE IdOrden=@id",
                new MySqlParameter("@id", id));
        }

        

        public bool CambiarEstado(int idOrden, string nuevoEstado)
        {
            if (Array.IndexOf(Estados, nuevoEstado) < 0)
                throw new ArgumentException("Estado no válido: " + nuevoEstado);

            return EjecutarNoQuery("UPDATE OrdenesReparacion SET EstadoOrden=@est WHERE IdOrden=@id",
                new MySqlParameter("@est", nuevoEstado),
                new MySqlParameter("@id", idOrden));
        }

        

        // Listado multitabla con filtros opcionales (estado, texto, rango de fechas).
        public DataTable ListarConJoin(string estado, string texto, DateTime? desde, DateTime? hasta)
        {
            string sql = SqlJoinBase + "WHERE 1 = 1 ";
            cmd.Parameters.Clear();

            if (!string.IsNullOrWhiteSpace(estado))
            {
                sql += "AND o.EstadoOrden = @est ";
                cmd.Parameters.AddWithValue("@est", estado);
            }

            if (!string.IsNullOrWhiteSpace(texto))
            {
                sql += "AND (c.Nombre LIKE @txt OR m.Nombre LIKE @txt OR s.NombreServicio LIKE @txt ";
                cmd.Parameters.AddWithValue("@txt", "%" + texto.Trim() + "%");

                int idBuscado;
                if (int.TryParse(texto.Trim(), out idBuscado))   // también permite buscar por N.º de orden
                {
                    sql += "OR o.IdOrden = @idb ";
                    cmd.Parameters.AddWithValue("@idb", idBuscado);
                }
                sql += ") ";
            }

            if (desde.HasValue && hasta.HasValue)
            {
                sql += "AND o.FechaIngreso BETWEEN @desde AND @hasta ";
                cmd.Parameters.AddWithValue("@desde", desde.Value.Date);
                cmd.Parameters.AddWithValue("@hasta", hasta.Value.Date);
            }

            sql += "ORDER BY o.IdOrden DESC";
            cmd.CommandText = sql;
            return LlenarTabla();
        }

        // Resumen por mecánico: LEFT JOIN (incluye mecánicos sin órdenes) + GROUP BY.
        public DataTable ResumenPorMecanico()
        {
            cmd.Parameters.Clear();
            cmd.CommandText =
                "SELECT m.Nombre AS Mecanico, COUNT(o.IdOrden) AS Ordenes, " +
                "COALESCE(SUM(s.PrecioBase), 0) AS TotalFacturado " +
                "FROM Mecanicos m " +
                "LEFT JOIN OrdenesReparacion o ON o.IdMecanico = m.IdMecanico AND o.EstadoOrden <> 'Cancelada' " +
                "LEFT JOIN Servicios s ON o.IdServicio = s.IdServicio " +
                "GROUP BY m.IdMecanico, m.Nombre " +
                "ORDER BY TotalFacturado DESC";
            return LlenarTabla();
        }

        // Datos para los ComboBox. Columnas: Id, Nombre (y Precio en Servicios).
        // Lista blanca: nunca se concatena texto del usuario dentro del SQL.
        public DataTable ObtenerCombo(string tabla)
        {
            string sql;
            switch (tabla)
            {
                case "Clientes":  sql = "SELECT IdCliente AS Id, Nombre FROM Clientes ORDER BY Nombre"; break;
                case "Mecanicos": sql = "SELECT IdMecanico AS Id, Nombre FROM Mecanicos ORDER BY Nombre"; break;
                case "Servicios": sql = "SELECT IdServicio AS Id, NombreServicio AS Nombre, PrecioBase AS Precio FROM Servicios ORDER BY NombreServicio"; break;
                default: throw new ArgumentException("Tabla no permitida: " + tabla);
            }
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            return LlenarTabla();
        }

        

        // Modo desconectado: el DataAdapter abre y cierra la conexión por sí solo.
        private DataTable LlenarTabla()
        {
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        private bool EjecutarNoQuery(string sql, params MySqlParameter[] parametros)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parametros);
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
