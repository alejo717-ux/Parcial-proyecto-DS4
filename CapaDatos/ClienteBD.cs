using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class ClienteBD : ConexionBD, IRepositorio<Cliente>
    {
        // Los campos opcionales vacíos se guardan como NULL
        private static object ANulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        public bool Insertar(Cliente c)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Clientes (Nombre, Telefono, Correo, Direccion) VALUES (@nom, @tel, @cor, @dir)";
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@tel", ANulo(c.Telefono));
                cmd.Parameters.AddWithValue("@cor", ANulo(c.Correo));
                cmd.Parameters.AddWithValue("@dir", ANulo(c.Direccion));

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
            cmd.CommandText = "SELECT IdCliente, Nombre, Telefono, Correo, Direccion FROM Clientes ORDER BY Nombre";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool Actualizar(Cliente c)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Clientes SET Nombre=@nom, Telefono=@tel, Correo=@cor, Direccion=@dir WHERE IdCliente=@id";
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@tel", ANulo(c.Telefono));
                cmd.Parameters.AddWithValue("@cor", ANulo(c.Correo));
                cmd.Parameters.AddWithValue("@dir", ANulo(c.Direccion));
                cmd.Parameters.AddWithValue("@id", c.IdCliente);

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
                cmd.CommandText = "DELETE FROM Clientes WHERE IdCliente=@id";
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
