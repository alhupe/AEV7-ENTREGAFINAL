using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploFechasHoras
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtContra.UseSystemPasswordChar = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nif = txtNifLogin.Text;
            string clave = txtContra.Text;

            // Verificar si el NIF es válido
            if (!Empleado.CalcLetra(nif))
            {
                MessageBox.Show("El NIF no es correcto.");
                return;
            }

            // Verificar si existe un empleado con el NIF dado
            if (!Empleado.BuscarEmpleado(nif))
            {
                MessageBox.Show("No existe ningún empleado con ese NIF.");
                return;
            }

            // Verificar si el usuario es administrador
            if (!Empleado.EsAdmin(nif))
            {
                MessageBox.Show("No eres administrador.");
                return;
            }

            // Verificar si la contraseña es correcta
            if (!Empleado.Login(nif, clave))
            {
                MessageBox.Show("La contraseña es incorrecta.");
                return;
            }

            // Si se llega hasta aquí, todas las condiciones se cumplen, abrir el formulario de mantenimiento y cerrar el formulario de inicio de sesión
            Frmppal principal = new Frmppal();
            Mantenimiento mant = new Mantenimiento();
            mant.ShowDialog(this); // Mostrar el formulario de mantenimiento como modal con respecto al formulario principal
            principal.Hide();
            this.Close();
        }

        // Cierra el formulario de Login
        private void btnVolver_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        // Cambia automaticamente a mayusculas las letras que se escriban en el textbox para evitar errores
        private void txtNifLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        
        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si se presionó la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al método btnEntrar_Click
                btnEntrar.PerformClick();
            }
        }
    }
}
