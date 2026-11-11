using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    // Mantiene en memoria al usuario que inició sesión.
    // Uso desde cualquier formulario del equipo:
    //   SesionUsuario.Registrar("Creó el cliente Carlos Mendoza");
    public static class SesionUsuario
    {
        public static int IdUsuario { get; private set; }
        public static string Username { get; private set; }
        public static string Rol { get; private set; }

        public static bool HaySesion
        {
            get { return IdUsuario > 0; }
        }

        public static bool EsAdministrador
        {
            get { return Rol == "Administrador"; }
        }

        public static void Iniciar(Usuario u)
        {
            IdUsuario = u.IdUsuario;
            Username = u.Username;
            Rol = u.Rol;
        }

        public static void Cerrar()
        {
            IdUsuario = 0;
            Username = null;
            Rol = null;
        }

        // Registra una acción en la Bitácora a nombre del usuario activo.
        public static void Registrar(string accion)
        {
            if (!HaySesion) return;
            new BitacoraBD().Registrar(IdUsuario, accion);
        }
    }
}
