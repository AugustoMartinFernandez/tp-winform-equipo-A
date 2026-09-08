using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio {
    public class MarcaNegocio {
        public List<Marca> listar() {

            List<Marca> lista = new List<Marca>() ;

            AccesoDatos datos = new AccesoDatos() ;

            try {

                datos.setearConsultas("SELECT Id, Descripcion FROM MARCAS") ;

                datos.ejecutarLectura() ;

                while (datos.Lector.Read()) {

                    Marca aux = new Marca() ;

                    aux.Id = (int)datos.Lector["Id"] ;

                    aux.Descripcion = (string)datos.Lector["Descripcion"] ;

                    lista.Add(aux) ;
                }

                return lista ;
            }

            catch (Exception ex) {

                throw ex ; }
           
            finally {

                datos.cerrarConexion() ;
            }
        }

        public void agregar(Marca nueva) {

            AccesoDatos datos = new AccesoDatos() ;
         
            try {

                datos.setearConsultas("INSERT INTO MARCAS (Descripcion) VALUES ('" + nueva.Descripcion + "')") ;

                datos.ejecutarAccion() ;
            }
            
            catch (Exception ex){
                
            throw ex ; }

            finally{ 

                datos.cerrarConexion() ;
            }
        }

        public void modificar(Marca marca) {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultas("UPDATE MARCAS SET Descripcion = '" + marca.Descripcion + "' WHERE Id = " + marca.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultas("DELETE FROM MARCAS WHERE Id = " + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}