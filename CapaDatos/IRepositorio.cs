using System.Data;

namespace Parcial3_Proyecto_DS4.CapaDatos
{
    internal interface IRepositorio<T>
    {
        bool Insertar(T entidad);
        DataTable Listar();
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }
}