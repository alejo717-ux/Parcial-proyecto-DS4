using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    /// <summary>
    /// Métodos estáticos centralizados para validar datos de entrada en todos los formularios
    /// y evitar que el sistema falle por datos incorrectos o mal escritos.
    /// </summary>
    internal static class Validador
    {
        // ---------- Mensajes ----------
        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ---------- Validaciones de contenido genéricas ----------
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

        public static bool EsUsernameValido(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Trim().Length < 3)
            {
                Advertencia("El nombre de usuario debe tener al menos 3 caracteres.");
                return false;
            }
            if (username.Contains(" "))
            {
                Advertencia("El nombre de usuario no puede contener espacios.");
                return false;
            }
            return true;
        }

        public static bool EsPasswordValido(string password, bool esNuevo)
        {
            if (esNuevo && (string.IsNullOrEmpty(password) || password.Length < 4))
            {
                Advertencia("La contraseña debe tener al menos 4 caracteres.");
                return false;
            }
            if (!esNuevo && !string.IsNullOrEmpty(password) && password.Length < 4)
            {
                Advertencia("La nueva contraseña debe tener al menos 4 caracteres.");
                return false;
            }
            return true;
        }

        public static bool ComboSeleccionado(ComboBox cbo, string campo)
        {
            if (cbo.SelectedIndex < 0 || cbo.SelectedItem == null)
            {
                Advertencia("Debe seleccionar un " + campo + " válido.");
                cbo.Focus();
                return false;
            }
            return true;
        }

        public static bool EsFechaValidaNoFutura(DateTimePicker dtp)
        {
            if (dtp.Value.Date > DateTime.Today)
            {
                Advertencia("La fecha de ingreso no puede ser una fecha futura.");
                dtp.Focus();
                return false;
            }
            return true;
        }

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

        public static void PrevenirEspaciosEnBlanco(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && ((TextBox)sender).Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        public static bool EsRangoFechasValido(DateTimePicker dtpDesde, DateTimePicker dtpHasta)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                Advertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.");
                dtpDesde.Focus();
                return false;
            }
            return true;
        }

    }
}