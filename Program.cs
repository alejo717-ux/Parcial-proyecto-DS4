using System;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaPresentacion;

namespace Parcial3_Proyecto_DS4
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instanciamos el Login del Estudiante 2
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Si las credenciales son correctas, abrimos el menú principal o formulario central
                    Application.Run(new FrmMenuPrincipal()); // O FrmClientes si el menú lo hace el Estudiante 4
                }
            }
        }
    }
}