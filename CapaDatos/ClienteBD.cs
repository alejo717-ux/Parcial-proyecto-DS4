using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class ClienteBD : ConexionBD, IRepositorio<Cliente>
    {
        public bool Insertar(Cliente c)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Clientes (Nombre, Telefono, Correo, Direccion) VALUES (@nom, @tel, @cor, @dir)";
            cmd.Parameters.AddWithValue("@nom", c.Nombre);
            cmd.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(c.Telefono) ? (object)DBNull.Value : c.Telefono);
            cmd.Parameters.AddWithValue("@cor", string.IsNullOrEmpty(c.Correo) ? (object)DBNull.Value : c.Correo);
            cmd.Parameters.AddWithValue("@dir", string.IsNullOrEmpty(c.Direccion) ? (object)DBNull.Value : c.Direccion);

            con.Open();
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas > 0;
        }

        public DataTable Listar()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT IdCliente, Nombre, Telefono, Correo, Direccion FROM Clientes";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool Actualizar(Cliente c)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Clientes SET Nombre=@nom, Telefono=@tel, Correo=@cor, Direccion=@dir WHERE IdCliente=@id";
            cmd.Parameters.AddWithValue("@nom", c.Nombre);
            cmd.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(c.Telefono) ? (object)DBNull.Value : c.Telefono);
            cmd.Parameters.AddWithValue("@cor", string.IsNullOrEmpty(c.Correo) ? (object)DBNull.Value : c.Correo);
            cmd.Parameters.AddWithValue("@dir", string.IsNullOrEmpty(c.Direccion) ? (object)DBNull.Value : c.Direccion);
            cmd.Parameters.AddWithValue("@id", c.IdCliente);

            con.Open();
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas > 0;
        }

        public bool Eliminar(int id)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Clientes WHERE IdCliente=@id";
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas > 0;
        }
    }
}
