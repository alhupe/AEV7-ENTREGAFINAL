using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EjemploFechasHoras
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();
            //En caso de que no se quieran mostrar las contraseñas
            //txtClaveNuevo.UseSystemPasswordChar = true;
        }

        public void btnListarEmpleados_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = Empleado.ListarEmpleados();
            dgvFichajes.DataSource = Fichaje.ListarFichajes();

            //En caso de que no se quieran mostrar las contraseñas


            //foreach (DataGridViewRow row in dgvEmpleados.Rows)
            //{
            //    if (row.Cells["clave"].Value != null)
            //    {
            //        row.Cells["clave"].Value = "********";
            //    }
            //}
        }

        private void btnBorrarEmpleado_Click(object sender, EventArgs e)
        {
            
            string nif = txtNifNuevo.Text; // Obtener el valor del TextBox txtNifNuevo

            if (string.IsNullOrEmpty(txtNifNuevo.Text))
            {
                MessageBox.Show("Debe introducir un NIF.");
            }
            else
            {
                if (!Empleado.CalcLetra(txtNifNuevo.Text))
                {
                    MessageBox.Show("El NIF no es correcto.");
                }
                else
                {
                    if (Empleado.BuscarEmpleado(nif))
                    {
                        Empleado.BorrarEmpleado(nif);
                        MessageBox.Show(string.Format("Se han borrado al empleado con el NIF {0}", nif));

                        txtApellidoNuevo.Text = string.Empty;
                        txtNombreNuevo.Text = string.Empty;
                        txtNifNuevo.Text = string.Empty;
                        chbAdministradorNuevo.Checked = false;
                        txtClaveNuevo.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("No existe ningún empleado con ese NIF.");
                    }
                }
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        { 
            string nif = txtNifNuevo.Text; // Obtener el valor del TextBox txtNifNuevo
            string nombre = txtNombreNuevo.Text; // Obtener el valor del TextBox txtNombreNuevo
            string apellido = txtApellidoNuevo.Text; // Obtener el valor del TextBox txtApellidoNuevo
            string clave = txtClaveNuevo.Text; // Obtener el valor del TextBox txtClaveNueva
            bool admin;

            //Comprobamos si se ha marcado como usuario administrador
            if (chbAdministradorNuevo.Checked)
            {
                admin = true;
            }
            else
            {
                admin = false;
            }

            if (string.IsNullOrEmpty(txtNifNuevo.Text) || string.IsNullOrEmpty(txtNombreNuevo.Text) || string.IsNullOrEmpty(txtApellidoNuevo.Text))
            {
                MessageBox.Show("Los campos NIF, nombre y apellido no pueden estar vacios.");
                
            }
            else
            {
                if (!Empleado.CalcLetra(nif))
                {
                    MessageBox.Show("El NIF no es correcto."); 
                }
                else
                {
                    if (Empleado.BuscarEmpleado(nif))
                    {
                        MessageBox.Show("Ya existe un empleado con este NIF.");
                    }
                    else
                    {
                        if (admin == true && string.IsNullOrEmpty(clave))
                        {
                            MessageBox.Show("Debe proporcionar una contraseña para el usuario administrador.");
                        }
                        else
                        {
                            Empleado.InsertarEmpleado(nif, nombre, apellido, admin, clave);

                            MessageBox.Show(string.Format("Se han agregado al empleado con el NIF {0}", nif));
                            if (admin == true)
                            {
                                MessageBox.Show("El usuario ES ADMINISTRADOR");
                            }
                            else
                            {
                                MessageBox.Show("El usuario NO es administrador");
                            }

                            txtApellidoNuevo.Text = string.Empty;
                            txtNombreNuevo.Text = string.Empty;
                            txtNifNuevo.Text = string.Empty;
                            chbAdministradorNuevo.Checked = false;
                            txtClaveNuevo.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            ConBD.CerrarConexion();
        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void btnSalirMantenimiento_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        // Cambia automaticamente las letras minusculas a mayusculas para evitar errores
        private void txtNifNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtNombreNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtApellidoNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }
    }
}
