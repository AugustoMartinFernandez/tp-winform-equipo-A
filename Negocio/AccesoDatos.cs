using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

// Para poder usar el servicio a bd

using System.Data.SqlClient ;

namespace Negocio {
    public class AccesoDatos {

        // Encapsulamos para que nadie desde fuera toque la conexion directamente
        private SqlConnection conexion ;
        private SqlCommand comando ;
        private SqlDataReader lector ;

        // Necesitamos leer el lector desde fuera
        // No que se pueda escribir desde afuera
        public SqlDataReader Lector {
            
        get { return lector ; }
       
        }
        // Constructor 
        public AccesoDatos() {

            // Dentro de la clase AccesoDatos.cs
            conexion = new SqlConnection("server=localhost; database=CATALOGO_P3_DB; user=sa; password=@Willystu10;");

            comando = new SqlCommand() ;
        }

        // Seteamos las consultas
        public void setearConsultas(string consulta) {
            // Le paso una sentencia SQL escrita
            comando.CommandType = System.Data.CommandType.Text ;

            comando.CommandText = consulta ;
        }
        // Ejecutaremos lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // Ejecutaremos acciones para NSERT/UPDATE/DELETE
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                // En la conexion ejecuta una instruccion SQL y devuelve el numero de filas afectadas
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // Agrego un parametro con su nombre y valor, para no concatenar el string directo
        public void setearParametro(string nombre, object valor) {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        // Cerramos la conexion
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

    }
}
