using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    /// <summary>
    /// Métodos estáticos para validar datos de entrada en los formularios
    /// y evitar que el sistema se caiga por datos mal escritos.
    /// </summary>
    internal static class Validador
    {
        // ---------- Mensajes ----------
        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ---------- Validaciones de contenido ----------
        public static bool CampoObligatorio(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                Advertencia("El campo " + campo + " es obligatorio.");
                return false;
            }
            return true;
        }

        public static bool EsEntero(string texto, string campo, out int valor)
        {
            if (!int.TryParse(texto == null ? "" : texto.Trim(), out valor))
            {
                Advertencia("El campo " + campo + " debe ser un número entero.");
                return false;
            }
            return true;
        }

        public static bool EsDecimalPositivo(string texto, string campo, out decimal valor)
        {
            if (!decimal.TryParse(texto == null ? "" : texto.Trim(), NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out valor) || valor < 0)
            {
                Advertencia("El campo " + campo + " debe ser un número válido mayor o igual a 0.");
                return false;
            }
            return true;
        }

        public static bool EsCorreoValido(string correo, bool obligatorio = false)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                if (obligatorio)
                {
                    Advertencia("El correo es obligatorio.");
                    return false;
                }
                return true;
            }

            if (!Regex.IsMatch(correo.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Advertencia("El correo no tiene un formato válido. Ejemplo: nombre@correo.com");
                return false;
            }
            return true;
        }

        public static bool EsTelefonoValido(string telefono, bool obligatorio = false)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                if (obligatorio)
                {
                    Advertencia("El teléfono es obligatorio.");
                    return false;
                }
                return true;
            }

            int digitos = 0;
            foreach (char c in telefono)
                if (char.IsDigit(c)) digitos++;

            if (digitos < 7 || digitos > 15)
            {
                Advertencia("El teléfono debe tener entre 7 y 15 dígitos.");
                return false;
            }
            return true;
        }

        // ---------- Para el evento KeyPress ----------
        public static void SoloLetras(KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsControl(c) && !char.IsLetter(c) && c != ' ' && c != '.' && c != '\'' && c != '-')
                e.Handled = true;
        }

        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public static void SoloTelefono(KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsControl(c) && !char.IsDigit(c) && c != '-' && c != ' ' && c != '+')
                e.Handled = true;
        }

        public static void SoloDecimal(KeyPressEventArgs e, TextBox caja)
        {
            char c = e.KeyChar;
            char separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (char.IsControl(c) || char.IsDigit(c)) return;
            if (c == separador && !caja.Text.Contains(separador.ToString())) return;

            e.Handled = true;
        }
    }
}
