using System;
using System.Data;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal class ClienteBD : ConexionBD, IRepositorio<Cliente>
    {
        // Hagan aqui el sistema CRUD para Implementar
        // las operaciones protegiendo la base de datos contra inyección SQL mediante parámetros
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

        // Les faltaria por hacer los metodos Listar, Actualziar y Eliminar


    }
}
