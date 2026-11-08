using System.Configuration;
using MySqlConnector; // Este es el único driver que necesitamos para MariaDB

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal abstract class ConexionBD
    {
        protected MySqlConnection con;
        protected MySqlCommand cmd;

        protected ConexionBD()
        {
            string cadena = ConfigurationManager.ConnectionStrings["miBD"].ConnectionString;
            con = new MySqlConnection(cadena);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
    }
}