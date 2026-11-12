using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class CategoriaServicioBD : ConexionBD, IRepositorio<CategoriaServicio>
    {
        // La descripción es opcional: vacía se guarda como NULL
        private static object ANulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        public bool Insertar(CategoriaServicio c)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO CategoriasServicio (NombreCategoria, Descripcion) VALUES (@nom, @des)";
                cmd.Parameters.AddWithValue("@nom", c.NombreCategoria);
                cmd.Parameters.AddWithValue("@des", ANulo(c.Descripcion));

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public DataTable Listar()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT IdCategoria, NombreCategoria, Descripcion FROM CategoriasServicio ORDER BY NombreCategoria";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool Actualizar(CategoriaServicio c)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE CategoriasServicio SET NombreCategoria=@nom, Descripcion=@des WHERE IdCategoria=@id";
                cmd.Parameters.AddWithValue("@nom", c.NombreCategoria);
                cmd.Parameters.AddWithValue("@des", ANulo(c.Descripcion));
                cmd.Parameters.AddWithValue("@id", c.IdCategoria);

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
                cmd.CommandText = "DELETE FROM CategoriasServicio WHERE IdCategoria=@id";
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
