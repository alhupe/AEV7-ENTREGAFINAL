using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EjemploFechasHoras
{
    class Fichaje
    {
        private String nif;
        private DateTime dia;
        private DateTime horaEntrada;
        private DateTime horaSalida;
        private bool finalizado;  // False (no finalizado) - True (finalizado)
        private float tiempoTotal;

        public String Nif { get { return nif; } set { nif = value; } }
        public DateTime Dia { get { return dia; } set { dia = value; } }
        public DateTime HEntrada { get { return horaEntrada; } set { horaEntrada = value; } }
        public DateTime HSalida { get { return horaSalida; } set { horaSalida = value; } }
        public bool Finalizado { get { return finalizado; } set { finalizado = value; } }
        public float TiempoTotal { get { return tiempoTotal; } set { tiempoTotal = value; } }

        public Fichaje(String dni)
        {
            nif = dni;
            finalizado = false;  // Cuando se crea el fichaje está abierto
            tiempoTotal = 0;
        }
        

        // Metodo para buscar los empleados que estan actualmente activos, es decir, que han fichado entrada pero no salida
        // Pasamos la fecha actual como parametro
        // Devuelve un string con el nombre, apellido y hora de entrada de los empleados actualmente activos, o un mensaje avisando de que no hay empleados activos
        public static string ListarEmpleados(DateTime dia)
        {
            ConBD.AbrirConexion();
            
            string consulta = String.Format("SELECT nombre, apellido, horaEntrada FROM empleados e INNER JOIN fichajes f ON f.Empleado_nif = e.nif WHERE f.finalizado = false AND f.dia = '{0}'", dia.ToString("yyyy-MM-dd"));
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            string mensaje = "";
            if (reader.Read())
            {
                mensaje += "Empleados actualmente activos y hora de entrada:" + "\r\n" + reader.GetString("nombre") + " " + reader.GetString("apellido") + " - " + reader.GetString("horaEntrada") + "\r\n";
            }
            else
            {
                mensaje += "No hay empleados activos actualmente";
            }
            reader.Close();
            ConBD.CerrarConexion();
            return mensaje;
        }


        // Metodo para listar todos los fichajes de la empresa
        // Devuelve una tabla con toda la informacion de los fichajes de la empresa
        public static DataTable ListarFichajes()
        {
            ConBD.AbrirConexion();
            string consulta = "SELECT * FROM fichajes";
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataTable tablaFichajes = new DataTable();
            datos.Fill(tablaFichajes);
            ConBD.CerrarConexion();
            return tablaFichajes;
        }


        // Método para ver la permanencia de un empleado entre 2 fechas proporcionadas por el usuario
        // Le pasamos como parametros el nif y ambas fechas previamente pedidas mediante un DataPicker
        // Devuelve una tabla con todos los fichajes de dicho empleado entre las 2 fechas seleccionadas
        public static DataTable VerPermanencias(string dni, DateTime d1, DateTime d2)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT * FROM fichajes WHERE Empleado_nif = '{0}' AND dia BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}'", dni, d1, d2);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataTable tablaPermanencias = new DataTable();
            datos.Fill(tablaPermanencias);
            ConBD.CerrarConexion();
            return tablaPermanencias;
        }


        // Metodo para fichar la entrada de un empleado
        // Le pasamos el nif, la hora de entrada y el dia como parametros, no devuelve nada
        // Podria modificarse para que comprobase el numero de filas afectadas y asi verificar que la consulta se ha realizado correctamente
        public static void FicharEntrada(string nif, TimeSpan horaEntrada, DateTime dia)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("INSERT INTO fichajes (Empleado_nif, dia, HoraEntrada, tiempoTotal) VALUES ('{0}', '{1}', '{2}', 0)", nif, dia.ToString("yyyy-MM-dd"), horaEntrada);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.ExecuteNonQuery();
            ConBD.CerrarConexion();
        }

        // Metodo que permite fichar la salida del empleado
        // Le pasamos el nif, la hora de salida y el dia como parametros
        // Devuelve el tiempo transcurrido entre la hora de entrada y la hora de salida del fichaje
        public static TimeSpan FicharSalida(string nif, TimeSpan horaSalida, DateTime dia)
        {
            ConBD.AbrirConexion();
            TimeSpan tiempoFichaje = TimeSpan.Zero;

            string horaEntradaStr = String.Format("SELECT horaEntrada FROM fichajes WHERE Empleado_nif = '{0}' and dia = '{1}'", nif, dia.ToString("yyyy-MM-dd"));
            MySqlCommand comandoHoraEntrada = new MySqlCommand(horaEntradaStr, ConBD.Conexion);
            TimeSpan horaEntrada = (TimeSpan)comandoHoraEntrada.ExecuteScalar();
            tiempoFichaje = horaSalida - horaEntrada;
           
            string consulta = String.Format("UPDATE fichajes SET horaSalida = '{0}', finalizado = true, tiempoTotal = '{3}' WHERE Empleado_nif = '{1}' AND dia = '{2}'", horaSalida, nif, dia.ToString("yyyy-MM-dd"), tiempoFichaje);
            MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
            comando.ExecuteNonQuery();

            ConBD.CerrarConexion();
            return tiempoFichaje;
        }
        

        // Metodo para comprobar si un empleado ya ha fichado entrada
        // Le pasamos al nif como parametro
        // Devuelve true si el empleado ha fichado entrada y false si no lo ha hecho
        // Se da por entendido que si hay un registro de dicho empleado en la fecha actual es porque ha fichado entrada
        public static bool ComprobarEntrada(string nif)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT Empleado_nif FROM fichajes WHERE Empleado_nif = '{0}' AND dia = '{1}'", nif, DateTime.Now.ToString("yyyy-MM-dd"));
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


        // Permite comprobar si un empleado ha fichado salida
        // Le pasamos el nif como parametro
        // Devuelve true si el empleado ha fichado salida y false si no lo ha hecho
        public static bool ComprobarSalida(string nif)
        {
            ConBD.AbrirConexion();
            string consulta = String.Format("SELECT Empleado_nif FROM fichajes WHERE Empleado_nif = '{0}' AND dia = '{1}' AND HoraSalida IS NOT NULL", nif, DateTime.Now.ToString("yyyy-MM-dd"));
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

        // Calcula el tiempo total fichado de un empleado entre 2 fechas dadas
        // Le pasamos como parametro la tabla de permanencias que ya contiene la informacion de las 2 fechas proporcionadas por el usuario
        // Devuelve la suma del tiempo total de todos los fichajes de dicho empleado entre ambas fechas
        public static TimeSpan CalcularTiempoTotal(DataTable tablaPermanencias)
        {
            TimeSpan tiempoTotal = TimeSpan.Zero;
            foreach (DataRow row in tablaPermanencias.Rows)
            {
                tiempoTotal += TimeSpan.Parse(row["tiempoTotal"].ToString());
            }
            return tiempoTotal;
        }

        //Metodo que realiza un fichaje de salida automaticamente a los empleados que no hayan fichado salida un dia anterior a la fecha actual

        //public static void SalidaAutomatica(DateTime dia)
        //{
        //    ConBD.AbrirConexion(); 
        //    string consulta = String.Format("SELECT Empleado_nif FROM fichajes WHERE dia < '{0}' AND HoraSalida IS NULL", dia.ToString("yyyy-MM-dd"));
        //    MySqlCommand comando = new MySqlCommand(consulta, ConBD.Conexion);
        //    MySqlDataReader reader = comando.ExecuteReader();
        //    if (!reader.HasRows)
        //    {
        //        reader.Close();
        //        ConBD.CerrarConexion();
        //    }
        //    else
        //    {
        //        reader.Close();
        //        string consulta2 = String.Format("UPDATE fichajes SET horaSalida = '23:59:59', finalizado = true, tiempoTotal = TIMEDIFF('23:59:59', horaEntrada) WHERE dia < '{0}' AND horaSalida IS NULL", dia.ToString("yyyy-MM-dd"));
        //        comando = new MySqlCommand(consulta2, ConBD.Conexion);
        //        comando.ExecuteNonQuery();
        //        ConBD.CerrarConexion();
        //    }
        //}
    }
}
