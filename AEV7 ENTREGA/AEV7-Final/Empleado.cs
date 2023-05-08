using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EjemploFechasHoras
{
    internal class Empleado
    {
        string nif;
        string nombre;
        string apellido;
        bool admin;
        string clave;

        public string Nif { get { return nif; } }
        public string Nombre { get { return nombre; } }
        public string Apellido { get { return apellido; } }
        public bool Admin { get { return admin; } }
        public string Clave { get { return clave; } }

        public Empleado(string nif, string nom, string ape, bool adm, string clave)
        {
            this.nif = nif;
            this.nombre = nom;
            this.apellido = ape;
            this.admin = adm;
            this.clave = clave;

        }

        /// <summary>
        /// Calcular la letra del nif y devuelve si es cierta o no
        /// </summary>
        /// <param name="nif">nif del usuario</param>
        /// <returns>True o False</returns>
        public static bool CalcLetra(string nif)
        {
            if (nif.Length != 9)
            {
                return false;
            }
            string letra = "TRWAGMYFPDXBNJZSQVHLCKE";
            string num = "";

            for (int i = 0; i < nif.Length - 1; i++)
            {
                if (char.IsDigit(nif[i]))
                {
                    num += nif[i];
                }
                else
                {
                    return false;
                }
            }
            char let = letra[int.Parse(num) % 23];

            if (let == nif[8])
            {
                return true;

            }
            else
                return false;

        }


        // Permite insertar un nuevo empleado en la base de datos
        // Le pasamos el nif, nombre, apellido, administrador y clave como parametros
        // No devuelve nada
        // Se podria modificar para que devuelva el numero de filas afectadas y de esta forma comprobar que la consulta a la base de datos se ha realizado correctamente
        public static void InsertarEmpleado(string nif, string nombre, string apellido, bool admin, string clave)
        {
            Empleado emp = new Empleado(nif, nombre, apellido, admin, clave);
            ConBD.AbrirConexion();
            string consulta = String.Format("INSERT INTO empleados VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", emp.nif, emp.nombre, emp.apellido, emp.admin ? 1 : 0, emp.clave);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.ExecuteNonQuery();
            ConBD.CerrarConexion();
        }

       

        // Lista todos los empleados dados de alta y devuelve una tabla para poder visualizarla en el datagridview
        public static DataTable ListarEmpleados()
        {
            ConBD.AbrirConexion();
            string consulta = "SELECT * FROM empleados";
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader datos = comando.ExecuteReader();
            DataTable tablaEmpleados = new DataTable();
            tablaEmpleados.Load(datos);
            ConBD.CerrarConexion();
            return tablaEmpleados;
        }

        // Permite borrar un empleado existente
        // Le pasamos en nif como parametro
        // No devuelve nada
        // Se podria modificar para que devuelva el numero de filas afectadas y de esta forma comprobar que la consulta a la base de datos se ha realizado correctamente
        public static void BorrarEmpleado(string nif)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("DELETE FROM empleados WHERE nif = '{0}'", nif);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.ExecuteNonQuery();
            ConBD.CerrarConexion();
        }

        // Sirve para comprobar si el empleado existe en la empresa
        // Le pasamos un nif como parametro
        // Devuelve true si el empleado existe y false si no hay ningun empleado con dicho nif
        public static bool BuscarEmpleado(string nif)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT nif FROM empleados WHERE nif = '{0}'", nif);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                ConBD.CerrarConexion();
                return true;
            }
            else
            {
                reader.Close();
                ConBD.CerrarConexion();
                return false;
            }
        }


        // Comprueba si el nif y la clave del usuario administrador coinciden
        // Le pasamos nif y clave como parametros
        // Devuelve true si el nif y la clave coinciden y false en caso de que no coincidan
        public static bool Login(string nif, string clave)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT * FROM empleados WHERE nif = '{0}' AND clave = '{1}'", nif, clave);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                ConBD.CerrarConexion();
                return true;
            }
            else
            {
                reader.Close();
                ConBD.CerrarConexion();
                return false;
            }
        }

        // Comprueba si el usuario es administrador o no.
        // Le pasamos el nif como parametro
        // Devuelve true si el usuario es administrador y false si no lo es
        public static bool EsAdmin(string dni)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT * FROM empleados WHERE nif = '{0}' AND administrador = true", dni);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                ConBD.CerrarConexion();
                return true;
            }
            else
            {
                reader.Close();
                ConBD.CerrarConexion();
                return false;
            }
        }
    }
}
