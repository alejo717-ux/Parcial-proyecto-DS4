using System;

namespace Parcial3_Proyecto_DS4.CapaEntidad
{
    public class OrdenReparacion
    {
        public int IdOrden { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdCliente { get; set; }
        public int IdMecanico { get; set; }
        public int IdServicio { get; set; }
        public string EstadoOrden { get; set; }
    }
}