using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class MecanicoBD : ConexionBD, IRepositorio<Mecanico>
    {
        // Los campos opcionales vacíos se guardan como NULL
        private static object ANulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        public bool Insertar(Mecanico m)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Mecanicos (Nombre, Especialidad, Telefono) VALUES (@nom, @esp, @tel)";
                cmd.Parameters.AddWithValue("@nom", m.Nombre);
                cmd.Parameters.AddWithValue("@esp", ANulo(m.Especialidad));
                cmd.Parameters.AddWithValue("@tel", ANulo(m.Telefono));

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
            cmd.CommandText = "SELECT IdMecanico, Nombre, Especialidad, Telefono FROM Mecanicos ORDER BY Nombre";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool Actualizar(Mecanico m)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Mecanicos SET Nombre=@nom, Especialidad=@esp, Telefono=@tel WHERE IdMecanico=@id";
                cmd.Parameters.AddWithValue("@nom", m.Nombre);
                cmd.Parameters.AddWithValue("@esp", ANulo(m.Especialidad));
                cmd.Parameters.AddWithValue("@tel", ANulo(m.Telefono));
                cmd.Parameters.AddWithValue("@id", m.IdMecanico);

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
                cmd.CommandText = "DELETE FROM Mecanicos WHERE IdMecanico=@id";
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
