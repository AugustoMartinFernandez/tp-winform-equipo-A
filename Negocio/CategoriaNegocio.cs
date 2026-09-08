using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio {
    public class CategoriaNegocio {
        public List<Categoria> listar() {

            List<Categoria> lista = new List<Categoria>() ;

            AccesoDatos datos = new AccesoDatos() ;

            try {

                datos.setearConsultas("SELECT Id, Descripcion FROM CATEGORIAS") ;
                
                datos.ejecutarLectura()  ;

                while (datos.Lector.Read()) {

                    Categoria aux = new Categoria() ;

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
    
        public void agregar(Categoria nueva) 
        {
            AccesoDatos datos = new AccesoDatos();
            try 
            {
                datos.setearConsultas("INSERT INTO CATEGORIAS (Descripcion) VALUES ('" + nueva.Descripcion + "')");
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

        public void modificar(Categoria categoria) 
        {
            AccesoDatos datos = new AccesoDatos();
            try 
            {
                datos.setearConsultas("UPDATE CATEGORIAS SET Descripcion = '" + categoria.Descripcion + "' WHERE Id = " + categoria.Id);
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
                datos.setearConsultas("DELETE FROM CATEGORIAS WHERE Id = " + id);
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
        
