using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class ServicioBD : ConexionBD, IRepositorio<Servicio>
    {
        public bool Insertar(Servicio s)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Servicios (NombreServicio, PrecioBase, IdCategoria) VALUES (@nom, @pre, @cat)";
                cmd.Parameters.AddWithValue("@nom", s.NombreServicio);
                cmd.Parameters.AddWithValue("@pre", s.PrecioBase);
                cmd.Parameters.AddWithValue("@cat", s.IdCategoria);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        // Incluye el nombre de la categoría mediante un JOIN
        public DataTable Listar()
        {
            cmd.Parameters.Clear();
            cmd.CommandText =
                "SELECT s.IdServicio, s.NombreServicio, s.PrecioBase, s.IdCategoria, c.NombreCategoria " +
                "FROM Servicios s " +
                "INNER JOIN CategoriasServicio c ON s.IdCategoria = c.IdCategoria " +
                "ORDER BY s.NombreServicio";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool Actualizar(Servicio s)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Servicios SET NombreServicio=@nom, PrecioBase=@pre, IdCategoria=@cat WHERE IdServicio=@id";
                cmd.Parameters.AddWithValue("@nom", s.NombreServicio);
                cmd.Parameters.AddWithValue("@pre", s.PrecioBase);
                cmd.Parameters.AddWithValue("@cat", s.IdCategoria);
                cmd.Parameters.AddWithValue("@id", s.IdServicio);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Servicios WHERE IdServicio=@id";
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
