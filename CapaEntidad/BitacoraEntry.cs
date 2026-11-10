using System;

namespace Parcial3_Proyecto_DS4.CapaEntidad
{
    public class BitacoraEntry
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public string Accion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}