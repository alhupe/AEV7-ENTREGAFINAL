using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EjemploFechasHoras
{
    public partial class Frmppal : Form
    {
        public Frmppal()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void txtNif_TextChanged(object sender, EventArgs e)
        {
            txtNif.SelectionStart = txtNif.TextLength; // Mover el cursor al final del texto
        }

        // Evita que se puede cerrar la aplicacion desde este formulario
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
        

        private void Frmppal_Load(object sender, EventArgs e)
        {
            if (ConBD.Conexion != null)
            {
                ConBD.AbrirConexion();
                ptbFlorida.Visible = true;
                dgvPermanencia.Visible = false;
                txtMessage.Visible = false;
                grpbPermanencias.Visible = false;
                ConBD.CerrarConexion();
            }
            else
            {
                txtMessage.Visible = true;
                txtMessage.Text = "No se ha podido conectar con la base de datos.";
            }
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }



        private void btnEntrada_Click_1(object sender, EventArgs e)
        {
            grpbPermanencias.Visible = false;
            dgvPermanencia.Visible = false;
            dgvPermanencia.DataSource = null;
            ptbFlorida.Visible = false;
            txtMessage.Visible = true;

            string nif = txtNif.Text;
            TimeSpan horaEntrada = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime dia = DateTime.Today;

            if (!Empleado.CalcLetra(txtNif.Text))
            {
                txtMessage.Text = "El NIF no es correcto.";
            }
            else
            {
                if (Empleado.BuscarEmpleado(nif))
                {
                    if (Fichaje.ComprobarEntrada(nif))
                    {
                        txtMessage.Text = "No se ha podido realizar, el empleado ya ha fichado entrada.";
                    }
                    else
                    {
                        Fichaje.FicharEntrada(nif, horaEntrada, dia);
                        MessageBox.Show("El empleado ha fichado entrada correctamente.");
                        txtNif.Text = string.Empty;
                        txtMessage.Text = string.Empty;
                        ptbFlorida.Visible = true;
                        txtMessage.Visible = false;
                    }
                }
                else
                {
                    txtMessage.Text = ("No existe ningún empleado con ese NIF.");
                }
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            grpbPermanencias.Visible = false;
            dgvPermanencia.Visible = false;
            dgvPermanencia.DataSource = null;
            ptbFlorida.Visible = false;
            txtMessage.Visible = true;

            string nif = txtNif.Text;
            TimeSpan horaSalida = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime dia = DateTime.Today;

            
            if (!Empleado.CalcLetra(txtNif.Text))
            {
                txtMessage.Text = "El NIF no es correcto.";
            }
            else
            {
                if (Empleado.BuscarEmpleado(nif))
                {
                    if (Fichaje.ComprobarEntrada(nif))
                    {
                        if (Fichaje.ComprobarSalida(nif))
                        {
                            txtMessage.Text = "No se ha podido realizar. El empleado ya ha fichado salida.";
                        }
                        else
                        {
                            MessageBox.Show("El fichaje de salida se ha realizado correctamente. Tiempo transcurrido: " + Fichaje.FicharSalida(nif, horaSalida, dia));
                            txtNif.Text = string.Empty;
                            ptbFlorida.Visible = true;
                            txtMessage.Visible = false;
                        }
                    }
                    else
                    {
                        txtMessage.Text = "El empleado no ha fichado entrada.";
                    }
                }
                else
                {
                    txtMessage.Text = ("No existe ningún empleado con ese NIF.");
                }
            }
        }

        private void btnPresencia_Click(object sender, EventArgs e)
        {
            grpbPermanencias.Visible = false;
            dgvPermanencia.DataSource = null;
            dgvPermanencia.Visible = false;
            ptbFlorida.Visible = false;
            txtMessage.Visible = true;

            DateTime dia = DateTime.Today;

            // Fichaje.SalidaAutomatica(DateTime.Today);
            string mensaje = Fichaje.ListarEmpleados(dia);
            if (string.IsNullOrEmpty(mensaje))
            {
                txtMessage.Text = "No hay empleados activos actualmente.";
                txtNif.Text = string.Empty;
            }
            else
            {
                txtMessage.Text = mensaje;
                txtNif.Text = string.Empty;
            }
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            grpbPermanencias.Visible = false;
            dgvPermanencia.Visible = false;
            dgvPermanencia.DataSource = null;
            ptbFlorida.Visible = true;
            txtMessage.Visible = false;

            Login login = new Login();
            login.ShowDialog();
           
            if (login.DialogResult == DialogResult.OK)
            {
                dgvPermanencia.DataSource = null;
                grpbPermanencias.Visible = false;
                dgvPermanencia.Visible = false;
                txtMessage.Visible = false;
                ptbFlorida.Visible = true;

            }
        }

        private void btnVerPermanencia_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas por el usuario
            DateTime fechaInicio = dtpFecha1.Value;
            DateTime fechaFin = dtpFecha2.Value.AddSeconds(1);
            string nif = txtNif.Text;
            DataTable permanencias = Fichaje.VerPermanencias(nif, fechaInicio, fechaFin);

            if (!Empleado.CalcLetra(txtNif.Text))
            {
                txtMessage.Text = "El NIF no es correcto.";
            }
            else
            {
                txtMessage.Text = string.Empty;

                // Valida que la fecha de inicio sea menor o igual que la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio debe ser menor o igual que la fecha de fin");
                    return;
                }
                else
                {
                    dgvPermanencia.DataSource = permanencias;
                    dgvPermanencia.Visible = true;
                    txtMessage.Text = "Tiempo total fichado: " + Fichaje.CalcularTiempoTotal(permanencias);
                    ptbFlorida.Visible = false;

                }
            }
        }

        private void btnSalirPermanencias_Click(object sender, EventArgs e)
        {
            txtNif.Text = string.Empty;
            grpbPermanencias.Visible = false;
            dgvPermanencia.DataSource = null;
            dgvPermanencia.Visible = false;
            txtMessage.Text = string.Empty;
            txtMessage.Visible = false;
            ptbFlorida.Visible = true;
        }

        private void btnPermanencia_Click(object sender, EventArgs e)
        {
            txtMessage.Visible = true;
            ptbFlorida.Visible = false;

            if (!Empleado.CalcLetra(txtNif.Text))
            {
                txtMessage.Text = "El NIF no es correcto.";
            }
            else
            {
                if (Empleado.BuscarEmpleado(txtNif.Text))
                {
                    txtMessage.Text = string.Empty;
                    dgvPermanencia.Visible = true;
                    grpbPermanencias.Visible = true;

                    dtpFecha1.Value = DateTime.Today;
                    dtpFecha2.Value = DateTime.Today;
                }
                else
                {
                    txtMessage.Text = "No existe ningún empleado con ese NIF.";
                }
            }
        }

        private void txtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }
    }
}
