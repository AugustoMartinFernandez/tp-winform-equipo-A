using System;
using System.Collections.Generic;
using System.Linq;
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
                throw ex ; 
            }
            finally {
                datos.cerrarConexion() ;
            }
        }
    
        public void agregar(Categoria nueva) 
        {
           
            if (string.IsNullOrWhiteSpace(nueva.Descripcion))
                throw new Exception("La descripción de la categoría no puede estar vacía.");
            
            if (nueva.Descripcion.Length > 50)
                throw new Exception("La descripción de la categoría no puede superar los 50 caracteres.");

            AccesoDatos datos = new AccesoDatos();
            try 
            {
                
                datos.setearConsultas("INSERT INTO CATEGORIAS (Descripcion) VALUES (@Descripcion)");
                datos.setearParametro("@Descripcion", nueva.Descripcion);
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
            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                throw new Exception("La descripción de la categoría no puede estar vacía.");
            
            if (categoria.Descripcion.Length > 50)
                throw new Exception("La descripción de la categoría no puede superar los 50 caracteres.");

            AccesoDatos datos = new AccesoDatos();
            try 
            {
               
                datos.setearConsultas("UPDATE CATEGORIAS SET Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Descripcion", categoria.Descripcion);
                datos.setearParametro("@Id", categoria.Id);
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
        
            AccesoDatos datosVerificacion = new AccesoDatos();
            try
            {
                datosVerificacion.setearConsultas("SELECT COUNT(*) FROM ARTICULOS WHERE IdCategoria = @IdCategoria");
                datosVerificacion.setearParametro("@IdCategoria", id);
                datosVerificacion.ejecutarLectura();
                
                if (datosVerificacion.Lector.Read())
                {
                    int cantidad = (int)datosVerificacion.Lector[0];
                    if (cantidad > 0)
                    {
                        throw new Exception("No se puede eliminar esta categoría porque está asociada a uno o más artículos.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosVerificacion.cerrarConexion();
            }

        
            AccesoDatos datos = new AccesoDatos();
            try 
            {
                datos.setearConsultas("DELETE FROM CATEGORIAS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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